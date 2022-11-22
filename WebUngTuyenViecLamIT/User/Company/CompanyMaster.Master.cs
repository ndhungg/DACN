using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.User.Company
{
    public partial class CompanyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {

            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            if (Session["company"] != null && Session["user"] == null)
            {
                Response.Redirect("ProfileCompany.aspx");
            }
        }
    }
}