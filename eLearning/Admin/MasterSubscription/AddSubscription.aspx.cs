using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.MasterSubscription
{
    public partial class AddSubscription : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                SubscriptionType();
                CourseNameDD();
            }

        }
        protected void course_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseId = int.Parse(course.SelectedValue);
            LoadSubCourses(courseId);
        }

        private void LoadSubCourses(int courseId)
        {

            string q = "exec GetSubCourseName @CourseID";
            SqlCommand cmd = new SqlCommand(q, conn);

            cmd.Parameters.AddWithValue("@CourseID", courseId);
            SqlDataReader rdr = cmd.ExecuteReader();

            chkSubCourses.DataSource = rdr;
            chkSubCourses.DataTextField = "SubCourseName";
            chkSubCourses.DataValueField = "SubCourseID";
            chkSubCourses.DataBind();


        }



        public void SubscriptionType()
        {
            string q = "exec GetSubscriptionType";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            subtype.DataSource = rdr;
            subtype.DataTextField = "SubscriptionTypeName";
            subtype.DataValueField = "SubscriptionTypeID";
            subtype.DataBind();


        }
        public void CourseNameDD()
        {
            string q = "exec GetCoursename";
            SqlCommand cmd = new SqlCommand(q, conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            course.DataSource = rdr;
            course.DataTextField = "CourseName";
            course.DataValueField = "CourseID";
            course.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            string subscriptionTypeName = subtype.SelectedItem.Text;
            double price = double.Parse(TextBox1.Text.Trim());
            string picFileName = "";
            string status = Substat.SelectedItem.Text;
            int courseId = int.Parse(course.SelectedValue);

            if (FileUpload1.HasFile)
            {
                picFileName = Path.GetFileName(FileUpload1.FileName);
                string savePath = Server.MapPath("~/Images/") + picFileName;
                FileUpload1.SaveAs(savePath);
            }

            foreach (ListItem item in chkSubCourses.Items)
            {
                if (item.Selected)
                {
                    int subCourseId = int.Parse(item.Value);
                    string q = $"exec InsertSubscription '{subscriptionTypeName}','{price}','{picFileName}','{status}','{courseId}','{subCourseId}'";
                    SqlCommand cmd = new SqlCommand(q, conn);



                    cmd.ExecuteNonQuery();

                }
            }

       
            Response.Write("<script>alert('Subscription(s) added successfully.');</script>");
        }



    }
}