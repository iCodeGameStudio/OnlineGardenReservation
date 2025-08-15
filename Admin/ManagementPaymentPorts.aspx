<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementPaymentPorts.aspx.cs" Inherits="Admin_ManagementPaymentPorts" %>

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
                                    <div class="col-sm-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ درگاه پرداختی وجود ندارد" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                <Columns>
                                                    <asp:BoundField HeaderText="نام صاحب حساب" DataField="name" />
                                                    <asp:BoundField HeaderText="مرچنت کد" DataField="merchant_code" />
                                                    <asp:TemplateField HeaderText="ویرایش" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnEdit" Width="30" ImageUrl="~/Images/iconEdit.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='edit' title="ویرایش" />
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

