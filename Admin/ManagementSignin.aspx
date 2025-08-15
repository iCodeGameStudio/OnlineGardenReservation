<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Admin/ManagementSignin.aspx.cs" Inherits="Admin_ManagementSignin" %>

<html>
<head runat="server">
    <link rel="shortcut icon" type="image/x-icon" href="../Images/logoicon.png">
    <meta name="viewport" content="width=device-width, initial-scale=1,user-scalable=no">
    <title>ورود به مدیریت</title>

    <script type="text/javascript" lang="javascript" src="../JS/jquery-2.2.3.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="../Stylesheet/lobibox.css" />
    <script type="text/javascript" lang="javascript" src="../JS/jquery-lobibox.1.2.4.min.js"></script>
    <link href="../Login/Stylesheet/style.css" rel="stylesheet" type="text/css">
    <link href="../Stylesheet/font.css" rel="stylesheet" type="text/css">
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div id="login-button" style="display: block;">
            <img src="../Login/images/login-icon.png">
        </div>

        <div id="container" style="display: none; transform: matrix(0, 0, 0, 0, 0, 0); left: 0px;">
            <h1>ورود به مدیریت</h1>
            <span class="close-btn">
                <img src="../Login/images/close.png">
            </span>
            <asp:TextBox ID="txtemail" runat="server" placeholder="آدرس ایمیل"></asp:TextBox>
            <asp:TextBox ID="txtpass" runat="server" placeholder="گذرواژه" TextMode="Password"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnsign" runat="server" Text="ورود" OnClick="btnlogin_Click"/>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="remember-container">
                <input type="checkbox" id="checkbox-2-1" class="checkbox" checked="checked">
                <span id="remember">من را بخاطر بسپار</span>
                <span id="forgotten">گذرواژه ام را فراموش کرده ام</span>
            </div>

        </div>

        <!-- Forgotten Password Container -->
        <div id="forgotten-container">
            <h1>بازیابی گذرواژه</h1>
            <span class="close-btn">
                <img src="../Login/images/close.png">
            </span>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtemailrecovery" runat="server" placeholder="آدرس ایمیل" ></asp:TextBox>

                    <asp:Button ID="btnrecovery" runat="server" Text="بازیابی" OnClick="btnrecovery_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <div class="progress-loading"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
            <ProgressTemplate>
                <div class="progress-loading"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <script src="../Login/JS/stopExecutionOnTimeout.js"></script>
        <script src="../Login/JS/TweenMax.min.js"></script>
        <script src="../Login/JS/jquery.min.js"></script>
        <script src="../Login/JS/JavaScript.js"></script>


<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtemail" ValidationGroup="g1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtpass" ValidationGroup="g1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtemailrecovery" ValidationGroup="g1"></asp:RequiredFieldValidator>
        <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>--%>

    </form>
</body>
</html>



