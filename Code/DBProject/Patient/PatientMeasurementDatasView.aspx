<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="PatientMeasurementDatasView.aspx.cs" Inherits="DBProject.Patient.PatientMeasurementDatasView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>我的歷史量測資料</title>

    <!-- CSS -->
    <link rel="stylesheet" href="../assets/bootstrap/css/bootstrap.min.css"/>


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

    <!------------------Styling------------------>
    <link rel="stylesheet" href="/assets/css/grid-view.css"/>

    <asp:GridView ID="TPatientMessurementDatasGrid" runat="server" class = "GridView-d" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%"
        EnableViewState ="False"
        AutoGenerateSelectButton="True" 
        OnRowCommand="TPatientMessurementDatasGrid_RowCommand"
        OnRowDataBound="TPatientMessurementDatasGrid_RowDataBound"
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
        
    >

        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" Width="100%" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
          
        <Columns>
            <asp:TemplateField HeaderText = "No." ItemStyle-Width="50">
                <ItemTemplate>
                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                </ItemTemplate>

            <ItemStyle Width="50px"></ItemStyle>
            </asp:TemplateField>
        </Columns>


    </asp:GridView>

    <br />

    <div class="form-group">
    <asp:Label ID="Label1" runat="server" Text="表單填寫時間 : "></asp:Label><asp:Label ID="lbMessurementDateF" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label3" runat="server" Text="身高量測時間 : "></asp:Label><asp:Label ID="lbHeightMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label5" runat="server" Text="體重量測時間 : "></asp:Label><asp:Label ID="lbWeightMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label7" runat="server" Text="BMI量測時間 : "></asp:Label><asp:Label ID="lbBMIMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label9" runat="server" Text="體溫量測時間 : "></asp:Label><asp:Label ID="lbTemperatureMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label11" runat="server" Text="脈搏與心跳量測時間 : "></asp:Label><asp:Label ID="lbHBMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label13" runat="server" Text="血氧量測時間 : "></asp:Label><asp:Label ID="lbBOMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label15" runat="server" Text="血糖量測時間 : "></asp:Label><asp:Label ID="lbPGMessurementDate" runat="server" Text=""></asp:Label>
    <br /><br /><asp:Label ID="Label17" runat="server" Text="血壓量測時間 : "></asp:Label><asp:Label ID="lbBPMessurementDate" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>
