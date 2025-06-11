using System;
using System.Configuration;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace GovPortal
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["emp_id"] == null || Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        [WebMethod(EnableSession = true)]
        //[WebMethod(EnableSession = true)]
        public static void UpdateLastActive()
        {
            try
            {
                string empId = System.Web.HttpContext.Current.Session["emp_id"]?.ToString();
                string sessionId = System.Web.HttpContext.Current.Session["session_id"]?.ToString();

                if (string.IsNullOrEmpty(empId) || string.IsNullOrEmpty(sessionId))
                {
                    throw new InvalidOperationException("Session data is missing");
                }

                string connStr = ConfigurationManager.ConnectionStrings["YourConnStr"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = @"UPDATE UserSessions 
                           SET LastActiveTime = @LastActiveTime 
                           WHERE EmpId = @EmpId AND SessionId = @SessionId";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpId", empId);
                        cmd.Parameters.AddWithValue("@SessionId", sessionId);
                        cmd.Parameters.AddWithValue("@LastActiveTime", DateTime.Now);

                        int rows = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"Rows updated: {rows}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in UpdateLastActive: " + ex.Message);
                throw new InvalidOperationException("Authentication failed.", ex);
            }
        }

    }

}

