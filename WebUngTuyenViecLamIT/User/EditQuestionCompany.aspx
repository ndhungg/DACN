<%@ Page Title="" Language="C#" MasterPageFile="~/User/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="EditQuestionCompany.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.EditQuestionCompany" %>
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
             <h3 class="text-center">Cập Nhật Thông Tin Câu Hỏi</h3>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtDescription" style="font-weight: 600">Câu hỏi thứ nhất ?</label>
                    <asp:TextBox ID="txtQuestion1" runat="server" CssClass="form-control" placeholder="VD: Vì sao bạn lựa chọn công ty chúng tôi ?" required
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtDescription" style="font-weight: 600">Câu hỏi thứ hai ?</label>
                    <asp:TextBox ID="txtQuestion2" runat="server" CssClass="form-control" placeholder="VD: Điểm mạnh của bạn là gì ?" required
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="txtDescription" style="font-weight: 600">Câu hỏi thứ ba ?</label>
                    <asp:TextBox ID="txtQuestion3" runat="server" CssClass="form-control" placeholder="VD: Mục tiêu nghề nghiệp của bạn ?" required
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

              <div class="row mr-lg-3 ml-lg-5 mb-3 pt-4">
                <div class="col-md-2 col-md-offset-2 mb-3">
                    <asp:Button ID="btnbEdit" runat="server" Text="Cập nhật" CssClass="btn btn-primary btn-block" OnClick="btnbEdit_Click"/>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
