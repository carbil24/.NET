<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestObject.aspx.cs" Inherits="ASP.NETServerObjects.RequestObjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Request Info:
            <br />
            <asp:Label ID="lblRequestInfo" runat="server"></asp:Label>
            <br />
            Browser Info:
            <br />
            <asp:Label ID="lblBrowserInfo" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
