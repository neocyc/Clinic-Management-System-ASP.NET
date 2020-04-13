<%@ Page Title="" Language="C#" MasterPageFile="~/IndexPageLogin.Master" AutoEventWireup="true" CodeBehind="PatientIndexPage.aspx.cs" Inherits="DBProject.PatientIndexPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MedicX 4 Health Care 首次登入 &amp; 填寫基本病歷表單</title>

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
    

    <!--引用 Validator-->
    <script src="../assets/bootstrap/js/plugin/validator.min.js"></script>
    <script src="../assets/bootstrap/js/plugin/bootstrap-validator.js"></script>
    
    <!--Script function-->
    <script type="text/javascript">

        function validatetest()
        {
            var form = document.getElementById("SignUpPage");

            var checkboxTotal = form.Nationality.length;

            for (i = 0; i < checkboxTotal; i++) {
                var checkboxState = form.Nationality[i].checked;

                if (checkboxState == true) {
                    break;
                }

                if (i == (checkboxTotal - 1)) {
                    alert("尚未勾選國籍. 請勾選國籍(複選).");
                    return false;
                }
            }

            for (i = 0; i < checkboxTotal; i++) {
                var checkboxState = form.Nationality[i].checked;
                if (checkboxState == true) {
                    if (i == 1) {
                        var checkStateCN = form.ChineseNationality.value;
                        if (checkStateCN == "") {
                            alert("尚未勾選旅行團. 請選擇旅行團");
                            return false;
                        }

                        if (checkStateCN == "Y") {
                            var TouringNo = document.getElementById('<%=TouringNo.ClientID %>');
                            //TouringNo.setAttribute("required");
                        }
                    }

                    if (i == 2) {
                        var Nationality = document.getElementById('<%=sNationality.ClientID %>');
                        Nationality.setAttribute("required","");
                    }
                }
            }            
        }

        //----------------------Function1-----------------------------//
        ////check Form feature: "checkbox","radiobox" and "input type=date"
        function validateS() {
            var form = document.getElementById("SignUpPage");

            var checkStateG = form.Gender.value;
            if (checkStateG == "") {
                alert("尚未勾選性別. 請選擇性別");
                return false;
            }

            var checkStateM = form.MaritalStatus.value;
            if (checkStateM == "") {
                alert("尚未勾選婚姻狀態. 請選擇婚姻狀態");
                return false;
            }            

            var Bdate = document.getElementById('<%=sBirthDate.ClientID %>').value;
            var Bdate_st = changeDate(Bdate);

            var Sdate = document.getElementById('<%=sSurgeryDate.ClientID %>').value;
            var Sdate_st = changeDate(Sdate);
            
            var arrDbirth1 = Bdate_st.split("-");
            var arrDbirth2 = Sdate_st.split("-");

            if (Bdate == "") {
                alert("尚未輸入生日. 請選擇生日日期.");

                var Bdate_a = document.getElementById('<%=sBirthDate.ClientID %>');
                Bdate_a.type = "text";

                return false;
            }
            else if ((Bdate_st == arrDbirth1[0]) || (arrDbirth1[0].length != 2) || arrDbirth1[1].length != 2 || arrDbirth1[2].length != 4 || !arrDbirth1[0].match(/^[0-9]*$/) || !arrDbirth1[1].match(/^[0-9]*$/) || !arrDbirth1[2].match(/^[0-9]*$/) || Number(arrDbirth1[0]) > 31 || Number(arrDbirth1[1]) > 12) {
                alert("生日日期格式錯誤. 請重新輸入生日.");

                var Bdate_a = document.getElementById('<%=sBirthDate.ClientID %>');
                Bdate_a.type = "text";

                return false;
            }

            var checkboxTotal = form.Nationality.length;

            for (i = 0; i < checkboxTotal;i++)
            {
                var checkboxState = form.Nationality[i].checked;

                if (checkboxState == true)
                {
                    break;
                }

                if (i == (checkboxTotal - 1)) {
                    alert("尚未勾選國籍. 請勾選國籍(複選).");
                    return false;
                }
            }

            for (i = 0; i < checkboxTotal; i++) {
                var checkboxState = form.Nationality[i].checked;
                if (checkboxState == true) {
                    if (i == 1)
                    {
                        var checkStateCN = form.ChineseNationality.value;
                        if (checkStateCN == "") {
                            alert("尚未勾選旅行團. 請選擇旅行團");
                            return false;
                        }                    

                        if (checkStateCN == "Y")
                        {
                            var TouringNo = document.getElementById('<%=TouringNo.ClientID %>');
                            TouringNo.setAttribute("required","");
                        }
                    }

                    if (i == 2)
                    {
                        var Nationality = document.getElementById('<%=sNationality.ClientID %>');
                        Nationality.setAttribute("required","");
                    }
                }              
            }

            var checkStateFMH = form.FamilyMedicalHistory.value;
            if (checkStateFMH == "") {
                alert("尚未勾選家族病史. 請選擇家族病史");
                return false;
            }

            var checkStateI = form.InternalMedical.value;
            if (checkStateI == "") {
                alert("尚未勾選個人內科病史. 請選擇個人內科病史");
                return false;
            }

            var checkStateS = form.SurgeryMedical.value;
            if (checkStateS == "") {
                alert("尚未勾選個人手術史. 請選擇個人手術史");
                return false;
            }

            if (Sdate == "") {
                alert("尚未輸入日期. 請選擇手術日期.");

                var Sdate_a = document.getElementById('<%=sSurgeryDate.ClientID %>');
                Sdate_a.type = "text";

                return false;
            }
            else if ((Sdate_st == arrDbirth2[0]) || (arrDbirth2[0].length != 2) || arrDbirth2[1].length != 2 || arrDbirth2[2].length != 4 || !arrDbirth2[0].match(/^[0-9]*$/) || !arrDbirth2[1].match(/^[0-9]*$/) || !arrDbirth2[2].match(/^[0-9]*$/) || Number(arrDbirth2[0]) > 31 || Number(arrDbirth2[1]) > 12) {
                alert("手術日期格式錯誤. 請重新輸入日期.");

                var Sdate_a = document.getElementById('<%=sSurgeryDate.ClientID %>');
                Sdate_a.type = "text";

                return false;
            }

            var checkStateA = form.AllergyMedical.value;
            if (checkStateA == "") {
                alert("尚未勾選個人藥物過敏史. 請選擇個人藥物過敏史");
                return false;
            }

            var checkStateT = form.Touring.value;
            if (checkStateT == "") {
                alert("尚未勾選旅遊史. 請選擇旅遊史");
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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="SignUpPage" data-toggle="validator" runat="server">
    
				       
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
                                <asp:TextBox ID="sName" runat="server" type="text" class="form-username form-control" placeholder="請填寫姓名" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                     	                            
                            </div> 
							
							<div class="form-group">
								<label>身分證字號</label>
                                <asp:TextBox ID="sIDNo" runat="server" type="text" class="form-username form-control" placeholder="請填寫身分證字號(第一個英文字母需大寫)" required maxlength="10" data-checkIDcardnumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div> 
							
							<div class="form-group">
									<label>電話(家)</label>
                                    <asp:TextBox ID="sPhoneH" runat="server" type="text" class="form-username form-control" placeholder="請填寫市話(XX-XXXXXXXX)" required maxlength="11" data-checkPhonenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div> 
                            </div>
							
							<div class="form-group">
									<label>電話(手機)</label>
                                    <asp:TextBox ID="sPhoneM" runat="server" type="text" class="form-username form-control" placeholder="請填寫手機號碼 (10 碼)" required maxlength="10" data-checkMobilenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div> 
                            </div>                         

                            <label>性別</label>
							<div class="form-group">
								
                                 <input type="radio" name="Gender" value="M" id="GenderDefault" />
                                  男
                                 <input type="radio" name="Gender" value="F" />
                                  女

                            </div>

							<label>婚姻狀態</label>
							<div class="form-group">
								
                                 <input type="radio" name="MaritalStatus" value="Married" id="MaritalStatusDefault" />
                                  已婚
                                 <input type="radio" name="MaritalStatus" value="Single" />
                                  單身

                            </div>
							
							<div class="form-group">
								<label>身高</label>
                                <asp:TextBox ID="sHeight" runat="server" type="text" class="form-username form-control" placeholder="請寫身高(單位 cm)" required maxlength="3" data-checkDatanumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                        	                            
                            </div>
							
							<div class="form-group">
								<label>體重</label>
                                <asp:TextBox ID="sWeight" runat="server" type="text" class="form-username form-control" placeholder="請寫體重(單位 kg)" required maxlength="3" data-checkDatanumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                        	                            
                            </div>

				            <div class="form-group">
								<label>出生日期</label>
                                <asp:TextBox ID="sBirthDate" runat="server" type="text" class="form-username form-control" placeholder="請點選出身日期(dd-mm-yyyy)" required></asp:TextBox>
           	                    <div class="help-block with-errors"></div>         
                            </div>
							
                            <div class="form-group">
								<label>郵遞區號</label>
                                <asp:TextBox ID="sZipcode" runat="server" type="text" class="form-username form-control" placeholder="請填郵遞區號 (3 碼)" required maxlength="3" data-checkDatanumber=" "></asp:TextBox>
                                <div class="help-block with-errors"></div>                        	                            
                            </div>

							<div class="form-group">
								<label>地址</label>
                                <asp:TextBox id="Address" placeholder ="請寫地址" TextMode="multiline" Columns="40" Rows="10" class="form-username form-control" runat="server" Height="75px" Width="100%" required />
                                <div class="help-block with-errors"></div>
                            </div>

				            <div class="form-group">
									<label>電子信箱(Email)</label>
                                    <asp:TextBox ID="sEmail" runat="server" type="email" class="form-username form-control" placeholder="Email : person@example.com" required></asp:TextBox>
                                    <div class="help-block with-errors"></div>
                            </div>

                            <div class="form-group">
								<label>緊急聯絡人姓名</label>
                                <asp:TextBox ID="sNameCE" runat="server" type="text" class="form-username form-control" placeholder="請填姓名" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div>

                            <div class="form-group">
								<label>與病患關係</label>
                                <asp:TextBox ID="sCERelationship" runat="server" type="text" class="form-username form-control" placeholder="請填關係" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div>

                            <div class="form-group">
									<label>緊急聯絡人電話</label>
                                    <asp:TextBox ID="sPhoneHEC" runat="server" type="text" class="form-username form-control" placeholder="請填市話(XX-XXXXXXXX)" required maxlength="11" data-checkPhonenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div>   
                            </div>
							
							<div class="form-group">
									<label>緊急聯絡人手機</label>
                                    <asp:TextBox ID="sPhoneMEC" runat="server" type="text" class="form-username form-control" placeholder="請填行動電話 (10 碼)" required maxlength="10" data-checkMobilenumber=" "></asp:TextBox>
                                    <div class="help-block with-errors"></div>   
                            </div>   
                               
                            <br />
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
								<label>一、職業與工作 :</label>
                                <asp:TextBox ID="sJob" runat="server" type="text" class="form-username form-control" placeholder="請填您的職業與工作" required></asp:TextBox>
                                <div class="help-block with-errors"></div>                       	                            
                            </div>
                            
                            <br />
                            <label>二、國籍 :</label>
							<div class="form-group">
								
                                 <input type="checkbox" name="Nationality" value="Nationality of origin" id="NationalityDefault" />
                                  本國<br />
                                 <input type="checkbox" name="Nationality" value="Chinese nationality" />
                                  中國
                                     
                                    <br /><label>旅行團</label>
                                     <div class="form-group">
                                         <input type="radio" name="ChineseNationality" value="Y" />
                                          Yes
                                         <input type="radio" name="ChineseNationality" value="N" id="ChineseTouringDefault" />
                                          No
                                         <br />團號 <asp:TextBox ID="TouringNo" runat="server" type="text" class="form-username form-control" placeholder="請填寫旅行團團號" ></asp:TextBox>
                                         <div class="help-block with-errors"></div>
                                     </div>

                                 <input type="checkbox" name="Nationality" value="Nationality of foreign" />
                                  外國
                                 <br /><label>國家</label>
                                 <asp:TextBox ID="sNationality" runat="server" type="text" class="form-username form-control" placeholder="請填你的國籍/國家" ></asp:TextBox>
                                 <div class="help-block with-errors"></div>
                            </div>

                            <br />
                            <label>三、家族病史 :</label>
                            <div class="form-group">
                                <input type="radio" name="FamilyMedicalHistory" value="Y" />
                                 Yes
                                <input type="radio" name="FamilyMedicalHistory" value="N" id="FamilyMedicalHistoryDefault" />
                                 No
                            </div>

                            <div class="form-group">
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
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH11,父親有高血壓" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH12,母親有高血壓" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH13,兒子有高血壓" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH14,女兒有高血壓" /></td>
                                    </tr>
                                    <tr>
                                      <td>心血管</td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH21,父親有心血管疾病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH22,母親有心血管疾病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH23,兒子有心血管疾病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH24,女兒有心血管疾病" /></td>
                                    </tr>
                                    <tr>
                                      <td>糖尿病</td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH31,父親有糖尿病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH32,母親有糖尿病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH33,兒子有糖尿病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH34,女兒有糖尿病" /></td>
                                    </tr>
                                      <tr>
                                      <td>痛風</td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH41,父親有痛風" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH42,母親有痛風" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH43,兒子有痛風" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH44,女兒有痛風" /></td>
                                    </tr>
                                      <tr>
                                      <td>氣喘過敏</td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH51,父親有氣喘過敏" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH52,母親有氣喘過敏" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH53,兒子有氣喘過敏" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH54,女兒有氣喘過敏" /></td>
                                    </tr>
                                      <tr>
                                      <td>其他</td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH61,父親有其他疾病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH62,母親有其他疾病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH63,兒子有其他疾病" /></td>
                                      <td><input type="checkbox" name="FamilyMedicalHistory" value="FMH64,女兒有其他疾病" /></td>
                                    </tr>
                                  </tbody>
                                </table>
                             </div>

                             <div class="form-group">
								<label>四、病史 :</label>
                                <br /><label>1.個人內科病史</label>
                                <div class="form-group">
                                         <input type="radio" name="InternalMedical" value="Y" />
                                          Yes
                                         <input type="radio" name="InternalMedical" value="N" id="InternalMedicalDefault" />
                                          No
                                         <br />
                                         <div class="form-group">
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH01,抽菸" id="PersonalMedicalHistoryDefault" />
                                              抽菸
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH02,喝酒" />
                                              喝酒
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH03,嚼檳榔" />
                                              嚼檳榔
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH04,高血壓" />
                                              高血壓
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH05,糖尿病" />
                                              糖尿病
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH06,B肝" />
                                              B肝
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH07,C肝" />
                                              C肝
                                             <br /><input type="checkbox" name="PersonalMedicalHistory" value="PMH08,心血管疾病" />
                                              心血管疾病
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH09,氣喘" />
                                              氣喘
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH10,過敏" />
                                              過敏
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH11,痛風" />
                                              痛風
                                             <input type="checkbox" name="PersonalMedicalHistory" value="PMH12,其他疾病" />
                                              其他
                                         </div>
                                </div>
                                <label>2.個人手術史</label>
                                <div class="form-group">
                                         <input type="radio" name="SurgeryMedical" value="Y" />
                                          Yes
                                         <input type="radio" name="SurgeryMedical" value="N" id="SurgeryMedicalDefault" />
                                          No
                                         <div class="form-group">
								            <label>日期</label>
                                            <asp:TextBox ID="sSurgeryDate" runat="server" type="text" class="form-username form-control" placeholder="請點選日期(dd-mm-yyyy)" ></asp:TextBox>
           	                            
                                         </div>
                                    
                                         <div class="form-group">
								            <label>病名</label>
                                            <asp:TextBox ID="sDiseaseName" runat="server" type="text" class="form-username form-control" placeholder="請填寫病名" ></asp:TextBox>
                                         </div>
                                </div>             
                                <div class="form-group">
								    <label>五、個人藥物過敏史 :</label>
                                    <div class="form-group">
                                         <input type="radio" name="AllergyMedical" value="Y" />
                                          Yes
                                         <input type="radio" name="AllergyMedical" value="N" id="AllergyMedicalDefault" />
                                          No
                                         <div class="form-group">
                                            <asp:TextBox ID="sAllergyMedicalSymptom" runat="server" type="text" class="form-username form-control" placeholder="請描述症狀" ></asp:TextBox>
           	                            
                                         </div>

                                    </div>
                                </div>

                                <div class="form-group">
								    <label>六、最近三個月旅遊史 :</label>
                                    <div class="form-group">
                                         <input type="radio" name="Touring" value="Y" />
                                          Yes
                                         <input type="radio" name="Touring" value="N" id="TouringDefault"/>
                                          No
                                         <div class="form-group">
                                            <asp:TextBox ID="sTourResume" runat="server" type="text" class="form-username form-control" placeholder="請描述旅遊歷程" ></asp:TextBox>
           	                            
                                         </div>

                                    </div>
                                </div>

                                <div class="form-group">                                    
								    <label>七、目前之長期服用藥物 :</label>                                   
                                        <div class="form-group ">                                            
                                            <asp:TextBox ID="sMedicinalName" runat="server" type="text" class="form-username form-control" placeholder="請描述藥物名稱" required></asp:TextBox>
           	                                <div class="help-block with-errors"></div>
                                        </div>                                 
                                </div>
                            </div>
                            <div class="text-center">
                                <asp:button Text ="完成註冊"  runat="server" type="submit" class="btn btn-primary" OnClientClick="return validateS();" onclick="signupV"></asp:button>
                                <asp:button Text ="測試"  runat="server" type="submit" class="btn btn-primary" OnClientClick="return validatetest();"></asp:button>
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
  

        </form>
</asp:Content>
