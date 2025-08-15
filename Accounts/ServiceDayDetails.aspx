<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="ServiceDayDetails.aspx.cs" Inherits="Accounts_ServiceDayDetails" %>

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
                            <h3 class="box-title">صبح / صبحانه / قبل از ظهر</h3>  
                           <div style="text-align:left;position:relative;top:-25px;">
                            <asp:ImageButton ID="btnEditMorning" runat="server" ImageUrl="~/Images/iconEdit.png" Width="30" Height="30" ToolTip="ویرایش" OnClick="btnEditMorning_Click"/>
                               &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRemoveMorning" runat="server" ImageUrl="~/Images/iconDelete.png" Width="30" Height="30" ToolTip="حذف" OnClick="btnRemoveMorning_Click"/>   
                               </div>                      
                        </div>
                        
                        <div class="box-body">
                            <div class="form-group">
                                <label>ظرفیت (نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtcapacity_morning" runat="server" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سرویس پذیرایی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txteating_morning" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سایر سرویس ها</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtother_morning" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-danger">
                        <div class="box-header">
                            <h3 class="box-title">ظهر / ناهار</h3>
                            <div style="text-align:left;position:relative;top:-25px;">
                            <asp:ImageButton ID="btnEditNoon" runat="server" ImageUrl="~/Images/iconEdit.png" Width="30" Height="30" ToolTip="ویرایش" OnClick="btnEditNoon_Click"/>
                               &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRemoveNoon" runat="server" ImageUrl="~/Images/iconDelete.png" Width="30" Height="30" ToolTip="حذف" OnClick="btnRemoveNoon_Click"/>   
                               </div>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>ظرفیت (نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtcapacity_noon" runat="server" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سرویس پذیرایی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txteating_noon" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سایر سرویس ها</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtother_noon" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-warning">
                        <div class="box-header">
                            <h3 class="box-title">عصر / عصرانه / بعد از ظهر</h3>
                            <div style="text-align:left;position:relative;top:-25px;">
                            <asp:ImageButton ID="btnEditAfternoon" runat="server" ImageUrl="~/Images/iconEdit.png" Width="30" Height="30" ToolTip="ویرایش" OnClick="btnEditAfternoon_Click"/>
                               &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRemoveAfternoon" runat="server" ImageUrl="~/Images/iconDelete.png" Width="30" Height="30" ToolTip="حذف" OnClick="btnRemoveAfternoon_Click"/>   
                               </div>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>ظرفیت (نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtcapacity_afternoon" runat="server" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سرویس پذیرایی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txteating_afternoon" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سایر سرویس ها</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtother_afternoon" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-info">
                        <div class="box-header">
                            <h3 class="box-title">شب / شام</h3>
                            <div style="text-align:left;position:relative;top:-25px;">
                            <asp:ImageButton ID="btnEditNight" runat="server" ImageUrl="~/Images/iconEdit.png" Width="30" Height="30" ToolTip="ویرایش" OnClick="btnEditNight_Click"/>
                               &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRemoveNight" runat="server" ImageUrl="~/Images/iconDelete.png" Width="30" Height="30" ToolTip="حذف" OnClick="btnRemoveNight_Click"/>   
                               </div>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>ظرفیت (نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtcapacity_night" runat="server" MaxLength="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سرویس پذیرایی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txteating_night" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>سایر سرویس ها</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-pencil"></i>
                                    </div>
                                    <asp:TextBox ID="txtother_night" runat="server" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
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

