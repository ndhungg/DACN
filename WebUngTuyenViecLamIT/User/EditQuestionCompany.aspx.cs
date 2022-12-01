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
    public partial class EditQuestionCompany : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                fillData();
            }
        }

        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                con = new SqlConnection(str);
                query = @"Select Row_Number() over(Order by (Select 1)) as [STT],q.question1,q.question2,q.question3
                          from Question q, Company c where q.CompanyId = c.CompanyId and q.QuestionId = '" + Request.QueryString["id"].ToString().Trim() + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtQuestion1.Text = sdr["question1"].ToString().Trim();
                        txtQuestion2.Text = sdr["question2"].ToString().Trim();
                        txtQuestion3.Text = sdr["question3"].ToString().Trim();
                        cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    }
                }
                else
                {
                    lblMsg.Text = "Không tìm thấy Job có tên trong danh !!!";
                    lblMsg.CssClass = "alert alert-warning";
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void btnbEdit_Click(object sender, EventArgs e)
        {
            string type = string.Empty;
            con = new SqlConnection(str);
            if (Request.QueryString["id"] != null)
            {
                query = @"Update Question set question1=@question1,question2=@question2,question3=@question3 where QuestionId = @id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@question1", txtQuestion1.Text.Trim());
                cmd.Parameters.AddWithValue("@question2", txtQuestion2.Text.Trim());
                cmd.Parameters.AddWithValue("@question3", txtQuestion3.Text.Trim());
                cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
            }
            type = "Cập nhật";
            con.Open();
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                lblMsg.Text = type + " thông tin câu hỏi thành công !!!";
                lblMsg.CssClass = "alert alert-success";
                clear();
                con.Close();
            }
            else
            {
                lblMsg.Text = type + "thông tin câu hỏi thất bại  !!!";
                lblMsg.CssClass = "alert alert-warning";
            }
        }

        private void clear()
        {
            txtQuestion1.Text = String.Empty;
            txtQuestion2.Text = String.Empty;
            txtQuestion3.Text = String.Empty;
        }
    }
}