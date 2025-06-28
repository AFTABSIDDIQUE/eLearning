using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.Master_Course
{
    public partial class AddSubcourse : System.Web.UI.Page
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
            string SubCourseName, SubCoursePic, SubStatus;
            decimal SubCoursePrice;
            int CourseID = int.Parse(Course.SelectedValue);
            FileUpload1.SaveAs(Server.MapPath("/Images") + Path.GetFileName(FileUpload1.FileName));
            SubCoursePic = "/Images" + Path.GetFileName(FileUpload1.FileName);
            SubCourseName = TextBox1.Text;
            SubCoursePrice = int.Parse(TextBox2.Text);
            SubStatus = DropDownList1.SelectedValue;
            string q = $"exec AddSubCourse '{SubCourseName}','{SubCoursePic}','{SubCoursePrice}','{SubStatus}','{CourseID}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Sub Course Added Successfully');</script>");

            ResetTemp();



        }
        private void CourseNameDD()
        {
            string q = "exec GetCoursename";
            SqlCommand cmd = new SqlCommand(q, conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            Course.DataSource = rdr;
            Course.DataTextField = "CourseName";
            Course.DataValueField = "CourseID";
            Course.DataBind();



        }




        private void ResetTemp()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";



        }


    }
}