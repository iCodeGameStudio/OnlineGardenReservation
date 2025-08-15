<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="~/Admin/ManagementServiceExtensions.aspx.cs" Inherits="Admin_ManagementServiceExtension" %>

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
                            <h3 class="box-title">فرم ثبت سرویس</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>مدت زمان سرویس (ماه)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtmounth" runat="server" ValidationGroup="Group1" MaxLength="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>مبلغ (تومان)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-money"></i>
                                    </div>
                                    <asp:TextBox ID="txtcost" runat="server" ValidationGroup="Group1" MaxLength="8" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnaddservice" runat="server" Text="ثبت سرویس" Width="100%" ValidationGroup="Group1" OnClick="btnaddservice_Click" />
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
                                <h5 style="line-height: 30px;">- مدت سرویس را به صورت عدد و بر اساس ماه وارد کنید.</h5>
                                <br>
                                <h5 style="line-height: 30px;">- مبلغ را به صورت عدد و بر اساس ریال وارد کنید.</h5>
                            </div>

                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
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
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ سرویسی تعریف نشده است" OnRowCommand="GridView1_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="مدت زمان سرویس">
                                                        <ItemTemplate><%# ToFarsi(Eval("period").ToString()) + " ماه"%></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="مبلغ">
                                                        <ItemTemplate><%# ToFarsi(String.Format("{0:#,##0}", Eval("cost"))) + " تومان"%></ItemTemplate>
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
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmounth" ValidationGroup="Group1" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcost" ValidationGroup="Group1" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\d+" ControlToValidate="txtmounth" ValidationGroup="Group1" Display="None"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\d+" ControlToValidate="txtcost" ValidationGroup="Group1" Display="None"></asp:RegularExpressionValidator>
    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>

