<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="MyTextBoxApplication.UserInfo" %>
<b>Information about <%=this.UserName%></b>
<br />
<br />
<%: this.UserName %> is <%: this.UserAge %> years old and lives in <%: this.UserCountry %>