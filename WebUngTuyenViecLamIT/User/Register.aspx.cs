using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebUngTuyenViecLamIT.User
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static string code = GenerateRandomString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string GenerateRandomString()
        {
            int length = 5;
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }


        public void sendEmail()
        {
            string from, to, pass, content;
            from = "timviecit123@gmail.com";
            pass = "lmztcnoaarspwfcf";
            to = txtEmail.Text.Trim();
            content = "Mã: " + code;

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = "Mã xác nhận tài khoản của bạn";
            mail.Body = content;
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, pass);
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
            }
            txtVerification.Focus();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                if (txtVerification.Text.Trim() == "")
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Tạo tài khoản thất bại, Vui lòng gửi lại sau !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                }
                else
                {
                    if (txtVerification.Text.Trim().Equals(code))
                    {
                        insertAccount();
                        string id = getId();
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
                            updateAccount();
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
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = " Mã xác nhận Gmail không đúng, tạo tài khoản thất bại !!! ";
                        lblMsg.CssClass = "alert alert-warning";
                    }
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
                    lblMsg.Text = "<b> Gmail: " + txtEmail.Text.Trim() + "</b> đã được sử dụng !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                    txtEmail.Focus();
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
                int status = 0;
                con = new SqlConnection(str);
                String query = @"insert into Account (UserName,PassWord,Status)
                                values (@Username,@Password,@Status)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
                cmd.Parameters.AddWithValue("@Status", status);
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

        private void updateAccount()
        {
            int status = 1;
            con = new SqlConnection(str);
            String query = @"Update Account set Status = @Status where UserName = @Username";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
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
            txtVerification.Text = String.Empty;
            ddlCountry.ClearSelection();
            ddlAccountType.ClearSelection();
        }

        protected void btnTestSendGmail_Click(object sender, EventArgs e)
        {
            sendEmail();
        }
    }
}