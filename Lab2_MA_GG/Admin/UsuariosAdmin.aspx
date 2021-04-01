<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="Lab2_MA_GG.Admin.TareasAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" DeleteCommand="DELETE FROM [Usuarios] WHERE [email] = @original_email AND [nombre] = @original_nombre AND [apellidos] = @original_apellidos AND [confirmado] = @original_confirmado AND [pass] = @original_pass AND [tipo] = @original_tipo" InsertCommand="INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [confirmado], [pass], [tipo]) VALUES (@email, @nombre, @apellidos, @confirmado, @pass, @tipo)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [email], [nombre], [apellidos], [confirmado], [pass], [tipo] FROM [Usuarios] WHERE ([email] &lt;&gt; @email)" UpdateCommand="UPDATE [Usuarios] SET [nombre] = @nombre, [apellidos] = @apellidos, [confirmado] = @confirmado, [pass] = @pass, [tipo] = @tipo WHERE [email] = @original_email AND [nombre] = @original_nombre AND [apellidos] = @original_apellidos AND [confirmado] = @original_confirmado AND [pass] = @original_pass AND [tipo] = @original_tipo">
        <DeleteParameters>
            <asp:Parameter Name="original_email" Type="String" />
            <asp:Parameter Name="original_nombre" Type="String" />
            <asp:Parameter Name="original_apellidos" Type="String" />
            <asp:Parameter Name="original_confirmado" Type="Boolean" />
            <asp:Parameter Name="original_pass" Type="String" />
            <asp:Parameter Name="original_tipo" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="apellidos" Type="String" />
            <asp:Parameter Name="confirmado" Type="Boolean" />
            <asp:Parameter Name="pass" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="nombre" Type="String" />
            <asp:Parameter Name="apellidos" Type="String" />
            <asp:Parameter Name="confirmado" Type="Boolean" />
            <asp:Parameter Name="pass" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="original_email" Type="String" />
            <asp:Parameter Name="original_nombre" Type="String" />
            <asp:Parameter Name="original_apellidos" Type="String" />
            <asp:Parameter Name="original_confirmado" Type="Boolean" />
            <asp:Parameter Name="original_pass" Type="String" />
            <asp:Parameter Name="original_tipo" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email" />
            <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
            <asp:BoundField DataField="apellidos" HeaderText="apellidos" SortExpression="apellidos" />
            <asp:CheckBoxField DataField="confirmado" HeaderText="confirmado" SortExpression="confirmado" />
            <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
            <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo" />
            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
