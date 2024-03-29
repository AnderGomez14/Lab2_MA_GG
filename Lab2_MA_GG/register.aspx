﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Lab2_MA_GG.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 40%;
            padding-left: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            REGISTRO DE USUARIOS
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <table style="width: 70%; margin-left: 20%; margin-right: auto;">
                        <tr>
                            <td>Email</td>
                            <td>
                                <asp:TextBox ID="EmailTextBox" runat="server" Width="100%" OnTextChanged="EmailTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="emailerror" runat="server" ControlToValidate="EmailTextBox" ErrorMessage=" Escribe un correo" />
                                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage=" Escriba un correo valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>Nombre</td>
                            <td>
                                <asp:TextBox ID="NombreTextBox" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox" ErrorMessage=" Escribe un nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td>Apellido</td>
                            <td>
                                <asp:TextBox ID="ApellidoTextBox" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ApellidoTextBox" ErrorMessage=" Escribe un apellido" />
                            </td>
                        </tr>
                        <tr>
                            <td>Password</td>
                            <td>
                                <asp:TextBox ID="PassTextBox" TextMode="Password" runat="server" Width="100%" OnTextChanged="PassTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PassTextBox" ErrorMessage="  Escribe una contraseña " /><br />
                                <asp:RegularExpressionValidator ID="passwordcheck1" runat="server" ControlToValidate="PassTextBox" ErrorMessage="La contraseña no es valida, minimo 6 caracteres" ValidationExpression="^[\s\S]{6,50}$" />
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Repetir Password</td>
                            <td>
                                <asp:TextBox ID="Pass2TextBox" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Pass2TextBox" ErrorMessage=" Escriba de nuevo la contraseña " /><br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="PassTextBox" ControlToValidate="Pass2TextBox" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>

                            </td>
                        </tr>
                        <tr>
                            <td>Rol</td>
                            <td>
                                <asp:RadioButtonList ID="TipoButtonList" runat="server">
                                    <asp:ListItem>Profesor</asp:ListItem>
                                    <asp:ListItem>Alumno</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style3">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TipoButtonList" ErrorMessage=" Elige un Rol" />
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; text-align: center;">
                        <br />
                        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Registrarse" Width="255px" OnClick="Register_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
