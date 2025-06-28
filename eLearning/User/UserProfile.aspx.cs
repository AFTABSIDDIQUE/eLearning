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
    public partial class UserProfile : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                ProfileDetails();
            }
            

        }
        public void ProfileDetails()
        {
            int userId = int.Parse(Session["Usersid"].ToString());
            string q = $"exec UserProfileDetails '{userId}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtUserName.Text = reader["UserName"].ToString();
                txtEmail.Text = reader["UserEmail"].ToString();
                txtContact.Text = reader["UserContact"].ToString();
            }
            else
            {
                txtUserName.Text = "No user data found.";
                txtEmail.Text = "";
                txtContact.Text = "";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Session["Usersid"].ToString());
            string userName = txtUserName.Text.Trim();
            string userEmail = txtEmail.Text.Trim();
            string userContact = txtContact.Text.Trim();
            string q = $"exec UpdateUserData '{userId}','{userName}','{userEmail}','{userContact}'";
            SqlCommand cmd = new SqlCommand(q, conn);

            cmd.ExecuteNonQuery();

        }
    }
}