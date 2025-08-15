<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta property="og:title" content="باغبون ، رزرواسیون باغ" />
    <meta property="og:description" content="رزرو آنلاین باغ ها و سفره خانه ها ، باغبون در نظر دارد بهترین خدمات باغ ها را به شما ارائه دهد." />
    <meta property="og:type" content="website" />
    <meta property="og:locale" content="fa_IR" />
    <meta property="og:url" content="http://baghebon.com/" />
    <meta property="og:image" content="http://baghebon.com/Images/Oglogo.jpg" />
    <meta property="og:image:width" content="700" />
    <meta property="og:image:height" content="439" />
    <script src="Stylesheet/flickity.pkgd.js"></script>
    <link href="Stylesheet/flickity.css" rel="stylesheet" />
    <link href='Date/normalize.css' rel='stylesheet' />
    <link href='Date/fontawesome/css/font-awesome.min.css' rel='stylesheet' />
    <link href="Date/vertical-responsive-menu.min.css" rel="stylesheet" />
    <link href="Date/prism.css" rel="stylesheet" />
    <link rel="stylesheet" href="Date/persianDatepicker-default.css" />
    <link rel="stylesheet" href="Date/persianDatepicker-dark.css" />
    <link rel="stylesheet" href="Date/persianDatepicker-latoja.css" />
    <link rel="stylesheet" href="Date/persianDatepicker-melon.css" />
    <link rel="stylesheet" href="Date/persianDatepicker-lightorang.css" />
    <script src="Date/prism.js"></script>
    <script src="Date/vertical-responsive-menu.min.js"></script>
    <script src="Date/persianDatepicker.js"></script>
    <script>
        $(function () {
            //usage
            $(".usage").persianDatepicker();

            //themes
            $("#pdpDefault").persianDatepicker({ alwaysShow: true, });
            $("#pdpLatoja").persianDatepicker({ theme: "latoja", selectedBefore: !0, });
            $("#pdpLightorang").persianDatepicker({ theme: "lightorang", alwaysShow: true, });
            $("#pdpMelon").persianDatepicker({ theme: "melon", alwaysShow: true, });
            $("#pdpDark").persianDatepicker({ theme: "dark", alwaysShow: true, });

            //size
            $("#pdpSmall").persianDatepicker({ cellWidth: 14, cellHeight: 12, fontSize: 8 });
            $("#pdpBig").persianDatepicker({ cellWidth: 78, cellHeight: 60, fontSize: 18 });

            //formatting
            $("#pdpF1").persianDatepicker({ formatDate: "YYYY/MM/DD hh:mm:ss:ms" });
            $("#pdpF2").persianDatepicker({ formatDate: "YYYY-0M-0D" });
            $("#pdpF3").persianDatepicker({ formatDate: "YYYY-NM-DW|ND", isRTL: !0 });

            //startDate & endDate
            $("#pdpStartEnd").persianDatepicker({ startDate: "1394/11/12", endDate: "1395/5/5" });
            $("#pdpStartToday").persianDatepicker({ startDate: "today", endDate: "1395/5/5" });
            $("#pdpEndToday").persianDatepicker({ startDate: "1393/11/12", endDate: "today" });

            //selectedBefor & selectedDate
            $("#pdpSelectedDate").persianDatepicker({ selectedDate: "1395/5/5" });
            $("#pdpSelectedBefore").persianDatepicker({ selectedBefore: !0 });
            $("#pdpSelectedBoth").persianDatepicker({ selectedBefore: !0, selectedDate: "1395/5/5" });

            //jdate & gdate attributes
            $("#pdp-data-jdate").persianDatepicker({
                onSelect: function () {
                    alert($("#pdp-data-jdate").data("gdate"));
                }
            });
            $("#pdp-data-gdate").persianDatepicker({
                showGregorianDate: true,
                onSelect: function () {
                    alert($("#pdp-data-gdate").data("jdate"));
                }
            });


            //Gregorian date
            $("#pdpGregorian").persianDatepicker({ showGregorianDate: true });

            // jDateFuctions
            var jdf = new jDateFunctions();
            var pd = new persianDate();
            $("#pdpjdf-1").persianDatepicker({
                onSelect: function () {
                    $("#pdpjdf-1").val(jdf.getJulianDayFromPersian(pd.parse($("#pdpjdf-1").val())));
                    $("#pdpjdf-2").val(jdf.getLastDayOfPersianMonth(pd.parse($("#pdpjdf-1").val())));
                    $("#pdpjdf-3").val(jdf.getPCalendarDate($("#pdpjdf-1").val()));
                }
            });


            //convert jalali date to miladi
            $("#year, #month, #day").on("change", function () {
                $("#month").val() > 6 ? $("#day-31").hide() : $("#day-31").show();;
                showConverted();
            });

            $("#year").keyup(showConverted);

            function showConverted() {
                try {
                    var pd = new persianDate();
                    pd.year = parseInt($("#year").val());
                    pd.month = parseInt($("#month").val());
                    pd.date = parseInt($("#day").val());

                    var jdf = new jDateFunctions();
                    $("#converted").html("Gregorian :  " + jdf.getGDate(pd)._toString("YYYY/MM/DD") + "     [" + jdf.getGDate(pd) + "]<br />Julian:  " + jdf.getJulianDayFromPersian(pd));

                } catch (e) {
                    $("#converted").html("Enter the year correctly!");
                }
            }


            //startDate is tomarrow
            var p = new persianDate();
            $("#pdpStartDateTomarrow").persianDatepicker({ startDate: p.now().addDay(1).toString("YYYY/MM/DD"), endDate: p.now().addDay(4).toString("YYYY/MM/DD") });


        });
    </script>
    <style>
        /* external css: flickity.css */

        * {
            box-sizing: border-box;
        }

        .carousel {
            background: #EEE;
        }

        .carousel-cell {
            width: 80%;
            height: 450px;
            /*margin:0 auto;*/
            background: #8C8;
            border-radius: 5px;
            /*counter-increment: gallery-cell;*/
        }

            /* cell number */
            .carousel-cell:before {
                display: block;
                text-align: center;
                /*content: counter(gallery-cell);*/
                line-height: 200px;
                font-size: 80px;
                color: white;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content-wrapper">
        <div id="home-box">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <ul id="search">
                        <li>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="100%">
                                <asp:ListItem Selected="True" Value="">همه سرویس ها</asp:ListItem>
                                <asp:ListItem Value="صبح">صبح / صبحانه</asp:ListItem>
                                <asp:ListItem Value="ظهر">ظهر / ناهار</asp:ListItem>
                                <asp:ListItem Value="عصر">عصر / عصرانه</asp:ListItem>
                                <asp:ListItem Value="شب">شب / شام</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="100%">
                                <asp:ListItem Selected="True" Value="">همه مکان ها</asp:ListItem>
                                <asp:ListItem Value="باغ مجالس">باغ مجالس</asp:ListItem>
                                <asp:ListItem Value="باغ رستوران">باغ رستوران</asp:ListItem>
                                <asp:ListItem Value="سفره خانه">سفره خانه</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li>
<%--                            <input type="text" id="pdpLatoja" class="theme-textbox arabic" data-jdate="1450/11/15" data-gdate="2300/2/4" autocomplete="off" readonly="readonly">--%>
                           <h5 id="pdpLatoja" class="theme-textbox" data-jdate="1450/11/15" data-gdate="2300/2/4"></h5>
                        </li>
                        <li>
                            <asp:Button ID="Button1" runat="server" Text="اعمال فیلتر" Width="100%" OnClientClick="myfunc()" OnClick="Button1_Click" />
                        </li>
                    </ul>
                    <script>
                        
                        function myfunc() {
                            document.getElementById('<%= Textbox1.ClientID %>').value = document.getElementById('pdpLatoja').textContent;
                        }
                        function myfunc2() {
                            document.getElementById('pdpLatoja').textContent = document.getElementById('<%= Textbox1.ClientID %>').value;
                            window.clearTimeout(myfunc2, 1);
                        }
                        window.setTimeout(myfunc2, 1);
                    </script>
                   
                     <asp:TextBox ID="Textbox1" runat="server" Style="display: none"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
       
        <div id="myslideshow" runat="server">
            <div class="slideShow" id="slider-wrapper" style="width: 100%;">
                 <!-- Flickity HTML init -->
    <div data-flickity='{ "autoPlay": 10000 , "pageDots": false , "rightToLeft": true , "initialIndex": 2 , "selectedAttraction": 0.01 ,
"friction": 0.15 , "freeScroll": true , "wrapAround": true }'>
        <div class="carousel-cell"><img src="Images/slider-01.jpg" style="width:100%;height:100%;"/></div>
        <div class="carousel-cell"><img src="Images/slider-02.jpg" style="width:100%;height:100%;"/></div>
        <div class="carousel-cell"><img src="Images/slider-03.jpg" style="width:100%;height:100%;"/></div>
        <div class="carousel-cell"><img src="Images/slider-05.jpg" style="width:100%;height:100%;"/></div>
        <div class="carousel-cell"><img src="Images/slider-06.jpg" style="width:100%;height:100%;"/></div>
    </div>
            </div>
        </div>
        <!-- End WOWSlider.com BODY section -->
    </div>
    <div class="separator"></div>
    <div id="divseparator" class="separator"></div>
    <div id="divme" runat="server">
        <div id="home-box3">
            <ul id="category">
                <li>
                    <div class="category-box">

                        <div class="category-box-image">
                            <a href="#">
                                <div class="vip"><span>ویژه</span></div>
                                <img src="<%= ResolveUrl("~/Images/no-photo.png")%>" alt="" title=""></a>
                        </div>

                        <div class="category-box-content">
                            <h3><a href="#" title="#">مشترکین ویژه</a></h3>
                        </div>

                    </div>
                </li>
                <li>
                    <div class="category-box">
                        <div class="category-box-image">
                            <a href="#">
                                <div class="vip"><span>ویژه</span></div>
                                <img src="<%= ResolveUrl("~/Images/no-photo.png")%>" alt="" title=""></a>
                        </div>
                        <div class="category-box-content">
                            <h3><a href="#" title="#">مشترکین ویژه</a></h3>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="category-box">
                        <div class="category-box-image">
                            <a href="#">
                                <div class="vip"><span>ویژه</span></div>
                                <img src="<%= ResolveUrl("~/Images/no-photo.png")%>" alt="" title=""></a>
                        </div>
                        <div class="category-box-content">
                            <h3><a href="#" title="#">مشترکین ویژه</a></h3>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="category-box">
                        <div class="category-box-image">
                            <a href="#">
                                <div class="vip"><span>ویژه</span></div>
                                <img src="<%= ResolveUrl("~/Images/no-photo.png")%>" alt="" title="">
                            </a>
                        </div>
                        <div class="category-box-content">
                            <h3><a href="#" title="#">مشترکین ویژه</a></h3>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div id="gardens" runat="server" style="display: block">
        <div id="home-box2">
            <div class="home-title">
                <h2>باغ ها</h2>
            </div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <ul class="products">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%# "GardenDetails?id=" + Eval("garden_id").ToString() %>">
                            <div class="product-box">
                                <div class="product-box-img">
                                    <a href="<%# "GardenDetails?id=" + Eval("garden_id").ToString() %>">
                                        <img src="<%# Eval("file_name").ToString() != "" ? "Images/Uploads/Gardens/" + Eval("file_name").ToString() : "Images/Uploads/Gardens/noimage.jpg" %>" />
                                    </a>
                                </div>
                                <div class="product-box-content">
                                    <h5><a href="<%# "GardenDetails?id=" + Eval("garden_id").ToString() %>"><%# Eval("garden_name").ToString() %></a></h5>
                                    <%--<p style="height: 10px;"><%# Eval("address").ToString() %></p>--%>
                                </div>
                            </div>
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
        </div>

    </div>
    <div id="garden_filter" runat="server" style="display: none">
        <div id="home-box22">
            <div class="home-title">
                <h2>باغ ها بر اساس فیلتر</h2>
            </div>
            <asp:Repeater ID="Repeater2" runat="server">
                <HeaderTemplate>
                    <ul class="products-Filter">
                </HeaderTemplate>
                <ItemTemplate>

                    <li>
                        <a href="<%# "GardenFilterDetails?gid=" + Eval("id").ToString() + "&sid=" + Eval("sid").ToString() %>">
                            <div class="product-box-Filter">
                                <div class="product-box-Filter-img">
                                    <img src="<%# Eval("file_name").ToString() != "" ? "Images/Uploads/Gardens/" + Eval("file_name").ToString() : "Images/Uploads/Gardens/noimage.jpg" %>" />
                                </div>
                                <div class="product-box-Filter-content">
                                    <a href="<%# "GardenFilterDetails?gid=" + Eval("id").ToString() + "&sid=" + Eval("sid").ToString() %>">
                                        <h5><%# Eval("ser_type").ToString() == "صبح" ? "سرویس صبح / صبحانه" : Eval("ser_type").ToString() == "ظهر" ? "سرویس ظهر / ناهار" : Eval("ser_type").ToString() == "عصر" ? "سرویس عصر / عصرانه" : "سرویس شب / شام" %></h5>
                                    </a>
                                    <a href="<%# "GardenFilterDetails?gid=" + Eval("id").ToString() + "&sid=" + Eval("sid").ToString() %>">
                                        <p style="height: 10px;"><%# "ظرفیت: " + persianNum(Eval("capacity").ToString()) + " نفر" %></p>
                                    </a>
                                </div>
                            </div>
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="clear-both"></div>
    </div>
    
    <div id="home-box5-wrapper">
        <div id="home-box5">
            <div class="home-title">
                <h2 style="color: #fff;">ویدیوهای شما</h2>
            </div>
            <div class="owl-carousel owl-theme">
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/lLa2z/vt/frame" name="cboxmain" id="cboxmain0" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/ikrbP/vt/frame" name="cboxmain" id="cboxmain1" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/17qec/vt/frame" name="cboxmain" id="cboxmain2" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/a0EAp/vt/frame" name="cboxmain" id="cboxmain3" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/JHtre/vt/frame" name="cboxmain" id="cboxmain4" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/3uAdi/vt/frame" name="cboxmain" id="cboxmain5" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/duxYI/vt/frame" name="cboxmain" id="cboxmain6" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/uSNr4/vt/frame" name="cboxmain" id="cboxmain7" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/lLa2z/vt/frame" name="cboxmain" id="cboxmain8" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/ikrbP/vt/frame" name="cboxmain" id="cboxmain9" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/17qec/vt/frame" name="cboxmain" id="cboxmain10" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/a0EAp/vt/frame" name="cboxmain" id="cboxmain11" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
                <div class="item">
                    <div style="height: 200px; background-color: rgba(0,0,0,0.5); color: white; border: 1px solid #000000; border-radius: 2px; text-align: right">
                        <iframe style="height: 70%; width: 100%; overflow: hidden;" src="https://www.aparat.com/video/video/embed/videohash/JHtre/vt/frame" name="cboxmain" id="cboxmain12" seamless="seamless" scrolling="no" frameborder="0" allowfullscreen="true" webkitallowfullscreen="true" mozallowfullscreen="true"></iframe>
                        <h4 style="padding: 5px;">نام باغ</h4>
                        <h5 style="padding-bottom: 10px; padding-right: 5px; padding-left: 5px;">زمان ارسال</h5>
                    </div>
                </div>
            </div>
            <script>
                $(document).ready(function () {
                    $('.owl-carousel').owlCarousel({
                        autoplay: true,
                        autoplayTimeout: 6000,
                        autoplayHoverPause: true,
                        center: true,
                        loop: true,
                        video: true,
                        lazyLoad: true,
                        margin: 10,
                        responsiveClass: true,
                        responsive: {
                            0: {
                                items: 1,
                                nav: true,
                            },
                            600: {
                                items: 3,
                                nav: false
                            },
                            1000: {
                                items: 5,
                                nav: true,
                                loop: true,
                                margin: 20
                            }
                        }
                    })
                })
            </script>
        </div>
    </div>
    
</asp:Content>

