<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementHome.aspx.cs" Inherits="Admin_ManagementHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua" id="small-box">
            <div class="inner">
              <h3 id="H_start_date_act" runat="server" class="arabic">0</h3>
              <p>تعداد کاربران فعال</p>
            </div>
            <div class="icon">
              <i class="ion ion-android-calendar"></i>
            </div>
            <a href="#" class="small-box-footer" style="display:none;">اطلاعات بیشتر <i class="fa fa-arrow-circle-left"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-green" id="small-box">
            <div class="inner">
              <h3 id="H_end_date_act" runat="server" class="arabic">0</h3>
              <p>تعداد درخواست ها</p>
            </div>
            <div class="icon">
              <i class="ion ion-android-calendar"></i>
            </div>
            <a href="#" class="small-box-footer" style="display:none;">اطلاعات بیشتر <i class="fa fa-arrow-circle-left"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow" id="small-box">
            <div class="inner">
              <h3 id="H_day_end_act" runat="server" class="arabic">0</h3>
              <p>گردش حساب</p>
            </div>
            <div class="icon">
              <i class="ion ion-flag"></i>
            </div>
            <a href="#" class="small-box-footer" style="display:none;">اطلاعات بیشتر <i class="fa fa-arrow-circle-left"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red" id="small-box">
            <div class="inner">
              <h3 id="H_act_count" runat="server" class="arabic">0</h3>
              <p>............</p>
            </div>
            <div class="icon">
              <i class="ion ion-grid"></i>
            </div>
            <a href="#" class="small-box-footer" style="display:none;">اطلاعات بیشتر <i class="fa fa-arrow-circle-left"></i></a>
          </div>
        </div>
        <!-- ./col -->
      </div>
</asp:Content>

