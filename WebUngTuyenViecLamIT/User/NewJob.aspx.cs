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
    public partial class NewJob : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        String query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String type = String.Empty;
                con = new SqlConnection(str);
                query = @"Insert into Jobs Values(@Title,@NoNumberPost,@Description,@Qualification,@Experience,@Specialization,@LastDateToApply
                        ,@Salary,@JobType,@CreateDate,@Status,@CompanyId) ";
                type = "Thêm mới";
                int status = 0;
                DateTime time = DateTime.Now;
                cmd = new SqlCommand(query, con);
                int id = Convert.ToInt32(Session["companyId"].ToString());
                cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@NoNumberPost", txtNoOfPost.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDay.Text.Trim());
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                cmd.Parameters.AddWithValue("@JobType", ddbJobType.SelectedValue);
                cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@CompanyId", id);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.Text = type + " công việc thành công !!!";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Text = type + " công việc thất bại  !!!";
                    lblMsg.CssClass = "alert alert-warning";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
                con.Close();
            }
            finally
            {
                con.Close();
            }
        }

        private void clear()
        {
            txtJobTitle.Text = String.Empty;
            txtNoOfPost.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtExperience.Text = String.Empty;
            txtQualification.Text = String.Empty;
            txtSpecialization.Text = String.Empty;
            txtLastDay.Text = String.Empty;
            txtSalary.Text = String.Empty;
            ddbJobType.ClearSelection();
        }
    }
}