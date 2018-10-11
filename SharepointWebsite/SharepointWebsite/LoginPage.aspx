<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SharepointWebsite.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginPage.aspx.cs" Inherits="SharepointWebsite.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="auto-style4">
        <div>
        </div>
            <asp:Label ID="SiteNameLabel" runat="server" Text="SiteName"></asp:Label>
            <asp:TextBox ID="SiteNameTextBox" runat="server" CssClass="auto-style1" Height="31px" Width="132px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="UserNameLabel" runat="server" Text="UserName"></asp:Label>
            <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="auto-style2" Height="28px" Width="136px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="auto-style3" Height="29px" Width="132px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LoginButton" runat="server" OnClick="Button1_Click" Text="Login" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
</asp:Content>