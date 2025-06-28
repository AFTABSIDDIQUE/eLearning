using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace eLearning.User
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(strcon);
            conn.Open();
            if (!IsPostBack)
            {
             LoadMyCourses();
            }
        }
         public void LoadMyCourses()
        {
            int userId = int.Parse(Session["Usersid"].ToString());
            SqlCommand cmd = new SqlCommand($"GetTotalCoursesByUser {userId}", conn);
            int totalCourses = int.Parse(cmd.ExecuteScalar().ToString());

            lblMyCourses.Text = totalCourses.ToString();

        }
    }
}