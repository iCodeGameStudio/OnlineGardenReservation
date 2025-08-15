<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMasterPage.master" AutoEventWireup="true" CodeFile="MemberReservations.aspx.cs" Inherits="MemberReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-6"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" DataKeyNames="id" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ رزروی وجود ندارد" OnRowCommand="GridView1_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="نام مکان">
                                                        <ItemTemplate><%# Eval("garden_name").ToString() %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نوع مکان">
                                                        <ItemTemplate><%# Eval("type").ToString() %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="شماره تماس">
                                                        <ItemTemplate><%# ToFarsi(Eval("tel").ToString())%></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="نوع سرویس">
                                                        <ItemTemplate><%# Eval("ser_type").ToString() == "صبح" ? "صبح / صبحانه" :  Eval("ser_type").ToString() == "ظهر" ? "ظهر / ناهار" : Eval("ser_type").ToString() == "عصر" ? "عصر / عصرانه" : "شب / شام" %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="تاریخ ارائه سرویس">
                                                        <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("date").ToString())) %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="آدرس">
                                                        <ItemTemplate><%# Eval("address") %></ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="حذف" HeaderStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnDelete" Width="30" ImageUrl="Images/iconDelete.png" runat="server" CommandArgument='<%# Eval("id") %>' CommandName='remove' title="حذف سرویس رزرو شده" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

