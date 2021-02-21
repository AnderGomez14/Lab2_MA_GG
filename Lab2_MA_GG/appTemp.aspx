<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appTemp.aspx.cs" Inherits="Lab2_MA_GG.appTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email del objeto Session:
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            <br />
            <asp:Button ID="CerrarSesionButton" runat="server" Text="Cerrar Sesion" OnClick="CerrarSesionButton_Click" />

        </div>
    </form>
</body>
</html>
