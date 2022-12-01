<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section>
        <div class="contrainer pt-50 pd-50">
            <div class="row">
                <div class="col-12 pb-20">
                    <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass ="pl-40"></asp:Label>
                </div>
                <div class="col-12">
                    <h2 class="contact-title text-xl-center">Đăng Nhập</h2>
                </div>
                <div class="col-lg-6 mx-auto">
                    <div class="form-contact contact_form">
                        <div class="row">
                            <div class="col-12 mt-12">
                                <div class="form-group">
                                    <label>Tên Đăng Nhập</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder ="Tên đăng nhập" required ></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12 mt-3">
                                <div class="form-group">
                                     <label>Mật Khẩu</label>
                                    <asp:TextBox ID="txtPassWord" TextMode ="Password" runat="server" CssClass="form-control" placeholder ="Nhập mật khẩu" required ></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-12 mt-3">
                                <div class="form-group">
                                     <label>Loại đăng nhập</label>
                                    <asp:DropDownList ID="ddlLoginType" CssClass="form-control w-100" runat="server">
                                        <asp:ListItem Value="0">Chọn quyền đăng nhập</asp:ListItem>
                                        <asp:ListItem>Admin</asp:ListItem>
                                        <asp:ListItem>Ứng Viên</asp:ListItem>
                                         <asp:ListItem>Nhà Tuyển Dụng</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa chọn quyền Login" ForeColor="Red"
                                         Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlLoginType"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-group mt-3">
                            <asp:Button ID="btnLogin" CssClass="button button-contactForm boxed-btn" runat="server" Text="Đăng Nhập" 
                                OnClick="btnLogin_Click" />
                        </div>
                        <div class="form-group mt-3>
                             <span class="ClickLink"> <a href="../User/Register.aspx">Tạo tài khoản mới !!! Click Here ...</a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
