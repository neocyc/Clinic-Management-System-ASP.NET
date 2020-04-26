<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="PatientHome.aspx.cs" Inherits="DBProject.PatientHome" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>Patient's Home</title>

<!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../assets/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../assets/css/form-elements.css"/>
    <link rel="stylesheet" href="../assets/css/style.css"/>

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="../assets/ico/favicon.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="../assets/ico/apple-touch-icon-57-precomposed.png"/>
        
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <!-- Javascript -->
    <script src="../assets/js/jquery-1.11.1.min.js"></script>
    <script src="../assets/bootstrap/js/bootstrap.min.js"></script>    

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div style="background-image:url(/assets/img/backgrounds/PatientHome.jpg); background-position:center; background-size:20px">

        <br />
        <h1><strong>Your Information</strong></h1>
        <br /><br />

         
                                <table class="table table-bordered">
                                  <caption></caption>
                                  <thead>
                                    <tr class="info">
                                      <th></th>
                                      <th></th>
                                      
                                    </tr>
                                  </thead>
                                  <tbody>
                                    <tr class="success">
                                      <td><h4><strong>Name: </strong></h4></td>
                                      <td><asp:Label ID="PName" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr class="success">
                                      <td> <h4><strong>Phone: </strong></h4></td>
                                      <td> <asp:Label ID="PPhone" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                     <tr class="success">
                                      <td><h4><strong>Birth Date: </strong></h4></td>
                                      <td><asp:Label ID="PBirthDate" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr class="success">
                                      <td><h4><strong>Age: </strong></h4></td>
                                      <td><asp:Label ID="PatientAge" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr class="success">
                                      <td><h4><strong>Gender:</strong></h4></td>
                                      <td><asp:Label ID="PGender" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr class="success">
                                      <td><h4><strong>Address: </strong></h4></td>
                                      <td><asp:Label ID="PAddress" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                  </tbody>
                                </table>
                         



    
    </div>

</asp:Content>
