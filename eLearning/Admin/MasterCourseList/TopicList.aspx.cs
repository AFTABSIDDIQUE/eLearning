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
    public partial class TopicList : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindTopicGrid();
            }

        }
        private void BindTopicGrid()
        {

            string q = "exec FetchTopicList";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindTopicGrid();
        }

       
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindTopicGrid();
        }

        
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int topicId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            GridViewRow row = GridView1.Rows[e.RowIndex];
            string topicName = ((TextBox)row.FindControl("txtTopicName")).Text;
            string topicUrl = ((TextBox)row.FindControl("txtTopicURL")).Text;


            string q = $"exec UpdateTopicData '{topicId}','{topicName}','{topicUrl}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;  


            BindTopicGrid();
        }

        

    }
}