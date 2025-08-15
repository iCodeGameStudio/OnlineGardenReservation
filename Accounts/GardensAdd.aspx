<%@ Page Title="" Language="C#" MasterPageFile="~/AccountsMasterPage.master" AutoEventWireup="true" CodeFile="GardensAdd.aspx.cs" Inherits="Accounts_GardensAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <div class="box box-info">
                        <div class="box-body">
                            <asp:Button ID="btnupload" runat="server" Text="ارسال تصاویر" Width="150" OnClick="btnupload_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="box box-danger">
                        <div class="box-header">
                            <h3 class="box-title">ثبت مشخصات باغ</h3>
                        </div>
                        <div class="box-body">
                            <div class="form-group">
                                <label>نام باغ</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-tree"></i>
                                    </div>
                                    <asp:TextBox ID="txtgardenname" runat="server" MaxLength="50" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>تلفن ثابت</label>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-phone"></i>
                                    </div>
                                    <asp:TextBox ID="txttel" runat="server" MaxLength="11" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>ظرفیت(نفر)</label>

                                <div class="input-group" >
                                    <div class="input-group-addon">
                                        <i class="fa fa-building"></i>
                                    </div>
                                    <asp:TextBox ID="txtcapacity" runat="server" MaxLength="5" ValidationGroup="G1"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>باغ من دارای امکانات</label>
                                <div class="input-group">
                                    <asp:CheckBoxList ID="chk" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chk_SelectedIndexChanged" RepeatDirection="Horizontal" RepeatColumns="2">
                                        <asp:ListItem Value="آلاچیق">آلاچیق</asp:ListItem>
                                        <asp:ListItem Value="سکو">سکو</asp:ListItem>
                                        <asp:ListItem Value="آب نما">آب نما</asp:ListItem>
                                        <asp:ListItem Value="پارکینگ">پارکینگ</asp:ListItem>
                                        <asp:ListItem Value="موسیقی زنده">موسیقی زنده</asp:ListItem>
                                        <asp:ListItem Value="پارک بازی کودکان">پارک بازی کودکان</asp:ListItem>
                                        <asp:ListItem Value="غذای سنتی">غذای سنتی</asp:ListItem>
                                        <asp:ListItem Value="غذای فرنگی">غذای فرنگی</asp:ListItem>
                                        <asp:ListItem Value="صبحانه">صبحانه</asp:ListItem>
                                        <asp:ListItem Value="نهار">نهار</asp:ListItem>
                                        <asp:ListItem Value="اقامت شبانه">اقامت شبانه</asp:ListItem>
                                        <asp:ListItem Value="اینترنت بی سیم">اینترنت بی سیم</asp:ListItem>
                                        <asp:ListItem Value="تخفیفات رزرو">تخفیفات رزرو</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-tags"></i>
                                    </div>
                                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>نوع مکان</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-tags"></i>
                                    </div>
                                    <asp:DropDownList ID="drptype" runat="server" Width="100%" ValidationGroup="G1">
                                        <asp:ListItem Selected="True" Value="">نوع مکان را انتخاب کنید</asp:ListItem>
                                        <asp:ListItem Value="باغ مجالس">باغ مجالس</asp:ListItem>
                                        <asp:ListItem Value="باغ رستوران">باغ رستوران</asp:ListItem>
                                        <asp:ListItem Value="سفره خانه">سفره خانه</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label>آدرس</label>

                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-map-marker"></i>
                                    </div>
                                    <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" ValidationGroup="G1" Height="100"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnsavegarden" runat="server" Text="ثبت مشخصات" Width="100%" OnClick="btnsavegarden_Click" ValidationGroup="G1" />
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

                            <div class="form-group" style="height: 500px;">
                                <%--                                <h5>- پس از تغییر گذرواژه باید مجددا به حساب کاربری خود وارد شوید.</h5>
                                <br>
                                <h5>- گذرواژه شما می تواند از حروف و یا اعداد انگلیسی تشکیل شده باشد.</h5>
                                <br>
                                <h5>- تعداد حروف گذرواژه شما باید بین 4 تا 20 حرف باشد.</h5>
                                <br>
                                <h5>- پس از تغییر گذرواژه یک ایمیل حاوی گذرواژه جدید برای شما ارسال خواهد شد.</h5>--%>
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

    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ControlToValidate="txtgardenname" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None" ControlToValidate="txttel" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtcapacity" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None" ControlToValidate="txtaddress" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="None" ControlToValidate="drptype" ValidationGroup="G1"></asp:RequiredFieldValidator>
    <script type="text/javascript" lang="javascript" src="../JS/jquery-validation.1.0.0.min.js"></script>
</asp:Content>

