<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServicesReport.aspx.cs" Inherits="Accounts_ServicesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">

                <div class="col-sm-12">
                    <div class="box box-success">
                        <div class="box-body">
                            <asp:Button ID="btnPrint" runat="server" Text="چاپ" Width="150" OnClientClick="doPrint()" />
                            <br /><br /><br />
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EnableModelValidation="True" EmptyDataText="هیچ سرویسی تاکنون ثبت نشده است" ForeColor="Black">
                                    <Columns>
                                        <asp:TemplateField HeaderText="نوع سرویس">
                                            <ItemTemplate><%# Eval("ser_type") %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ظرفیت">
                                            <ItemTemplate><%# ToFarsi(Eval("capacity").ToString()) + " نفر" %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="سرویس پذیرایی">
                                            <ItemTemplate><%# Eval("ser_eating") %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="سایر سرویس ها">
                                            <ItemTemplate><%# Eval("other_ser") %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاریخ">
                                            <ItemTemplate><%# ToFarsi(miladiToShamsi(Eval("date"))) %></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                    <script>
                        function doPrint() {
                            var prtContent = document.getElementById('<%= GridView1.ClientID %>');
                            prtContent.border = 1; //set no border here
                            prtContent.dir = "rtl";
                            prtContent.lang = "fa";
                            prtContent.setAttribute("Style", "border:1px solid #000");
                            var WinPrint = window.open('', '', 'left=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=1,status=0,resizable=1,scale=119');
                            WinPrint.document.write(prtContent.outerHTML);
                            WinPrint.document.close();
                            WinPrint.focus();
                            WinPrint.print();
                            WinPrint.close();
                        }


                    </script>
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

