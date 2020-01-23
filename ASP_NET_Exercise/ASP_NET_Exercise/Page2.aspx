<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="ASP_NET_Exercise.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFirstName" runat="server" ></asp:Label>
            <asp:Label ID="lblLastName" runat="server" ></asp:Label>
            <asp:Label ID="lblAge" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnResults" runat="server" Text="Results" OnClick="btnResults_Click" />
        </div>
    </form>
</body>
</html>
