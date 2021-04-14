<%@ Page Title="" Language="C#" MasterPageFile="~/Profesor/ProfesorMaster.Master" AutoEventWireup="true" CodeBehind="tareasprofesor.aspx.cs" Inherits="Lab2_MA_GG.Profesor.tareasprofesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Seleccionar asignatura"></asp:Label>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT GruposClase.codigoasig FROM GruposClase WITH (nolock) INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE (ProfesoresGrupo.email = @email)">
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="email" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DropAsignaturas" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoasig" DataValueField="codigoasig" OnSelectedIndexChanged="DropAsignaturas_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-10ConnectionString %>" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo" DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)">
                <DeleteParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Codigo" Type="String" />
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="CodAsig" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropAsignaturas" Name="CodAsig" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Descripcion" Type="String" />
                    <asp:Parameter Name="CodAsig" Type="String" />
                    <asp:Parameter Name="HEstimadas" Type="Int32" />
                    <asp:Parameter Name="Explotacion" Type="Boolean" />
                    <asp:Parameter Name="TipoTarea" Type="String" />
                    <asp:Parameter Name="Codigo" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo" DataSourceID="SqlDataSource2" enableeventvalidation="false" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <br />
            <asp:Button ID="Button2" runat="server" Height="50px" OnClick="Button2_Click" Text="INSERTAR NUEVA TAREA" />
            <ajaxToolkit:ConfirmButtonExtender ID="Button2_ConfirmButtonExtender" runat="server" BehaviorID="Button2_ConfirmButtonExtender" ConfirmText="Seguro que quieres añadir una tarea?" TargetControlID="Button2" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <br />
</asp:Content>
