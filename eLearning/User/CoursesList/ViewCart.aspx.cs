using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.User.CoursesList
{
    public partial class ViewCart : System.Web.UI.Page
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


        protected void GridViewCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int userId = 1;
                int subCourseId = Convert.ToInt32(e.CommandArgument);

                string q = $"exec RemoveCartData '{userId}','{subCourseId}'";
                SqlCommand cmd = new SqlCommand(q, conn);

                cmd.ExecuteNonQuery();


                LoadCart();
            }
        }
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

    }
}