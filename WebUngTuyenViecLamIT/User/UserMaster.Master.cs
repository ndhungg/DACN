using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        String resume = "Hồ Sơ";
        String login = "Đăng Nhập";
        String logout = "Đăng Xuất";
        String register = "Đăng Ký";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                lbRegisterOrProfile.Text = resume;
                lbLoginOrLogout.Text = logout;
            }
            else if(Session["company"] != null)
            {
                lbRegisterOrProfile.Text = resume;
                lbLoginOrLogout.Text = logout;
            }
            else
            {
                lbRegisterOrProfile.Text =register;
                lbLoginOrLogout.Text = login;
            }
        }

        protected void lbRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (lbRegisterOrProfile.Text.Trim().Equals(resume))
            {
                if(Session["user"] != null)
                {
                    Response.Redirect("Profile.aspx");
                }
                else if(Session["company"] != null)
                {
                    Response.Redirect("ProfileCompany.aspx");
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }


        protected void lbLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (lbLoginOrLogout.Text.Trim().Equals(login))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

    }

   }
