<%@ Page Title="" Language="C#" MasterPageFile="~/ManagementsMasterPage.master" AutoEventWireup="true" CodeFile="ManagementResult.aspx.cs" Inherits="Admin_ManagementResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div id="divaccess" runat="server">
        <br /><br /><br />
        <table style="width: 100%">
            <tr>
                <td colspan="4" style="text-align: center;">
                    <img src="../Images/no-entry.png" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <h3>کاربر گرامی شما اجازه دسترسی به این بخش را ندارید</h3>
                </td>
            </tr>
        </table>
        <br /><br /><br />
    </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress DisplayAfter="10" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
        <ProgressTemplate>
            <div class="progress-loading"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

