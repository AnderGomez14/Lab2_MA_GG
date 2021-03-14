<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="insertartarea.aspx.cs" Inherits="Lab2_MA_GG.Profesor.insertartarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>
    <asp:TextBox ID="CodigoTextBox" runat="server" Style="margin-left: 11px" Width="186px"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
    <asp:TextBox ID="DescripcionTextBox" runat="server" Height="46px" Style="margin-left: 23px" Width="362px"></asp:TextBox>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase WITH (nolock) INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE (ProfesoresGrupo.email = @email)">
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="email" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Asignatura  "></asp:Label>
    <asp:DropDownList ID="AsignaturasDropBox" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Horas Estimadas    "></asp:Label>
    <asp:TextBox ID="HorasTextBox" runat="server" Height="20px" Style="margin-left: 6px" Width="69px"></asp:TextBox>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="HorasTextBox" ErrorMessage="Introduzca caracter adecuado" ForeColor="#FF3300" MaximumValue="1000000000000" MinimumValue="0"></asp:RangeValidator>
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT DISTINCT [TipoTarea] FROM [TareasGenericas]"></asp:SqlDataSource>
    <br />
    <%--<asp:Label ID="Label6" runat="server" Text="Tipo Tarea"></asp:Label>--%>
    <asp:DropDownList ID="TipoDropBox" runat="server" Style="margin-left: 16px" DataSourceID="SqlDataSource2" DataTextField="TipoTarea" DataValueField="TipoTarea">
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Label ID="Feedback" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="AñadirTarea" runat="server" Text="Añadir Tarea" OnClick="AñadirTarea_Click" />
    <br />
    <br />
</asp:Content>
