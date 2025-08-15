<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="~/Admin/ManagementUsersAdd.aspx.cs" Inherits="Admin_ManagementChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-danger">
                        <div class="box-header">
                            <h3 class="box-title">فرم ثبت مدیر</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>نام</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtname" runat="server" ValidationGroup="G1" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>نام خانوادگی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtfamily" runat="server" ValidationGroup="G1" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>کد ملی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-user"></i>
                                    </div>
                                    <asp:TextBox ID="txtmelicode" runat="server" ValidationGroup="G1" MaxLength="10"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>تلفن همراه</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-phone"></i>
                                    </div>
                                    <asp:TextBox ID="txtmobile" runat="server" ValidationGroup="G1" MaxLength="11"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>آدرس ایمیل</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-envelope-o"></i>
                                    </div>
                                    <asp:TextBox ID="txtmail" runat="server" ValidationGroup="G1" MaxLength="150"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سطح دسترسی</label>
                                <div class="input-group">

                                    <asp:RadioButton ID="rd1" runat="server" Text="مدیر عالی" GroupName="rd" />
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:RadioButton ID="rd2" runat="server" Text="مدیر میانی" GroupName="rd" Checked="true" />
                                </div>
                            </div>

                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnchangepass" runat="server" Text="ثبت مدیر" Width="100%" ValidationGroup="G1" OnClick="btnchangepass_Click" />
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
                            <div class="form-group" style="text-align: justify;">
                                <h5 style="line-height: 30px;">- نام و نام خانوادگی را به صورت صحیح و فارسی وارد نمایید.</h5>
                                <br>
                                <h5 style="line-height: 30px;">- آدرس ایمیل واقعی را وارد نمایید، در صورت فراموشی گذرواژه می توان از طریق ایمیل ، حساب کاربری را بازگرداند.</h5>
                                <br>
                                <h5 style="line-height: 30px;">- پس از تعریف مدیر جدید ، نام کاربری همان ایمیل و گذرواژه همان کد ملی می باشد.</h5>
                                <br>
                                <h5 style="line-height: 30px;">- پس از ثبت نام ، توصیه می شود نسبت به تغییر گذرواژه اقدام کنند.</h5>
                            </div>

                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                
            </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtname" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txtfamily" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtmelicode" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtmail" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="txtmobile" ValidationGroup="G1"></asp:RequiredFieldValidator>
    
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ControlToValidate="txtmobile" ValidationGroup="G1" ValidationExpression="09\d{9}"></asp:RegularExpressionValidator>
    <%--برای شماره موبایل--%>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="None" ControlToValidate="txtmail" ValidationGroup="G1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <%--برای ایمیل--%>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtmelicode" ValidationExpression="\d+" ValidationGroup="G1" Display="Static" EnableClientScript="true" runat="server" />
    <%--برای اعداد--%>

    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>

