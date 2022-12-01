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
    public partial class ViewResumeJobs : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader sdr;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAppliedJob();
        }

        private void ShowAppliedJob()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [STT], aj.AppliedJobsId, aj.JobId, u.Name, c.CompanyName, j.Title,
                      c.Mobile, j.JobType, c.Email from AppliedJobs aj
                      inner join [User] u on aj.UserId = u.UserId
                      inner join Jobs j on aj.JobId = j.JobId
					  inner join Company c on c.CompanyId = j.CompanyId where u.UserId = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Session["userId"].ToString());
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
         
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //ứng tuyển nhưng chưa gửi câu trả lời
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int appliedJobsId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string query = @"Delete AppliedJobs where AppliedJobsId = @id";
                con = new SqlConnection(str);
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", appliedJobsId);
                con.Open();
                int r  = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "Hủy ứng tuyển thành công!!!";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Hủy ứng tuyển thất bại!!!";
                    lblMsg.CssClass = "alert alert-success";
                }
                //else
                //{
                //string idFeedBack = string.Empty;
                //string query = @"select f.FeedBackId from AppliedJobs aj
                //          inner join FeedBack f on f.AppliedJobsId = aj.AppliedJobsId
                //          where aj.AppliedJobsId = @id";
                // con = new SqlConnection(str);
                // cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@id", appliedJobsId);
                // con.Open();
                // sdr = cmd.ExecuteReader();
                // if (sdr.HasRows)
                // {
                //     if (sdr.Read())
                //     {
                //         idFeedBack = sdr["FeedBackId"].ToString();
                //         query = @"select s.SaveDataId from FeedBack f
                //                 inner join SaveData s on s.FeedBackId = f.FeedBackId
                //                 where f.FeedBackId = @id";
                //         con = new SqlConnection(str);
                //         cmd = new SqlCommand(query, con);
                //         cmd.Parameters.AddWithValue("@id", idFeedBack);
                //         con.Open();
                //         sdr = cmd.ExecuteReader();
                //         if (sdr.HasRows)
                //         {
                //             if (sdr.Read())
                //             {
                //                 string idSaveData = string.Empty;
                //                 idSaveData = sdr["SaveDataId"].ToString();
                //                 query = @"Delete SaveData where SaveDataId = @id";
                //                 con = new SqlConnection(str);
                //                 cmd = new SqlCommand(query, con);
                //                 cmd.Parameters.AddWithValue("@id", idSaveData);
                //                 con.Open();
                //                 sdr = cmd.ExecuteReader();
                //                 if (sdr.HasRows)
                //                 {
                //                     if (sdr.Read())
                //                     {
                //                         query = @"Delete FeedBack where FeedBackId = @id";
                //                         con = new SqlConnection(str);
                //                         cmd = new SqlCommand(query, con);
                //                         cmd.Parameters.AddWithValue("@id", idFeedBack);
                //                         con.Open();
                //                         con.Open();
                //                         sdr = cmd.ExecuteReader();
                //                         if (sdr.HasRows)
                //                         {
                //                             query = @"Delete AppliedJobs where AppliedJobsId = @id";
                //                             con = new SqlConnection(str);
                //                             cmd = new SqlCommand(query, con);
                //                             cmd.Parameters.AddWithValue("@id", appliedJobsId);
                //                             con.Open();
                //                             int r =  cmd.ExecuteNonQuery();
                //                             if(r > 0)
                //                             {
                //                                 lblMsg.Text = "Hủy ứng tuyển thành công!!!";
                //                                 lblMsg.CssClass = "alert alert-success";
                //                             }
                //                             else
                //                             {
                //                                 lblMsg.Text = "Hủy ứng tuyển thất bại!!";
                //                                 lblMsg.CssClass = "alert alert-warning";
                //                             }
                //                         }
                //                     }
                //                 }
                //             }
                //         }
                //     else
                //     {
                //         query = @"Delete FeedBack where FeedBackId = @id";
                //         con = new SqlConnection(str);
                //         cmd = new SqlCommand(query, con);
                //         cmd.Parameters.AddWithValue("@id", idFeedBack);
                //         con.Open();
                //         //con.Open();
                //         sdr = cmd.ExecuteReader();
                //         if (sdr.HasRows)
                //         {
                //             query = @"Delete AppliedJobs where AppliedJobsId = @id";
                //             con = new SqlConnection(str);
                //             cmd = new SqlCommand(query, con);
                //             cmd.Parameters.AddWithValue("@id", appliedJobsId);
                //             con.Open();
                //             int r = cmd.ExecuteNonQuery();
                //             if (r > 0)
                //             {
                //                 lblMsg.Text = "Hủy ứng tuyển thành công!!!";
                //                 lblMsg.CssClass = "alert alert-success";
                //             }
                //             else
                //             {
                //                 lblMsg.Text = "Hủy ứng tuyển thất bại!!";
                //                 lblMsg.CssClass = "alert alert-warning";
                //             }
                //         }
                //     }
                //     }
                // }
                // else
                // {
                //     query = @"Delete AppliedJobs where AppliedJobsId = @id";
                //     con = new SqlConnection(str);
                //     cmd = new SqlCommand(query, con);
                //     cmd.Parameters.AddWithValue("@id", appliedJobsId);
                //     con.Open();
                //     int r = cmd.ExecuteNonQuery();
                //     if(r > 0)
                //     {
                //         lblMsg.Text = "Hủy ứng tuyển thành công!!!";
                //         lblMsg.CssClass = "alert alert-success";
                //     }
                // }

                GridView1.EditIndex = -1;
                ShowAppliedJob();
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowAppliedJob();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "ListQusetion")
            {
                Response.Redirect("ListQuestion.aspx?id=" + e.CommandArgument);
            }
        }
    }
}