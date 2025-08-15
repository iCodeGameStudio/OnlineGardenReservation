<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="GardenFilterDetails.aspx.cs" Inherits="GardenFilterDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <meta property="og:title" content="باغبون ، رزرواسیون باغ" />
    <meta property="og:description" content="رزرو آنلاین باغ ها و سفره خانه ها ، باغبون در نظر دارد بهترین خدمات باغ ها را به شما ارائه دهد." />
    <meta property="og:type" content="website" />
    <meta property="og:locale" content="fa_IR" />
    <meta property="og:url" content="http://baghebon.com/" />
    <meta property="og:image" content="http://baghebon.com/Images/Oglogo.jpg" />
    <meta property="og:image:width" content="700" />
    <meta property="og:image:height" content="439" />
    <script src="Stylesheet/sliderengine/amazingslider.js"></script>
    <link rel="Stylesheet/stylesheet" type="text/css" href="sliderengine/amazingslider-1.css">
    <script src="Stylesheet/sliderengine/initslider-1.js"></script>
    <script src="JS/persianNum.jquery-2.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="page">
        <div class="page-title">
            <h3 id="htitle">جزئیات</h3>
        </div>
        <div id="product-box1Filter">
            <div id="product-box1Filter-right">
                <div class="register-title">
                    <h3>مشخصات مکان مورد نظر</h3>
                </div>
                <ul id="important-info">
                    <li><b>نام مکان : <span id="spanname" runat="server">--------------</span></b></li>
                    <li class="arabic"><b>ظرفیت : <span id="spancapacity" runat="server">--------------</span></b></li>
                    <li><b>دسته بندی : <span id="spantype" runat="server">--------------</span></b></li>
                    <li class="arabic"><b>شماره تماس : <span id="spantel" runat="server">--------------</span></b></li>
                    <li><b>امکانات : </b>
                        <asp:TextBox ID="txtpossibilities" runat="server" TextMode="MultiLine" ReadOnly="true" Height="60" Width="100%"></asp:TextBox></li>
                    <li><b>آدرس : </b>
                        <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" ReadOnly="true" Height="60" Width="100%"></asp:TextBox></li>

                </ul>
                <div class="register-title">
                    <h3>مشخصات سرویس قابل ارائه</h3>
                </div>
                <ul id="important-info">
                    <li><b>نوع سرویس : <span id="txtser_type" runat="server">--------------</span></b></li>
                    <li class="arabic"><b>ظرفیت سرویس : <span id="txtcapacity" runat="server">--------------</span></b></li>
                    <li><b>سرویس پذیرایی : <span id="txtser_eating" runat="server">--------------</span></b></li>
                    <li><b>سایر سرویس ها : <span id="txtotherser" runat="server">--------------</span></b></li>
                    <li class="arabic"><b>تاریخ ارائه سرویس : <span id="txtdate" runat="server">--------------</span></b>
                    <li>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnReserve" runat="server" Text="رزرو کن" Width="100%" OnClick="btnReserve_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </li>
                </ul>
            </div>
            <div id="product-box1Filter-left">

                <div id="amazingslider-wrapper-1" style="display: block; position: relative; max-width: 390px; padding-left: 0px; padding-right: 150px; margin: 0px auto 0px;">
                    <div id="amazingslider-1" style="display: block; position: relative; margin: 0 auto;">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                <ul class="amazingslider-slides" style="display: none;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <a href="<%# "Images/Uploads/Gardens/" + Eval("file_name").ToString() %>" class="html5lightbox" data-width="960" data-height="720">
                                        <img src="<%# "Images/Uploads/Gardens/" + Eval("file_name").ToString() %>" />
                                    </a>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate></ul></FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <HeaderTemplate>
                                <ul class="amazingslider-thumbnails" style="display: none;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <img src="<%# "Images/Uploads/Gardens/" + Eval("file_name").ToString() %>" />
                                </li>
                            </ItemTemplate>
                            <FooterTemplate></ul></FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script>
        $(document).ready(function () {
            $('body').persianNum();
        })
    </script>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <div class="progress-loading"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
</asp:Content>

