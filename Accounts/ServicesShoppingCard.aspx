<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServicesShoppingCard.aspx.cs" Inherits="Accounts_ServicesShoppingCard" %>

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
                            <h3 class="box-title">خرید سرویس</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>نوع سرویس</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtservice" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>مبلغ سرویس</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtcost" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="Button1" Width="100%" runat="server" Text="تکمیل خرید سرویس" OnClick="Button1_Click" />
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
                                <h5 style="line-height: 30px;">- تکمیل خرید به منزله ایجاد فاکتور خرید می باشد.</h5>
                                <br>
                                <h5 style="line-height: 30px;">- در انتخاب سرویس مورد نظر دقت کافی را داشته باشید.</h5>
                                <br>
                                <h5 style="line-height: 30px;">- مبلغ پرداختی به (تومان) می باشد.</h5>
                            </div>
                        </div>
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
</asp:Content>

