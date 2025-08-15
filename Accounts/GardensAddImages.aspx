<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="GardensAddImages.aspx.cs" Inherits="Accounts_GardensAddImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <!-- /.box-header -->
                <div class="box-body">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="Upload" runat="server" Text="ارسال و ثبت" OnClick="Upload_Click" Width="200px" />
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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ تصویری از باغ شما موجود نیست" OnRowCommand="GridView1_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="انتخاب به عنوان پیش نمایش" HeaderStyle-Width="100">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Convert.ToBoolean(Eval("cover")) %>' AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تصاویر ثبت شده">
                                                        <ItemTemplate>
                                                            <asp:Image ID="Image1" Width="180" Height="180" runat="server" ImageUrl='<%# "~/Images/Uploads/Gardens/" + Eval("file_name").ToString() %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" Width="40" Height="40" runat="server" ImageUrl="~/Images/iconDelete.png" CommandArgument='<%# Eval("id") %>' CommandName='remove' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
    
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

