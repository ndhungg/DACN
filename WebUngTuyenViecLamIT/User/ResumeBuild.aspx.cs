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
    public partial class ResumeBuild : System.Web.UI.Page
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
                showUserInfo();
            }
        }

        private void showUserInfo()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                query = "select a.UserName, u.Name, u.Email, u.Mobile,u.Favourite, u.WorksOn,u.Experience, u.Resume, u.Address, u.Country from[User] u, Account a where u.UserId = '" + Request.QueryString["id"] + "'";
                cmd = new SqlCommand(query, con);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = Session["user"].ToString().Trim();
                        txtFullName.Text = sdr["Name"].ToString().Trim();
                        txtEmail.Text = sdr["Email"].ToString().Trim();
                        txtMobile.Text = sdr["Mobile"].ToString().Trim();
                        txtFavourite.Text = sdr["Favourite"].ToString().Trim();
                        txtWork.Text = sdr["WorksOn"].ToString().Trim();
                        txtExperience.Text = sdr["Experience"].ToString().Trim();
                        txtAdress.Text = sdr["Address"].ToString().Trim();
                        ddlConuntry.SelectedValue = sdr["Country"].ToString().Trim();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Không tìm thấy thông tin người dùng!!!";
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
                    string userImage = string.Empty;
                    string filePath = string.Empty;
                    //bool isValidToExcute = false;
                    bool isValid = false;
                    con = new SqlConnection(str);
                    if (fuResume.HasFile)
                    {
                        if (Untils.IsValidToExtensionResume(fuResume.FileName))
                        {
                            concatQuery = "Resume=@Resume,";
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }

                    if (fuUserImage.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuUserImage.FileName))
                        {
                            userImage = "UserImage=@UserImage,";
                            isValid = true;
                        }
                        else
                        {
                            userImage = string.Empty;
                        }
                    }

                    else
                    {
                        concatQuery = string.Empty;
                        userImage = string.Empty;
                    }

                    query = @"Update [User] set Name=@Name,Email=@Email,Mobile=@Mobile,
                              Favourite=@Favourite,WorksOn=@WorksOn,Experience=@Experience," + concatQuery + @"Address=@Address, "+ userImage + @"Country=@Country where UserId=@UserId";
                    cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Favourite", txtFavourite.Text.Trim());
                    cmd.Parameters.AddWithValue("@WorksOn", txtWork.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlConuntry.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);
                    if (fuResume.HasFile)
                    {
                        if (Untils.IsValidToExtensionResume(fuResume.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            filePath = "Resumes/" + obj.ToString() + fuResume.FileName;
                            fuResume.PostedFile.SaveAs(Server.MapPath("~/Resumes/") + obj.ToString() + fuResume.FileName);
                            cmd.Parameters.AddWithValue("@Resume", filePath);
                            isValid = true;
                        }
                        else
                        {
                            concatQuery = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Vui lòng lựa chọn file .doc, .docx, .pdf";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }

                    if (fuUserImage.HasFile)
                    {
                        if (Untils.IsValidToExtension(fuUserImage.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            filePath = "CompanyImages/" + obj.ToString() + fuUserImage.FileName;
                            fuUserImage.PostedFile.SaveAs(Server.MapPath("~/CompanyImages/") + obj.ToString() + fuUserImage.FileName);
                            cmd.Parameters.AddWithValue("@UserImage", filePath);
                            isValid = true;
                        }
                        else
                        {
                            userImage = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = "Vui lòng lựa chọn file .jpg, .png, .jepg";
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
                        if(r > 0)
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
            catch(SqlException ex)
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