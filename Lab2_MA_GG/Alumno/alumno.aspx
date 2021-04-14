<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/AlumnoMaster.Master" AutoEventWireup="true" CodeBehind="alumno.aspx.cs" Inherits="Lab2_MA_GG.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Gestión Web de Tareas-Dedicacion</h2>
    <br />
    <h2 style="text-align: center">Alumnos</h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="5000">
            </asp:Timer>
            <p style="text-align: center">
                Usuarios en linea:
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </p>
            <p style="text-align: center">
                <asp:ListBox ID="ListBoxAlumnos" runat="server" Width="171px"></asp:ListBox>
                <asp:ListBox ID="ListBoxProfesores" runat="server" Width="171px"></asp:ListBox>

            </p>
            <p style="text-align: center">
                &nbsp;
            </p>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



