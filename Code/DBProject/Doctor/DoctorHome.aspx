<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/doctormaster.Master" AutoEventWireup="true" CodeBehind="DoctorHome.aspx.cs" Inherits="doctor.doctorhome" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>Doctor's Home</title>

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
    <script src="../assets/js/jquery.backstretch.min.js"></script>

    <script type="text/javascript">
        //repaire bug of "scripts.js" use to "jquery.backstretch.min.js"
        jQuery(document).ready(function () {
            /*
            Fullscreen background
            */
            $.backstretch("../assets/img/backgrounds/PatientHome.jpg");
        });
    </script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="Cp1" runat="server">


    <div >

            <h1>Your Profile</h1>

             <div class="top-content"> 
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-box">
                            <div class="form-top">
                                <div class="form-top-left">

                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-pencil"></i>

                                </div>

                            </div>    
                            <div class="form-bottom">      

                                <div class="form-group">
            <h3>Name:       <asp:label id="Label1" runat="server"   Font-Bold="true" Font-Size="Medium"  /> </h3>   
            </div>
                                <div class="form-group">
                                    <h4>Phone:      <asp:label id="Label2" runat="server"   Font-Bold="true" Font-Size="Medium"  /> </h4>
               </div>
                                <div class="form-group">
                                    <h4> Address: <asp:label id="Label3" runat="server" Font-Bold="true" Font-Size="Medium"   />  </h4>
             </div>
                                <div class="form-group">
            <h4> BirthDate:   <asp:label id="Label4" runat="server"  Font-Bold="true" Font-Size="Medium" /></h4>
                                    </div>
            <div class="form-group">
            <h4>Gender:  <asp:label id="Label5" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>  
            <div class="form-group">

                <div class="form-group">
                <h4>Department No: <asp:label id="Label6" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
                    </div>
           <div class="form-group">
           <h4>Charges Per Visit: <asp:label id="Label7" runat="server"   Font-Bold="true" Font-Size="Medium"  /> </h4>
            </div>
               <div class="form-group">
               <h4>Monthly Salary: <asp:label id="Label8" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
           </div>
                <div class="form-group">
           <h4>Repute Index: <asp:label id="Label9" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
            </div>
                  <div class="form-group">  
                    <h4>Patients Treated: <asp:label id="Label10" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
           </div>
          
                <div class="form-group">
            <h4>Qualification: <asp:label id="Label11" runat="server"   Font-Bold="true" Font-Size="Medium"  />  </h4>
            </div>

                <div class="form-group">
                    <h4>Specialization: <asp:label id="Label12" runat="server"   Font-Bold="true" Font-Size="Medium"  />    </h4>
            </div>

                <div class="form-group">
                    <h4>Work Experience: <asp:label id="Label13" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
            </div>

                <div class="form-group">
                    <h4>Status: <asp:label id="Label14" runat="server"   Font-Bold="true" Font-Size="Medium"  /></h4>
                </div>                
                </div>
                        </div>

                    </div>

                </div>

            </div>

             </div>

    </div>
                 </div>
        </div>
    
    </asp:Content>