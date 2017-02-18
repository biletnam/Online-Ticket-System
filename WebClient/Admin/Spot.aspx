<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Spot.aspx.cs" Inherits="WebClient.Admin.Spot" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="remindModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Reminder</h4>
                </div>
                <div class="modal-body">
                    <p>Ooops, unknown error occurs! Please try again.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button CssClass="btn btn-default" runat="server" data-dismiss="modal" Text="Close"/>
                </div>
             </div>
        </div>
    </div>

    <br />

    <div id="announcement" class="container">
      <div class="row">
        <div class="col-md-12 alert alert-info">
          <div class="text-center">
            <div class="row"><h4><Strong>Announcement</Strong></h4></div>
            <div class="row">It would be the best to upload a square image rather than retancle image</div>
          </div>
        </div>
      </div>
    </div>

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center"><h4>Add a new spot</h4></div>
            <div class="panel-body">
                <br />
                <div class="row">
                    <div class="form-horizontal">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="State" CssClass="col-md-2 control-label">State</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="State" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="State"
                                        CssClass="text-danger" ErrorMessage="The state field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ZipCode" CssClass="col-md-2 control-label">ZipCode</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="ZipCode" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ZipCode"
                                        CssClass="text-danger" ErrorMessage="The zipcode field is required." />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                                        CssClass="text-danger" ErrorMessage="The spot name field is required." />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-2 control-label">City</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="City" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                                        CssClass="text-danger" ErrorMessage="The city field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                                        CssClass="text-danger" ErrorMessage="The price field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Img" CssClass="col-md-2 control-label">Image</asp:Label>
                                <div class="col-md-10">
                                    <asp:FileUpload runat="server" ID="Img" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Img"
                                        CssClass="text-danger" ErrorMessage="The image is not uploaded yet." />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-horizontal">
                        <div class="col-sm-6">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Introduction" CssClass="col-md-2 control-label">Introduction</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Introduction" CssClass="form-control" TextMode="MultiLine" Rows="6" style="overflow:hidden"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Introduction"
                                    CssClass="text-danger" ErrorMessage="The introduction field is required." />
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnAddSpot" runat="server" class="btn btn-primary" OnClick="btnAddSpot_Click" Text="Submit" />
                </div>
            </div>
        </div>
    </div>
                
</asp:Content>
