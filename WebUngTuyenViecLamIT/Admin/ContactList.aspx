<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="WebUngTuyenViecLamIT.Admin.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
         <div class="container pt-4 pb-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">Danh sách ý kiến phản hồi của người dùng</h3>
         </div>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table tab-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmtyDataText="No record display ...!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" DataKeyNames="ContactId"
                    OnRowDeleting ="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         <asp:BoundField DataField="STT" HeaderText="STT">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Name" HeaderText="Tên Người Dùng">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Email" HeaderText="Email">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Subject" HeaderText="Tiêu Đề">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Message" HeaderText="Nội Dung">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:CommandField CausesValidation="false" HeaderText="Xóa" ShowDeleteButton="true"
                             DeleteImageUrl="../assets/img/icon/trashIcon-32.png" ButtonType="Image">
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
