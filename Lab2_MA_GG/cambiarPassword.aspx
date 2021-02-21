<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Lab2_MA_GG.CambiarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <div id="request" runat="server">
        <form id="formReset" runat="server">
            Email del usuario a recuperar:
            <asp:TextBox ID="email" runat="server" Width="203px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="emailerror" runat="server" ControlToValidate="email" ErrorMessage="Escribe un correo" ValidationGroup="Resetear" />
            <asp:Label ID="ErrorReset" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="buttonReset" runat="server" Text="Resetear Contraseña" ValidationGroup="Resetear" OnClick="buttonReset_Click" />
        </form>
    </div>
    <div id="change" runat="server">
        <form id="formChange" runat="server">

            <table>
                <tr>
                    <td class="auto-style1">Password</td>
                    <td>
                        <asp:TextBox ID="password1" TextMode="Password" runat="server" Width="210px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="password1" ErrorMessage="  Escribe una contraseña " ValidationGroup="CambiarPass" /><br />
                        <asp:RegularExpressionValidator ID="passwordcheck1" runat="server" ControlToValidate="password1" ErrorMessage="La contraseña no es valida, minimo 6 caracteres" ValidationExpression="^[\s\S]{6,50}$" ValidationGroup="CambiarPass" />
                    </td>
                </tr>
                <tr>
                    <td>Repetir Password</td>
                    <td>
                        <asp:TextBox ID="password2" TextMode="Password" runat="server" Width="210px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password2" ErrorMessage=" Escriba de nuevo la contraseña " ValidationGroup="CambiarPass" /><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password1" ControlToValidate="password2" ErrorMessage="Las contraseñas no coinciden" ValidationGroup="CambiarPass"></asp:CompareValidator>

                    </td>
                </tr>
            </table>
            <asp:Button ID="changeButton" runat="server" Text="Cambiar Contraseña" ValidationGroup="CambiarPass" OnClick="changeButton_Click" />
        </form>

    </div>
</body>
</html>
