<%@ Page Title="" Language="C#" MasterPageFile="~/Alumno/AlumnoMaster.Master" AutoEventWireup="true" CodeBehind="tareasalumno.aspx.cs" Inherits="Lab2_MA_GG.Alumno.TareasAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
            <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
            <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
            <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
            <asp:BoundField DataField="Instanciar" HeaderText="Instanciar" HtmlEncode="False" />
        </Columns>
    </asp:GridView>
</asp:Content>
