using Razorpay.Api;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.User.VideoPanel
{
    public partial class VideoPanel : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
            if (!IsPostBack)
            {
                LoadPlaylist();



            }
        }

        private void LoadPlaylist()
        {

            string query = "SELECT TopicID, t.TopicName, t.TopicUrl,t.SubCourseID, c.CoursePic,t.CourseID as CourseID FROM Topic t inner join Course c on t.CourseID=c.CourseID where t.CourseID=2";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Session["CourseID"] = rdr["CourseID"].ToString();
            Session["SubCourseID"] = rdr["SubCourseID"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter data = new SqlDataAdapter(query, conn);
            data.Fill(ds);
            rptPlaylist.DataSource = ds;
            rptPlaylist.DataBind();
            

        }

        public void PlayListtracker()
        {
            if (string.IsNullOrEmpty(hdnSelectedTopicID.Value))
            {
                return;
            }

            if (!int.TryParse(hdnSelectedTopicID.Value, out int topicId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid topic id.');", true);
                return;
            }
            string q = $"UPDATE Topic set isEnabled=1 where TopicID='{topicId}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
        




        protected void Button3_Click(object sender, EventArgs e)
        {
            int userId = 2;
            int courseId = int.Parse(Session["CourseID"].ToString());
            int subCourseId = int.Parse(Session["SubCourseID"].ToString());
            int TopicID = int.Parse(hdnSelectedTopicID.Value.ToString());
            int rating = int.Parse(DropDownList2.SelectedValue);
            string feedback = TextBox1.Text;

            string q = $"exec InsertReview '{userId}','{courseId}','{subCourseId}','{TopicID}','{rating}','{feedback}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            //Response.Write("<script>alert('FeedBack Sent');</script>");
            TextBox1.Text = "";
            DropDownList2.ClearSelection();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {

            string filePath = null;
            string fileName = null;
            int topicId = int.Parse(hdnSelectedTopicID.Value.ToString());
            string q = $"SELECT * FROM Assignment WHERE TopicID = '{topicId}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@id", topicId);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                filePath = rdr["AssignmentFile"].ToString();
                fileName = rdr["AssignmentID"].ToString();
            }


            if (!string.IsNullOrEmpty(filePath))
            {
                string absolutePath = Server.MapPath(filePath);

                if (File.Exists(absolutePath))
                {
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName}");
                    Response.TransmitFile(absolutePath);
                    Response.End();
                }
                else
                {

                    Response.Write("<script>alert('File not found on server {fileId}');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No file path found in database ');</script>");
            }
        }


        private void BindMCQs()
        {
            if (string.IsNullOrEmpty(hdnSelectedTopicID.Value))
            {
                
                return;
            }

            if (!int.TryParse(hdnSelectedTopicID.Value, out int topicId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid topic id.');", true);
                return;
            }

            string query = $"SELECT * FROM MCQ WHERE TopicID = '{topicId}'";
            SqlCommand cmd = new SqlCommand(query, conn);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rptMCQ.DataSource = dt;

            rptMCQ.DataBind();
        }

        protected void btnSubmitMCQ_Click(object sender, EventArgs e)
        {
            int score = 0;
            int total = rptMCQ.Items.Count;


            foreach (RepeaterItem item in rptMCQ.Items)
            {
                HiddenField hfMCQID = (HiddenField)item.FindControl("hfMCQID");
                string mcqID = hfMCQID.Value;
                string userAnswer = Request.Form["q" + mcqID];

                if (!string.IsNullOrEmpty(userAnswer))
                {
                    string correctAnswer = "";

                        conn.Open();
                        string query = "SELECT Answer FROM MCQ WHERE MCQID = @MCQID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MCQID", mcqID);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            correctAnswer = result.ToString();
                        }
                    
                    if (userAnswer == correctAnswer)
                    {
                        score++;
                    }
                }
            }

            lblMCQResult.Text = $"Your Score: {score} out of {total}";
        }



        protected void Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hdnSelectedTopicID.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No topic selected.');", true);
                return;
            }

            if (!int.TryParse(hdnSelectedTopicID.Value, out int topicId))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid topic id.');", true);
                return;
            }

            string query = $"SELECT * FROM MCQ WHERE TopicID = '{topicId}'";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataSet ds = new DataSet();
            SqlDataAdapter data = new SqlDataAdapter(cmd);  
            data.Fill(ds);

            rptMCQ.DataSource = ds;

            rptMCQ.DataBind();
        }

        protected void btnHidden_Click(object sender, EventArgs e)
        {
            PlayListtracker();
        }
    }
}


