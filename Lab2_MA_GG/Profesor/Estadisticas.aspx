<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="Lab2_MA_GG.Profesor.Estadisticas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="TareasTotal" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Numero de entregas realizadas en total:
    <asp:Label ID="TareasTotales" runat="server"></asp:Label>
    <br />
    Horas totales registradas por el alumno: 
    <asp:Label ID="HorasTotal" runat="server"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="email" AutoPostBack="True">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT * FROM [Usuarios] WHERE ([tipo] = @tipo)">
        <SelectParameters>
            <asp:Parameter DefaultValue="Alumno" Name="tipo" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT COUNT(*) FROM [EstudiantesTareas] WHERE ([Email] = @Email)">
        <SelectParameters>
            <asp:Parameter DefaultValue="Alumno" Name="tipo" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    Numero de entregas realizadas por el alumno:
    <asp:Label ID="TareasAlumno" runat="server"></asp:Label>
    <br />
    Horas totales registradas por el alumno: 
    <asp:Label ID="HorasTotalAlumno" runat="server"></asp:Label>
    <br />
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
        <Series>
            <asp:Series Name="Series1" YValueMembers="HReales" XValueMember="CodTarea">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT [HReales], [CodTarea] FROM [EstudiantesTareas] WHERE ([Email] = @Email)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="Email" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
