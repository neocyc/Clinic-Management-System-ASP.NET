<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="PatientMedicalRecordsView.aspx.cs" Inherits="DBProject.Patient.PatientMedicalRecordsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MedicX 4 Health Care &amp; 我的病歷資料</title>

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
          
    <!--
    <script src="../assets/js/scripts.js"></script>
    -->

    <script type="text/javascript">
        //repaire bug of "scripts.js" use to "jquery.backstretch.min.js"
        jQuery(document).ready(function () {
            /*
            Fullscreen background
            */
            $.backstretch("../assets/img/backgrounds/PatientIndexPage.jpg");
        });
    </script>    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
				       
        <div  >    
        <!-- Top content -->
             	                                
        <div class="top-content"> 
            <div class="inner-bg">
               <div class="container">
                                                
                    <div class="row">
                                                	
                        <div class="col-sm-12">
                        	
                        	<div class="form-box">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>病歷資料</h3>
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
	                            		
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                       </div>

                           <div class="form-group">
								<label>姓名</label>
                                <br /><asp:TextBox ID="sName" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填寫姓名" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                     	                            
                            </div> 
							
							<div class="form-group">
								<label>身分證字號</label>
                                <asp:TextBox ID="sIDNo" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填寫身分證字號(第一個英文字母需大寫)"  maxlength="10" required data-checkIDcardnumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div> 
							
							<div class="form-group">
									<label>電話(家)</label>
                                    <asp:TextBox ID="sPhoneH" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填寫市話(XX-XXXXXXXX)"  maxlength="11" required data-checkPhonenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div> 
                            </div>
							
							<div class="form-group">
									<label>電話(手機)</label>
                                    <asp:TextBox ID="sPhoneM" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填寫手機號碼 (10 碼)"  maxlength="10" required data-checkMobilenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div> 
                            </div>                                           
                            
							<div class="form-group">
							     <label>性別 : <asp:Label ID="sGender" runat="server" Text="Label"></asp:Label></label><div class="help-block with-errors"></div>
                                              
                            </div>
							
							<div class="form-group">
								 <label>婚姻狀態 : <asp:Label ID="sMaritalStatus" runat="server" Text="Label"></asp:Label></label><div class="help-block with-errors"></div>
                                 
                            </div>
							
							<div class="form-group">
								<label>身高</label>
                                <asp:TextBox ID="sHeight" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請寫身高(單位 cm)"  maxlength="3" required data-checkDatanumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                        	                            
                            </div>
							
							<div class="form-group">
								<label>體重</label>
                                <asp:TextBox ID="sWeight" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請寫體重(單位 kg)"  maxlength="3" required data-checkDatanumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                        	                            
                            </div>

				            <div class="form-group">
								<label>出生日期</label>
                                <asp:TextBox ID="sBirthDate" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請點選出身日期(dd-mm-yyyy)" required></asp:TextBox>
           	                    <div class="help-block with-errors"></div>         
                            </div>
							
                            <div class="form-group">
								<label>郵遞區號</label>
                                <asp:TextBox ID="sZipcode" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填郵遞區號 (3 碼)"  maxlength="3" required data-checkDatanumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                        	                            
                            </div>

							<div class="form-group">
								<label>地址</label>
                                <asp:TextBox id="Address" disabled="disabled" placeholder ="請寫地址" TextMode="multiline" Columns="40" Rows="10" class="form-username form-control" runat="server" Height="75px" Width="100%" required />
                                <div class="help-block with-errors"></div>
                            </div>

				            <div class="form-group">
									<label>電子信箱(Email)</label>
                                    <asp:TextBox ID="sEmail" runat="server" disabled="disabled" type="email" class="form-username form-control" placeholder="Email : person@example.com" required></asp:TextBox>
                                    <div class="help-block with-errors"></div>
                            </div>

                            <div class="form-group">
								<label>緊急聯絡人姓名</label>
                                <asp:TextBox ID="sNameCE" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填姓名" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div>

                            <div class="form-group">
								<label>與病患關係</label>
                                <asp:TextBox ID="sCERelationship" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填關係" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div>

                            <div class="form-group">
									<label>緊急聯絡人電話</label>
                                    <asp:TextBox ID="sPhoneHEC" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填市話(XX-XXXXXXXX)"  maxlength="11" required data-checkPhonenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div>   
                            </div>
							
							<div class="form-group">
									<label>緊急聯絡人手機</label>
                                    <asp:TextBox ID="sPhoneMEC" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填行動電話 (10 碼)"  maxlength="10" required data-checkMobilenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div>   
                            </div>   
                               
                            <br />
                            <div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>初診病歷</h3>
	                            		
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                        </div>

                            <div class="form-group">
								<label>一、職業與工作</label>
                                <asp:TextBox ID="sJob" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填您的職業與工作" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div>
                            
                            <br />

							<div class="form-group">
								 <label>二、國籍  </label>
                                 <br /><label>所屬國籍 : <asp:Label ID="sNationality" runat="server" Text="Label"></asp:Label></label>
                                 <br /><label>是否為中國旅行團 : <asp:Label ID="sChineseNationalityTouring" runat="server" Text="Label"></asp:Label></label>
                                 <br /><label>中國旅行團編號  </label>
                                 <asp:TextBox ID="TouringNo" runat="server" disabled="disabled" type="text" class="form-username form-control" maxlength="10" required data-checkMobilenumber=" "></asp:TextBox>
                                 <label>外國國籍  </label>
                                 <asp:TextBox ID="sForeignNationality" runat="server" disabled="disabled" type="text" class="form-username form-control" maxlength="10" required data-checkMobilenumber=" "></asp:TextBox>
                                                                                             
                            </div>

                            <br />
                            
                            <div class="form-group">
                                <label>三、家族病史 </label><br />
                                <label>有無家族病史 : <asp:Label ID="sFamilyMedicalHistory" runat="server" Text="Label"></asp:Label></label>
                                                         
                            </div>

                            <label>家族病史描述  </label>
                            <asp:TextBox id="sFamilyMedicalHistoryDescription" disabled="disabled" TextMode="multiline" Columns="40" Rows="10" class="form-username form-control" runat="server" Height="75px" Width="100%" required />
                                                  
                             <div class="form-group">
								<br /><label>四、病史 </label>
                               
                                    <div class="form-group">
                                         <label>1.個人內科病史</label><div class="help-block with-errors"></div>
                                         <asp:TextBox id="sPersonalMedicalHistory" disabled="disabled" TextMode="multiline" Columns="40" Rows="10" class="form-username form-control" runat="server" Height="75px" Width="100%" required />
                                                                                                     
                                    </div>                                    
                                
                                    <div class="form-group">
                                         <label>2.個人手術史</label> <div class="help-block with-errors"></div>
                                         <label>是否曾經動過手術 : <asp:Label ID="sSurgeryMedical" runat="server" Text="Label"></asp:Label></label> 
                                         
                                    </div>     
								            <label>手術日期  </label>
                                            <asp:TextBox ID="sSurgeryDate" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請點選日期(dd-mm-yyyy)" ></asp:TextBox>           	                            
                                         
								            <label>病名  </label>
                                            <asp:TextBox ID="sDiseaseName" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請填寫病名" ></asp:TextBox>
                                    </div> 
                                    <br />
                                <div class="form-group">
								    <label>五、個人藥物過敏史 </label><div class="help-block with-errors"></div>
                                    <div class="form-group">
                                         <label>有無藥物過敏 : <asp:Label ID="sAllergyMedical" runat="server" Text="Label"></asp:Label></label>
                                          </div>
                                         <label>過敏症狀描述  </label>
                                            <asp:TextBox ID="sAllergyMedicalSymptom" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請描述症狀" ></asp:TextBox>
           	                            
                                </div>

                                    <br />
                                <div class="form-group">
								    <label>六、最近三個月旅遊史 </label><div class="help-block with-errors"></div>
                                   
                                            <asp:TextBox ID="sTourResume" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請描述旅遊歷程" ></asp:TextBox>                               
                                    
                                </div>

                                <div class="form-group">                                    
								    <label>七、目前之長期服用藥物 </label>                                   
                                        <div class="form-group ">                                            
                                            <asp:TextBox ID="sMedicinalName" runat="server" disabled="disabled" type="text" class="form-username form-control" placeholder="請描述藥物名稱" required></asp:TextBox>
           	                                <div class="help-block with-errors"></div>
                                        </div>                                 
                                </div>       
                            

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
  

       
</asp:Content>
