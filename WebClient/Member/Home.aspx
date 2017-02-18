<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebClient.Member.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-body">
                <div id="Tabs" role="tabpanel">
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="active"><a href="#info" aria-controls="info" role="tab" data-toggle="tab">Info</a></li>
                        <li><a href="#spots" aria-controls="spots" role="tab" data-toggle="tab">Spots</a></li>
                    </ul>

                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active" id="info">
                            <br />
                            <asp:Label ID="username" runat="server"></asp:Label>
                            <br />
                            <asp:Table ID="table_info" runat="server" CssClass="table" Visible="false">
                                <asp:TableRow>
                                    <asp:TableCell><Strong>Attraction</Strong></asp:TableCell>
                                    <asp:TableCell><Strong>Verificaton</Strong></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>

                        <div role="tabpanel" class="tab-pane" id="spots">
                            <br />
                            <asp:DataList ID="spotList" runat="server" RepeatColumns="5"
                                RepeatDirection="Horizontal" BorderColor="#DCDCDC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="1" GridLines="Both">
                                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="true" ForeColor="#663399" />
                                <ItemTemplate>
                                    <div style="text-align: center">
                                        <div>
                                            <asp:ImageButton runat="server" OnClick="imgBtn_Click" ImageUrl='<%#"../ImgCache/" + Eval("name") + ".jpg" %>'
                                                CommandArgument='<%# Eval("location.state") + "|" + Eval("location.city") + "|" + Eval("location.zipcode") + "|" + 
                                          Eval("name")  + "|" + Eval("introduction") + "|" + Eval("price") %>' />
                                        </div>
                                        <div><strong><%# Eval("name") %></strong></div>
                                        <div><%# Eval("location.city")%>, <%# Eval("location.state")%></div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>
</asp:Content>

