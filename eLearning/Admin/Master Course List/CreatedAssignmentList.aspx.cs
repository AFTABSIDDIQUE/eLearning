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

namespace eLearning.Admin.Master_Course_List
{
    public partial class CreatedAssignmentList : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(strcon);
            conn.Open();
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        public void BindGridview()
        {

            SqlCommand cmd = new SqlCommand("exec selectallAssignment", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewAssignment.DataSource = dt;
            GridViewAssignment.DataBind();
        }
        protected void GridViewAssignment_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                string fileName = e.CommandArgument.ToString();
                string filePath = Server.MapPath("~/Upload/" + fileName);

                if (File.Exists(filePath))
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('File not found.');</script>");
                }

            }
        }
    }
}