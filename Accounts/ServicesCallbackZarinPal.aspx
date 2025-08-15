<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServicesCallbackZarinPal.aspx.cs" Inherits="Accounts_ServicesCallbackZarinPal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <link type="text/css" rel="Stylesheet" href="<%= ResolveUrl("Stylesheet/fancybox.css") %>" />
    <script type="text/javascript" lang="javascript" src="<%= ResolveUrl("~/JS/jquery-generic.min.js") %>"></script>
    <script type="text/javascript" lang="javascript" src="<%= ResolveUrl("~/JS/jquery-fancybox.2.1.5.min.js") %>"></script>
    <script type="text/javascript" lang="javascript">$(document).ready(function () { $('.fancybox').fancybox(); });</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div runat="server" id="divmessage"></div>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <div class="row">
        <div class="col-md-6">
            <div class="box box-danger">
                <div class="box-header">
                    <h3 class="box-title">جزئیات تراکنش</h3>
                </div>
                <div class="box-body">
                    <div class="form-group">
                        <label>شماره فاکتور</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-file-invoice-dollar"></i>
                            </div>
                            <asp:TextBox ID="txtfactnumber" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>مبلغ (تومان)</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-dollar-sign"></i>
                            </div>
                            <asp:TextBox ID="txtcost" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label>نوع سرویس</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar-check"></i>
                            </div>
                            <asp:TextBox ID="txtservice" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label>زمان تراکنش</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar-alt"></i>
                            </div>
                            <asp:TextBox ID="txtdatetime" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label>کد رهگیری</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-chalkboard"></i>
                            </div>
                            <asp:TextBox ID="txtref" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label>وضعیت تراکنش</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-money-bill-alt"></i>
                            </div>
                            <asp:TextBox ID="txtstatus" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label>آدرس آی پی شما</label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-server"></i>
                            </div>
                            <asp:TextBox ID="txtipaddress" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </asp:PlaceHolder>
</asp:Content>

