using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.Master_Course
{
    public partial class AddTopic : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {

                CourseNameDD();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string createdBy = Session["name"].ToString();
            string TopicName, TopicUrl, TopicStatus;

            TopicName = TextBox1.Text;
            TopicUrl = TextBox2.Text;
            TopicStatus = DropDownList3.SelectedValue;
            int CourseID = int.Parse(Course.SelectedValue);
            int SubCourseID = int.Parse(SubCourse.SelectedValue);

            string q = $"exec AddTopicName '{TopicName}', '{TopicUrl}', '{TopicStatus}','{CourseID}','{SubCourseID}','{createdBy}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Topic Added Successfully');</script>");
            ResetTemp();
        }
        private void ResetTemp()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";

        }
        public void CourseNameDD()
        {
            string q = "exec GetCoursename";
            SqlCommand cmd = new SqlCommand(q, conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            Course.DataSource = rdr;
            Course.DataTextField = "CourseName";
            Course.DataValueField = "CourseID";
            Course.DataBind();
            rdr.Close();



        }

        public void SubCourseDD(int CourseID)
        {
            //int CourseID = int.Parse(Course.SelectedValue);
            //int CourseID = int.Parse(Course.SelectedValue.ToString());
            string q = $"exec GetSubCourseName '{CourseID}'";
            SqlCommand cmd = new SqlCommand(q, conn);

            SqlDataReader rdr = cmd.ExecuteReader();
            SubCourse.DataSource = rdr;
            SubCourse.DataTextField = "SubCourseName";
            SubCourse.DataValueField = "SubCourseID";
            SubCourse.DataBind();

        }

        protected void Course_SelectedIndexChanged(object sender, EventArgs e)
        {

            int CourseID = int.Parse(Course.SelectedValue);
            SubCourseDD(CourseID);


            //SqlDataReader rdr = cmd.ExecuteReader();
            //SubCourse.DataSource = rdr;
            //SubCourse.DataTextField = "SubCourseName";
            //SubCourse.DataValueField = "SubCourseID";
            //SubCourse.DataBind();
        }

        protected void SubCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SubCourseDD();
        }
    }
}