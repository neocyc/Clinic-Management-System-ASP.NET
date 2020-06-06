<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.Master" AutoEventWireup="true" CodeBehind="ViewHealthEducationVideos.aspx.cs" Inherits="DBProject.Patient.ViewHealthEducationVideos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>觀看衛教影片</title>

    <script type="text/javascript">
        $(function () {
            $('#ContentPlaceHolder1_txtVideoURL').blur(function () {
                $.ajax({
                    //url: "@Url.Action('GetUrlArgument', 'YoutubeSample')",
                    url: "ViewHealthEducationVideos.aspx/GetUrlArgument",
                    type: "POST",
                    data: {},                                   
                    dataType: "json",
                    contentType: 'application/json; charset=UTF-8',
                    traditional: true,
                    complete: function () {
                    },
                    success: function (data) {
                        if (data.d == "") {
                            $("#ContentPlaceHolder1_ifm_video").hide();
                            alert("這不是YouTubej影片網址!!");
                        }
                        else {
                            $("#ContentPlaceHolder1_ifm_video").attr("src", "https://www.youtube.com/embed/" + data.d + "?rel=0");
                            $("#ContentPlaceHolder1_ifm_video").show();
                        }
                    },
                    Error: function () {
                        alert("發生錯誤");
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView            
                ID="dgvVideoList"
                AutoGenerateSelectButton="true"
                EnableViewState="False" 
                OnSelectedIndexChanging="SelectVideo_Click"
                OnRowDataBound="dgvVideoList_RowDataBound"
                runat="server" 
                BackColor="White" 
                BorderColor="#DEDFDE" 
                BorderStyle="Double" 
                BorderWidth="2px" 
                CellPadding="8" 
                Caption="衛教影片清單" 
                CaptionAlign="Top" 
                HorizontalAlign="Center" 
                Width="380px"  
                GridLines="Horizontal" 
                CellSpacing="3" 
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

            </asp:GridView>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <br />
        <label> 【預覽影片】 </label>
        <div style="width: 800px;">
            <iframe id="ifm_video" runat="server" width="640" height="390" frameborder="0" allowfullscreen />
        </div>
    </asp:PlaceHolder>
</asp:Content>
