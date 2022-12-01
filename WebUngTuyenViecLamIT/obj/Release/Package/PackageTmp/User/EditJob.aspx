<%@ Page Title="" Language="C#" MasterPageFile="~/User/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="EditJob.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.EditJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container pt-4 pb-4">
            <div class="btn-toolbar justify-content-between mb-3">
                <div class="btn-group">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
            </div>
                  
               <h3 class="text-center">Cập Nhật Thông Tin Công Việc</h3>
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
                    <label for="txtExperience" style="font-weight: 600">Yêu Cầu Kinh Nghiệm</label>
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

            <div class="row mr-lg-3 ml-lg-5 mb-3 pt-4">
                <div class="col-md-2 col-md-offset-2 mb-3">
                    <asp:Button ID="btnEdit" runat="server" Text="Cập Nhật" CssClass="btn btn-primary btn-block" OnClick="btnEdit_Click"/>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
