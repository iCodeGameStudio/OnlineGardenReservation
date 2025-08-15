<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementContactUs.aspx.cs" Inherits="Admin_ManagementContactUs" %>

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
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-6"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ پیامی برای شما ارسال نشده است" OnRowCommand="GridView1_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="نام">
                                                        <ItemTemplate><%# Eval("name") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="آدرس ایمیل">
                                                        <ItemTemplate><%# Eval("email") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="موضوع پیام">
                                                        <ItemTemplate><%# Eval("subject") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="پیام">
                                                        <ItemTemplate><%# Eval("message") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="زمان">
                                                        <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("date"))) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="وضعیت">
                                                        <ItemTemplate><%# Eval("seen").ToString() == "0" ? "خوانده نشده" : "خوانده شده"  %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" Width="30" ImageUrl="~/Images/iconDelete.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='remove' title="حذف پیام" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="نمایش" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <a href="<%# "ManagementContactUsDetails?id=" + Eval("id") %>">
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

