<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="Result.aspx.cs" Inherits="Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta property="og:title" content="باغبون ، رزرواسیون باغ" />
    <meta property="og:description" content="رزرو آنلاین باغ ها و سفره خانه ها ، باغبون در نظر دارد بهترین خدمات باغ ها را به شما ارائه دهد." />
    <meta property="og:type" content="website" />
    <meta property="og:locale" content="fa_IR" />
    <meta property="og:url" content="http://baghebon.com/" />
    <meta property="og:image" content="http://baghebon.com/Images/Oglogo.jpg" />
    <meta property="og:image:width" content="700" />
    <meta property="og:image:height" content="439" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-title" style="text-align: right;">
        <h3 id="htitle">نتیجه عملیات</h3>
    </div>
    <div id="page">
        <br />
        <br />
        <div id="passwordchanged" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>کاربر گرامی، تغییر گذرواژه شما با موفقیت انجام شد.</p>
                <p>جهت ورود به حساب کاربری خود، روی لینک زیر کلیک کنید.</p>
                <a href="<%= ResolveUrl("~/Signin")%>" title="ورود به حساب کاربری">ورود به حساب کاربری</a>
            </div>
        </div>
        <div id="passwordchangedaccount" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>کاربر گرامی، تغییر گذرواژه شما با موفقیت انجام شد.</p>
                <p>جهت ورود به حساب کاربری خود، روی لینک زیر کلیک کنید.</p>
                <a href="<%= ResolveUrl("~/Accounts/AccountSignin")%>" title="ورود به حساب کاربری">ورود به حساب کاربری</a>
            </div>
        </div>
        <div id="passwordchangedmanagement" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>مدیریت محترم، تغییر گذرواژه شما با موفقیت انجام شد.</p>
                <p>جهت ورود به حساب خود، مجددا وارد شوید.</p>
            </div>
        </div>
        <div id="forgetpasswordaccountsuccessful" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>کاربر گرامی، درخواست بازیابی گذرواژه شما با موفقیت ثبت شد.</p>
                <p>یک ایمیل حاوی لینک تغییر گذرواژه به آدرس ایمیل شما ارسال شده است.</p>
                <p>ایمیل خود را باز کنید و روی لینک تغییر گذرواژه کلیک نمایید.</p>
            </div>
        </div>
        <div id="forgetpasswordmanagersuccessful" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>مدیریت گرامی، درخواست بازیابی گذرواژه شما با موفقیت ثبت شد.</p>
                <p>یک ایمیل حاوی لینک تغییر گذرواژه به آدرس ایمیل شما ارسال شده است.</p>
                <p>ایمیل خود را باز کنید و روی لینک تغییر گذرواژه کلیک نمایید.</p>
            </div>
        </div>
        <div id="forgetpasswordaccountinvalidrequest" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-unsuccessful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات ناموفق" title="عملیات ناموفق">
                <p>کاربر گرامی، درخواست بازیابی گذرواژه شما معتبر نمی باشد.</p>
            </div>
        </div>
        <div id="forgetpasswordmanagerinvalidrequest" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-unsuccessful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات ناموفق" title="عملیات ناموفق">
                <p>مدیریت گرامی، درخواست بازیابی گذرواژه شما معتبر نمی باشد.</p>
            </div>
        </div>
        <div id="forgetpasswordaccountchangedsuccessful" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>کاربر گرامی، تغییر گذرواژه شما با موفقیت انجام شد.</p>
                <p>جهت ورود به حساب کاربری خود، روی لینک زیر کلیک کنید.</p>
                <a href="<%= ResolveUrl("~/Accounts/AccountSignin")%>" title="ورود به حساب کاربری">ورود به حساب کاربری</a>
            </div>
        </div>
        <div id="forgetpasswordmanagerchangedsuccessful" class="result" runat="server">
            <div style="width: 100%; height: 64px; margin: 0 auto; text-align: center; line-height: 50px;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق">
                <p>مدیریت گرامی، تغییر گذرواژه شما با موفقیت انجام شد.</p>
                <p>جهت ورود به پنل مدیریت خود، با گذرواژه جدید وارد شوید.</p>
            </div>
        </div>
    </div>

    <div class="clear-both"></div>






    <%--<div class="main">
        <div id="forgetpasswordsuccessful" class="result" runat="server">
            <p style="width: 64px; height: 64px; margin: 0 auto;">
                <img src="<%= ResolveUrl("~/Images/icon-successful.png")%>" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق"></p>
            <p>کاربر گرامی، درخواست بازیابی گذرواژه شما با موفقیت ثبت شد.</p>
            <p>یک ایمیل حاوی لینک تغییر گذرواژه به آدرس ایمیل شما ارسال شده است.</p>
            <p>ایمیل خود را باز کنید و روی لینک تغییر گذرواژه کلیک نمایید.</p>
        </div>
        <div id="forgetpasswordunsuccessful" class="result" runat="server">
        <p style="width: 64px; height: 64px; margin: 0 auto;">
            <img src="<%= ResolveUrl("~/Images/icon-unsuccessful.png")%>" style="width: 64px; height: 64px; border: 0;" alt="عملیات ناموفق" title="عملیات ناموفق"></p>
        <p>کاربر گرامی، درخواست بازیابی گذرواژه شما معتبر نمی باشد.</p>
    </div>
        <div id="forgetpasswordchangedsuccessful" class="result" runat="server">
            <p style="width: 64px; height: 64px; margin: 0 auto;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق"></p>
            <p>کاربر گرامی، تغییر گذرواژه شما با موفقیت انجام شد.</p>
            <p>جهت ورود به حساب کاربری خود، روی لینک زیر کلیک کنید.</p>
            <a href="<%= ResolveUrl("~/Accounts/AccountSignin")%>" title="ورود به حساب کاربری">ورود به حساب کاربری</a>
        </div>
        <div id="passwordchangedmanagement" class="result" runat="server">
            <p style="width: 64px; height: 64px; margin: 0 auto;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق"></p>
            <p>مدیریت محترم، تغییر گذرواژه شما با موفقیت انجام شد.</p>
            <p>جهت ورود به حساب خود، روی لینک زیر کلیک کنید.</p>
            <a href="<%= ResolveUrl("~/Admin/ManagementSignin")%>" title="ورود به مدیریت">ورود به مدیریت</a>
        </div>
        <div id="passwordchangedaccount" class="result" runat="server">
            <p style="width: 64px; height: 64px; margin: 0 auto;">
                <img src="Images/icon-successful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق"></p>
            <p>کاربر گرامی، تغییر گذرواژه شما با موفقیت انجام شد.</p>
            <p>جهت ورود به حساب کاربری خود، روی لینک زیر کلیک کنید.</p>
            <a href="<%= ResolveUrl("~/Accounts/AccountSignin")%>" title="ورود به مدیریت">ورود به حساب کاربری</a>
        </div>
        <div id="nologin" class="result" runat="server">
            <p style="width: 64px; height: 64px; margin: 0 auto;">
                <img src="Images/icon-unsuccessful.png" style="width: 64px; height: 64px; border: 0;" alt="عملیات موفق" title="عملیات موفق"></p>
            <p>کاربر گرامی، برای دسترسی به این قسمت ابتدا باید وارد شوید.</p>
            <p>جهت ورود به حساب کاربری خود، روی لینک زیر کلیک کنید.</p>
            <a href="<%= ResolveUrl("~/Accounts/AccountSignin")%>" title="ورود به حساب کاربری">ورود به حساب کاربری</a>
        </div>
    </div>
    --%>
</asp:Content>

