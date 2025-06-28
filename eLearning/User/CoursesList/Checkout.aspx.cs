using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;

namespace eLearning.User.CoursesList
{
    public partial class Checkout : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                LoadCart();
            }
        }
        private void LoadCart()
        {
            int userId = int.Parse(Session["Usersid"].ToString());

            string q = $"exec DisplayCartData '{userId}'";
            SqlDataAdapter da = new SqlDataAdapter(q, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewCart.DataSource = dt;
            GridViewCart.DataBind();


            double total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += double.Parse(row["SubCoursePrice"].ToString());
            }

            if (GridViewCart.FooterRow != null)
            {
                Label lbl = (Label)GridViewCart.FooterRow.FindControl("lblTotal");
                if (lbl != null)
                    lbl.Text = "Total: ₹ " + total.ToString();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            double totalAmount = 0;

            Label lbl = (Label)GridViewCart.FooterRow.FindControl("lblTotal");
            if (lbl != null)
            {
                string amt = lbl.Text.Replace("Total: ₹ ", "").Trim();
                totalAmount = double.Parse(amt);
            }



            string keyId = "rzp_test_Kl7588Yie2yJTV";
            string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";

            RazorpayClient client = new RazorpayClient(keyId, keySecret);

            Dictionary<string, object> options = new Dictionary<string, object>
                {
                    { "amount", (int)(totalAmount * 100) },  // Amount in paisa
                    { "currency", "INR" },
                    { "receipt", "order_rcptid_11" },
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
                    window.location.href='Invoice.aspx';
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

    }
}