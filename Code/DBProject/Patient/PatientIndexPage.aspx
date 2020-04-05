<%@ Page Title="" Language="C#" MasterPageFile="~/IndexPageLogin.Master" AutoEventWireup="true" CodeBehind="PatientIndexPage.aspx.cs" Inherits="DBProject.Patient.PatientIndexPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>MedicX 4 Health Care Login &amp; Register</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >

   


 <script type="text/javascript">


     //----------------------Function1-----------------------------//
     function validateEmail(Email) {
         if (Email == "") {
             alert("Email missing. Enter Email.");
             return false;
         }

         else if (Email.indexOf("@") == -1 || Email.indexOf(".com") == -1) {
             alert("Your email address seems incorrect. Please enter a new one.");
             return false;
         }

         else {
             var location = Email.indexOf("@");

             if (Email[0] == '@' || Email[location + 1] == '.') {
                 alert("Your email address seems incorrect. Please enter a new one.");
                 return false;
             }

             var emailPat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
             var EmailmatchArray = Email.match(emailPat);

             if (EmailmatchArray == null) {
                 alert("Your email address seems incorrect. Please enter a new one.");
                 return false;
             }
         }

         return true;
     }






     //----------------------Function2-----------------------------//
     function validateS() {
         var Name = document.getElementById('<%=sName.ClientID %>').value;

         var Bdate = document.getElementById('<%=sBirthDate.ClientID %>').value;
         var Bdate_st = changeDate(Bdate);

         var Email = document.getElementById('<%=sEmail.ClientID %>').value;
         var phone = document.getElementById('<%=sPhone.ClientID %>').value;
         var pass = document.getElementById('<%=sPassword.ClientID %>').value;
         var cpass = document.getElementById('<%=scPassword.ClientID %>').value;

         /*now the validation code*/

         if (Name == "") {
             alert("Name missing. Enter Name.");

             if (Bdate == "") {
                 var Bdate_a = document.getElementById('<%=sBirthDate.ClientID %>');
                 Bdate_a.type = "text";
             }

             return false;
         }


         var arrDbirth = Bdate_st.split("-");

         if (Bdate == "") {
             alert("Birth Date missing. Enter Birth Date.");

             var Bdate_a = document.getElementById('<%=sBirthDate.ClientID %>');
             Bdate_a.type = "text";

             return false;
         }

         else if ((Bdate_st == arrDbirth[0]) || (arrDbirth[0].length != 2) || arrDbirth[1].length != 2 || arrDbirth[2].length != 4 || !arrDbirth[0].match(/^[0-9]*$/) || !arrDbirth[1].match(/^[0-9]*$/) || !arrDbirth[2].match(/^[0-9]*$/) || Number(arrDbirth[0]) > 31 || Number(arrDbirth[1]) > 12) {
             alert("Birth Date Format Incorrect or out of Range.");

             var Bdate_a = document.getElementById('<%=sBirthDate.ClientID %>');
             Bdate_a.type = "text";

             return false;
         }


         if (!validateEmail(Email))
             return false;


         if (pass == "" || cpass == "") {
             alert("Password field is empty.");
             return false;
         }

         else if (pass != cpass) {
             alert("Passwords do not match.");
             return false;
         }


         if (phone.length != 11) {
             alert("Phone number should be of 11 digits.");
             return false;
         }


         if (Request.Form["Gender"] == null) {
             alert("Gender not selected.");
             return false;
         }

         return true;
     }






     //----------------------Function4-----------------------------//
     //input date string ,conversion the string to date format dd-mm-yyyy
     function changeDate(date) {
         var y = date.substr(0, 4);
         var m = date.substr(5, 2);
         var d = date.substr(8, 2);

         return d + '-' + m + '-' + y;
     }






    

     //------------------------------------------------------------------//
     //------------------------------------------------------------------//
     //------------------------------------------------------------------//

</script>


    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../assets/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../assets/css/form-elements.css"/>
    <link rel="stylesheet" href="../assets/css/style.css"/>

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="assets/ico/favicon.png"/>
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
    <script src="../assets/js/scripts.js"></script>

</head>



<body>

    
				       
        <div>    
        <!-- Top content -->
             	                                
        <div class="top-content"> 
            <div class="inner-bg">
               <div class="container">
                    
                   <div class="row">
                         <div class="col-sm-8 col-sm-offset-2 text">
                        
                            <h1><strong>MedicX 4 Health Care</strong> first Login &amp; Fill Patient Information Form</h1>
                            
                            <div class="description">
                            	<p>
	                            	This is a <strong>"Patient Information form"</strong> for Health Care Clinic.<br />If you are first Login,please fill this form.Thank you! 
                            	</p>                            
                            </div>
                        </div>
                    </div>

                    
                    <div class="row">
                                                	
                        <div class="col-sm-12">
                        	
                        	<div class="form-box">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>Patient Information form</h3>
	                            		<p>Fill in the form below to finish Login Step:</p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                            </div>


	                            <div class="form-bottom">
				                    
                                    
                                    
                        <!-- sign up form start honay laga hai :)-->
                                    
                                    
                           <div class="form-group">
								<label>Name</label>
                                <asp:TextBox ID="sName" runat="server" type="text" class="form-username form-control" placeholder="Name" ></asp:TextBox>
                                                       	                            
                            </div> 
							
							<div class="form-group">
								<label>Identification Number</label>
                                <asp:TextBox ID="sIDNo" runat="server" type="text" class="form-username form-control" placeholder="Identification Number" ></asp:TextBox>
                                                       	                            
                            </div> 
							
							<div class="form-group">
									<label>TEL</label>
                                    <asp:TextBox ID="sPhoneH" runat="server" type="text" class="form-username form-control" placeholder="Phone Number" ></asp:TextBox>

                            </div>
							
							<div class="form-group">
									<label>Mobile</label>
                                    <asp:TextBox ID="sPhone" runat="server" type="text" class="form-username form-control" placeholder="Mobile Number (10 Digits)" ></asp:TextBox>

                            </div>
							
                            <div class="form-group">
									<label>Password</label>
                                    <asp:TextBox ID="sPassword" runat="server" type="password" class="form-username form-control" placeholder="Enter New Password" ></asp:TextBox>

                            </div>


                            <div class="form-group">
									<label>Confirm Password</label>
                                    <asp:TextBox ID="scPassword" runat="server" type="password" class="form-username form-control" placeholder="Confirm Password" ></asp:TextBox>

                            </div>
                                                                
                            <div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>General Information</h3>
	                            		<p>Please fill in the form:</p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                        </div>

                            <label>Gender</label>
							<div class="form-group">
								
                                 <input type="radio" name="Gender" value="M" id="GenderDefault" checked="checked" />
                                  Male
                                 <input type="radio" name="Gender" value="F" />
                                  Female

                            </div>

							<label>Marital Status</label>
							<div class="form-group">
								
                                 <input type="radio" name="MaritalStatus" value="Married" id="MaritalStatusDefault" checked="checked" />
                                  Married
                                 <input type="radio" name="MaritalStatus" value="Single" />
                                  Single

                            </div>
							
							<div class="form-group">
								<label>Height</label>
                                <asp:TextBox ID="sHeight" runat="server" type="text" class="form-username form-control" placeholder="Height(cm)" ></asp:TextBox>
                                                       	                            
                            </div>
							
							<div class="form-group">
								<label>Weight</label>
                                <asp:TextBox ID="sWeight" runat="server" type="text" class="form-username form-control" placeholder="Weight(kg)" ></asp:TextBox>
                                                       	                            
                            </div>

				            <div class="form-group">
								<label>BirthDate</label>
                                <asp:TextBox ID="sBirthDate" runat="server" type="text" class="form-username form-control" placeholder="Birth Date (dd-mm-yyyy)" ></asp:TextBox>
           	                            
                            </div>
							
                            <div class="form-group">
								<label>Zip code</label>
                                <asp:TextBox ID="sZipcode" runat="server" type="text" class="form-username form-control" placeholder="Zip code" ></asp:TextBox>
                                                       	                            
                            </div>

							<div class="form-group">
								<label>Address</label>
                                <asp:TextBox id="Address" placeholder ="Address" TextMode="multiline" Columns="40" Rows="10" runat="server" Height="75px" Width="100%" />
        
                            </div>

				            <div class="form-group">
									<label>Email</label>
                                    <asp:TextBox ID="sEmail" runat="server" type="text" class="form-username form-control" placeholder="Email : person@example.com" ></asp:TextBox>

                            </div>

                            <div class="form-group">
								<label>Contact in emergency of Name</label>
                                <asp:TextBox ID="sNameCE" runat="server" type="text" class="form-username form-control" placeholder="Name" ></asp:TextBox>
                                                       	                            
                            </div>

                            <div class="form-group">
								<label>Relationship with patient</label>
                                <asp:TextBox ID="sRelationship" runat="server" type="text" class="form-username form-control" placeholder="Relationship" ></asp:TextBox>
                                                       	                            
                            </div>

                            <div class="form-group">
									<label>Contact in emergency of TEL</label>
                                    <asp:TextBox ID="sPhoneHEC" runat="server" type="text" class="form-username form-control" placeholder="Phone Number" ></asp:TextBox>

                            </div>
							
							<div class="form-group">
									<label>Contact in emergency of Mobile</label>
                                    <asp:TextBox ID="sPhoneEC" runat="server" type="text" class="form-username form-control" placeholder="Mobile Number (10 Digits)" ></asp:TextBox>

                            </div>   
                                    
                            <div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>Personal Information</h3>
	                            		<p>Please fill in the form:</p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                        </div>

                            <div class="form-group">
								<label>Job and Work :</label>
                                <asp:TextBox ID="sJob" runat="server" type="text" class="form-username form-control" placeholder="Fill your job" ></asp:TextBox>
                                                       	                            
                            </div>

                            <label>Nationality :</label>
							<div class="form-group">
								
                                 <input type="checkbox" name="Nationality" value="Nationality of origin" id="NationalityDefault" />
                                  Nationality of origin<br />
                                 <input type="checkbox" name="Nationality" value="Chinese nationality" />
                                  Chinese nationality
                                 <div class="form-group">
                                     <input type="radio" name="ChineseNationality" value="N" id="ChineseNationalityDefault" />
                                      No
                                     <input type="radio" name="ChineseNationality" value="Y" />
                                      Yes
                                     <br />
                                 </div>
                                 <input type="checkbox" name="Nationality" value="Nationality of foreign" />
                                  Nationality of foreign
                                 <br /><label>Country :</label>
                                 <asp:TextBox ID="sNationality" runat="server" type="text" class="form-username form-control" placeholder="Fill your Country of Citizenship" ></asp:TextBox>
                            </div>

                                    <asp:button Text ="Finish SignUp"  runat="server" type="submit" class="btn btn-primary" OnClientClick="return validateS();" onclick="signupV"></asp:button>
                    <!-- sign up ends here -->
                                            
                               </div>
                           </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
 

        <!-- Footer -->
        <footer>
        	<div class="container">
        		<div class="row">
        			
        			<div class="col-sm-8 col-sm-offset-2">
        				<div class="footer-border"></div>
        				<p>If you have any query, please feel free to contact us. <i class="fa fa-smile-o"></i></p>
                    </div>
        			
        		</div>
        	</div>
        </footer>

       
        </div>
  


</body>
</html>

</asp:Content>
