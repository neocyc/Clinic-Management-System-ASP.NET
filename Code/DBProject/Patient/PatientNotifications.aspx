<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="PatientNotifications.aspx.cs" Inherits="DBProject.PatientNotifications" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>醫師留言通知</title>

</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1><strong style="margin:37%">醫師留言通知</strong></h1>
    <br /><br />

    <div style="margin-left: 70px">

    <asp:Label ID="Notify" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label>
    <br /><br />

    <asp:Label ID="NDoctor" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label>
    <br /><br />

    <asp:Label ID="NTimings" runat="server"  Font-Bold="true" Font-Size="Medium"></asp:Label>
    <br /><br />
    
    <asp:Repeater ID="RepeaterDoctorMessage" runat="server">
        <ItemTemplate>
            <br />
            <label> 【醫師叮嚀與囑咐】 </label>
            <br />
            發言醫師:<asp:Label ID="Message_Name" runat="server" Text='<%# Bind("DoctorName") %>'></asp:Label>
            <br />
            留言時間:<asp:Label ID="Message_Time" runat="server" Text='<%# Bind("initDate") %>'></asp:Label>
            <br />
            留言內容:
            <br />
            <asp:Label ID="Message_Main" runat="server" Text='<%# Bind("MessageInfo") %>'></asp:Label>
            <br/>
            
        </ItemTemplate>
    </asp:Repeater>



</asp:Content>
