<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementGardens.aspx.cs" Inherits="Admin_ManagementMembers" %>

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
                            <br />
                            <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="جستجو" OnClick="Button1_Click" Width="200px" />
                            <br />
                            <br />
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-6"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ باغی وجود ندارد">
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
                                                    <asp:TemplateField HeaderText="نوع سرویس">
                                                        <ItemTemplate><%# ToFarsi(Convert.ToInt32(Eval("act_count")) == 0 ? "3 ماهه رایگان" : setPeriod(Eval("id")) + " ماهه") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تاریخ شروع فعالسازی">
                                                        <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("start_date_act")).ToString())%></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تاریخ پایان فعالسازی">
                                                        <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("end_date_act")).ToString()) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تعداد فعالسازی">
                                                        <ItemTemplate><%# ToFarsi(Eval("act_count").ToString())%></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="رد پا" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <a href="<%# "ManagementGardenLogs?id=" + Eval("id") %>">
                                                                <img src="../Images/logIcon.png" width="30" height="30" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نمایش" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <a href="<%# "ManagementGardenDetails?id=" + Eval("id") %>">
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


