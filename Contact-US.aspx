<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Contact-US.aspx.cs" Inherits="Contact_US" %>

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
    <div class="page-title">
        <h3 id="htitle">تماس با مدیریت</h3>
    </div>
    <div id="page">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="register-right" style="height: 550px;">
                    <div class="register-title">
                        <h3>تماس با ما</h3>
                    </div>
                    <table class="register" style="width: 100%;">
                        <tbody>
                            <tr>
                                <td class="th">نام<span class="validation" style="visibility: hidden;">*</span>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtname" runat="server" MaxLength="50" ValidationGroup="g1" Width="100%"></asp:TextBox>
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
                                <td class="th">آدرس ایمیل<span class="validation" style="visibility: hidden;">*</span></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtemail" runat="server" MaxLength="150" ValidationGroup="g1" Width="100%"></asp:TextBox>
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
                                <td class="th">موضوع پیام<span class="validation" style="visibility: hidden;">*</span></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtsubject" runat="server" MaxLength="100" ValidationGroup="g1" Width="100%"></asp:TextBox>
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
                                <td>
                                    <div class="details-box">
                                        <p>
                                        </p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="th">پیام شما<span class="validation" style="visibility: hidden;">*</span></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" Height="100" ValidationGroup="g1" Width="100%"></asp:TextBox>
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
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="ارسال پیام" ValidationGroup="g1" Width="100%" OnClick="Button1_Click" />
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

                            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="register-left" style="height: 550px;">
            <div class="register-title">
                <h3>توضیحات</h3>
            </div>
            <p>- آدرس ایمیل خود را به صورت صحیح وارد کنید.</p>
            <br />
            <p>- نام خود را می توانید به فارسی یا انگلیسی تایپ کنید.</p>
            <br />
            <p>- جواب پیام ارسالی شما به آدرس ایمیل شما ارسال خواهد شد.</p>
        </div>

    </div>

    <div class="clear-both"></div>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtname" ValidationGroup="g1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtemail" ValidationGroup="g1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtmessage" ValidationGroup="g1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtsubject" ValidationGroup="g1"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="txtemail" ValidationGroup="g1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <script type="text/javascript" lang="javascript" src="JS/jquery-validation.1.0.0.min.js"></script>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

