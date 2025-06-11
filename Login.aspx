<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="GovPortal.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Employee Login</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" /><br /><br />
        Employee ID: <asp:TextBox ID="txtEmpId" runat="server" /><br /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </form>
</body>
</html>
