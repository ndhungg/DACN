<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="contrainer pt-50 pd-50">
            <div class="row">
                <div class="col-12 pb-20">
                    <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="pl-40"></asp:Label>
                </div>
                <div class="col-12">
                    <h2 class="contact-title text-xl-center">Đăng Ký Tài Khoản</h2>
                </div>
                <div class="col-lg-6 mx-auto">
                    <div class="form-contact contact_form">
                        <div class="row">
                            <div class="col-12 pb-12">
                                <h6>Thông Tin Đăng Ký</h6>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Tên Đăng Nhập</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Tên đăng nhập" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6 mt-3">
                                <div class="form-group">
                                    <label>Mật Khẩu</label>
                                    <asp:TextBox ID="txtPassWord" TextMode="Password" runat="server" CssClass="form-control" placeholder="Nhập mật khẩu" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6 mt-3">
                                <div class="form-group">
                                    <label>Xác Nhận Mật Khẩu</label>
                                    <asp:TextBox ID="txtConfirmPassWord" TextMode="Password" runat="server" CssClass="form-control" placeholder="Xác nhận mật khẩu" required></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu không trùng khớp."
                                        ControlToCompare="txtPassWord" ControlToValidate="txtConfirmPassWord" ForeColor="Red" Display="Dynamic" SetFocusOnError="true"
                                        Font-Size="Small"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="col-12 pb-12">
                                <h6>Thông Tin Người Dùng</h6>
                            </div>
                            <div class="col-12">
                                <div class="form-group mt-8">
                                    <label>Họ và Tên</label>
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Họ và Tên" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Họ và Tên không hợp lệ" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z'-'\sáàảãạăâắằấầặẵẫậéèẻ ẽẹếềểễệóòỏõọôốồổỗộ ơớờởỡợíìỉĩịđùúủũụưứ� �ửữựÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠ ƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼ� ��ỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞ ỠỢỤỨỪỬỮỰỲỴÝỶỸửữựỵ ỷỹ]*$" ControlToValidate="txtFullName">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-12 pb-4">
                                <div class="form-group">
                                    <label>Địa Chỉ</label>
                                    <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control" placeholder="Địa Chỉ" TextMode="MultiLine" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group pt-4">
                                    <label>Số Điện Thoại</label>
                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Số Điện Thoại" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Số điện thoại không họp lệ" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Địa chỉ Gmail không hợp lệ" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="\w+([-+.’]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Mã Xác Nhận Email</label>
                                    <asp:TextBox ID="txtVerification" runat="server" CssClass="form-control" placeholder="Vui lòng nhập mã xác nhận"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="col-md-13 pt-3">
                                    <label style="font-weight: 600">Quốc Gia</label>
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control w-100" DataSourceID="SqlDataSource1"
                                        AppendDataBoundItems="True" DataTextField="Name" DataValueField="Name">
                                        <asp:ListItem Value="0">Lựa chọn quốc gia của bạn</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebSiteTuyenDungConnectionString %>"
                                        SelectCommand="SELECT [Name] FROM [Country]"></asp:SqlDataSource>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn chưa lựa chọn quốc gia !!!" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ControlToValidate="ddlCountry">
                                    </asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:WebSiteTuyenDungConnectionString %>" SelectCommand="SELECT [Name] FROM [Country]"></asp:SqlDataSource>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="col-md-13 pt-3">
                                    <label style="font-weight: 600">Loại tài khoản</label>
                                    <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-contact w-100" AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">Chọn loại tài khoản</asp:ListItem>
                                        <asp:ListItem>Ứng Viên</asp:ListItem>
                                        <asp:ListItem>Nhà Tuyển Dụng</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn chưa lựa loại tài khoản !!!" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ControlToValidate="ddlAccountType">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%-- <div class="col-12">
                                <div class="form-group">
                                    <label>Quốc Gia</label>
                                    <asp:DropDownList ID="ddlConuntry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                                        AppenDataBoundItems="true" DataTextField="Name" DataValueField="Name">
                                        <asp:ListItem Value="0">
                                            Lựa chọn quốc gia của bạn !!!
                                        </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebSiteTuyenDungConnectionString %>" SelectCommand="SELECT [Name] FROM [Country]">
                                    </asp:SqlDataSource>

                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa lựa chọn quốc gia !!!" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ControlToValidate="ddlConuntry"></asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:WebSiteTuyenDungConnectionString %>" SelectCommand="SELECT [Name] FROM [Country]">
                                    </asp:SqlDataSource>
                                </div>
                            </div>--%>
                        </div>
                        <div class="form-group mt-3 mr-10">
                            <asp:Button ID="btnRegister" CssClass="button button-contactForm boxed-btn" runat="server" Text="Đăng Ký"
                                OnClick="btnRegister_Click" />
                        </div>
                         <div class="form-group mt-3 mr-10">
                            <asp:Button ID="btnTestSendGmail" CssClass="button button-contactForm boxed-btn" runat="server" Text="test"
                                OnClick="btnTestSendGmail_Click" />
                        </div>
                        <div class="form-group mt-3">
                            <span class="ClickLink"><a href="../User/Login.aspx">Bạn đã có tài khoản ? Click Here ...</a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
