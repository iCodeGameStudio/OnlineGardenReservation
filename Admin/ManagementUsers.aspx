<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementUsers.aspx.cs" Inherits="Admin_ManagementUsers" %>

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
                            <asp:Button ID="Button1" runat="server" Text="تعریف مدیر جدید" OnClick="Button1_Click" Width="200px" />
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
                                                    <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ مدیری غیر از شما وجود ندارد" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="نام" DataField="name" />
                                                            <asp:BoundField HeaderText="نام خانوادگی" DataField="family" />
                                                            <asp:BoundField HeaderText="کد ملی" DataField="melicode" ItemStyle-CssClass="arabic"/>
                                                            <asp:BoundField HeaderText="تلفن همراه" DataField="mobile" ItemStyle-CssClass="arabic"/>
                                                            <asp:BoundField HeaderText="ایمیل" DataField="email" />
                                                            <asp:TemplateField HeaderText="تعداد بازدید">
                                                                <ItemTemplate><%# ToFarsi(Eval("login_count").ToString())%></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="آخرین بازدید">
                                                                <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("last_login")).ToString())%></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="سطح دسترسی">
                                                                <ItemTemplate><%# Eval("access").ToString() == "1" ? "مدیر عالی" : "مدیر میانی" %></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ویرایش" HeaderStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnEdit" Width="30" ImageUrl="~/Images/iconEdit.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='edit' title="ویرایش" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="30">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnDelete" Width="30" ImageUrl="~/Images/iconDelete.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='remove' title="حذف مدیر" />
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
