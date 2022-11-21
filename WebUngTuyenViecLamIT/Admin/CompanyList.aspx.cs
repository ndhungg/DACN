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
    public partial class CompanyList : System.Web.UI.Page
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
                showCompanyList();
            }
        }

        private void showCompanyList()
        {
            String query = String.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [STT], c.CompanyId, c.CompanyName, c.Email, c.Mobile, c.Address 
                  from Company  c 
                  inner join Account a on a.AccountId = c.AccountId";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            showCompanyList();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int companyId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string query = @"Select a.AccountId, j.JobId from Company c 
                                inner join Account a on a.AccountId = c.AccountId
                                inner join Jobs j on j.CompanyId = c.CompanyId
                                where c.CompanyId = @id";
                con = new SqlConnection(str);
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", companyId);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        string accountId = sdr["AccountId"].ToString();
                        query = "Delete from Company where CompanyId = @id";
                        con = new SqlConnection(str);
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", companyId);
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        con.Close();

                        if (r > 0)
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
                else
                {
                    string q = @"Select a.AccountId from Company c inner join Account a on a.AccountId = c.AccountId
                                    where c.CompanyId = @id ";
                    con = new SqlConnection(str);
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@id", companyId);
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        if (sdr.Read())
                        {
                            string accountId = sdr["AccountId"].ToString();
                            query = "Delete from Company where CompanyId = @id";
                            con = new SqlConnection(str);
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", companyId);
                            con.Open();
                            int r = cmd.ExecuteNonQuery();
                            con.Close();

                            if (r > 0)
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
                GridView1.EditIndex = -1;
                showCompanyList();
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
    }
}