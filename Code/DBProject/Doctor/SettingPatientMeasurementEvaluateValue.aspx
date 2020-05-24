<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/DoctorMaster.Master" AutoEventWireup="true" CodeBehind="SettingPatientMeasurementEvaluateValue.aspx.cs" Inherits="DBProject.Doctor.SettingPatientMessurementEvaluateValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>設定病人量測資料評估數值</title>
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
	                        		
	                            </div>


	                            <div class="form-bottom">
				                    
                                    
                                    
                        <!-- sign up form start honay laga hai :)-->                       

                            <div class="form-group">
                                <table class="table table-bordered">
                                  <caption> 請填設定以下量測數值的警示範圍</caption>
                                  <thead>
                                    <tr>
                                      <th>項目</th>
                                      <th>量測數值(最大值)</th>
                                      <th>量測數值(最小值)</th>
                                    </tr>
                                  </thead>
                                  <tbody>
                                    <tr>
                                      <td>體溫</td>
                                      <td><asp:TextBox ID="temperatureMax" runat="server" type="text" class="form-username form-control" placeholder="請填寫體溫最高值" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="temperatureMin" runat="server" type="text" class="form-username form-control" placeholder="請填寫體溫最低值"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>脈搏/心跳</td>
                                      <td><asp:TextBox ID="heartbeatMax" runat="server" type="text" class="form-username form-control" placeholder="請填寫脈搏或心跳最大值" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="heartbeatMin" runat="server" type="text" class="form-username form-control" placeholder="請填寫脈搏或心跳最小值"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>血氧</td>
                                      <td><asp:TextBox ID="bloodoxygenMax" runat="server" type="text" class="form-username form-control" placeholder="請填寫血氧最大值" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="bloodoxygenMin" runat="server" type="text" class="form-username form-control" placeholder="請填寫血氧最小值"></asp:TextBox></td>
                                    </tr>

                                     <tr>
                                      <td>血糖</td>
                                      <td><asp:TextBox ID="plasmaglucoseMax" runat="server" type="text" class="form-username form-control" placeholder="請填寫血糖最大值" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="plasmaglucoseMin" runat="server" type="text" class="form-username form-control" placeholder="請填寫血糖最小值"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                      <td>血壓(收縮壓)</td>
                                      <td><asp:TextBox ID="systolicbloodpressureMax" runat="server" type="text" class="form-username form-control" placeholder="請填寫血壓(收縮壓)最大值" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="systolicbloodpressureMin" runat="server" type="text" class="form-username form-control" placeholder="請填寫血壓(收縮壓)最小值"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                      <td>血壓(舒張)</td>
                                      <td><asp:TextBox ID="diastolicbloodpressureMax" runat="server" type="text" class="form-username form-control" placeholder="請填寫血壓(舒張壓)最大值" ></asp:TextBox></td>
                                      <td><asp:TextBox ID="diastolicbloodpressureMin" runat="server" type="text" class="form-username form-control" placeholder="請填寫血壓(舒張壓)最小值"></asp:TextBox></td>
                                    </tr>

                                  </tbody>
                                </table>
                             </div>                            
                            
                             <asp:button Text ="寫入設定"  runat="server" type="submit" class="btn btn-primary center-block" OnClick="SentMessurementData_Click"></asp:button>
				           

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
