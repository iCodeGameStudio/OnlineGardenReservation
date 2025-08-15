<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServicesAdd.aspx.cs" Inherits="Accounts_ServicesAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-success">
                        <div class="box-header">
                            <h3 class="box-title">نوع سرویس</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <asp:DropDownList ID="dropdown" runat="server" Width="100%" OnSelectedIndexChanged="dropdown_SelectedIndexChanged" AutoPostBack="true" ValidationGroup="G1"></asp:DropDownList>
                            </div>
                            <div class="form-group" runat="server" id="sertype" style="display: none;">
                                <label>نوع سرویس</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtsertype" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group" runat="server" id="sercapacity" style="display: none;">
                                <label>ظرفیت (نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtcapacity" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group" runat="server" id="sereating" style="display: none;">
                                <label>سرویس پذیرایی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtsereating" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group" runat="server" id="serother" style="display: none;">
                                <label>سایر سرویس ها</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtotherser" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnAddService" runat="server" Text="ثبت سرویس" ValidationGroup="G1" Width="100%" OnClick="btnAddService_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3 class="box-title">مشخص کننده تاریخ ها</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table dir="rtl" style="text-align: center; overflow: hidden; width: 100%;">
                                        <tr>
                                            <td style="width: 10%;">
                                                <asp:Button ID="previusYear" runat="server" Text="سال قبل" Width="100%" Style="border-radius: 7px;" OnClick="previusYear_Click"></asp:Button></td>
                                            <td style="width: 80%;">
                                                <asp:Button ID="btnyear" runat="server" Text="" Width="100%" Style="border-radius: 7px; background: linear-gradient(#43b844,#14980f)" Enabled="false"></asp:Button></td>
                                            <td style="width: 10%;">
                                                <asp:Button ID="nextYear" runat="server" Text="سال بعد" Width="100%" Style="border-radius: 7px;" OnClick="nextYear_Click"></asp:Button></td>
                                            <asp:ListBox ID="lstYear" runat="server" Visible="false"></asp:ListBox>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="arrow1" runat="server" Text="ماه قبل" Width="100%" OnClick="arrow1_Click" Style="border-radius: 7px;"></asp:Button></td>
                                            <td>
                                                <asp:Button ID="month1" runat="server" Text="" Width="100%" Style="border-radius: 7px; background: linear-gradient(#0094ff,#2074ff)" Enabled="false"></asp:Button></td>
                                            <td>
                                                <asp:Button ID="arrow2" runat="server" Text="ماه بعد" Width="100%" OnClick="arrow2_Click" Style="border-radius: 7px;"></asp:Button></td>
                                        </tr>
                                    </table>
                                    <table dir="rtl" style="text-align: center; overflow: hidden; width: 100%;">
                                        <tr>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;ش&nbsp;</td>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;ی&nbsp;</td>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;د&nbsp;</td>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;س&nbsp;</td>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;چ&nbsp;</td>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;پ&nbsp;</td>
                                            <td style="width: 14%; background: linear-gradient(#f5e465,#f7976f); font-size: 14px; border: solid 1px #c9885f">&nbsp;ج&nbsp;</td>
                                        </tr>
                                    </table>
                                    <table dir="rtl" style="text-align: center; overflow: hidden; width: 100%; border: solid 1px #00f550" border="1">
                                        <tr>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button1" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox2" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button2" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox3" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button3" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox4" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button4" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox5" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button5" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox6" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button6" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td style="width: 14%">
                                                <asp:CheckBox ID="CheckBox7" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button7" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBox8" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button8" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox9" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button9" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox10" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button10" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox11" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button11" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox12" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button12" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox13" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button13" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox14" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button14" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBox15" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button15" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox16" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button16" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox17" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button17" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox18" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button18" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox19" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button19" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox20" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button20" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox21" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button21" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBox22" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button22" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox23" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button23" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox24" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button24" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox25" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button25" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox26" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button26" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox27" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button27" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox28" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button28" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBox29" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button29" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox30" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button30" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox31" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button31" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox32" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button32" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox33" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button33" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px; white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox34" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button34" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox35" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button35" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBox36" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button36" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="CheckBox37" runat="server" Checked="false" TextAlign="Left" OnCheckedChanged="CheckBox_CheckedChanged" AutoPostBack="true" />
                                                <br />
                                                <asp:Button ID="Button37" runat="server" OnClick="Button_Click" Width="100%" Height="70px" Style="border-radius: 7px;white-space: normal;" />
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:ListBox ID="lst" runat="server" Width="300" Visible="false"></asp:ListBox>
                                <asp:ListBox ID="lst2" runat="server" Width="300" Visible="false"></asp:ListBox>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dropdown" ValidationGroup="G1" Display="None"></asp:RequiredFieldValidator>
    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

