using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUngTuyenViecLamIT.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader sdr;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                showUserList();
            }
        }

        private void showUserList()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [STT], u.UserId, a.UserName, u.Name, u.Email, u.Mobile, u.Address 
                      from [User]  u 
                      inner join Account a on a.AccountId = u.AccountId";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string query = @"Select a.AccountId , al.AppliedJobsId  from [User]  u 
                                 inner join Account a on a.AccountId = u.AccountId
                                 inner join AppliedJobs al on al.UserId = u.UserId
                                 inner join Jobs j on j.JobId = al.JobId
                                 where  u.UserId = @id";
                con = new SqlConnection(str);
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", userId);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        string applideId = sdr["AppliedJobsId"].ToString();
                        string accountId = sdr["AccountId"].ToString();

                        query = "delete from AppliedJobs where AppliedJobsId =@id";
                        con = new SqlConnection(str);
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", applideId);
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        con.Close();
                        if (r > 0)
                        {
                            query = "Delete from [User] where UserId = @id";
                            con = new SqlConnection(str);
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", userId);
                            con.Open();
                            int r1 = cmd.ExecuteNonQuery();
                            con.Close();
                            if (r1 > 0)
                            {
                                String query1 = "Delete Account where AccountId = @id";
                                con = new SqlConnection(str);
                                cmd = new SqlCommand(query1, con);
                                cmd.Parameters.AddWithValue("@id", accountId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                lblMsg.Text = "Xóa thành công!!!";
                                lblMsg.CssClass = "alert alert-success";
                            }
                            else
                            {
                                lblMsg.Text = "Xóa thất bại!!!";
                                lblMsg.CssClass = "alert alert-warning";
                            }
                        }
                    }
                }
                else
                {
                    string q = @"select a.AccountId from Account a, [User] u where a.AccountId = u.AccountId and u.UserId = @id";
                    con = new SqlConnection(str);
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@id", userId);
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        if (sdr.Read())
                        {
                            query = "Delete from [User] where UserId = @id";
                            con = new SqlConnection(str);
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", userId);
                            con.Open();
                            int r = cmd.ExecuteNonQuery();
                            con.Close();
                            if (r > 0)
                            {
                                string accountId = sdr["AccountId"].ToString();
                                String query1 = "Delete Account where AccountId = @id";
                                con = new SqlConnection(str);
                                cmd = new SqlCommand(query1, con);
                                cmd.Parameters.AddWithValue("@id", accountId);
                                con.Open();
                                int r1 = cmd.ExecuteNonQuery();
                                con.Close();
                                if (r1 > 0)
                                {
                                    lblMsg.Text = "Xóa thành công!!!";
                                    lblMsg.CssClass = "alert alert-success";
                                }
                                else
                                {
                                    lblMsg.Text = "Xóa thất bại!!!";
                                    lblMsg.CssClass = "alert alert-warning";
                                }
                            }
                        }
                    }
                }
                GridView1.EditIndex = -1;
                showUserList();
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
            showUserList();
        }
    }
}