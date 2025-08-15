<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServicesDefaultAdd.aspx.cs" Inherits="Accounts_ServicesAdd" %>

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
                                <label>نوع سرویس</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:DropDownList ID="dropdown" runat="server" Width="100%">
                                        <asp:ListItem Selected="True" Value="" Text="سرویس مورد نظر را انتخاب کنید"></asp:ListItem>
                                        <asp:ListItem Value="صبح" Text="صبح / صبحانه / قبل از ظهر"></asp:ListItem>
                                        <asp:ListItem Value="ظهر" Text="ظهر / ناهار"></asp:ListItem>
                                        <asp:ListItem Value="عصر" Text="عصر / عصرانه / بعد از ظهر"></asp:ListItem>
                                        <asp:ListItem Value="شب" Text="شب / شام"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>ظرفیت (نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-users"></i>
                                    </div>
                                    <asp:TextBox ID="txtcapacity" runat="server" ValidationGroup="Group1" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سرویس پذیرایی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-users"></i>
                                    </div>
                                    <asp:TextBox ID="txteating" runat="server" ValidationGroup="Group1" placeholder="مثال: چلوکباب ، کلم پلو و ..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سایر سرویس ها</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-users"></i>
                                    </div>
                                    <asp:TextBox ID="txtotherservice" runat="server" ValidationGroup="Group1" placeholder="مثال: موسیقی زنده و ..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnaddservice" runat="server" Text="ثبت سرویس" Width="100%" ValidationGroup="Group1" OnClick="btnaddservice_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="hidePanel">
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3 class="box-title">متن توافق</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <p class="arabic">-توافق 1</p>
                                <br />
                                <p class="arabic">-توافق 2</p>
                                <br />
                                <p class="arabic">-توافق 3</p>
                                <br />
                                <p class="arabic">-توافق 4</p>
                                 <br />
                                <p class="arabic">-توافق 5</p>
                                 <br />
                                <p class="arabic">-توافق 6</p>
                                <br />
                                <p class="arabic">-توافق 7</p>
                                <br />
                            </div>
                        </div>

                    </div>
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
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ سرویس پیشفرضی تعریف نشده است" OnRowCommand="GridView1_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="نوع سرویس">
                                                        <ItemTemplate><%# Eval("ser_type") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ظرفیت">
                                                        <ItemTemplate><%# setPersianNumber(Eval("capacity").ToString()) + " نفر" %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="سرویس پذیرایی">
                                                        <ItemTemplate><%# Eval("ser_eating") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="سایر سرویس ها">
                                                        <ItemTemplate><%# Eval("other_ser").ToString() == "" ? "ثبت نشده است" : Eval("other_ser").ToString() %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تاریخ ثبت">
                                                        <ItemTemplate><%# miladiToShamsi(Eval("date").ToString()) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" Width="30" ImageUrl="~/Images/iconDelete.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='remove' title="حذف سرویس" />
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
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dropdown" ValidationGroup="Group1" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcapacity" ValidationGroup="Group1" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txteating" ValidationGroup="Group1" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\d+" ControlToValidate="txtcapacity" ValidationGroup="Group1" Display="None"></asp:RegularExpressionValidator>
    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>

