using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        void BindGrid()
        {
            string q = "exec FetchUserData";
            SqlDataAdapter da = new SqlDataAdapter(q, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindGrid();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUsers.Rows[e.RowIndex];
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            string userName = ((TextBox)row.FindControl("txtUserName")).Text;
            string userEmail = ((TextBox)row.FindControl("txtUserEmail")).Text;
            string userContact = ((TextBox)row.FindControl("txtUserContact")).Text;
            string role = ((TextBox)row.FindControl("txtRole")).Text;
            string stat = ((TextBox)row.FindControl("txtstat")).Text;

            string q = $"exec UpdateUserData '{userId}','{userName}','{userEmail}','{userContact}','{stat}'";
            SqlCommand cmd = new SqlCommand(q, conn);

            cmd.ExecuteNonQuery();

            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            string q = $"exec DeleteUserData '{userId}'";
            SqlCommand cmd = new SqlCommand(q, conn);

            cmd.ExecuteNonQuery();

            BindGrid();
        }
    }
}