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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                String query = @"insert into [User] (Username,Password,Name,Address,Mobile,Email,Country)
                                values (@Username,@Password,@Name,@Address,@Mobile,@Email,@Country)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", ddlConuntry.SelectedValue);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Tạo tài khoản thành công !!! ";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Tạo tài khoản thất bại, Vui lòng gửi lại sau !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                }
            }
            catch(SqlException ex)
            {
                //Check UserName đã có in litsUser hay chưa and Message UseName Duplication
                if (ex.Message.Contains("Violation of UNIQUE KEY contraint"))
                {
                    Response.Write("<script>alert('" + ex.Message + "'); </script>");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b> Tài khoản có tên: " + txtUserName.Text.Trim() + "</b> đã tồn tại trong danh sách !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                    txtUserName.Text = String.Empty;
                    txtUserName.Focus();
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
            txtUserName.Text = String.Empty;
            txtPassWord.Text = String.Empty;
            txtConfirmPassWord.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtAdress.Text = String.Empty;
            txtMobile.Text = String.Empty;
            txtEmail.Text = String.Empty;
            ddlConuntry.ClearSelection();
        }
        
    }
}