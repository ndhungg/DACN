<%@ Page Title="" Language="C#" MasterPageFile="~/User/ViewUser/UserApplied.Master" AutoEventWireup="true" CodeBehind="UserAppliedJobs.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.UserAppliedJobs" %>
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
              <div class="input-group h-25">
                 <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/ViewResume.aspx" CssClass="btn btn-primary" Visible="false">Quay Lại</asp:HyperLink>
             </div>

             </div>
           

            <h3 class="text-center">Danh sách chi tiết công việc </h3>
         </div>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table tab-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmtyDataText="No record display ...!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnRowDataBound="GridView1_RowDataBound"
                     OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="JobId" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">
                     <Columns>

                         <asp:BoundField DataField="STT" HeaderText="STT">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                          <asp:BoundField DataField="CompanyName" HeaderText="Tên Công Ty">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Title" HeaderText="Tên Công Việc">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="JobType" HeaderText="Loại Công Việc">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="NoNumberPost" HeaderText="Số Lượng">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Experience" HeaderText="Yêu Cầu Kinh Nghiệm">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                          <asp:BoundField DataField="LastDateToApply" HeaderText="Thời Gian Ứng Tuyển" DataFormatString="{0: dd-MM-yy}">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="CreateDate" HeaderText="Ngày Đăng Bài " DataFormatString="{0: dd-MM-yy}">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:CommandField CausesValidation="false" HeaderText="Xóa" ShowDeleteButton="true"
                             DeleteImageUrl="../assets/img/icon/trashIcon-32.png" ButtonType="Image">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:CommandField>

                       <%--  <asp:TemplateField HeaderText="Cập Nhật">
                             <ItemTemplate>
                                 <asp:LinkButton ID="btnEditJob" runat="server" CommandName="EditJob" CommandArgument='<%# Eval("JobId") %>'>
                                      <asp:Image ID="Image1" runat="server" ImageUrl="../assets/img/icon/update-32.png"/>
                                 </asp:LinkButton>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>--%>

                     </Columns>
                     <HeaderStyle BackColor="#2196f3" ForeColor="White" />
                     </asp:GridView>
             </div>
         </div>

         </div>
</asp:Content>
