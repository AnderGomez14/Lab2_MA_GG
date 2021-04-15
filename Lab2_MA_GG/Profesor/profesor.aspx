<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="profesor.aspx.cs" Inherits="Lab2_MA_GG.Profesor.profesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 style="text-align: center">Gestión Web de Tareas-Dedicacion</h2>
    <br />
    <h2 style="text-align: center">Profesores</h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:Gravatar ID="Gravatar1" runat="server" Size="200" DefaultImageBehavior="Identicon" DefaultImage="https://upload.wikimedia.org/wikipedia/commons/1/1a/Bertin_biografia.jpg" Style="margin-left: 200px; max-height: 200px; display: block; margin: auto;" />
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
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
