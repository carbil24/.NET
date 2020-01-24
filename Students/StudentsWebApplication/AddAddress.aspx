<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAddress.aspx.cs" Inherits="StudentsWebApplication.AddAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Street:
            <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
            <br />
            City:
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <br />
            Province:
            <asp:TextBox ID="txtProvince" runat="server"></asp:TextBox>
            <br />
            PostalCode:
            <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnInsertAddress" runat="server" Text="Insert Address" OnClick="btnInsertAddress_Click" />
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
