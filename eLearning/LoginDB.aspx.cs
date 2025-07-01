using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLearning
{
    public partial class LoginDB : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cnf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cnf);
            conn.Open();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string em = txtLoginEmail.Text, pass = txtLoginPassword.Text;
            string q = $"exec LoginDetails '{em}','{pass}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                while (rdr.Read())
                {
                    int id = int.Parse(rdr["userId"].ToString());
                    Session["Users"] = em;
                    Session["email"] = rdr["UserEmail"];
                    Session["name"] = rdr["UserName"];
                    Session["Usersid"] = rdr["UserId"];
                    DateTime lastLogin = DateTime.Parse(rdr["LastLogin"].ToString());
                    DateTime check = lastLogin.AddDays(2);
                    string now = DateTime.Now.ToString("yyyy/MM/dd hh:mm tt");
                    TimeSpan diff = DateTime.Now - lastLogin;
                    int daysDifference = diff.Days;
                    //DateTime check = DateTime.Now;
                    if (daysDifference < 2)
                    {
                        if ((rdr["UserEmail"].Equals(em) || rdr["UserName"].Equals(em)) && rdr["UserPassword"].Equals(pass))
                        {
                            if (rdr["role"].Equals("Admin"))
                            {
                                //DateTime dateTime = DateTime.Now;
                                string query = $"exec LastLogin '{now}','{id}' ";
                                SqlCommand cmd1 = new SqlCommand(query, conn);
                                cmd1.ExecuteNonQuery();
                                Response.Redirect("/Admin/AdminHome.aspx");
                            }
                            else if (rdr["role"].Equals("User"))
                            {
                                string query = $"exec LastLogin '{now}','{id}' ";
                                SqlCommand cmd1 = new SqlCommand(query, conn);
                                cmd1.ExecuteNonQuery();
                                Response.Redirect("/User/UserHome.aspx");
                            }
                            else
                            {
                                Response.Write("404 User Not found");
                            }

                        }
                        
                    }
                    else
                    {
                        Response.Write("<script>alert('Your Account is Inactive, Please Contact Admin');</script>");
                        string qu = $"update Users set stat='Inactive' where UserId='{id}'";
                        SqlCommand cm = new SqlCommand(qu, conn);
                        cm.ExecuteNonQuery();
                    }


                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Credential')</script>");
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name= txtRegName.Text, email= txtRegEmail.Text, phone= txtRegContact.Text, password= txtRegPassword.Text;
            string q = $"exec manageUser '0','{name}','{email}','{phone}','{password}','Active','User'";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('User Created Successfully'); window.location='LoginDB.aspx';</script>");



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string toEmail,email, name, phone,sub;
            toEmail = "aftabsiddique2526@gmail.com";
            email = TextBox1.Text;
            name = TextBox2.Text;
            phone = TextBox3.Text;
            sub = "Inactive Account's Form Submission";
            sendMail(toEmail,email, name, phone,sub);
        }
        public void sendMail(string toEmail, string email,string name, string phone,string sub)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("maithilidukhande2004@gmail.com");
            mail.To.Add(toEmail);
            mail.Subject = sub;
            string body = $@"
                Dear Admin,

                The user account is currently inactive. Please activate the account for this user.

                Details:
                - User Name: {name}
                - User Email: {email}
                - User Contact Number: {phone}

                Thank you.";
            mail.Body = body;


            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new NetworkCredential("maithilidukhande2004@gmail.com", "rkznfhyuucpzyvfm");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(mail);
            Response.Write("<script>alert('Mail Send Successfully!!!')</script>");
        }
    }
}

