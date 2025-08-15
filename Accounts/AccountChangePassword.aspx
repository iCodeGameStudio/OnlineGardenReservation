<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="AccountChangePassword.aspx.cs" Inherits="Accounts_AccountChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-danger">
                        <div class="box-header">
                            <h3 class="box-title">تغییر گذرواژه</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>گذرواژه فعلی</label>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-unlock"></i>
                                    </div>
                                    <asp:TextBox ID="txtoldpass" runat="server" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>گذرواژه جدید</label>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-lock"></i>
                                    </div>
                                    <asp:TextBox ID="txtnewpass" runat="server" TextMode="Password" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>تأیید گذرواژه</label>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-lock"></i>
                                    </div>
                                    <asp:TextBox ID="txtconfpass" runat="server" TextMode="Password" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnchangepass" runat="server" Text="تغییر گذرواژه" Width="100%" OnClick="btnchangepass_Click" ValidationGroup="G1"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3 class="box-title">توافق نامه</h3>
                        </div>
                        <div class="box-body">

                            <div class="form-group">
                                <h5>- پس از تغییر گذرواژه باید مجددا به حساب کاربری خود وارد شوید.</h5>
                                <br>
                                <h5>- گذرواژه شما می تواند از حروف و یا اعداد انگلیسی تشکیل شده باشد.</h5>
                                <br>
                                <h5>- تعداد حروف گذرواژه شما باید بین 4 تا 20 حرف باشد.</h5>
                                <br>
                                <h5>- پس از تغییر گذرواژه یک ایمیل حاوی گذرواژه جدید برای شما ارسال خواهد شد.</h5>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtoldpass" ValidationGroup="G1"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtnewpass" ValidationGroup="G1"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtconfpass" ValidationGroup="G1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="txtnewpass" ValidationGroup="G1" ValidationExpression="\w{4,20}"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtconfpass" ValidationGroup="G1" ValidationExpression="\w{4,20}"></asp:RegularExpressionValidator>
            <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

