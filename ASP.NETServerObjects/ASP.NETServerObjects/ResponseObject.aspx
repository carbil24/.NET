<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponseObject.aspx.cs" Inherits="ASP.NETServerObjects.ResponseObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="lblDownload" runat="server" Text="Download Summary" OnClick="lblDownload_Click"></asp:LinkButton>
            <br />
            <asp:Label id="lblMessage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
