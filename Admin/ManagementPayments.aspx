<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementPayments.aspx.cs" Inherits="Admin_ManagementPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ تراکنشی وجود ندارد">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="نام">
                                                        <ItemTemplate><%# Eval("name") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نام خانوادگی">
                                                        <ItemTemplate><%# Eval("family") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="کد ملی">
                                                        <ItemTemplate><%# ToFarsi(Eval("melicode").ToString()) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="مدت زمان سرویس">
                                                        <ItemTemplate><%# ToFarsi(Eval("period").ToString()) + " ماهه" %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="مبلغ سرویس">
                                                        <ItemTemplate><%# ToFarsi(Eval("cost").ToString()) + " تومان" %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="زمان خرید سرویس">
                                                        <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("date")))%></ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="شماره فاکتور">
                                                        <ItemTemplate><%# "فاکتور شماره " + ToFarsi(Eval("reference_id").ToString()) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="کد رهگیری">
                                                        <ItemTemplate><%# ToFarsi(Eval("ref_id").ToString()) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="وضعیت خرید">
                                                        <ItemTemplate><%# Eval("status") %></ItemTemplate>
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

