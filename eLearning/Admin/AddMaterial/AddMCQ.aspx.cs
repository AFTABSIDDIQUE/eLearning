using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.AddMaterial
{
    public partial class AddMCQ : System.Web.UI.Page
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
                fetSubCourse();
                fetTopic();
                Hfcount.Value = "0";
                Repeater1.Visible = false;
                BindRepeater();

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
        public void fetSubCourse()
        {
            SqlCommand cmd = new SqlCommand($"exec fetchSubCourse", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList2.DataSource = rdr;
            DropDownList2.DataTextField = "SubCourseName";
            DropDownList2.DataValueField = "SubCourseID";
            DropDownList2.DataBind();
            rdr.Close();
            DropDownList2.Items.Insert(0, new ListItem("Select SubCourse", ""));
        }
        public void fetTopic()
        {
            SqlCommand cmd = new SqlCommand($"exec fetchTopic", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DropDownList3.DataSource = rdr;
            DropDownList3.DataTextField = "TopicName";
            DropDownList3.DataValueField = "TopicID";
            DropDownList3.DataBind();
            rdr.Close();
            DropDownList3.Items.Insert(0, new ListItem("Select Topic", ""));
        }

        public void BindRepeater()
        {
            int count = int.Parse(Hfcount.Value);

            DataTable dt = new DataTable();
            dt.Columns.Add("");

            for (int i = 0; i < count; i++)
            {
                dt.Rows.Add("");
            }

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Repeater1.Visible = count > 0;
        }
        protected void btnmcq_Click(object sender, EventArgs e)
        {
            Hfcount.Value = (int.Parse(Hfcount.Value) + 1).ToString();
            BindRepeater();
        }
        
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int courseId = int.Parse(DropDownList1.SelectedValue);
            int subCourseId = int.Parse(DropDownList2.SelectedValue);
            int topicId = int.Parse(DropDownList3.SelectedValue);
            string CreatedBy = null;

            foreach (RepeaterItem item in Repeater1.Items)
            {
                TextBox txtQuestion = (TextBox)item.FindControl("txtQuestion");
                TextBox txtA = (TextBox)item.FindControl("txtOptionA");
                TextBox txtB = (TextBox)item.FindControl("txtOptionB");
                TextBox txtC = (TextBox)item.FindControl("txtOptionC");
                TextBox txtD = (TextBox)item.FindControl("txtOptionD");
                TextBox txtAns = (TextBox)item.FindControl("txtAnswer");


                string question = txtQuestion.Text;
                string optionA = txtA.Text;
                string optionB = txtB.Text;
                string optionC = txtC.Text;
                string optionD = txtD.Text;
                string answer = txtAns.Text;
                string q = $"exec InsertMCQ '{question}','{optionA}','{optionB}','{optionC}','{optionD}','{answer}',{courseId} ,{subCourseId},{topicId},'{CreatedBy}'";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.ExecuteNonQuery();
            }

            Hfcount.Value = "0";
            Repeater1.Visible = false;
            Repeater1.DataSource = null;
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            Repeater1.DataBind();
        }
    }
}