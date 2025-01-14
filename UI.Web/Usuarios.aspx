﻿<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<%@ Register src="UCBotones.ascx" tagname="UCBotones" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script runat = "server" >
        void ValidarRegexClave(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Util.Validaciones.ValidarRegexClave(args.Value);
        }
        </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField HeaderText="Nombre" DataField="PersonaNombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="PersonaApellido" />
                    <asp:BoundField HeaderText="EMail" DataField="PersonaEMail" />
                    <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
            <br />
            <uc1:UCBotones ID="UCBotones1" runat="server" Oneditar="linkEditar_Click" Oneliminar="linkEliminar_Click" Onnuevo="linkNuevo_Click"/>
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Visible="False">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="validUsuario" runat="server" ErrorMessage="El usuario no puede estar vacio" ForeColor="Red" ControlToValidate="txtUsuario" ValidationGroup="formUsuario">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblPersona" runat="server" Text="Persona: "></asp:Label>
            <asp:DropDownList ID="ddlPersona" runat="server" DataTextField="NombreCompleto" DataValueField="ID">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
            &nbsp;<asp:CustomValidator ID="validClave" runat="server" ControlToValidate="txtClave" ErrorMessage="La contraseñas debe tener entre 4 y 50 caracteres." ForeColor="Red" OnServerValidate="ValidarRegexClave" ValidateEmptyText="True" ValidationGroup="formUsuario">*</asp:CustomValidator>
            <br />
            <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="txtRepetirClave" runat="server"></asp:TextBox>
            &nbsp;<asp:CompareValidator ID="validRepetirClaveCoincide" runat="server" ControlToCompare="txtClave" ControlToValidate="txtRepetirClave" ErrorMessage="Las contraseñas no coinciden." ForeColor="Red" ValidationGroup="formUsuario">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="validRepetirClaveObligatorio" runat="server" ControlToValidate="txtRepetirClave" ErrorMessage="Las contraseñas no coinciden." ForeColor="Red" ValidationGroup="formUsuario">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="chkHabilitado" runat="server" />
            <br />
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" HeaderText="Error" ValidationGroup="formUsuario" />
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="linkCancelar" runat="server" OnClick="linkCancelar_Click">Cancelar</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="linkAceptar" runat="server" OnClick="linkAceptar_Click">Aceptar</asp:LinkButton>
            </asp:Panel>
        </asp:Panel>
</asp:Content>

    
