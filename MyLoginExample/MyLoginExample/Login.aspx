<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyLoginExample.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUserName" ForeColor="red" runat="server" controltovalidate="txtUserName" ErrorMessage="Please enter a UserName"></asp:RequiredFieldValidator>
    <br /><br />

    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPassword" ForeColor="red" runat="server" controltovalidate="txtPassword" ErrorMessage="Please enter a Password"></asp:RequiredFieldValidator>

    <br /><br />

    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

</asp:Content>
