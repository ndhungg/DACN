<%@ Page Title="" Language="C#" MasterPageFile="~/User/Company/CompanyMaster.Master" AutoEventWireup="true" CodeBehind="ViewUserAppliedJobs.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.ViewUserAppliedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
         <div class="container pt-4 pb-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">Danh sách Chi Tiết Thông Tin Ứng Viên </h3>
         </div>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table tab-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmtyDataText="No record display ...!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                     OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppliedJobsId" OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound ="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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

                         <asp:BoundField DataField="Name" HeaderText="Tên Ứng Viên">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Email" HeaderText="Email">
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Mobile" HeaderText="Số Điện Thoại">
                         <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                           <asp:TemplateField HeaderText="Hồ Sơ">
                             <ItemTemplate>
                                 <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container,"DataItem.Resume","../{0}") %>'>
                                     <i class="fas fa-download"></i>  Download</asp:HyperLink>
                                 <asp:HiddenField ID="hdnJobId" runat="server" Value='<%# Eval("JobId") %>' Visible="false" />
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>

                        <%-- <asp:TemplateField HeaderText =" Trạng Thái">
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text=' <%# Eval("Status").ToString() == "False" ? "Chưa gửi câu hỏi" : "Đã gửi câu hỏi" %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>--%>

                           <asp:TemplateField HeaderText="Gửi câu hỏi">
                             <ItemTemplate>
                                 <asp:LinkButton ID="btSendQuestion" runat="server" CommandName="SendQuestion" CommandArgument='<%# Eval("AppliedJobsId") %>'>
                                      <asp:Image ID="Image1" runat="server" ImageUrl="../assets/img/icon/send-32.png"/>
                                 </asp:LinkButton>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>

                           <asp:TemplateField HeaderText="Câu trả lời">
                             <ItemTemplate>
                                 <asp:LinkButton ID="btListFeedBackUser" runat="server" CommandName="ListFeedBackUser" CommandArgument='<%# Eval("AppliedJobsId") %>'>
                                      <asp:Image ID="Image2" runat="server" ImageUrl="../assets/img/icon/reply-32.png"/>
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
