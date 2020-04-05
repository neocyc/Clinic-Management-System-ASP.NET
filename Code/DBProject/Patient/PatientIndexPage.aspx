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
                        
                            <h1><strong>MedicX 4 Health Care</strong> 首次登入 &amp; 填寫基本病歷表單</h1>
                            
                            <div class="description">
                            	<p>
	                            	這是一張<strong>"基本病歷表單"</strong> for Health Care Clinic.<br />如果你是首次登入註冊系統,請詳填此表單.感謝您的配合! 
                            	</p>                            
                            </div>
                        </div>
                    </div>

                    
                    <div class="row">
                                                	
                        <div class="col-sm-12">
                        	
                        	<div class="form-box">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>病歷表單</h3>
	                            		<p>完成登入步驟，請填寫此表單 : </p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                            </div>


	                            <div class="form-bottom">
				                    
                                    
                                    
                        <!-- sign up form start honay laga hai :)-->
                                    
                           <div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>基本資料</h3>
	                            		<p>請填寫以下表格 : </p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                       </div>

                           <div class="form-group">
								<label>姓名</label>
                                <asp:TextBox ID="sName" runat="server" type="text" class="form-username form-control" placeholder="請填寫姓名" ></asp:TextBox>
                                                       	                            
                            </div> 
							
							<div class="form-group">
								<label>身分證字號</label>
                                <asp:TextBox ID="sIDNo" runat="server" type="text" class="form-username form-control" placeholder="請填寫身分證字號" ></asp:TextBox>
                                                       	                            
                            </div> 
							
							<div class="form-group">
									<label>電話(家)</label>
                                    <asp:TextBox ID="sPhoneH" runat="server" type="text" class="form-username form-control" placeholder="請填寫市話" ></asp:TextBox>

                            </div>
							
							<div class="form-group">
									<label>電話(手機)</label>
                                    <asp:TextBox ID="sPhone" runat="server" type="text" class="form-username form-control" placeholder="請填寫手機號碼 (10 碼)" ></asp:TextBox>

                            </div>                         

                            <label>性別</label>
							<div class="form-group">
								
                                 <input type="radio" name="Gender" value="M" id="GenderDefault" checked="checked" />
                                  男
                                 <input type="radio" name="Gender" value="F" />
                                  女

                            </div>

							<label>婚姻狀態</label>
							<div class="form-group">
								
                                 <input type="radio" name="MaritalStatus" value="Married" id="MaritalStatusDefault" checked="checked" />
                                  已婚
                                 <input type="radio" name="MaritalStatus" value="Single" />
                                  單身

                            </div>
							
							<div class="form-group">
								<label>身高</label>
                                <asp:TextBox ID="sHeight" runat="server" type="text" class="form-username form-control" placeholder="請寫身高(單位 cm)" ></asp:TextBox>
                                                       	                            
                            </div>
							
							<div class="form-group">
								<label>體重</label>
                                <asp:TextBox ID="sWeight" runat="server" type="text" class="form-username form-control" placeholder="請寫體重(單位 kg)" ></asp:TextBox>
                                                       	                            
                            </div>

				            <div class="form-group">
								<label>出生日期</label>
                                <asp:TextBox ID="sBirthDate" runat="server" type="text" class="form-username form-control" placeholder="請點選出身日期(dd-mm-yyyy)" ></asp:TextBox>
           	                            
                            </div>
							
                            <div class="form-group">
								<label>郵遞區號</label>
                                <asp:TextBox ID="sZipcode" runat="server" type="text" class="form-username form-control" placeholder="請填郵遞區號 (3 碼)" ></asp:TextBox>
                                                       	                            
                            </div>

							<div class="form-group">
								<label>地址</label>
                                <asp:TextBox id="Address" placeholder ="請寫地址" TextMode="multiline" Columns="40" Rows="10" runat="server" Height="75px" Width="100%" />
        
                            </div>

				            <div class="form-group">
									<label>電子信箱(Email)</label>
                                    <asp:TextBox ID="sEmail" runat="server" type="text" class="form-username form-control" placeholder="Email : person@example.com" ></asp:TextBox>

                            </div>

                            <div class="form-group">
								<label>緊急聯絡人姓名</label>
                                <asp:TextBox ID="sNameCE" runat="server" type="text" class="form-username form-control" placeholder="請填姓名" ></asp:TextBox>
                                                       	                            
                            </div>

                            <div class="form-group">
								<label>與病患關係</label>
                                <asp:TextBox ID="sRelationship" runat="server" type="text" class="form-username form-control" placeholder="請填關係" ></asp:TextBox>
                                                       	                            
                            </div>

                            <div class="form-group">
									<label>緊急聯絡人電話</label>
                                    <asp:TextBox ID="sPhoneHEC" runat="server" type="text" class="form-username form-control" placeholder="請填市話" ></asp:TextBox>

                            </div>
							
							<div class="form-group">
									<label>緊急聯絡人手機</label>
                                    <asp:TextBox ID="sPhoneEC" runat="server" type="text" class="form-username form-control" placeholder="請填行動電話 (10 碼)" ></asp:TextBox>

                            </div>   
                                    
                            <div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>初診病歷</h3>
	                            		<p>請填寫以下表格 : </p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                        </div>

                            <div class="form-group">
								<label>職業與工作 :</label>
                                <asp:TextBox ID="sJob" runat="server" type="text" class="form-username form-control" placeholder="請填您的職業與工作" ></asp:TextBox>
                                                       	                            
                            </div>
                            
                            <br />
                            <label>國籍 :</label>
							<div class="form-group">
								
                                 <input type="checkbox" name="Nationality" value="Nationality of origin" id="NationalityDefault" />
                                  本國<br />
                                 <input type="checkbox" name="Nationality" value="Chinese nationality" />
                                  中國
                                     
                                    <br /><label>旅行團</label>
                                     <div class="form-group">
                                         <input type="radio" name="ChineseNationality" value="N" id="ChineseNationalityDefault" />
                                          No
                                         <input type="radio" name="ChineseNationality" value="Y" />
                                          Yes
                                         <br />團號 <asp:TextBox ID="TouringNo" runat="server" type="text" class="form-username form-control" placeholder="請填寫旅行團團號" ></asp:TextBox>
                                     </div>

                                 <input type="checkbox" name="Nationality" value="Nationality of foreign" />
                                  外國
                                 <br /><label>國家</label>
                                 <asp:TextBox ID="sNationality" runat="server" type="text" class="form-username form-control" placeholder="請填你的國籍/國家" ></asp:TextBox>
                            </div>

                            <br />
                            <label>家族病史 :</label>
                            <div class="form-group">
                                <input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />
                                 No
                                <input type="radio" name="FamilyMedicalHistory" value="Y" />
                                 Yes
                            </div>
                            <table class="table table-bordered">
                              <caption>如有相關病史，請勾選下列表格</caption>
                              <thead>
                                <tr>
                                  <th>項目</th>
                                  <th>父</th>
                                  <th>母</th>
                                  <th>子</th>
                                  <th>女</th>
                                </tr>
                              </thead>
                              <tbody>
                                <tr>
                                  <td>高血壓</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                </tr>
                                <tr>
                                  <td>心血管</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                </tr>
                                <tr>
                                  <td>糖尿病</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                </tr>
                                  <tr>
                                  <td>痛風</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                </tr>
                                  <tr>
                                  <td>氣喘過敏</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                  <td><input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />No<br /><input type="radio" name="FamilyMedicalHistory" value="Y" />Yes</td>
                                </tr>
                                  <tr>
                                  <td>其他</td>
                                  <td><input type="radio" name="OtherFDefault" value="N" id="OtherFDefault" />No<br /><input type="radio" name="OtherFDefault" value="Y" />Yes</td>
                                  <td><input type="radio" name="OtherMDefault" value="N" id="OtherMDefault" />No<br /><input type="radio" name="OtherMDefault" value="Y" />Yes</td>
                                  <td><input type="radio" name="OtherSDefault" value="N" id="OtherSDefault" />No<br /><input type="radio" name="OtherSDefault" value="Y" />Yes</td>
                                  <td><input type="radio" name="OtherDDefault" value="N" id="OtherDDefault" />No<br /><input type="radio" name="OtherDDefault" value="Y" />Yes</td>
                                </tr>
                              </tbody>
                            </table>


                            <asp:button Text ="完成註冊"  runat="server" type="submit" class="btn btn-primary" OnClientClick="return validateS();" onclick="signupV"></asp:button>
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
