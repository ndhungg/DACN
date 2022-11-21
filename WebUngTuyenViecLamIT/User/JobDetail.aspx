<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="JobDetail.aspx.cs" Inherits="WebUngTuyenViecLamIT.User.JobDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

        <!-- Hero Area Start-->
        <div class="slider-area ">
            <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="../assets/img/hero/about.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="hero-cap text-center">
                                        <h2><%#jobTitle %></h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Hero Area End -->
        <div>
            <asp:Label ID="LblMsg" runat="server" Visible="false"></asp:Label>
        </div>

        <!-- job post company Start -->
        <div class="job-post-company pt-120 pb-120">
            <div class="container">
                <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <div class="row justify-content-between">
                            <!-- Left Content -->
                            <div class="col-xl-7 col-lg-8">
                                <!-- job single -->
                                <div class="single-job-items mb-50">
                                    <div class="job-items">
                                        <div class="company-img">
                                            <img width="80" src="<%# GetImageUrl( Eval("CompanyImage")) %>" alt="">
                                            &nbsp;&nbsp;&nbsp;
                                        </div>
                                        <div class="job-tittle job-tittle2">
                                            <h4><%# Eval("Title") %></h4>
                                            <ul>
                                                <li><%# Eval("CompanyName") %></li>
                                                <li><i class="fas fa-map-marker-alt"></i><%# Eval("City") %> , <%# Eval("Country") %></li>
                                                <li><%# Eval("Salary") %></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            <!-- job single End -->

                            <div class="job-post-details">
                                <div class="post-details1 mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Mô tả công việc</h4>
                                    </div>
                                    <p><%# Eval("Description") %></p>
                                </div>
                                <div class="post-details2  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Kiến thức và Kỹ năng cần có</h4>
                                    </div>
                                    <ul>
                                        <li><%# Eval("Specialization") %></li>
                                    </ul>
                                </div>
                                <div class="post-details2  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Trường học và Kinh nghiệm</h4>
                                    </div>
                                    <ul>
                                        <li><%# Eval("Qualification") %></li>
                                        <li><%# Eval("Experience") %></li>
                                    </ul>
                                </div>
                            </div>

                        </div>
                        <!-- Right Content -->
                        <div class="col-xl-4 col-lg-4">
                            <div class="post-details3  mb-50">
                                <!-- Small Section Tittle -->
                                <div class="small-section-tittle">
                                    <h4>Tổng Quan Về Công Việc</h4>
                                </div>
                                <ul>
                                    <li>Ngày đăng bài: <span><%# DataBinder.Eval(Container.DataItem, "CreateDate", "{0:dd-MM-yyyy}") %></span></li>
                                    <li>Thành phố: <span><%# Eval("City") %></span></li>
                                    <li>Số lượng ứng viên: <span><%# Eval("NoNumBerPost") %></span></li>
                                    <li>Loại công việc: <span><%# Eval("JobType") %></span></li>
                                    <li>Mức lương:  <span><%# Eval("Salary") %></span></li>
                                    <li>Ngày ứng tuyển: <span><%# DataBinder.Eval(Container.DataItem, "LastDateToApply", "{0:dd-MM-yyyy}") %></span></li>
                                </ul>
                                <div class="apply-btn2">
                                  <%--  <a href="#" class="btn">Ứng Tuyển Ngay</a>--%>
                                    <asp:LinkButton ID="labAppliedJobs" runat="server" CssClass="btn" Text="Ứng Tuyển Ngay" CommandName="Ứng Tuyển Ngay"></asp:LinkButton>
                                </div>
                            </div>
                            <div class="post-details4 mb-50">
                                <!-- Small Section Tittle -->
                                <div class="small-section-tittle">
                                    <h4>Thông Tin Về Công Ty</h4>
                                </div>
                                <span></span>
                                <p></p>
                                <ul>
                                    <li>Tên Công Ty:<span><%# Eval("CompanyName") %></span></li>
                                     <li>Địa Chỉ:<span><%# Eval("Address") %></span></li>
                                    <li>WebSite:<span><%# Eval("Website") %></span></li>
                                    <li>Email:<span><%# Eval("Email") %></span></li>
                                </ul>
                            </div>
                        </div>
                        </div>

                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <!-- job post company End -->

    </main>
</asp:Content>
