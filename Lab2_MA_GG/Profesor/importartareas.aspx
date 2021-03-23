<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="importartareas.aspx.cs" Inherits="Lab2_MA_GG.Profesor.importartareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-bottom: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style1" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase WITH (nolock) INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE (ProfesoresGrupo.email = @email)">
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="email" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Xml ID="Xml1" runat="server"></asp:Xml>
    <br />
    <asp:Label ID="Feedback" runat="server"></asp:Label>
    <br />
    <br />
    <input id="file" type="file" runat="server" name="file">
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Importar (XMLD)" OnClick="Button2_Click" />
    <asp:Button ID="Button1" runat="server" Text="Importar (JSON)" OnClick="Button1_Click" />

</asp:Content>
