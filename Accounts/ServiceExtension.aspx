<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServiceExtension.aspx.cs" Inherits="Accounts_ServiceExtension" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <!-- /.box-header -->
                        <div class="box-body">

                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ سرویسی ثبت نشده است">
                                            <Columns>
                                                <asp:TemplateField HeaderText="مدت سرویس">
                                                    <ItemTemplate><%# ToFarsi(Eval("period").ToString()) + " ماهه" %></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="مبلغ سرویس">
                                                    <ItemTemplate><%# ToFarsi(String.Format("{0:#,##0}", Eval("cost"))) + " تومان" %></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="انتخاب" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <a href="<%# "ServicesShoppingCard?id=" + Eval("id") %>">
                                                                <img src="../Images/icon-enter.png" width="30" height="30" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
                <!-- /.box -->
            </div>
            <!-- /.col -->
            </div>
            <!-- /.row -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>

