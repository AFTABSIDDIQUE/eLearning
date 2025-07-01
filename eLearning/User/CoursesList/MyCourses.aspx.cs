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
    public partial class MyCourses : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Learning"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                FetchMyCourse();
            }
        }
        public void FetchMyCourse()
        {
            int userId = 0;


            string q = $"exec FetchMySubCourse '{userId}'";
            SqlCommand subCourseCmd = new SqlCommand(q, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(subCourseCmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {

                gvTransactions.DataSource = dt1;
                gvTransactions.DataBind();
            }
            else
            {
                string q1 = $"exec FetchMySubscription '{userId}'";
                SqlCommand subscriptionCmd = new SqlCommand(q1, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(subscriptionCmd);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                if (dt2.Rows.Count > 0)
                {

                    gvTransactions.DataSource = dt2;
                    gvTransactions.DataBind();
                }
                else
                {

                    gvTransactions.DataSource = null;
                    gvTransactions.DataBind();
                }
            }
        }
        protected void gvTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PlayCourse")
            {

            }
        }
    }
}
