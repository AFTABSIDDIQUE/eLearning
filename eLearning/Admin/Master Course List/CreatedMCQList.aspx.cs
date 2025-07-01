using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning.Admin.Master_Course_List
{
    public partial class CreatedMCQList : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(strcon);
            conn.Open();
            BindGridview();
        }
        public void BindGridview()
        {

            SqlCommand cmd = new SqlCommand("exec selectallMCQ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridViewMCQ.DataSource = dt;
            GridViewMCQ.DataBind();
        }
    }
}