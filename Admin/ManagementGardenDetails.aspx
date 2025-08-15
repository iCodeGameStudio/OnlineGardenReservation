<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementGardenDetails.aspx.cs" Inherits="Admin_ManagementGardenDetails" %>

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
                            <h3 class="box-title">مشخصات کاربر</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>نام</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>نام خانوادگی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtfamily" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>کد ملی</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtmelicode" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>تلفن همراه</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>آدرس ایمیل</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                                </div>
                            </div>

                             <div class="form-group">
                                <label>استان</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtprovince" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>شهر</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="box box-primary">
                        <div class="box-header">
                            <h3 class="box-title">مشخصات باغ</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>نام باغ</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtgardenname" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>تلفن تماس</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txttel" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>ظرفیت(نفر)</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtcapacity" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                <label>نوع مکان</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txttype" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>امکانات باغ</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtpossibilities" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>آدرس</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                    </div>
                                    <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnsave1" Text="ویرایش مشخصات" Width="100%" runat="server"/>
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

     <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>

