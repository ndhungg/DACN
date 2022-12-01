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
    public partial class QuestionUser : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        String query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }


        private void clear()
        {
            txtQuestion1.Text = String.Empty;
            txtQuestion2.Text = String.Empty;
            txtQuestion3.Text = String.Empty;
        }

        //private string getAppliedId()
        //{
        //    string id = string.Empty;
        //    string companyId = Session["CompanyId"].ToString();
        //    con = new SqlConnection(str);
        //    string query = @"Select aj.AppliedJobsId from AppliedJobs aj
        //                    inner join [User] u on aj.UserId = u.UserId
        //                    inner join Jobs j on aj.JobId = j.JobId
        //                    inner join Company c on c.CompanyId = j.CompanyId
        //                    where c.CompanyId = @companyId";
        //    cmd = new SqlCommand(query, con);
        //    cmd.Parameters.AddWithValue("@companyId", companyId);
        //    con.Open();
        //    sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        if (sdr.Read())
        //        {
        //            id = sdr["AppliedJobsId"].ToString();
        //        }
        //    }
        //    return id;
        //}


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String type = String.Empty;
                type = "Thêm mới";
                int status = 0;
                con = new SqlConnection(str);
                query = @"Insert into Question Values(@question1,@question2,@question3,@Status,@CompanyId) ";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@question1", txtQuestion1.Text.Trim());
                cmd.Parameters.AddWithValue("@question2", txtQuestion2.Text.Trim());
                cmd.Parameters.AddWithValue("@question3", txtQuestion3.Text.Trim());
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@CompanyId", Session["companyId"].ToString());
                con.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMsg.Text = type + " câu hỏi thành công !!!";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Text = type + " câu hỏi thất bại  !!!";
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
    }
}