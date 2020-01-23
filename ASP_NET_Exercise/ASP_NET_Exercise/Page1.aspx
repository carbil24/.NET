<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="ASP_NET_Exercise.Page1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label><br />
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label><br />
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label><br />
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
