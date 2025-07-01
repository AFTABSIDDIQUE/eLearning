using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.Review
{
    public partial class UserReview : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            string q = "exec fetchReview";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected string GetStars(object ratingObj)                 // display through stars
        {
            int rating = int.Parse(ratingObj.ToString());
            string stars = "";

            for (int i = 1; i <= 5; i++)
            {
                stars += (i <= rating) ? "<i class=\"fa-solid fa-star\"></i>" : "<i class=\"fa-regular fa-star\"></i>";
            }

            return stars;
        }

        protected void Button1_Click(object sender, EventArgs e)        // Approve all
        {
            string q = "UpdateStatus";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            BindGrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)      // Approve single row
        {
            int Rid = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "EditRow")
            {

                string q = $"UpdateStatusforSelRow {Rid}";
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            BindGrid();

        }
    }
}