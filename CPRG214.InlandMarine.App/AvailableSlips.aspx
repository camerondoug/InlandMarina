<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvailableSlips.aspx.cs" Inherits="CPRG214.InlandMarine.App.AvailableSlips" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Available Leases</h3>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Select Dock"></asp:Label>
    <br />
    <asp:DropDownList ID="uxDocks" runat="server" OnSelectedIndexChanged="uxDocks_SelectedIndexChanged1" AutoPostBack="True" Width="194px"></asp:DropDownList>
        <br />
    <asp:Label ID="Label3" runat="server" Text="Available Slips on Selected Dock"></asp:Label>
    
    <asp:GridView ID="uxSlipsGridview" runat="server">
    </asp:GridView>
</asp:Content>
