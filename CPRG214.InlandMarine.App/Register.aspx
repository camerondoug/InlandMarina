<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CPRG214.InlandMarine.App.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
      <h3>Register with Us</h3>
    <div class="col-md-4">
        <table class="table">
            <tr>
                <td style="width:150px">First Name:</td>
                <td>
                    <asp:TextBox ID="uxFirstname" runat="server"></asp:TextBox>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name is Required" ControlToValidate="uxFirstname" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Lastname:</td>
                <td>
                    <asp:TextBox ID="uxLastname" runat="server"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name is Required" ControlToValidate="uxLastname" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
             <tr>
                <td>Phone:</td>
                <td>
                    <asp:TextBox ID="uxPhone" runat="server"></asp:TextBox>
                </td>
                 <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Phone Number is Required" ControlToValidate="uxPhone" ForeColor="Red">*</asp:RequiredFieldValidator> </td>
            </tr>
            <tr>
                <td>City:</td>
                <td>
                    <asp:TextBox ID="uxCity" runat="server"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="City is Required" ControlToValidate="uxCity" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="uxAuthenticate" runat="server" Text="Authenticate" OnClick="uxAuthenticate_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="uxError" ForeColor="Red" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
    </div>
</asp:Content>
