<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Lab2_MA_GG.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 50;">
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx">Registrarse</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server">Modificar Contraseña</asp:HyperLink>
        </div>
    </form>
</body>
</html>
