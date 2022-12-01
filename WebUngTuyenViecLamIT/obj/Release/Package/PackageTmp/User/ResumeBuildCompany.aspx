<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuildCompany.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.ResumeBuildCompany" %>
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
                    <h2 class="contact-title text-xl-center">Thông Tin Công Ty</h2>
                </div>
                <div class="col-lg-6 mx-auto">
                    <div class="form-contact contact_form">
                        <div class="row">
                            <div class="col-12 pb-12">
                                <h6>Tài Khoản</h6>
                            </div>
                            <div class="col-12">
                                <div class="form-group mt-8">
                                    <label>Họ và Tên Công Ty</label>
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Họ và Tên" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Họ và Tên không hợp lệ" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z'-'\sáàảãạăâắằấầặẵẫậéèẻ ẽẹếềểễệóòỏõọôốồổỗộ ơớờởỡợíìỉĩịđùúủũụưứ� �ửữựÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠ ƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼ� ��ỀỂỄỆỈỊỌỎỐỒỔỖỘỚỜỞ ỠỢỤỨỪỬỮỰỲỴÝỶỸửữựỵ ỷỹ]*$" ControlToValidate="txtFullName">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-12">
                                <div class="form-group">
                                    <label>Tên Đăng Nhập</label>
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Tên đăng nhập" required></asp:TextBox>
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

                            <div class="col-12">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email" required></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-12">
                                <div class="form-group">
                                    <label>Quốc Gia</label>
                                    <asp:DropDownList ID="ddlConuntry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                                        AppenDataBoundItems="true" DataTextField="Name" DataValueField="Name">
                                        <asp:ListItem Value="0">
                                            Lựa chọn quốc gia của bạn !!!
                                        </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa lựa chọn quốc gia !!!" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ControlToValidate="ddlConuntry"></asp:RequiredFieldValidator>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebSiteTuyenDungConnectionString %>" SelectCommand="SELECT [Name] FROM [Country]"></asp:SqlDataSource>
                                </div>
                            </div>

                            <div class="col-12 pb-12 pt-4">
                                <h6>Thông Tin Công Ty</h6>
                            </div>

                           <%-- <div class="col-md-6 col-sm-12 ">
                                <div class="form-group">
                                    <label>Precentage / Grade</label>
                                    <asp:TextBox ID="txtTenTh" runat="server" CssClass="form-control" placeholder="VD: 90%" required></asp:TextBox>
                                </div>
                            </div>--%>

                           <%-- <div class="col-md-6 col-sm-12 ">
                                <div class="form-group">
                                    <label>Precentage / Grade</label>
                                    <asp:TextBox ID="txtTweflth" runat="server" CssClass="form-control" placeholder="VD: 90%" required></asp:TextBox>
                                </div>
                            </div>--%>

                            <%--<div class="col-md-6 col-sm-12 ">
                                <div class="form-group">
                                    <label>Điểm trung bình tốt nghiệp</label>
                                    <asp:TextBox ID="txtGraduation" runat="server" CssClass="form-control" placeholder="VD: 3.2" required></asp:TextBox>
                                </div>
                            </div>--%>

                             <%--<div class="col-md-6 col-sm-12 ">
                                <div class="form-group">
                                    <label>Điểm trung bình tốt nghiệp</label>
                                    <asp:TextBox ID="txtPostGraduation" runat="server" CssClass="form-control" placeholder="VD: 3.2" required></asp:TextBox>
                                </div>
                            </div>--%>

                            <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Website Công Ty</label>
                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" placeholder="VD: abc@gmail.com ..." required></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-6 col-sm-12">
                                <div class="form-group">
                                    <label>Tỉnh / Thành Phố</label>
                                    <asp:TextBox ID="txtCiTy" runat="server" CssClass="form-control" placeholder="VD: TP.HCM ..." required></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-12 ">
                                <div class="form-group">
                                    <label>Hình ảnh / Logo</label>
                                    <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control pt-2" ToolTip="Chỉ chấp nhận các file có đuôi .png, .jpg, .jepg" />
                                </div>
                            </div>

                        </div>
                        <div class="form-group mt-10">
                            <asp:Button ID="Update" runat="server" Text="Cập Nhật" CssClass="button button-contractForm boxed-btn mr-4"
                                OnClick="Update_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
