<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="Signin" %>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no">
    <meta charset="UTF-8">
    <link rel="shortcut icon" type="image/x-icon" href="Images/logoicon.png">
    <title>ورود به حساب کاربری</title>
    <meta property="og:title" content="باغبون ، رزرواسیون باغ" />
    <meta property="og:description" content="رزرو آنلاین باغ ها و سفره خانه ها ، باغبون در نظر دارد بهترین خدمات باغ ها را به شما ارائه دهد." />
    <meta property="og:type" content="website" />
    <meta property="og:locale" content="fa_IR" />
    <meta property="og:url" content="http://baghebon.com/" />
    <meta property="og:image" content="http://baghebon.com/Images/Oglogo.jpg" />
    <meta property="og:image:width" content="700" />
    <meta property="og:image:height" content="439" />
    <script type="text/javascript" lang="javascript" src="JS/jquery-2.2.3.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="Stylesheet/lobibox.css" />
    <script type="text/javascript" lang="javascript" src="JS/jquery-lobibox.1.2.4.min.js"></script>
    <link href="Login/Stylesheet/style.css" rel="stylesheet" type="text/css">
    <link href="Stylesheet/font.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
<%--        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="login-button" style="display: block;">
            <img src="Login/images/login-icon.png">
        </div>

        <div id="container" style="display: none; transform: matrix(0, 0, 0, 0, 0, 0); left: 0px;">
            <h1>ورود به حساب کاربری</h1>
            <span class="close-btn">
                <img src="Login/images/close.png">
            </span>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtmobile" runat="server" placeholder="تلفن همراه" ValidationGroup="vgsignup" MaxLength="11"></asp:TextBox>
                    <asp:TextBox ID="txtpass" runat="server" placeholder="گذرواژه" TextMode="Password" ValidationGroup="vgsignup"></asp:TextBox>
                    <asp:Button ID="btnsign" runat="server" Text="ورود" OnClick="btnsign_Click" ValidationGroup="vgsignup" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<div id="remember-container">
                <input type="checkbox" id="checkbox-2-1" class="checkbox" checked="checked">
                <span id="remember">من را بخاطر بسپار</span>
                <span id="forgotten">گذرواژه ام را فراموش کرده ام</span>
                
            </div>--%>
            <div id="divsignup">
                <a class="signup" href="Register">هنوز ثبت نام نکرده ام</a>
            </div>
        </div>

       <%-- <!-- Forgotten Password Container -->
        <div id="forgotten-container">
            <h1>بازیابی گذرواژه</h1>
            <span class="close-btn">
                <img src="../Login/images/close.png">
            </span>

            <asp:TextBox ID="txtemailrecovery" runat="server" placeholder="آدرس ایمیل" ValidationGroup="vgsignup2"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnrecovery" runat="server" Text="بازیابی" ValidationGroup="vgsignup2" OnClick="btnrecovery_Click"/>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>--%>
        <%-- <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
            <ProgressTemplate>
                <div class="progress-loading"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>

        <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <div class="progress-loading"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

            <script type="text/javascript" src="Login/JS/stopExecutionOnTimeout.js"></script>
    <script type="text/javascript" src="Login/JS/TweenMax.min.js"></script>
    <script type="text/javascript" src="Login/JS/jquery.min.js"></script>
    <script type="text/javascript" src="Login/JS/JavaScript.js"></script>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtmobile" ValidationGroup="vgsignup"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtpass" ValidationGroup="vgsignup"></asp:RequiredFieldValidator>
<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtemailrecovery" ValidationGroup="vgsignup2"></asp:RequiredFieldValidator>--%>
        <script type="text/javascript" lang="javascript" src="JS/jquery-validation.1.0.0.min.js"></script>

    </form>
</body>
</html>



