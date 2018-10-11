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

    <div id="done" style="margin-top: 10%; margin-left:25%;">
        <div class="form-group">
            <asp:Label ID="SiteNameLabel" runat="server" for="text" Text="Site Name"></asp:Label>
            <asp:TextBox ID="SiteNameTextBox" type="text" CssClass="form-control" runat="server" placeholder="Enter Valid Site Name" required="required"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="ListNameLabel" runat="server" Text=" "></asp:Label>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
        <%--<div class="checkbox">
        <label>
            <input type="checkbox">
            Remember me</label>
    </div>--%>
        <%--    <button type="submit" class="btn btn-default">Submit</button>--%>
        <asp:Button ID="BackupButton" type="submit" CssClass="btn btn-success" runat="server" OnClick="BackupButton_Click" Text="Backup" />

         <br />

         <div class="form-group">
            <asp:Label ID="UrlLabel" runat="server" Text="Url: "></asp:Label>
            <asp:PlaceHolder ID="UrlData" runat="server"></asp:PlaceHolder>
             <br />
             <br />
             <br />
             <asp:Button ID="SubmitButton" type="submit" CssClass="btn btn-success" runat="server" OnClick="SubmitButton_Click" Text="Exit" Width="101px" />
        </div>
    </div>


    <br />
    <br />
    <br />
    <br />


    <%--    <div class="text-center">
        <div>
        </div>


        <div class="text-center">



            <br />



            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;



            <asp:Label ID="SiteNameLabel" runat="server" CssClass="label label-default label-lg" Style="font-size: initial;" Text="SiteName"></asp:Label>
            &nbsp;<asp:TextBox ID="SiteNameTextBox" CssClass="form-control" runat="server" placeholder="Enter Valid Site Name" Height="16px" Style="margin-left: 410" Width="131px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="ListNameLabel" CssClass="label label-primary label-lg" Style="font-size: initial;" runat="server" Text=" "></asp:Label>
            <asp:PlaceHolder ID="PlaceHolderLabel" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:Button ID="BackupButton" CssClass="btn btn-success" runat="server" Font-Bold="True" OnClick="BackupButton_Click" Text="Backup" />


        </div>
    </div>--%>
</asp:Content>
