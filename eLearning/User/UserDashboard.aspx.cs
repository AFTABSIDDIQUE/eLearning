using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace eLearning.User
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        SqlConnection conn;
        int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = int.Parse(Session["Usersid"].ToString());
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            conn.Open();

            if (!IsPostBack)
            {
                LoadMyCourses();
                LoadCompleted();
                LoadInCompleted();
                LoadPieChart();
                LoadCompletionDetails();
            }
        }

        public void LoadMyCourses()
        {
            SqlCommand cmd = new SqlCommand($"GetTotalCoursesByUser {userId}", conn);
            int TotalCourses = int.Parse(cmd.ExecuteScalar().ToString());
            lblMyCourses.Text = TotalCourses.ToString();
        }

        public void LoadCompleted()
        {
            SqlCommand cmd = new SqlCommand($"getCompletedCourseByUser {userId}", conn);
            int CompleteCourses = int.Parse(cmd.ExecuteScalar().ToString());
            Label1.Text = CompleteCourses.ToString();
        }

        public void LoadInCompleted()
        {
            SqlCommand cmd = new SqlCommand($"getInCompletedCourseByUser {userId}", conn);
            int InCompleteCourses = int.Parse(cmd.ExecuteScalar().ToString());
            Label2.Text = InCompleteCourses.ToString();
        }

        public void LoadPieChart()
        {
            int completedCourses = int.Parse(Label1.Text);
            int incompletedCourses = int.Parse(Label2.Text);

            PieChart.Series.Clear();
            Series series = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                LabelForeColor = Color.White
            };

            if (completedCourses > 0)
            {
                series.Points.AddXY("Completed", completedCourses);
                series.Points[series.Points.Count - 1].Color = ColorTranslator.FromHtml("#28a745");
            }

            if (incompletedCourses > 0)
            {
                series.Points.AddXY("Incompleted", incompletedCourses);
                series.Points[series.Points.Count - 1].Color = ColorTranslator.FromHtml("#dc3545");
            }

            PieChart.Series.Add(series);
        }

        public string GetBarColor(double percentage)
        {
            if (percentage < 50)
                return "#dc3545";
            else if (percentage < 80)
                return "#ffc107";
            else
                return "#28a745";
        }

        public void LoadCompletionDetails()
        {

            SqlCommand cmd = new SqlCommand($"GetSubCourseCompletionByUser {userId}", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            dt.Columns.Add("BarColor", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                double percent = Convert.ToDouble(row["CompletionPercentage"]);
                string color = GetBarColor(percent);
                row["BarColor"] = $"background-color: {color};";
            }

            rptCompletion.DataSource = dt;
            rptCompletion.DataBind();
        }
    }
}