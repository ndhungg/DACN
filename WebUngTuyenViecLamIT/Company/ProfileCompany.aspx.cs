using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.Company
{
    public partial class ProfileCompany : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        SqlDataAdapter sda;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                showCompanyProfile();
            }
        }

        private void showCompanyProfile()
        {
            con = new SqlConnection(str);
            String query = "Select c.CompanyId,a.UserName,c.CompanyName,c.Address,c.Mobile,c.Email,c.Country,c.CompanyImage, c.Website,c.City " +
                           "from Company c, Account a where a.Username = @username and c.CompanyId = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", Session["company"]);
            cmd.Parameters.AddWithValue("@id", Session["companyId"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dlProfileCompany.DataSource = dt;
                dlProfileCompany.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Vui lòng đăng nhập lại !!!'); </script>");
            }
        }

        protected void dlProfileCompany_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditCompanyProfile")
            {
                Response.Redirect("ResumeBuild.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}