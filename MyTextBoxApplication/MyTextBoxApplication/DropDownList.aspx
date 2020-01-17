<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DropDownList.aspx.cs" Inherits="MyTextBoxApplication.DropDownList" %>

<%@ Register Src="~/UserInfo.ascx" TagPrefix="uc1" TagName="UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" autopostback="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        <asp:ListItem Text="No one" Value="1" Selected="True"></asp:ListItem>
        <asp:ListItem Value="2">Carlos</asp:ListItem>
        <asp:ListItem Value="3">Universe</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label1" runat="server" ></asp:Label><br />
    <br />
    <uc1:UserInfo runat="server" ID="UserInfo" UserAge="30" UserName="Carlos" UserCountry="Canada" />
</asp:Content>
