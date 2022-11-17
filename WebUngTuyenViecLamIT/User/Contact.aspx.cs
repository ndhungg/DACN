using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.User
{
    public partial class Contact : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                String query = @"insert into Contact values (@Name, @Email, @Subject, @Message)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name.Value.Trim());
                cmd.Parameters.AddWithValue("@Email", email.Value.Trim());
                cmd.Parameters.AddWithValue("@Subject", subject.Value.Trim());
                cmd.Parameters.AddWithValue("@Message", message.Value.Trim());
                con.Open();
               int r =  cmd.ExecuteNonQuery();
                if( r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cảm ơn bạn đã phản hồi, chúng tôi sẽ trả lời câu hỏi của bạn trong thời gian sớm nhất !!! ";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Không thể gửi phản hồi, Vui lòng gửi lại sau !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
            finally
            {
                con.Close();
            }
        }

        private void clear()
        {
            name.Value = String.Empty;
            email.Value = String.Empty;
            subject.Value = String.Empty;
            message.Value = String.Empty;

        }
    }
}