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
    public partial class JobListing : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showJobList();
                RBSelectedColorChange();
            }
        }

        private void showJobList()
        {
            if (dt == null)
            {
                con = new SqlConnection(str);
                string query = @"Select j.JobId,j.Title,j.Salary,j.JobType,c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate 
                                 from Jobs j, Company c where j.Status = 1 and j.CompanyId = c.CompanyId
                                 order by CreateDate DESC ";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
            lbljobCount.Text = JobCount(dt.Rows.Count);
        }

        private string JobCount(int count)
        {
            if (count > 1)
            {
                return "Số lượng công việc có trên Website là :  <b>" + count + "</b>";
            }
            else if (count == 1)
            {
                return "Số lượng công việc phù hợp <b>" + count + "</b>";
            }
            else
            {
                return "Không tìm thấy công việc phù hợp";
            }
        }

        private void RBSelectedColorChange()
        {
            if(RadioButtonList1.SelectedItem.Selected == true)
            {
                RadioButtonList1.SelectedItem.Attributes.Add("class", "selectedradio");
            }
        }


        protected string GetImageUrl(Object url)
        {
            string url1 = "";
            if(string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "~/Images/No_image.png";
            }
            else
            {
                url1 = string.Format("~/{0}",url);
            }
            return ResolveUrl(url1);
        }

        public static string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "Mới");
            thresholds.Add(minute * 2, "{0} phút trước");
            thresholds.Add(45 * minute, "{0} phút trước");
            thresholds.Add(120 * minute, "{0} giờ trước");
            thresholds.Add(day, " hôm qua");
            thresholds.Add(day * 2, "{0} ngày trước");
            thresholds.Add(day * 30, "{0} ngày trước");
            thresholds.Add(day * 365, "{0} tháng trước");
            thresholds.Add(long.MaxValue, "{0} năm trước");
            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCountry.SelectedValue != "0")
            {
                con = new SqlConnection(str);
                string query = @"Select j.JobId,j.Title,j.Salary,j.JobType,c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate 
                                from Jobs j, Company c
                                where j.CompanyId = c.CompanyId and j.Status = 1 and c.City like N'%" + ddlCountry.SelectedValue + "%' ";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();
            }
            else
            {
                showJobList();
                RBSelectedColorChange();
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String jobType = String.Empty;
            jobType = SelectedCheckBox();
            if(jobType != "")
            {
                con = new SqlConnection(str);
                string query = @"Select j.JobId,j.Title,j.Salary,j.JobType,c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate 
                                from Jobs j, Company c
                                where j.CompanyId = c.CompanyId and j.Status = 1 and j.JobType IN (" + jobType + ")";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();
            }
            else
            {
                showJobList();
            }
        }

        private string SelectedCheckBox()
        {
            string jobType = string.Empty;
            for(int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    jobType += "'" + CheckBoxList1.Items[i].Text + "' ,";
                }
            }
            return jobType = jobType.TrimEnd(',');
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedValue != "0")
            {
                string postDate = string.Empty;
                postDate = selectedRadioButton();
                con = new SqlConnection(str);
                string query = @"Select j.JobId,j.Title,j.Salary,j.JobType,c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate 
                                from Jobs j, Company c
                                where j.CompanyId = c.CompanyId and j.Status = 1 and Convert(DATE, j.CreateDate) " + postDate + " ";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();
            }
            else
            {
                showJobList();
                RBSelectedColorChange();
            }
        }

        private string selectedRadioButton()
        {
            string postDate = string.Empty;
            DateTime date = DateTime.Today;
            if(RadioButtonList1.SelectedValue == "1")
            {
                postDate = "= Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else if(RadioButtonList1.SelectedValue == "2")
            {
                postDate = "between Convert(DATE,'" + DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                postDate = "between Convert(DATE,'" + DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                postDate = "between Convert(DATE,'" + DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else
            {
                postDate = "between Convert(DATE,'" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }

            return postDate;
        }

        protected void lbFilter_Click(object sender, EventArgs e)
        {
            try
            {
                bool isCondition = false;
                string subquery = string.Empty;
                string jobType = string.Empty;
                string postDate = string.Empty;
                string addAnd = string.Empty;
                string query = string.Empty;
                List<string> queryList = new List<string>();
                con = new SqlConnection(str);
                if (ddlCountry.SelectedValue != "0")
                {
                    queryList.Add(" j.CompanyId = c.CompanyId and j.Status = 1 and c.City like N'%" + ddlCountry.SelectedValue + "%' ");
                    isCondition = true;
                }

                jobType = SelectedCheckBox();

                if (jobType != "")
                {
                    queryList.Add(" j.CompanyId = c.CompanyId and j.Status = 1 and j.JobType IN (" + jobType + ") ");
                    isCondition = true;
                }

                if (RadioButtonList1.SelectedValue != "0")
                {
                    postDate = selectedRadioButton();
                    queryList.Add(" j.CompanyId = c.CompanyId and j.Status = 1 and j.Convert(DATE, CreateDate) " + postDate);
                    isCondition = true;
                }

                if (isCondition)
                {
                    foreach(string a in queryList){
                        subquery += a + " and ";
                    }
                    subquery = subquery.Remove(subquery.LastIndexOf("and"), 3);
                    query = @"Select j.JobId,j.Title,j.JobType,c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate from Jobs j, Company c where j.Status = 1 and j.CompanyId = c.CompanyId
                             " + subquery + " ";
                }
                else
                {
                    query = @"Select j.JobId,j.Title,j.JobType,c.CompanyName,c.CompanyImage,c.City,c.Country,j.CreateDate from Jobs j, Company c where j.Status = 1 and j.CompanyId = c.CompanyId";
                }
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();


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

        protected void lbReset_Click(object sender, EventArgs e)
        {
            ddlCountry.ClearSelection();
            CheckBoxList1.ClearSelection();
            RadioButtonList1.SelectedValue = "0";
            RBSelectedColorChange();
            showJobList();
        }

        protected void ddbSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}