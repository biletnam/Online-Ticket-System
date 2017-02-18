<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebClient.Account.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="remindModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Reminder</h4>
                </div>
                <div class="modal-body">
                    <p>This email has been used!</p>
                </div>
                <div class="modal-footer">
                    <asp:Button CssClass="btn btn-default" runat="server" data-dismiss="modal" Text="Close"/>
                </div>
             </div>
        </div>
    </div>

    <div id="remindCapchaModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Reminder</h4>
                </div>
                <div class="modal-body">
                    <p>Captcha dosen't match!</p>
                </div>
                <div class="modal-footer">
                    <asp:Button CssClass="btn btn-default" runat="server" data-dismiss="modal" Text="Close"/>
                </div>
             </div>
        </div>
    </div>

    <br />

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center"><h4>Registration</h4></div>
            <div class="panel-body">

                <br />
                <h4>Basic information</h4>

                <hr />
                <div class="row">

                    <div class="form-horizontal">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="First" CssClass="col-md-2 control-label">First</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="First" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="First" CssClass="text-danger" ErrorMessage="The first name field is required." />
                                </div>
                            </div>
                        </div>
            
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Last" CssClass="col-md-2 control-label">Last</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Last" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Last" CssClass="text-danger" ErrorMessage="The last name field is required." />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <h4>Verify information</h4>
                <hr />
                <div class="row">

                    <div class="form-horizontal">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Image ID="image" runat="server" />
                            </div>
                        </div>
            
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Capcha" CssClass="col-md-2 control-label">Capcha</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Capcha" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Last" CssClass="text-danger" ErrorMessage="The capcha field is required." />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <h4>Login information</h4>
                <hr />
                <div class="row">

                    <div class="form-horizontal">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
                                </div>
                            </div>
                        </div>
            
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The password field is required." />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm Password</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password is required." />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Password and confirm password must be matched." />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <hr />
                <div class="text-center">
                    <asp:Button ID="btnRegister" runat="server" class="btn btn-primary" OnClick="btnRegister_Click" Text="Submit" />
                    <br />
                    <asp:LinkButton ID="linkBtn" Visible="false" runat="server" OnClick="linkBtn_Click">Success! Go to login</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
