<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackupPage.aspx.cs" Inherits="SharepointWebsite.BackupPage" %>

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

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BackupPage.aspx.cs" Inherits="SharepointWebsite.BackupPage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="text-center">
        <div>
        </div>
            <div class="text-center">


            <asp:Label ID="SiteNameLabel" runat="server" Text="SiteName"></asp:Label>
            <asp:TextBox ID="SiteNameTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="ListNameLabel" runat="server" Text=" "></asp:Label>
            <asp:PlaceHolder ID="PlaceHolderLabel" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:Button ID="BackupButton" runat="server" OnClick="BackupButton_Click" Text="Backup" />
            </div>
        </div>
</asp:Content>