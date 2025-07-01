using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Learning"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindSubscriptionGrid();
                BindSubCourseGrid();
            }
        }
        private void BindSubscriptionGrid()
        {

            string query = "exec FetchSubscriptionTransactionDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewSubscription.DataSource = dt;
            GridViewSubscription.DataBind();

        }

        private void BindSubCourseGrid()
        {

            string query = "exec FetchSubCourseTransactionDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewSubCourse.DataSource = dt;
            GridViewSubCourse.DataBind();

        }
    }
}