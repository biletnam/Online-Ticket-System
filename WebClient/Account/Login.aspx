<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebClient.Account.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="remindModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Reminder</h4>
                </div>
                <div class="modal-body">
                    <p>Invalid login information!</p>
                </div>
                <div class="modal-footer">
                    <asp:Button CssClass="btn btn-default" runat="server" data-dismiss="modal" Text="Close"/>
                </div>
             </div>
        </div>
    </div>

    <h2><%: Title %>.</h2>
    <hr />

    <div class="row">

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="btn btn-primary" />
                    &nbsp;&nbsp;
                    <asp:HyperLink NavigateUrl="~/Account/Register.aspx" runat="server" Text="Register"></asp:HyperLink>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
