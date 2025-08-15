<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta property="og:title" content="باغبون ، رزرواسیون باغ" />
    <meta property="og:description" content="رزرو آنلاین باغ ها و سفره خانه ها ، باغبون در نظر دارد بهترین خدمات باغ ها را به شما ارائه دهد." />
    <meta property="og:type" content="website" />
    <meta property="og:locale" content="fa_IR" />
    <meta property="og:url" content="http://baghebon.com/" />
    <meta property="og:image" content="http://baghebon.com/Images/Oglogo.jpg" />
    <meta property="og:image:width" content="700" />
    <meta property="og:image:height" content="439" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="content-wrapper">
                <div id="page-banner"></div>
                <div class="page-title">
                    <h3 id="htitle">عضویت</h3>
                </div>
                <div id="page">
                    <div>
                        <div id="register-right" style="height: 550px;">
                            <div class="register-title">
                                <h3>عضویت در سایت</h3>
                            </div>
                            <table class="register" style="width: 100%;">
                                <tbody>
                                    <tr>
                                        <td class="th">نام</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtname" runat="server" MaxLength="50" Width="100%" ValidationGroup="G1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="details-box">
                                                <p>
                                                </p>
                                            </div>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td class="th">تلفن همراه</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtmobile" runat="server" MaxLength="11" Width="100%" ValidationGroup="G1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="details-box">
                                                <p></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="th">گذرواژه</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtpassword" runat="server" MaxLength="20" Width="100%" ValidationGroup="G1" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="details-box">
                                                <p>
                                                </p>

                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="th">تأیید گذرواژه</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtconfpassword" runat="server" MaxLength="20" Width="100%" ValidationGroup="G1" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="details-box">
                                                <br />
                                                <br />
                                            </div>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="ثبت نام" Width="100%" OnClick="Button1_Click" ValidationGroup="G1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="details-box">
                                                <p></p>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div id="register-left" style="height: 550px;">
                        <div class="register-title">
                            <h3>حفظ حریم کاربری</h3>
                        </div>
                        <div id="ContentPlaceHolder1_divprivacy">
                        </div>
                    </div>
                    <div id="ContentPlaceHolder1_ValidationSummary1" style="display: none;"></div>
                </div>
            </div>
            <div class="clear-both"></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ValidationGroup="G1" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmobile" ValidationGroup="G1" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpassword" ValidationGroup="G1" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtconfpassword" ValidationGroup="G1" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="09\d{9}" ControlToValidate="txtmobile" ValidationGroup="G1" Display="None"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtpassword" ValidationGroup="G1" ValidationExpression="\w{6,20}"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="None" ControlToValidate="txtconfpassword" ValidationGroup="G1" ValidationExpression="\w{6,20}"></asp:RegularExpressionValidator>
    <script type="text/javascript" lang="javascript" src="JS/jquery-validation.1.0.0.min.js"></script>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


