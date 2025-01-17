﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Dictados.aspx.cs" Inherits="UI.Web.Dictados" %>
<%@ Register src="UCBotones.ascx" tagname="UCBotones" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvDictados" runat="server" 
            AutoGenerateColumns="False" OnSelectedIndexChanged="gvCursos_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="DocenteId" HeaderText="ID_Docente" />
                <asp:BoundField DataField="Docente" HeaderText="Docente" />
                <asp:BoundField DataField="CursoId" HeaderText="ID_Curso" />
                <asp:BoundField DataField="Curso" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <uc1:UCBotones ID="UCBotones1" runat="server" Oneditar="linkEditar_Click" Oneliminar="linkEliminar_Click" Onnuevo="linkNuevo_Click" />
        <br />
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
            <asp:Label ID="lblDocente" runat="server" Text="Docente"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlDocentes" runat="server" DataValueField="ID">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="validDocente" runat="server" ControlToValidate="ddlDocentes" ErrorMessage="El docente no puede ser nulo." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="formDictados">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCurso" runat="server" Text="Curso"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlCursos" runat="server" DataValueField="ID">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="validCurso" runat="server" ControlToValidate="ddlCursos" ErrorMessage="El curso no puede ser nulo." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="formDictados">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCargo" runat="server" Text="Cargo"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddlCargos" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="validCargo" runat="server" ControlToValidate="ddlCargos" ErrorMessage="El cargo no puede ser nulo." ForeColor="Red" InitialValue="[Seleccionar]" ValidationGroup="formDictados">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" HeaderText="Error" ValidationGroup="formDictados" />
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="linkCancelar" runat="server" OnClick="linkCancelar_Click">Cancelar</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="linkAceptar" runat="server" OnClick="linkAceptar_Click">Aceptar</asp:LinkButton>
            </asp:Panel>
            <br />
        </asp:Panel>
</asp:Content>
