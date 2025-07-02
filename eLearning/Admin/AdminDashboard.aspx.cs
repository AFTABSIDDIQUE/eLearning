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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["Learning"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                CountOfCourses();
                CountOfSubCourses();
                //CountOfSubscription();
                CountOfActiveUser();
                CountOfInactiveUser();
                BindCourseDropdown();
            }
        }
        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedCourseId = int.Parse(ddlCourse.SelectedValue);
            LoadSubCourseGrid(selectedCourseId);

        }

        private void LoadSubCourseGrid(int courseId)
        {

            string query = $"exec FetchDataBasedOnCourse '{courseId}'";


            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridViewSubCourseData.DataSource = dt;
            GridViewSubCourseData.DataBind();
        }

        private void BindCourseDropdown()
        {
            string query = "exec LoadCourse";

            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataReader reader = cmd.ExecuteReader();
            ddlCourse.DataSource = reader;
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();

            ddlCourse.Items.Insert(0, new ListItem("-- Select Course --", "0"));

        }

        public void CountOfCourses()
        {
            string q = "exec CountOfCourses";
            SqlCommand cmd = new SqlCommand(q, conn);
            lblCourses.Text = cmd.ExecuteScalar().ToString();

        }
        public void CountOfSubCourses()
        {
            string q = "exec CountOfSubCourses";
            SqlCommand cmd = new SqlCommand(q, conn);
            lblSubCourses.Text = cmd.ExecuteScalar().ToString();

        }
        public void CountOfSubscription()
        {
            string q = "exec CountOfSubscription";
            SqlCommand cmd = new SqlCommand(q, conn);
            lblSubscriptions.Text = cmd.ExecuteScalar().ToString();
        }
        public void CountOfActiveUser()
        {
            string q = "exec CountOfActiveUser";
            SqlCommand cmd = new SqlCommand(q, conn);
            lblActiveUsers.Text = cmd.ExecuteScalar().ToString();
        }
        public void CountOfInactiveUser()
        {
            string q = "exec CountOfInactiveUser";
            SqlCommand cmd = new SqlCommand(q, conn);
            lblInactiveUsers.Text = cmd.ExecuteScalar().ToString();
        }


    }
}