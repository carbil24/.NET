<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TextBox.aspx.cs" Inherits="MyTextBoxApplication.TextBox" %>

<%@ Register Src="~/UserInfo.ascx" TagPrefix="uc1" TagName="UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="textbox" runat="server" ></asp:TextBox><br />
    <asp:Label ID="Label1" runat="server" ></asp:Label><br />
    <asp:Button ID="Button1" runat="server" Text="Say Hello" onclick="Button1_Click"/>
    <br />
    <uc1:UserInfo runat="server" ID="UserInfo" UserAge="40" UserName="Dan" UserCountry="Canada" />
</asp:Content>
