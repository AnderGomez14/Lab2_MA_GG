﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Lab2_MA_GG.inicio" %>

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
                        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage=" Escribe un Email" />
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PassTextBox" ErrorMessage=" Escribe la contraseña" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="Feedback" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx">Registrarse </asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/cambiarPassword.aspx">Modificar Contraseña</asp:HyperLink>
        </div>
    </form>
</body>
</html>