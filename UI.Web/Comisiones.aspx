﻿<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<%@ Register src="UCBotones.ascx" tagname="UCBotones" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvComisiones" runat="server" 
            AutoGenerateColumns="False" OnSelectedIndexChanged="gvComisiones_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Comisión" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" />
                <asp:BoundField DataField="Plan.Descripcion" HeaderText="Descripción Plan" />
                <asp:CommandField HeaderText="Seleccionar" SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
        <uc1:UCBotones ID="UCBotones2" runat="server" Oneditar="linkEditar_Click" Oneliminar="linkEliminar_Click" Onnuevo="linkNuevo_Click"/>
        <br />
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
            <asp:Label ID="lblAnio" runat="server" Text="Año Especialidad:"></asp:Label>
            <asp:TextBox ID="txtAnio" runat="server" type="number" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validAnio" runat="server" ErrorMessage="El año no puede estar vacio" ForeColor="Red" ControlToValidate="txtAnio" ValidationGroup="formComisiones">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblDescripcion" runat="server" Text="Número de comisión:"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" type="number" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validDescripcion" runat="server" ErrorMessage="La descripción no puede estar vacia" ForeColor="Red" ControlToValidate="txtDescripcion" ValidationGroup="formComisiones">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblPlan" runat="server" Text="Plan:"></asp:Label>
            <asp:DropDownList ID="ddlPlan" runat="server" DataTextField="Descripcion" DataValueField="ID">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="validPlan" runat="server" ErrorMessage="El plan no puede estar vacio" ForeColor="Red" ControlToValidate="ddlPlan" InitialValue="[Seleccionar]" ValidationGroup="formComisiones">*</asp:RequiredFieldValidator>
            <br />
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" HeaderText="Error" ValidationGroup="formComisiones" />
            <asp:Panel ID="formActionsPanel" runat="server">
                <asp:LinkButton ID="linkCancelar" runat="server" OnClick="linkCancelar_Click">Cancelar</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="linkAceptar" runat="server" OnClick="linkAceptar_Click">Aceptar</asp:LinkButton>
            </asp:Panel>
            <br />
        </asp:Panel>
</asp:Content>