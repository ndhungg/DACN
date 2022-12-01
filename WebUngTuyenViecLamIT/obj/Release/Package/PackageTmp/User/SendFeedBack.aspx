<%@ Page Title="" Language="C#" MasterPageFile="~/User/ViewUser/UserApplied.Master" AutoEventWireup="true" CodeBehind="SendFeedBack.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.SendFeedBack" %>
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
             <h3 class="text-center">Trả lời câu hỏi</h3>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label style="font-weight: 600">Câu hỏi thứ nhất: </label>
                    <asp:Label ID="txtQuestion1" runat="server" style="font-weight: 600" Text="txtQuestion1"></asp:Label>
                    <div class="pt-2">
                        <asp:TextBox ID="txtFeedBack1" runat="server" CssClass="form-control" placeholder="VD: Câu trả lời ..." required
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>


              <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label style="font-weight: 600">Câu hỏi thứ hai: </label>
                    <asp:Label ID="txtQuestion2" runat="server" style="font-weight: 600" Text="txtQuestion2"></asp:Label>
                    <div class="pt-2">
                        <asp:TextBox ID="txtFeedBack2" runat="server" CssClass="form-control" placeholder="VD: Câu trả lời ..." required
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>

               <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label style="font-weight: 600">Câu hỏi thứ ba: </label>
                    <asp:Label ID="txtQuestion3" runat="server" style="font-weight: 600" Text="txtQuestion3"></asp:Label>
                    <div class="pt-2">
                        <asp:TextBox ID="txtFeedBack3" runat="server" CssClass="form-control" placeholder="VD: Câu trả lời ..." required
                        TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>

              <div class="row mr-lg-3 ml-lg-5 mb-3 pt-4">
                <div class="col-md-2 col-md-offset-2 mb-3">
                    <asp:Button ID="btnSend" runat="server" Text="Gửi" CssClass="btn btn-primary btn-block" OnClick="btnSend_Click"/>
                </div>
            </div>

            <div class="row mr-lg-3 ml-lg-5 mb-3 pt-4">
                <div class="col-md-2 col-md-offset-2 mb-3">
                    <asp:Button ID="btnBack" runat="server" Text="Quay Lại" CssClass="btn btn-primary btn-block" OnClick="btnBack_Click"/>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
