using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.AddMaterial
{
    public partial class AddAssignment : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(strcon);
            conn.Open();
            if (!IsPostBack)
            {
                fetchCouses();
                DropDownList2.Items.Clear();
                DropDownList2.Items.Insert(0, new ListItem("Select SubCourse", ""));

                DropDownList3.Items.Clear();
                DropDownList3.Items.Insert(0, new ListItem("Select Topic", ""));

            }
        }
        public void fetchCouses()
        {

            SqlCommand cmd = new SqlCommand($"exec fetchCourse", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList1.DataSource = rdr;
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataValueField = "CourseID";
            DropDownList1.DataBind();
            rdr.Close();
            DropDownList1.Items.Insert(0, new ListItem("Select Course", ""));

        }
        public void fetSubCourse(int CourseId)
        {
            SqlCommand cmd = new SqlCommand($"exec fetchSubCourse '{CourseId}' ", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList2.DataSource = rdr;
            DropDownList2.DataTextField = "SubCourseName";
            DropDownList2.DataValueField = "SubCourseID";
            DropDownList2.DataBind();
            rdr.Close();

        }
        public void fetTopic(int SubCourseId)
        {
            SqlCommand cmd = new SqlCommand($"exec fetchTopic '{SubCourseId}'", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList3.DataSource = rdr;
            DropDownList3.DataTextField = "TopicName";
            DropDownList3.DataValueField = "TopicID";
            DropDownList3.DataBind();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            int courseId = int.Parse(DropDownList1.SelectedValue);
            int subCourseId = int.Parse(DropDownList2.SelectedValue);
            int topicId = int.Parse(DropDownList3.SelectedValue);
            string CreatedBy = "null";  //Default

            string AssignmentPath = "";


            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                string filepath = "~/Upload/" + filename;
                FileUpload1.SaveAs(Server.MapPath(filepath));
                AssignmentPath = filepath;
            }

            string q = $"exec InsertAssignment '{AssignmentPath}',{courseId} ,{subCourseId},{topicId},'{CreatedBy}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Assingment Uploaded Successfully');</script>");

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "")
            {
                int CourseId = int.Parse(DropDownList1.SelectedValue);
                fetSubCourse(CourseId);
            }
            else
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Insert(0, new ListItem("Select SubCourse", ""));
            }


            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select Topic", ""));
        }


        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue != "")
            {
                int SubCourseId = int.Parse(DropDownList2.SelectedValue);
                fetTopic(SubCourseId);
            }
            else
            {
                DropDownList3.Items.Clear();
                DropDownList3.Items.Insert(0, new ListItem("Select Topic", ""));
            }
        }


    }
}