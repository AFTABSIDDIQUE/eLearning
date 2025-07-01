using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.User.VideoPanel
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            if (!IsPostBack)
            {


            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {


            string query = "SELECT * FROM MCQ WHERE TopicID = '2'";
            SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@topicId", topicId);

            DataSet ds = new DataSet();
            SqlDataAdapter data = new SqlDataAdapter(cmd);  // pass the *command*, not just the query
            data.Fill(ds);

            //int topicId = int.Parse(hdnSelectedTopicID.Value.ToString());
            //string query = "SELECT * FROM MCQ WHERE TopicID = @topicId";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@topicId", topicId);

            ////SqlDataAdapter da = new SqlDataAdapter(cmd);
            ////DataTable dt = new DataTable();

            //DataSet ds = new DataSet();
            //SqlDataAdapter data = new SqlDataAdapter(query, conn);
            //data.Fill(ds);

            rptMCQ.DataSource = ds;

            rptMCQ.DataBind();
        }
    }
}