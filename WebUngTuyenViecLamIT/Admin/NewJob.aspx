<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="WebUngTuyenViecLamIT.Admin.NewJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container pt-4 pb-4">
            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>

                <div class="input-group h-25">
                    <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/JobList.aspx" CssClass="btn btn-primary" Visible="false">Quay Lại</asp:HyperLink>
                </div>
            </div>

            <h3 class="text-center"><%Response.Write(Session["title"]); %></h3>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtJobTitle" style="font-weight: 600">Tên Công Việc</label>
                    <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="VD: Design, Web Developer" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtNoOfPost" style="font-weight: 600">Số Lượng Vị Trí</label>
                    <asp:TextBox ID="txtNoOfPost" runat="server" CssClass="form-control" placeholder="Số lượng vị trí" required
                        TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtDescription" style="font-weight: 600">Mô Tả</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Nội dung công việc" required
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtQualification" style="font-weight: 600">Bằng Cấp/Trường Học</label>
                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="VD: HUTECH, FPT ..." required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtExperience" style="font-weight: 600">Kinh Nghiệm</label>
                    <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="VD: 1 năm, 2 năm hoặc chưa có ... " required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtSpecialization" style="font-weight: 600">Chuyên Môn</label>
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="VD: C#, Java, GoLang ... " required
                        TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="txtLastDay" style="font-weight: 600">Thời Gian Ứng Tuyển </label>
                    <asp:TextBox ID="txtLastDay" runat="server" CssClass="form-control" placeholder="" required
                        TextMode="Date"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtSalary" style="font-weight: 600">Mức Lương</label>
                    <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="VD: 1000/Tháng,...(USD)" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="ddbJobType" style="font-weight: 600">Loại Công Việc</label>
                    <asp:DropDownList ID="ddbJobType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Chọn loại công việc</asp:ListItem>
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Remote</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa chọn loại công việc !!!" ForeColor="Red"
                        ControlToValidate="ddbJobType" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtCompany" style="font-weight: 600">Tên Công Ty</label>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control" placeholder="VD: FPT Softwate" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <label for="ddbJobType" style="font-weight: 600">Logo / Hình ảnh</label>
                    <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png " />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn chưa chọn logo công ty !!!" ForeColor="Red"
                        ControlToValidate="ddbJobType" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtWebsite" style="font-weight: 600">Website Công Ty</label>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" placeholder="VD: abc@gmail.com" required></asp:TextBox>
                </div>

                <div class="col-md-6 pt-3">
                    <label for="txtEmail" style="font-weight: 600">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="VD: abc@gmail.com" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="txtWebsite" style="font-weight: 600">Thành Phố</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="VD: TP.HCM" required></asp:TextBox>
                </div>

                <div class="col-md-6">
                    <div class="col-md-13 pt-3">
                        <label for="txtWebsite" style="font-weight: 600">Quốc Gia</label>
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
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-4">
                    <label for="txtAdress" style="font-weight: 600">Địa Chỉ</label>
                    <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control" placeholder="VD: Số nhà x, đường x, quận x, ... " required
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-3 ml-lg-5 mb-3 pt-4">
                <div class="col-md-2 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" Text="Thêm Mới" CssClass="btn btn-primary btn-block"
                        OnClick="btnAdd_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
