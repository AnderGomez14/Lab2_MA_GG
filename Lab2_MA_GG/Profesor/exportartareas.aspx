<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="exportartareas.aspx.cs" Inherits="Lab2_MA_GG.Alumno.exportartareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style1" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase WITH (nolock) INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE (ProfesoresGrupo.email = @email)">
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="email" />
        </SelectParameters>
    </asp:SqlDataSource>

    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True">
    </asp:GridView>

    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Exportar XML" OnClick="Button2_Click" />

    <asp:Button ID="Button3" runat="server" Text="Exportar JSON" OnClick="Button3_Click" />

    <br />

</asp:Content>
