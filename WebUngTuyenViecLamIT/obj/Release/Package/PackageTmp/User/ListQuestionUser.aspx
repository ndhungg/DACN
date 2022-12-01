<%@ Page Title="" Language="C#" MasterPageFile="~/User/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="ListQuestionUser.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.ListQuestionUser" %>
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
           

            <h3 class="text-center">Danh sách chi tiết câu hỏi </h3>
         </div>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table tab-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmtyDataText="No record display ...!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnRowDataBound="GridView1_RowDataBound"
                     OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="QuestionId" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
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

                         <asp:CommandField CausesValidation="false" HeaderText="Xóa" ShowDeleteButton="true"
                             DeleteImageUrl="../assets/img/icon/trashIcon-32.png" ButtonType="Image">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:CommandField>

                         <asp:TemplateField HeaderText="Cập Nhật">
                             <ItemTemplate>
                                 <asp:LinkButton ID="EditQusetion" runat="server" CommandName="EditQusetion" CommandArgument='<%# Eval("QuestionId") %>'>
                                      <asp:Image ID="Image1" runat="server" ImageUrl="../assets/img/icon/update-32.png"/>
                                 </asp:LinkButton>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>

                     </Columns>
                     <HeaderStyle BackColor="#2196f3" ForeColor="White" />
                     </asp:GridView>
             </div>
         </div>

         </div>

</asp:Content>
