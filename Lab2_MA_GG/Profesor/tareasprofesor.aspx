<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="tareasprofesor.aspx.cs" Inherits="Lab2_MA_GG.Profesor.tareasprofesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Seleccionar asignatura"></asp:Label>
    <br />
    <asp:DropDownList ID="DropAsignaturas" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Height="50px" Text="INSERTAR NUEVA TABLA" OnClick="~/Profesor/tareasprofesor.aspx" PostBackUrl="~/Profesor/insertartarea.aspx"/>
    <br />
    <br />
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
