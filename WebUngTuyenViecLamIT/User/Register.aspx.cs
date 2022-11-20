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
        SqlDataReader sdr;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                insertAccount();
                string id = getId();
                con = new SqlConnection(str);
                string company = "Nhà Tuyển Dụng";
                if (ddlAccountType.SelectedValue.Equals(company))
                {
                    string query = @"insert into Company (CompanyName,Email,Mobile,Address,Country,AccountId)
                              values (@CompanyName,@Email,@Mobile,@Address,@Country,@AccountId)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CompanyName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@AccountId", id);
                }
                else
                {
                    string query = @"insert into [User] (Name,Email,Mobile,Address,Country,AccountId)
                           values (@Name,@Email,@Mobile,@Address,@Country,@AccountId)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@AccountId", id);
                }
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
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY contraint"))
                {
                    Response.Write("<script>alert('" + ex.Message + "'); </script>");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b> Tài khoản có tên: " + txtUserName.Text.Trim() + "</b> đã tồn tại trong danh sách !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
            finally
            {
                con.Close();
            }
        }

        private void insertAccount()
        {
            try
            {
                con = new SqlConnection(str);
                String query = @"insert into Account (UserName,PassWord)
                                values (@Username,@Password)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
                con.Open();

                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY contraint"))
                {
                    Response.Write("<script>alert('" + ex.Message + "'); </script>");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b> Tài khoản có tên: " + txtUserName.Text.Trim() + "</b> đã tồn tại trong danh sách !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                    txtUserName.Focus();
                }
            }
            finally
            {
                con.Close();
            }
        }


        private string getId()
        {
            string id = "";
            con = new SqlConnection(str);
            String query = @"Select AccountId from Account where Username = @Username and Password = @Password";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
            con.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                id = sdr["AccountId"].ToString();
            }
            con.Close();
            return id;
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
            ddlCountry.ClearSelection();
            ddlAccountType.ClearSelection();
        }
        
    }
}