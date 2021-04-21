<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="coordinador.aspx.cs" Inherits="Lab2_MA_GG.Manage.coordinador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Seleccionar asignatura"></asp:Label>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropAsignaturas" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" OnSelectedIndexChanged="DropAsignaturas_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            La dedicacion media de esta asignatura es igual a:
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
