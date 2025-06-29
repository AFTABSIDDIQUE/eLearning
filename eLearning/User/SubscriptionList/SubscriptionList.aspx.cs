using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.User.SubscriptionList
{
    public partial class SubscriptionList : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                LoadSubscriptions();
            }
        }

        public void LoadSubscriptions()
        {

            string q = "exec FetchSubscriptionList";


            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "BuyNow")
            {
                string[] values = e.CommandArgument.ToString().Split('|');
                if (values.Length == 3)
                {
                    string subscriptionTypeName = values[0];
                    decimal subscriptionPrice = decimal.Parse(values[1].ToString());
                    string subCourses = values[2];

                    int userId = 1;
                    InsertIntoSubscriptionCart(userId, subscriptionTypeName, subscriptionPrice, subCourses);
                    StartPayment(subscriptionPrice);
                }
            }
        }
        public void StartPayment(decimal totalAmount)
        {
            string keyId = "rzp_test_Kl7588Yie2yJTV";
            string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(keyId, keySecret);

            Dictionary<string, object> options = new Dictionary<string, object>
    {
        { "amount", (int)(totalAmount * 100) },  // amount in paisa
        { "currency", "INR" },
        { "receipt", "order_rcptid_" + Guid.NewGuid().ToString("N").Substring(0, 8) }, // unique receipt
        { "payment_capture", 1 }
    };

            Razorpay.Api.Order order = client.Order.Create(options);
            string orderId = order["id"].ToString();

            string razorpayScript = $@"
    var options = {{
        'key': '{keyId}',
        'amount': {(int)(totalAmount * 100)},
        'currency': 'INR',
        'name': 'Masstech Business Solutions Pvt.Ltd',
        'description': 'Course Checkout Payment',
        'order_id': '{orderId}',
        'handler': function (response) {{
            alert('Payment successful. Payment ID: ' + response.razorpay_payment_id);
            window.location.href='Invoice.aspx';  // Redirect on success
        }},
        'prefill': {{
            'name': 'Krish Kheloji',
            'email': 'khelojikrish@gmail.com',
            'contact': '7208921898'
        }},
        'theme': {{
            'color': '#F37254'
        }}
    }};
    var rzp = new Razorpay(options);
    rzp.open();";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "razorpay", razorpayScript, true);
        }


        public void InsertIntoSubscriptionCart(int userId, string subscriptionTypeName, decimal price, string subCourses)
        {
            string q = $"exec InsertSubscriptionCart '{userId}','{subscriptionTypeName}','{price}','{subCourses}'";
            SqlCommand cmd = new SqlCommand(q, conn);


            cmd.ExecuteNonQuery();

        }


    }
}