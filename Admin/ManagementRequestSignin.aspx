<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementRequestSignin.aspx.cs" Inherits="Admin_ManagementRequestSignin" %>

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
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ درخواست ثبت نامی وجود ندارد" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                <Columns>
                                                    <asp:BoundField HeaderText="نام" DataField="name" />
                                                    <asp:BoundField HeaderText="نام خانوادگی" DataField="family" />
                                                    <asp:BoundField HeaderText="کد ملی" DataField="melicode" ItemStyle-CssClass="arabic"/>
                                                    <asp:BoundField HeaderText="تلفن همراه" DataField="mobile" ItemStyle-CssClass="arabic"/>
                                                    <asp:BoundField HeaderText="ایمیل" DataField="email" />
                                                    <asp:BoundField HeaderText="استان" DataField="province" />
                                                    <asp:BoundField HeaderText="شهر" DataField="city" />
                                                    <asp:TemplateField HeaderText="وضعیت">
                                                        <ItemTemplate><%# Eval("active").ToString() == "0" ? "تأیید نشده" : Eval("active").ToString() == "2" ? "رد شده" : Eval("active").ToString() == "3" ? "معلق شده": "مشخص نیست" %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="رد" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnRefuse" Width="30" ImageUrl='<%# Eval("active").ToString() == "2" ? "~/Images/refuse-disable.png" : "~/Images/refuse.png" %>' runat="server" CommandArgument='<%# Eval("id") %>' CommandName='refuse' title="رد درخواست عضویت" Enabled='<%# Eval("active").ToString() == "2" ? false : true %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تعلیق" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnSuspension" Width="30" ImageUrl='<%# Eval("active").ToString() == "3" ? "~/Images/iconSuspensionDisable.png" : "~/Images/iconSuspension.png" %>' runat="server" CommandArgument='<%# Eval("id") %>' CommandName='suspension' title="معلق کردن اکانت کاربر" Enabled='<%# Eval("active").ToString() == "3" ? false : true %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تأیید" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnAccept" Width="30" ImageUrl="~/Images/iconAccept.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='accept' title="تأیید درخواست عضویت" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ویرایش" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" Width="30" ImageUrl="~/Images/iconEdit.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='edit' title="ویرایش" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnRemove" Width="30" ImageUrl="~/Images/iconDelete.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='remove' title="حذف این درخواست" />
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



