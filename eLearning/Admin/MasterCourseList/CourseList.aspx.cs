using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.Master_Course_List
{
    public partial class CourseList : System.Web.UI.Page
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
        public void BindGrid()
        {
            string q = "exec FetchCourseData";
            SqlDataAdapter da = new SqlDataAdapter(q, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int courseId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string courseName = ((TextBox)row.FindControl("txtCourseName")).Text;
            string coursePic = ((TextBox)row.FindControl("txtCoursePic")).Text;
            string courseStatus = ((TextBox)row.FindControl("txtCourseStatus")).Text;
            string q = $"exec UpdateCourseData '{courseId}','{courseName}','{coursePic}','{courseStatus}'";
            SqlCommand cmd = new SqlCommand(q, conn);

            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;


            BindGrid();
        }


    }
}