using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.User.CoursesList
{
    public partial class Invoice1 : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {

                SaveTransaction();
            }
        }


        private void SaveTransaction()
        {


            int userId = (int)Session["UserID"];
            string subscriptionName = Session["SubscriptionType"].ToString();
            decimal amount = (decimal)Session["Price"];
            string TransactionStatus = "Success";




            string query = $"exec InsertSubscriptionTransactionDetails '{userId}','{subscriptionName}','{amount}','{TransactionStatus}'";

            SqlCommand cmd = new SqlCommand(query, conn);


            cmd.ExecuteNonQuery();

        }
    }
}