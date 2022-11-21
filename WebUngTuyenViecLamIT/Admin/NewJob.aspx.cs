using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.Admin
{
    public partial class NewJob : System.Web.UI.Page
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
            if(Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                query = "Select *from Jobs where JobId = '"+Request.QueryString["id"] +"' ";
                cmd = new SqlCommand(query,con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtNoOfPost.Text = sdr["NoPost"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specialization"].ToString();
                        txtLastDay.Text = Convert.ToDateTime(sdr["LastDateToApply"]).ToString("yyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddbJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAdress.Text = sdr["Address"].ToString();
                        txtCity.Text = sdr["City"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        btnAdd.Text = "Cập Nhật";
                        linkBack.Visible = true;
                        Session["title"] = "Cập Nhật Thông Tin Công Việc";
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String type, concatQuery, imagePath = String.Empty;
                Boolean isValidToExcute = false;
                con = new SqlConnection(str);
                if (Request.QueryString["id"] != null)
                {
                    if (fuCompanyLogo.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyImage=@CompanyImage,";
                        }
                        else
                        {
                            concatQuery = String.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = String.Empty;
                    }
                    query = @"Update Jobs set Title=@Title,NoPost=@NoPost,Description=@Description,Qualification=@Qualification,Experience=@Experience,
                            Specialization=@Specialization,LastDateToApply=@LastDateToApply,Salary=@Salary,JobType=@JobType,CompanyName=@CompanyName," + concatQuery + @"Website=@Website,
                            Email=@Email,Address=@Address,City=@City,Country=@Country where JobId=@id";

                    type = "Cập nhật";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoPost", txtNoOfPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDay.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddbJobType.Text.Trim());
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());

                    if (fuCompanyLogo.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);
                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExcute = true;

                        }
                        else
                        {
                            lblMsg.Text = "Vui lòng lựa chọn hình ảnh có file .jpg, .png, .jepg ";
                            lblMsg.CssClass = "alert alert-error";
                        }
                    }
                    else
                    {
                        isValidToExcute = true;
                    }
                }
                else
                {
                    query = @"Insert into Jobs Values(@Title,@NoPost,@Description,@Qualification,@Experience,@Specialization,@LastDateToApply
                        ,@Salary,@JobType,@CompanyName,@CompanyImage,@Website,@Email,@Address,@CreateDate,@City,@Country) ";

                    type = "Thêm mới";
                    DateTime time = DateTime.Now;
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoPost", txtNoOfPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", txtLastDay.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddbJobType.Text.Trim());
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    if (fuCompanyLogo.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);
                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExcute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Vui lòng lựa chọn hình ảnh có file .jpg, .png, .jepg ";
                            lblMsg.CssClass = "alert alert-error";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                        isValidToExcute = true;
                    }
                }

                if (isValidToExcute)
                {
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = type + " công việc thành công !!!";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Text = type + " công việc thất bại  !!!";
                        lblMsg.CssClass = "alert alert-warning";
                    }
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

        private void clear()
        {
            txtJobTitle.Text = String.Empty;
            txtNoOfPost.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtExperience.Text = String.Empty;
            txtQualification.Text = String.Empty;
            txtSpecialization.Text = String.Empty;
            txtLastDay.Text = String.Empty;
            txtSalary.Text = String.Empty;
            ddbJobType.ClearSelection();
            txtCompany.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtAdress.Text = String.Empty;
            txtWebsite.Text = String.Empty;
            txtCity.Text = String.Empty;
            ddlCountry.ClearSelection();
        }

    }
}