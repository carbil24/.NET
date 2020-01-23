<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionObject.aspx.cs" Inherits="SessionAndApplicationServerObjects.SessionObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>User Information</title>
</head>
<body>
  <form id="form1" runat="server">
    <h3>
      User information</h3>
    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    <asp:Panel ID="enterUserInfoPanel" runat="server">
      <table cellpadding="3" border="0">
        <tr>
          <td>
            First name:</td>
          <td>
            <asp:TextBox ID="firstNameTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Last name:</td>
          <td>
            <asp:TextBox ID="lastNameTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Address:</td>
          <td>
            <asp:TextBox ID="addressTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            City:</td>
          <td>
            <asp:TextBox ID="cityTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            State or Province:</td>
          <td>
            <asp:TextBox ID="stateOrProvinceTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Zip Code/Postal Code:</td>
          <td>
            <asp:TextBox ID="zipCodeTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            Country:</td>
          <td>
            <asp:TextBox ID="countryTextBox" runat="server" /></td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td>
            <asp:Button ID="enterInfoButton" runat="server" Text="Enter user information" OnClick="EnterInfoButton_OnClick" /></td>
        </tr>
      </table>
    </asp:Panel>
    <asp:Panel ID="userInfoPanel" runat="server">
      <table cellpadding="3" border="0">
        <tr>
          <td>
            Name:</td>
          <td>
            <asp:Label ID="firstNameLabel" runat="server" />
            <asp:Label ID="lastNameLabel" runat="server" />
          </td>
        </tr>
        <tr>
          <td valign="top">
            address:</td>
          <td>
            <asp:Label ID="addressLabel" runat="server" /><br />
            <asp:Label ID="cityLabel" runat="server" />,
            <asp:Label ID="stateOrProvinceLabel" runat="server" />
            <asp:Label ID="zipCodeLabel" runat="server" /><br />
            <asp:Label ID="countryLabel" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            &nbsp;</td>
          <td>
            <asp:Button ID="changeInfoButton" runat="server" Text="Change user information" OnClick="ChangeInfoButton_OnClick" /></td>
        </tr>
      </table>
    </asp:Panel>
  </form>
</body>
</html>

