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
    public partial class AddNewCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

           

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string createdBy = Session["name"].ToString();
            string CourseName, CoursePic, CourseStatus;


            CourseName = TextBox1.Text;
            CourseStatus = DropDownList1.SelectedValue;
            FileUpload1.SaveAs(Server.MapPath("/Images") + Path.GetFileName(FileUpload1.FileName));
            CoursePic = "/Images" + Path.GetFileName(FileUpload1.FileName);

            string q = $"exec AddCourse '{CourseName}', '{CoursePic}','{CourseStatus}','{createdBy}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Course Added Successfully');</script>");





        }




    }
}