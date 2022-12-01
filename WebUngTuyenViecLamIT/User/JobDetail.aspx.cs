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
    public partial class JobDetail : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        SqlDataAdapter sda;
#pragma warning disable CS0169 // The field 'JobDetail.sdr' is never used
        SqlDataReader sdr;
#pragma warning restore CS0169 // The field 'JobDetail.sdr' is never used
        DataTable dt,dt1;
        public string jobTitle = string.Empty;
        string appliedJobs = "Ứng Tuyển Ngay";

        protected void Page_Init(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] != null)
            {
                showJobDetail();
                DataBind();
            }
            else
            {
                Response.Redirect("JobListing.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            showJobDetail();
        }

        private void showJobDetail()
        {
            con = new SqlConnection(str);
            string query = @"Select j.JobId, j.Title,j.NoNumberPost,j.Description, j.Qualification, j.Experience, j.Salary,j.JobType,
                            c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate, j.Specialization, j.LastDateToApply, c.Address,c.Website,c.Email
                            from Jobs j, Company c where c.CompanyId = j.CompanyId and j.JobId = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id",Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            jobTitle = dt.Rows[0]["Title"].ToString();
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
        

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals(appliedJobs))
            {
                if (Session["user"] != null && Session["company"] == null)
                {
                    try
                    {
                        con = new SqlConnection(str);
                        string query = "Insert into AppliedJobs values (@JobId, @UserId)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                        cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            LblMsg.Visible = true;
                            LblMsg.Text = "Ứng tuyển thành công !!!";
                            LblMsg.CssClass = "alert alert-success";
                            showJobDetail();
                        }
                        else
                        {
                            LblMsg.Visible = true;
                            LblMsg.Text = "Ứng tuyển thất bại !!!";
                            LblMsg.CssClass = "alert alert-waring";
                        }
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

                else if (Session["user"] == null && Session["company"] != null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"] != null && Session["company"] == null )
            {
                LinkButton btnApplyJob = e.Item.FindControl("labAppliedJobs") as LinkButton;
                if (isApplied())
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Bạn đã ứng tuyển rồi";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "ứng Tuyển Ngay";
                }
            }
        }


        //cách fix lấy ra mã ứng tuyển của người dùng và fix lại funcition isApplied
        // nếu status = 1 đã hủy ứng tuyển, nếu status = 0 chưa ứng tuyển

        bool isApplied()
        {
            con = new SqlConnection(str);
            string query = @"Select * from AppliedJobs where UserId = @UserId and JobId = @JobId";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
            cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}