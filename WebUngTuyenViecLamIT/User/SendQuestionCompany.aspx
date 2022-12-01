<%@ Page Title="" Language="C#" MasterPageFile="~/User/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="SendQuestionCompany.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.SendQuestionCompany" %>
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
           

            <h3 class="text-center">Danh sách chi tiết câu hỏi </h3>
         </div>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table tab-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmtyDataText="No record display ...!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                     DataKeyNames="QuestionId" OnRowDeleting="GridView1_RowDeleting">
                     <Columns>

                         <asp:BoundField DataField="STT" HeaderText="STT">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="question1" HeaderText="Thông tin câu hỏi thứ nhất">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="question2" HeaderText="Thông tin câu hỏi thứ 2">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="question3" HeaderText="Thông tin câu hỏi thứ ba">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <%-- <asp:TemplateField HeaderText =" Trạng Thái">
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text=' <%# Eval("StatusSend").ToString() == "False" ? "Chưa gửi câu hỏi" : "Đã gửi câu hỏi" %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>--%>

                         <asp:CommandField CausesValidation="false" HeaderText="Gửi" ShowDeleteButton="true"
                             DeleteImageUrl="../assets/img/icon/send-32.png" ButtonType="Image">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:CommandField>

                     </Columns>
                     <HeaderStyle BackColor="#2196f3" ForeColor="White" />
                     </asp:GridView>
             </div>
         </div>

         </div>


</asp:Content>
