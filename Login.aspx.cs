using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace GovPortal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string empId = txtEmpId.Text.Trim();

            if (!string.IsNullOrEmpty(empId))
            {
                Session["emp_id"] = empId;
                Session["session_id"] = Session.SessionID;

                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["YourConnStr"].ConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO UserSessions (EmpId, SessionId, LoginTime, LastActiveTime) 
                                   VALUES (@EmpId, @SessionId, @LoginTime, @LastActiveTime)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpId", empId);
                        cmd.Parameters.AddWithValue("@SessionId", Session.SessionID);
                        cmd.Parameters.AddWithValue("@LoginTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LastActiveTime", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.Text = "Please enter your Employee ID.";
            }
        }
    }
}
