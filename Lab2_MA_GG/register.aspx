<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Lab2_MA_GG.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 188px;
        }

        .auto-style3 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            REGISTRO DE USUARIOS<table style="width: 30%;">
                <tr>
                    <td class="auto-style1">Email</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Nombre</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Apellido</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Password</td>
                    <td>
                        <asp:TextBox ID="TextBox4" TextMode="Password" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Repetir Password</td>
                    <td>
                        <asp:TextBox ID="TextBox5" TextMode="Password" runat="server" Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Rol</td>
                    <td>
                        <asp:RadioButton ID="AlumnoButton" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Alumno" />
                        <br />
                        <asp:RadioButton ID="ProfesorButton" runat="server" Text="Profesor" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Registrarse" Width="255px" />
        </div>
    </form>
</body>
</html>
