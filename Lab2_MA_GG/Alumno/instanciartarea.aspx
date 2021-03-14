<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/AlumnoMaster.Master" AutoEventWireup="true" CodeBehind="instanciartarea.aspx.cs" Inherits="Lab2_MA_GG.Alumno.instanciartarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 30%; margin-left: 42%; margin-right: auto;">
        <tr>
            <td>Usuario</td>
            <td style="width: 40%">
                <asp:TextBox ID="EmailTextBox" runat="server" Width="100%" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="emailerror" runat="server" ControlToValidate="EmailTextBox" ErrorMessage=" Escribe un Usuario" />
            </td>
        </tr>
        <tr>
            <td>Tarea</td>
            <td>
                <asp:TextBox ID="TareaTextBox" runat="server" Width="100%" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TareaTextBox" ErrorMessage=" Escribe un Tarea" />
            </td>
        </tr>
        <tr>
            <td>Horas estimadas</td>
            <td>
                <asp:TextBox ID="HorasEstimadasTextBox" runat="server" Width="100%" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="HorasEstimadasTextBox" ErrorMessage=" Escribe una duracion" />
            </td>
        </tr>
        <tr>
            <td>Horas Dedicadas</td>
            <td>
                <asp:TextBox ID="HorasDedicadasTextBox" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="HorasDedicadasTextBox" ErrorMessage="  Escribe una duracion " /><br />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div align="center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True">
        </asp:GridView>
        <br />
        <asp:Label ID="Feedback" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Instanciar Tarea" Style="text-align: center" />
    </div>
</asp:Content>
