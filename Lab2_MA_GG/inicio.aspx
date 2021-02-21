<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Lab2_MA_GG.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 50%; margin-left: 40%; margin-right: 10%;">
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" ControlToValidate="EmailTextBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage=" Escribe un Email " />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage=" Escriba un correo valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="PassTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PassTextBox" ErrorMessage=" Escribe la contraseña " />
                        <asp:RegularExpressionValidator ID="passwordcheck1" runat="server" ControlToValidate="PassTextBox" ErrorMessage=" La contraseña no es valida, minimo 6 caracteres" ValidationExpression="^[\s\S]{6,50}$" ValidationGroup="CambiarPass" />

                    </td>
                </tr>
            </table>
            <div style="width: 100%; text-align: center;">
                <br />
                <asp:Label ID="Feedback" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/register.aspx">Registrarse </asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/cambiarPassword.aspx">Modificar Contraseña</asp:HyperLink>
                <br />
                <br />
                <img src="https://i.imgur.com/xdT6gxU.gif" style="max-height: 170px;">
            </div>

        </div>
    </form>
</body>
</html>
