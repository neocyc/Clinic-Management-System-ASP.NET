<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/DoctorMaster.Master" AutoEventWireup="true" CodeBehind="PatientMeasurementValueSetting.aspx.cs" Inherits="DBProject.Doctor.PatientMeasurementValueSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>設定病人量測資料建議</title>

    <!-- CSS -->
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css"/>

    <!-- Javascript -->
    <script src="../assets/js/jquery-1.11.1.min.js"></script>
    <script src="../assets/bootstrap/js/bootstrap.min.js"></script>    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cp1" runat="server">
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
                                      <td><asp:TextBox ID="BMIT" runat="server" type="text" class="form-username form-control" placeholder="請填寫BMI值"></asp:TextBox></td>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cp2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Cp3" runat="server">
</asp:Content>
