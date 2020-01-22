<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerObject.aspx.cs" Inherits="ASP.NETServerObjects.ServerObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter your name:
            <br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
