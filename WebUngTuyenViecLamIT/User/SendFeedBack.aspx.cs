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
    public partial class SendFeedBack : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        string query = string.Empty;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowQuestions();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            if (Request.QueryString["id"] != null)
            {
                string id = Request.QueryString["id"].ToString();
                con = new SqlConnection(str);
                query = @"Select Row_Number() over(Order by (Select 1)) as [STT],q.question1,q.question2,q.question3 from Company c
                        inner join Question q on q.CompanyId = c.CompanyId
                        inner join SendQuestions s on s.QuestionId = q.QuestionId
                        where s.SendQuestionId = '" + Request.QueryString["id"].ToString().Trim() + "' ";
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


        public string getAppliedJobsId()
        {
            string id = string.Empty;
            string idSend = Request.QueryString["id"].ToString();
            con = new SqlConnection(str);
            query = @"Select s.AppliedJobsId from SendQuestions s where s.SendQuestionId = '" + Request.QueryString["id"].ToString().Trim() + "' ";
            cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    id = sdr["AppliedJobsId"].ToString();
                }
            }
            return id;
        }

        public string getFeedBackId()
        {
            string id = string.Empty;
            string idSend = Request.QueryString["id"].ToString();
            con = new SqlConnection(str);
            query = @"Select f.FeedBackId from FeedBack f, SendQuestions s where s.SendQuestionId = '" + Request.QueryString["id"].ToString().Trim() + "' ";
            cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    id = sdr["FeedBackId"].ToString();
                }
            }
            return id;
        }

        private void insertFeedBack()
        {
            try
            {
                string id = getAppliedJobsId();
                con = new SqlConnection(str);
                query = "Insert into FeedBack Values(@FeedBack1, @FeedBack2, @FeedBack3,@AppliedJobsId)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FeedBack1", txtFeedBack1.Text.Trim());
                cmd.Parameters.AddWithValue("@FeedBack2", txtFeedBack2.Text.Trim());
                cmd.Parameters.AddWithValue("@FeedBack3", txtFeedBack3.Text.Trim());
                cmd.Parameters.AddWithValue("@AppliedJobsId", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
            finally
            {
                con.Close();
            }
        }


        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string idSend = Request.QueryString["id"].ToString();
                if (idSend != null)
                {
                    insertFeedBack();
                    string id = getFeedBackId();
                    con = new SqlConnection(str);
                    query = "Insert into SaveData Values(@SendQuestionId, @FeedBackId)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SendQuestionId", idSend);
                    cmd.Parameters.AddWithValue("@FeedBackId", id);
                    con.Open();
                    int  r =  cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Text ="Phản hồi thành công !!!";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Text = "Phản hồi thất bại !!!";
                        lblMsg.CssClass = "alert alert-warning";
                    }

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "'); </script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string id = getAppliedJobsId();
            Response.Redirect("ListQuestion.aspx?id=" + id);
        }
    }
}