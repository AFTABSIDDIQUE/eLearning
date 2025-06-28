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
    public partial class ViewCoursesList : System.Web.UI.Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            if (!IsPostBack)
            {
                LoadCourses();
            }


        }
        protected void dlSubCourses_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                string[] args = e.CommandArgument.ToString().Split('|');

                int subCourseID = int.Parse(args[0]);
                string subCourseName = args[1];
                string subCoursePic = args[2];
                double subCoursePrice = double.Parse(args[3]);

                int userID = int.Parse(Session["Usersid"].ToString());


                string query = $"exec AddCart '{userID}','{subCourseID}','{subCourseName}','{subCoursePic}','{subCoursePrice}'";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();



            }
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseId = int.Parse(ddlCourses.SelectedValue);
            if (courseId > 0)
            {
                LoadSubCourses(courseId);
            }
            else
            {
                dlSubCourses.DataSource = null;
                dlSubCourses.DataBind();
            }
        }
        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseId = int.Parse(ddlCourses.SelectedValue);
            string sortOrder = ddlSort.SelectedValue;

            if (courseId > 0)
            {
                LoadSubCourses(courseId, sortOrder);
            }
        }

        private void LoadCourses()
        {

            string query = "exec LoadCourse";
            SqlCommand cmd = new SqlCommand(query, conn);
            ddlCourses.DataSource = cmd.ExecuteReader();
            ddlCourses.DataTextField = "CourseName";
            ddlCourses.DataValueField = "CourseID";
            ddlCourses.DataBind();
            ddlCourses.Items.Insert(0, new ListItem("Select Course", "0"));

        }

        private void LoadSubCourses(int courseId, string sortOrder = "")
        {
            string query;

            if (sortOrder != "")
            {
                query = $"exec LoadSubCourseSorted '{courseId}', '{sortOrder}'";
            }
            else
            {
                query = $"exec LoadSubCourse '{courseId}'";
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dlSubCourses.DataSource = dt;
            dlSubCourses.DataBind();
        }


    }
}
