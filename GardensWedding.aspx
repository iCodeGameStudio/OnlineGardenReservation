<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="GardensWedding.aspx.cs" Inherits="GardensWedding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta property="og:title" content="باغبون ، رزرواسیون باغ" />
    <meta property="og:description" content="رزرو آنلاین باغ ها و سفره خانه ها ، باغبون در نظر دارد بهترین خدمات باغ ها را به شما ارائه دهد." />
    <meta property="og:type" content="website" />
    <meta property="og:locale" content="fa_IR" />
    <meta property="og:url" content="http://baghebon.com/" />
    <meta property="og:image" content="http://baghebon.com/Images/Oglogo.jpg" />
    <meta property="og:image:width" content="700" />
    <meta property="og:image:height" content="439" />
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
                            <input type="text" id="pdpLatoja" class="theme-textbox" data-jdate="1450/11/15" data-gdate="2300/2/4" autocomplete="off" readonly="readonly">                           
                        </li>
                        <li>
                            <asp:Button ID="Button1" runat="server" Text="اعمال فیلتر" Width="100%" OnClientClick="myfunc()" OnClick="Button1_Click" />
                        </li>
                    </ul>
                    <script>
                        function myfunc() {
                            document.getElementById('<%= Textbox1.ClientID %>').value = document.getElementById('pdpSelectedBefore').value;
                        }
                        function myfunc2() {
                            document.getElementById('pdpSelectedBefore').value = document.getElementById('<%= Textbox1.ClientID %>').value;
                            window.clearTimeout(myfunc2, 1);
                        }
                        window.setTimeout(myfunc2, 1);


                    </script>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:TextBox ID="Textbox1" runat="server" Style="display: none"></asp:TextBox>
        <div id="myhomebox2">
            <div id="home-box2">
                <div class="home-title">
                    <h2>باغ های مجالس</h2>
                </div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <ul class="products">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
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
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
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
    </div>
</asp:Content>

