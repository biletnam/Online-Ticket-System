<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div id="announcement" class="container">
      <div class="row">
        <div class="col-md-12 alert alert-info">
          <div class="row text-center"><h4><Strong>Announcement</Strong></h4></div>
          <br />
          <div class="row"><strong>Introduction:</strong></div>
          <div class="row">Our application is a online-ticket system enabling customers to browse each spot and process
              order he/she is interested in. Also, weather service and POI is running to obtain real-time weather information and
              near stores in each spot.
          </div>
          <br />
          <div class="row"><strong>User:</strong></div>
          <div class="row">We have four admins including group members and TA. Haisheng Lin:(hlin86@asu.edu , "123456"); Jiadong Xia:
              (jxia19@asu.edu, "123456"); Mengyuan Zhang:(mzhan123@asu.edu, "123456"); TA:(TA, "CSE445598ta!"). End users can click "Log in"
              to sign in or "Register" to sign up.
          </div>
          <br />
          <div class="row"><strong>Testing:</strong></div>
          <div class="row">After login please click "staff" or "spot" to add new item into system (you must be admin). Click "Member"
              to scan spots and order ticket.
          </div>
          <br />
          <div class="row"><strong>Contribution:</strong></div>
          <div class="row">Haisheng Lin: features of adding attraction; displaying details of selected spot; weather service; POI service to 
              search near stores; Encryption and decryption operations with XML file, wrapped into DLL file
          </div>
          <div class="row">Jiadong Xia: Login and register; Ticket order and searching ordered ticket information.
          </div>
        </div>
      </div>
    </div>

    <div class="row text-center">
        <asp:HyperLink NavigateUrl="~/Account/Login.aspx" runat="server" Text="Click Here to Start"></asp:HyperLink>
    </div>

</asp:Content>
