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
    public partial class ResumeBuildCompany : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        SqlDataReader sdr;
        String query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["company"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                showCompanyInfo();
            }
        }

        private void showCompanyInfo()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                query = "Select c.CompanyId,a.UserName,c.CompanyName,c.Address,c.Mobile,c.Email,c.Country,c.CompanyImage, c.Website, c.City from Company c, Account a where c.CompanyId = '" + Request.QueryString["id"] + "'";
                cmd = new SqlCommand(query, con);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = Session["company"].ToString().Trim();
                        txtFullName.Text = sdr["CompanyName"].ToString().Trim();
                        txtEmail.Text = sdr["Email"].ToString().Trim();
                        txtMobile.Text = sdr["Mobile"].ToString().Trim();
                        txtAdress.Text = sdr["Address"].ToString().Trim();
                        txtWebsite.Text = sdr["Website"].ToString().Trim();
                        txtCiTy.Text = sdr["City"].ToString().Trim();
                        ddlConuntry.SelectedValue = sdr["Country"].ToString().Trim();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Không tìm thấy thông tin công ty!!!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    //bool isValidToExcute = false;
                    bool isValid = false;
                    con = new SqlConnection(str);
                    if (fuImage.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuImage.FileName))
                        {
                            concatQuery = "CompanyImage=@CompanyImage,";
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }

                    query = @"Update Company set CompanyName=@CompanyName,Email=@Email,Mobile=@Mobile,
                              Website=@Website,City=@City," + concatQuery + @"Address=@Address,Country=@Country where CompanyId=@id";
                    cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@CompanyName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", txtCiTy.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlConuntry.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    if (fuImage.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuImage.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            filePath = "CompanyImages/" + obj.ToString() + fuImage.FileName;
                            fuImage.PostedFile.SaveAs(Server.MapPath("~/CompanyImages/") + obj.ToString() + fuImage.FileName);
                            cmd.Parameters.AddWithValue("@CompanyImage", filePath);
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Vui lòng lựa chọn file .png, .jpg, .jepg";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValid = true;
                    }

                    if (isValid)
                    {
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cập nhật thành công";
                            lblMsg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Không thể cập nhật thông tin người dùng, Vui lòng thử lại sau !!!";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cập nhật thất bại, <b> Đăng Nhập </b> và thử lại";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("violation of unique key contraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b> tài khoản có tên: " + txtUserName.Text.Trim() + "</b> đã tồn tại trong danh sách !!! ";
                    lblMsg.CssClass = "alert alert-warning";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}