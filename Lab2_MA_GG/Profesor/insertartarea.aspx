<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="insertartarea.aspx.cs" Inherits="Lab2_MA_GG.Profesor.insertartarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Código"></asp:Label>
<asp:TextBox ID="CodigoTextBox" runat="server" style="margin-left: 11px" Width="186px"></asp:TextBox>
<br />
<asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
<asp:TextBox ID="LabelTextBox" runat="server" Height="46px" style="margin-left: 23px" Width="362px"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label4" runat="server" Text="Asignatura  "></asp:Label>
<asp:DropDownList ID="AsignaturasDropBox" runat="server">
</asp:DropDownList>
<br />
<br />
<asp:Label ID="Label5" runat="server" Text="Horas Estimadas    "></asp:Label>
<asp:TextBox ID="HorasTextBox" runat="server" Height="20px" style="margin-left: 6px" Width="69px"></asp:TextBox>
<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="HorasTextBox" ErrorMessage="Introduzca caracter adecuado" ForeColor="#FF3300" MaximumValue="1000000000000" MinimumValue="0"></asp:RangeValidator>
<br />
<br />
<asp:Label ID="Label6" runat="server" Text="Tipo Tarea"></asp:Label>
<asp:DropDownList ID="TipoDropBox" runat="server" style="margin-left: 16px">
</asp:DropDownList>
<br />
<br />
<asp:Button ID="AñadirTarea" runat="server" Text="Añadir Tarea" />
<br />
<br />
</asp:Content>
