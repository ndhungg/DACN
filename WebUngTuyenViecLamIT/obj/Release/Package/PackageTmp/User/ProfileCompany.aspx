<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ProfileCompany.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.ProfileCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container pt-5 pb-5">
        <div class="main-body ">
            <asp:DataList ID="dlProfileCompany" Width="100%" runat="server" OnItemCommand ="dlProfileCompany_ItemCommand" >
                <ItemTemplate>
                    <div class="row gutters-sm">
                        <div class="col-md-4 mb-3">
                            <div class="card">
                                <div class="card-body">
                                    <div class="d-flex flex-column align-items-center text-center">
                                        <%--<img src="http://bootdey.com/img/Content/avatar/avatar7.png" alt="UserPic" class="rounded-circle"
                                            width="150" />--%>
                                         <div class="company-img">
                                            <img width="150"  src="<%# GetImageUrl( Eval("CompanyImage")) %>" alt="">
                                            &nbsp;&nbsp;&nbsp;
                                        </div>
                                        <div class="mt-3">
                                            <h4 class="text-capitalize"><%# Eval("CompanyName") %></h4>
                                            <p class="text-secondary mb-1"><%# Eval("UserName") %></p>
                                            <p class="text-muted font-size-sm text-capitalize">
                                                <i class="fas fa-map-marker-alt"></i><%# Eval("Country") %>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="card mb-3">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Tên Công Ty</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("CompanyName") %>
                                        </div>
                                    </div>

                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Email</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Email") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Số Điện Thoại</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Mobile") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Địa Chỉ</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("Address") %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Hình ảnh / Logo</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary text-capitalize">
                                            <%# Eval("CompanyImage") == DBNull.Value ? "Chưa tải lên" : "Đã Tải lên" %>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <asp:Button ID="btnEdit" runat="server" Text="Sửa" CssClass="button button-contactForm boxed-btn"
                                                CommandName="EditCompanyProfile" CommandArgument='<%# Eval("CompanyId") %>' />
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:Button ID="btnViewCompany" runat="server" Text="Danh sách công việc" CssClass="button button-contactForm boxed-btn"
                                                CommandName="ViewListJobCompany" CommandArgument='<%# Eval("CompanyId") %>' />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
