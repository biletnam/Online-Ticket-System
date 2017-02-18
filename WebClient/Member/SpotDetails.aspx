<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SpotDetails.aspx.cs" Inherits="WebClient.Member.SpotDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="remindModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Reminder</h4>
                </div>
                <div class="modal-body">
                    <p>Your ticket is </p>
                    <asp:Label ID="lab_ticket" runat="server"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:Button CssClass="btn btn-default" runat="server" data-dismiss="modal" Text="Close"/>
                </div>
             </div>
        </div>
    </div>
    
    <br />

    <div class="row">
        <div class="col-sm-3">
            <asp:Image runat="server" ID="image" />
        </div>
        <div class="col-sm-6">
            <div class="row">
                <div class="col-sm-9">
                    <div class="row">
                        <asp:Label ID="name" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:Label ID="address" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="row">
                        <asp:Label ID="price" runat="server" ForeColor="Orange"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div class="row">
                <asp:Label ID="introduction" runat="server"></asp:Label>
            </div>
        </div>
    </div>

    <br />
    <br />

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center"><h4>Weather Forcast for coming serval days</h4></div>
            <div class="panel-body">
                <asp:Table ID="table_weather" runat="server" CssClass="table" Visible="false">
                    <asp:TableRow>
                        <asp:TableCell><Strong>Date</Strong></asp:TableCell>
                        <asp:TableCell><Strong>Weather</Strong></asp:TableCell>
                        <asp:TableCell><Strong>Temperature</Strong></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
    </div>

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center"><h4>Some stores near the attraction</h4></div>
            <div class="panel-body">
                <asp:Table ID="table_store" runat="server" CssClass="table" Visible="false">
                    <asp:TableRow>
                        <asp:TableCell><Strong>Business</Strong></asp:TableCell>
                        <asp:TableCell><Strong>Distance</Strong></asp:TableCell>
                        <asp:TableCell><Strong>Vicinity</Strong></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
    </div>

    <br />

    <div class="text-center">
        <asp:Button ID="btnOrder" runat="server" class="btn btn-primary" OnClick="btnOrder_Click" Text="Order" />
    </div>

</asp:Content>
