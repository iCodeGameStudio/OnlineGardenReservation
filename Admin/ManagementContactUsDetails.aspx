<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementContactUsDetails.aspx.cs" Inherits="Admin_ManagementContactUsDetails" %>

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
                            <h3 class="box-title">پیام ارسال شده برای شما</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>نام</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtname" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>آدرس ایمیل</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtemail" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>موضوع پیام</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtsubject" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>پیام</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>زمان</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtdatetime" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3 class="box-title">پیام شما</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>متن پیام</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtyourmessage" runat="server" TextMode="MultiLine" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnsendmessage" runat="server" Text="ارسال پیام" Width="100%" ValidationGroup="G1" OnClick="btnsendmessage_Click" />
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
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtyourmessage" ValidationGroup="G1" Display="None"></asp:RequiredFieldValidator>

    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>

