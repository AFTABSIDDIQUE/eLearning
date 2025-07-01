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
    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                int userId = Convert.ToInt32(Session["Usersid"]);


                string q1 = $"exec DisplayCartData1 '{@userId}'";
                SqlCommand cmd = new SqlCommand(q1, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    string subCourseName = row["SubCourseName"].ToString();
                    decimal price = Convert.ToDecimal(row["SubCoursePrice"]);
                    String TransactionStatus = "Success";
                    string q = $"exec InsertSubCourseTransactionDetails '{userId}','{subCourseName}','{price}','{TransactionStatus}'";
                    SqlCommand cmd1 = new SqlCommand(q, conn);
                    cmd1.ExecuteNonQuery();
                }

            }


        }
    }

}
