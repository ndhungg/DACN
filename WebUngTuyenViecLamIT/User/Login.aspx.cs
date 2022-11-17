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
        String username, password = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(ddlLoginType.SelectedValue == "Quản Lý")
                {
                    username = ConfigurationManager.AppSettings["username"];
                    password = ConfigurationManager.AppSettings["password"];
                    if(username == txtUserName.Text.Trim() && password == txtPassWord.Text.Trim())
                    {
                        Session["Quản Lý"] = username;
                        Response.Redirect("../Admin/Dashboard.aspx", false);
                    }
                    else
                    {
                        showErrorMsg(txtUserName.Text.ToString());
                    }
                }
                else
                {
                    con = new SqlConnection(str);
                    String query = @"Select *from [User] where Username = @Username and Password = @Password";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassWord.Text.Trim());
                    con.Open();
                    sdr = cmd.ExecuteReader();

                    if(sdr.Read())
                    {
                        Session["user"] = sdr["Username"].ToString();
                        Session["userId"] = sdr["UserId"].ToString();
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        showErrorMsg(txtUserName.Text.ToString());
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
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