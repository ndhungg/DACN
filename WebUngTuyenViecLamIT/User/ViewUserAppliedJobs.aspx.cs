using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.User
{
    public partial class ViewUserAppliedJobs : System.Web.UI.Page
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
                ShowAppliedJob();
            }
        }

        private void ShowAppliedJob()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [STT], aj.AppliedJobsId, aj.JobId, c.CompanyName, j.Title,
                      u.Mobile,u.Name, U.Email, u.Resume from AppliedJobs aj
                      inner join [User] u on aj.UserId = u.UserId
                      inner join Jobs j on aj.JobId = j.JobId
					  inner join Company c on c.CompanyId = j.CompanyId
                      where c.CompanyId = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Session["companyId"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAppliedJob();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            //e.Row.ToolTip = "Click xem thông tin chi tiết công việc";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)

        {
            //TextBoxUserID.Text = GridView1.SelectedRow.Cells[1].Text;  lấy dữ liệu từ 1 dòng trên gridview
            //GridView row  in  GridView1.Rows();
            //GridViewRow row =  GridView1.Rows;
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    if (row.RowIndex == GridView1.SelectedIndex)
            //    {
            //        HiddenField jobId = (HiddenField)row.FindControl("hdnJobId");
            //        Response.Redirect("JobList.aspx?id=" + jobId.Value);
            //    }
            //    else
            //    {
            //        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            //    }
            //}
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowAppliedJob();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SendQuestion")
            {
                Response.Redirect("SendQuestionCompany.aspx?id=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "ListFeedBackUser")
            {
                Response.Redirect("ListFeedBackUser.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}