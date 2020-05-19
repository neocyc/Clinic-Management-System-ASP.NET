<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="PatientMeasurementDataAdd.aspx.cs" Inherits="DBProject.Patient.PatientMeasurementDataAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MedicX 4 Health Care &amp; 填寫量測資料</title>

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
            $.backstretch("../assets/img/backgrounds/PatientIndexPage.jpg");
        });
    </script>  

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="top-content"> 
            <div class="inner-bg">
               <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                        
                            <h1><strong>MedicX 4 Health Care</strong> 填寫個人量測記錄表單</h1>
                            
                            <div class="description">
                                <p>
    	                            這是一張<strong>"量測記錄表單"</strong> for Health Care Clinic.<br /> 
                                <p>  
                                <br />
                   
                                <asp:Button ID="btnTableMode" runat="server" class="btn btn-primary" Text="表格模式" OnClick="btnTableMode_Click" />
                                <asp:Button ID="btnFormMode" runat="server" class="btn btn-primary" Text="表單模式" OnClick="btnFormMode_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    
    <asp:PlaceHolder ID="SignupTable" Visible="false" runat="server">
				       
        <div>    
        <!-- Top content -->
             	                                
        <div class="top-content"> 
            <div class="inner-bg">
               <div class="container">
                    
                   

                    
                    <div class="row">
                                                	
                        <div class="col-sm-12">
                        	
                        	<div class="form-box">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>量測記錄表格</h3>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                            </div>


	                            <div class="form-bottom">
				                    
                                    
                                    
                        <!-- sign up form start honay laga hai :)-->                       

                            <div class="form-group">
                                <table class="table table-bordered">
                                  <caption> 請填寫以下量測資料</caption>
                                  <thead>
                                    <tr>
                                      <th>項目</th>
                                      <th>量測數值</th>
                                      <th>量測時間</th>
                                    </tr>
                                  </thead>
                                  <tbody>
                                    <tr>
                                      <td>身高</td>
                                      <td><asp:TextBox ID="heightT" runat="server" type="text" class="form-username form-control" placeholder="請填寫身高(cm)" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="heightDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>
                                    
                                    <tr>
                                      <td>體重</td>
                                      <td><asp:TextBox ID="weightT" runat="server" type="text" class="form-username form-control" placeholder="請填寫體重(kg)" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="weightDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>
                                    
                                    <tr>
                                      <td>BMI<br />BMI參考公式:體重(公斤) / 身高平方(公尺平方)</td>
                                      <td><asp:Label ID="BMIT" runat="server"></asp:Label></td>
                                      <td><asp:TextBox ID="BMIDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>體溫</td>
                                      <td><asp:TextBox ID="temperatureT" runat="server" type="text" class="form-username form-control" placeholder="請填寫體溫" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="temperatureDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>脈搏/心跳</td>
                                      <td><asp:TextBox ID="heartbeatT" runat="server" type="text" class="form-username form-control" placeholder="請填寫脈搏或心跳" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="heartbeatDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>血氧</td>
                                      <td><asp:TextBox ID="bloodoxygenT" runat="server" type="text" class="form-username form-control" placeholder="請填寫血氧" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="bloodoxygenDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>血糖</td>
                                      <td><asp:TextBox ID="plasmaglucoseT" runat="server" type="text" class="form-username form-control" placeholder="請填寫血糖" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="plasmaglucoseDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                      <td>血壓</td>
                                      <td><asp:TextBox ID="bloodpressureT" runat="server" type="text" class="form-username form-control" placeholder="請填寫血壓" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="bloodpressureDateT" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox></td>
                                    </tr>

                                  </tbody>
                                </table>
                             </div>                            
                            
                             <asp:button Text ="送出量測資料"  runat="server" type="submit" class="btn btn-primary center-block" OnClick="SentMessurementDataT_Click"></asp:button>
				           

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
  
    </asp:PlaceHolder>
       
    <asp:PlaceHolder ID="SignupForm" Visible="false" runat="server">
         
        <div>    
        <!-- Top content -->
             	                                
        <div class="top-content"> 
            <div class="inner-bg">
               <div class="container">
                   
                    <div class="row">
                                                	
                        <div class="col-sm-12">
                        	
                        	<div class="form-box">
                        		<div class="form-top">
	                        		<div class="form-top-left">
	                        			<h3>量測記錄表單</h3>
                                        <br />
                                        <p>請填寫以下量測資料</p>
	                        		</div>
	                        		<div class="form-top-right">
	                        			<i class="fa fa-pencil"></i>
	                        		</div>
	                            </div>


	                            <div class="form-bottom">
				                    
                                    
                                    
                        <!-- sign up form start honay laga hai :)-->                         
                                 
                           <div class="form-group">
							    <label>量測日期</label>
                                <asp:TextBox ID="MessurementDateForm" runat="server" type="text" class="form-username form-control" placeholder="請點選量測日期(dd-mm-yyyy)"></asp:TextBox>           	                            
                           
                           </div>         
                           
                           <div class="form-group">
								<label>身高</label>
                                <asp:TextBox ID="heightF" runat="server" type="text" class="form-username form-control" placeholder="請填寫身高(cm)" ></asp:TextBox>
                                           	                            
                            </div> 
							
							<div class="form-group">
								<label>體重</label>
                                <asp:TextBox ID="weightF" runat="server" type="text" class="form-username form-control" placeholder="請填寫體重(kg)"></asp:TextBox>
                                                      	                            
                            </div> 
							
							<div class="form-group">
								<label>BMI</label><br />
                                <label>BMI參考公式:體重(公斤) / 身高平方(公尺平方)</label><br />
                                <asp:Label ID="BMIF" runat="server"></asp:Label> 
                            </div> 
							
                            <div class="form-group">
								<label>體溫</label>
                                <asp:TextBox ID="temperatureF" runat="server" type="text" class="form-username form-control" placeholder="請填寫體溫"></asp:TextBox>
                                                      	                            
                            </div> 
                           
                            <div class="form-group">
								<label>脈搏/心跳</label>
                                <asp:TextBox ID="heartbeatF" runat="server" type="text" class="form-username form-control" placeholder="請填寫脈搏或心跳"></asp:TextBox>
                                                      	                            
                            </div> 

                            <div class="form-group">
								<label>血氧</label>
                                <asp:TextBox ID="bloodoxygenF" runat="server" type="text" class="form-username form-control" placeholder="請填寫血氧"></asp:TextBox>
                                                      	                            
                            </div> 

                            <div class="form-group">
								<label>血糖</label>
                                <asp:TextBox ID="plasmaglucoseF" runat="server" type="text" class="form-username form-control" placeholder="請填寫血糖"></asp:TextBox>
                                                      	                            
                            </div> 

                            <div class="form-group">
								<label>血壓</label>
                                <asp:TextBox ID="bloodpressureF" runat="server" type="text" class="form-username form-control" placeholder="請填寫血壓"></asp:TextBox>
                                                      	                            
                            </div> 

                             <!-- sign up ends here -->
                                            
                            <asp:button Text ="送出量測資料"  runat="server" type="submit" class="btn btn-primary center-block" OnClick="SentMessurementDataF_Click"></asp:button>				           

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

    </asp:PlaceHolder>

</asp:Content>

