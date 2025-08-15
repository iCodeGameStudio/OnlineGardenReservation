<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Admin_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="page-title">
        <h3 id="htitle">بازگردانی گذرواژه</h3>
    </div>

    <div id="page">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="register-right" style="height:400px;">
                    <div class="register-title">
                        <h3>تغییر گذرواژه</h3>
                    </div>
                    <table class="register" style="width: 100%;">
                        <tbody>                           
                            <tr>
                                <td class="th">گذرواژه جدید<span class="validation" style="visibility: hidden;">*</span>
                                    <span class="validation" style="visibility: hidden;">*</span>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtnewpassword" runat="server" MaxLength="20" ValidationGroup="G1" Width="100%"></asp:TextBox>
                            </tr>
                            <tr>
                                <td>
                                    <div class="details-box">
                                        <p></p>
                                    </div>

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
                                <td class="th">تأیید گذرواژه</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtconfirmpassword" runat="server" MaxLength="20" ValidationGroup="G1" Width="100%"></asp:TextBox>
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
                                    <asp:Button ID="Button1" runat="server" Text="تغییر گذرواژه" ValidationGroup="G1" Width="100%" OnClick="Button1_Click" />
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
        <div id="register-left" style="height:400px;">
            <div class="register-title">
                <h3>حفظ حریم کاربری</h3>
            </div>
            <div>
                <div class="form-group">
                    <p style="text-align:justify;">- گذرواژه شما می تواند از حروف و یا اعداد انگلیسی تشکیل شده باشد.</p>
                    <br>
                    <br>
                    <p style="text-align:justify;">- تعداد حروف گذرواژه شما باید بین 4 تا 20 حرف باشد.</p>
                    <br />
                    <br />
                </div>
            </div>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
     <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <div class="progress-loading"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    <div class="clear-both"></div>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtnewpassword" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtconfirmpassword" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="txtnewpassword" ValidationGroup="G1" ValidationExpression="\w{4,20}"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtconfirmpassword" ValidationGroup="G1" ValidationExpression="\w{4,20}"></asp:RegularExpressionValidator>
    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>


