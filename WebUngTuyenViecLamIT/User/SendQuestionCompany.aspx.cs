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
    public partial class SendQuestionCompany : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowQusetions();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowQusetions();
        }

        private void ShowQusetions()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            string id = Session["companyId"].ToString();
            query = @"Select Row_Number() over(Order by (Select 1)) as [STT], q.QuestionId, q.question1,q.question2,q.question3
                      from Question q, Company c where q.CompanyId = c.CompanyId and c.CompanyId = '" + id + "' ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int questionId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string appliedId = Request.QueryString["id"].ToString();
                String query = @"Insert into SendQuestions Values(@QuestionId,@AppliedJobsId)";
                con = new SqlConnection(str);
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                cmd.Parameters.AddWithValue("@AppliedJobsId", appliedId);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "Gửi câu hỏi thành công!!!";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Gửi câu hỏi thất bại!!!";
                    lblMsg.CssClass = "alert alert-warning";
                }
                GridView1.EditIndex = -1;
                ShowQusetions();
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
        
    }
}