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
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string username, password,status = string.Empty;

        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                username = ConfigurationManager.AppSettings["UserName"];
                password = ConfigurationManager.AppSettings["PassWord"];
                status = ConfigurationManager.AppSettings["Status"];

                if (ddlLoginType.SelectedValue == "Ứng Viên")
                {
                    con = new SqlConnection(str);
                    String query = @"select u.UserId,a.UserName, u.Name, u.Address, u.Mobile, u.Email,u.Country
                                     from Account a, [User] u
                                     where a.PassWord = @PassWord and a.UserName = @UserName and a.AccountId = u.AccountId and a.Status = 1";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        if (sdr.Read())
                        {
                            Session["user"] = sdr["UserName"].ToString();
                            Session["userId"] = sdr["UserId"].ToString();
                            Response.Redirect("Default.aspx", false);
                        }
                        else if (txtUserName.Text.Trim() != username || txtPassWord.Text.Trim() != password)
                        {
                            showErrorMsg(txtUserName.Text.ToString());
                        }
                    }
                    con.Close();
                }
                else if (ddlLoginType.SelectedValue == "Nhà Tuyển Dụng")
                {
                    con = new SqlConnection(str);
                    String query = @"select c.CompanyId, a.UserName, c.CompanyName, c.Address, c.Mobile, c.Email,c.Satus,c.Country
                                     from Account a, Company c
                                     where a.PassWord = @PassWord and a.UserName = @UserName and a.AccountId = c.AccountId and a.Status = 1";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        if (sdr.Read())
                        {
                            id = Convert.ToInt32(sdr["CompanyId"].ToString());
                            Session["company"] = sdr["UserName"].ToString();
                            Session["companyId"] = sdr["CompanyId"].ToString();
                            Response.Redirect("Default.aspx", false);
                        }
                        else if (txtUserName.Text.Trim() != username || txtPassWord.Text.Trim() != password)
                        {
                            showErrorMsg(txtUserName.Text.ToString());
                        }
                    }
                    con.Close();
                }
                else
                {
                    int s = Convert.ToInt32(status);
                    if (username == txtUserName.Text.Trim() && password == txtPassWord.Text.Trim() && s == 1)
                    {
                        Session["admin"] = username;
                        Response.Redirect("../Admin/Dashboard.aspx", false);
                    }
                    else if (txtUserName.Text.Trim() != username || txtPassWord.Text.Trim() != password)
                    {
                        showErrorMsg(txtUserName.Text.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                con.Close();
            }
        }

        private void showErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "<b> Tài khoản: " + userType + "</b> thông tin đăng nhập không chính xác!!!";
            lblMsg.CssClass = "alert alert-warning";
        }
    }
}