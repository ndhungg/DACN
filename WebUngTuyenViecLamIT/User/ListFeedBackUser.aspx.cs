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
    public partial class ListFeedBackUser : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
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
                showFeedBackUser();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
              showFeedBackUser();
        }

        private void showFeedBackUser()
        {
           con = new SqlConnection(str);
           string id = Request.QueryString["id"].ToString();
           string query = @"Select Row_Number() over(Order by (Select 1)) as [STT],s.SendQuestionId, 
                            s.AppliedJobsId, q.QuestionId, q.question1,q.question2,q.question3,
                            f.feedBack1, f.feedBack2,f.feedBack3
                            from Company c
                            inner join Question q on q.CompanyId = c.CompanyId
                            inner join SendQuestions s on s.QuestionId = q.QuestionId 
					        inner join FeedBack f on f.AppliedJobsId = s.AppliedJobsId
					        inner join SaveData sa on sa.FeedBackId = f.FeedBackId
					        where s.AppliedJobsId = '" + id + "' ";
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
                    txtFeedBack1.Text = sdr["feedBack1"].ToString().Trim();
                    txtFeedBack2.Text = sdr["feedBack2"].ToString().Trim();
                    txtFeedBack3.Text = sdr["feedBack3"].ToString().Trim();
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                }
            }
            else
            {
                con = new SqlConnection(str);
                query = @"Select Row_Number() over(Order by (Select 1)) as [STT],s.SendQuestionId, 
                            s.AppliedJobsId, q.QuestionId, q.question1,q.question2,q.question3
                            from Company c
                            inner join Question q on q.CompanyId = c.CompanyId
                            inner join SendQuestions s on s.QuestionId = q.QuestionId 
					        where s.AppliedJobsId = '" + id + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                sdr = cmd.ExecuteReader();
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
                lblMsg.Text = "ứng viên chưa trả lời câu hỏi của bạn !!!";
                lblMsg.CssClass = "alert alert-warning";
            }
            sdr.Close();
            con.Close();
        }
    }
}