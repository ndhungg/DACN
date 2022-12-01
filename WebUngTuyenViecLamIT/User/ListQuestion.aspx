<%@ Page Title="" Language="C#" MasterPageFile="~/User/ViewUser/UserApplied.Master" AutoEventWireup="true" CodeBehind="ListQuestion.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.ListQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
         <div class="container pt-4 pb-4">

           <%-- <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>--%>

             <div class="btn-toolbar justify-content-between mb-3">
                 <div class="btn-group">
                       <asp:Label ID="lblMsg" runat="server"></asp:Label>
                 </div>
             </div>
           

            <h3 class="text-center">Danh sách chi tiết câu hỏi công ty <%Response.Write(Session["companyname"]); %></h3>
         </div>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table tab-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmtyDataText="No record display ...!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" 
                     OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="SendQuestionId" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
                     <Columns>

                         <asp:BoundField DataField="STT" HeaderText="STT">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="question1" HeaderText="Câu hỏi thứ nhất">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="question2" HeaderText="Câu hỏi thứ 2">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="question3" HeaderText="Câu hỏi thứ ba">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:TemplateField HeaderText="Phản hồi câu hỏi">
                             <ItemTemplate>
                                 <asp:LinkButton ID="SendFeddBack" runat="server" CommandName="SendFeedBack" CommandArgument='<%# Eval("SendQuestionId") %>'>
                                      <asp:Image ID="Image2" runat="server" ImageUrl="../assets/img/icon/question-32.png"/>
                                 </asp:LinkButton>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>

                     </Columns>
                     <HeaderStyle BackColor="#2196f3" ForeColor="White" />
                     </asp:GridView>
             </div>
         </div>
          <div class="row mr-lg-3 ml-lg-5 mb-3 pt-4">
                <div class="col-md-2 col-md-offset-2 mb-3">
                    <asp:Button ID="btnBack" runat="server" Text="Quay Lại" CssClass="btn btn-primary btn-block" OnClick="btnBack_Click"/>
                </div>
            </div>
         </div>

</asp:Content>
