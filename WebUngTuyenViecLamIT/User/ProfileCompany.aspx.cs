using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.User
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
            if (Session["company"] == null && Session["user"] == null)
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
            cmd.Parameters.AddWithValue("@username", Session["company"].ToString());
            cmd.Parameters.AddWithValue("@id", Session["companyId"].ToString());
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
                Response.Redirect("ResumeBuildCompany.aspx?id=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "ViewListJobCompany")
            {
                Response.Redirect("JobListCompany.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected string GetImageUrl(Object url)
        {
            string url1 = string.Empty;
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "~/Images/No_image.png";
            }
            else
            {
                url1 = string.Format("~/{0}", url);
            }
            return ResolveUrl(url1);
        }
    }
}