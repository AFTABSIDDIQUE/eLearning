using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.MasterSubscription
{
    public partial class SubscriptionType : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string SubscriptionType, SubscriptionStatus;
            SubscriptionType = txtsubtype.Text;
            SubscriptionStatus = substat.SelectedValue;

            string q = $"exec InsertSubscriptionType '{SubscriptionType}','{SubscriptionStatus}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Subscription Added Successfully')</script>");


        }


    }
}