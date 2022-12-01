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
    public partial class ListQuestion : System.Web.UI.Page
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
                ShowQuestions();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowQuestions();
        }

        private void ShowQuestions()
        {
            string query = string.Empty;
            Session["companyname"] = getNameCompany();
            con = new SqlConnection(str);
            string id = Request.QueryString["id"].ToString();
            query = @"Select Row_Number() over(Order by (Select 1)) as [STT],s.SendQuestionId, s.AppliedJobsId, q.QuestionId, q.question1,q.question2,q.question3
                    from Company c
                    inner join Question q on q.CompanyId = c.CompanyId
                    inner join SendQuestions s on s.QuestionId = q.QuestionId where s.AppliedJobsId = '" + id + "' ";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            if(dt != null)
            {
                GridView1.DataBind();
            }
        }

        private string getNameCompany()
        {
            string name = string.Empty;
            con = new SqlConnection(str);
            string id = Request.QueryString["id"].ToString();
            string query = @"Select c.CompanyName from Company c,SendQuestions s
                             where s.AppliedJobsId = '" + id + "' ";
            cmd = new SqlCommand(query, con);
            con.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                if(sdr.Read())
                {
                    name = sdr["CompanyName"].ToString();
                }
            }
            return name;
        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "SendFeedBack")
            {
                Response.Redirect("SendFeedBack.aspx?id=" + e.CommandArgument.ToString());
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string id = Session["userId"].ToString();
            Response.Redirect("ViewResumeJobs.aspx?id=" + id);
        }
    }
}