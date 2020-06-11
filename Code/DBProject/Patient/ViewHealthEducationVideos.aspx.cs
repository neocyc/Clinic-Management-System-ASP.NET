using DBProject.DAL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject.Patient
{
    public partial class ViewHealthEducationVideos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = (int)Session["idoriginal"];
            LoadHealthEducationVideoList();
        }

        protected void SelectVideo_Click(object sender, GridViewSelectEventArgs e)
        { 
            int num = e.NewSelectedIndex;
            int vid = Convert.ToInt32(dgvVideoList.Rows[num].Cells[1].Text);
            Response.Write("<script>alert('影片 : " + dgvVideoList.Rows[num].Cells[2].Text + " 資料載入中......');</script>");            

            Session["videoURL"] = dgvVideoList.Rows[num].Cells[4].Text;
            //lblUploadDate.Text = dgvVideoList.Rows[num].Cells[6].Text;

            Response.Write("<script>alert('影片 : " + dgvVideoList.Rows[num].Cells[2].Text + " 資料載入完成!!');</script>");

            List<string> VideoKeyList = GetUrlArgument();
            ifm_video.Attributes.Add("src", "https://www.youtube.com/embed/" + VideoKeyList[0].ToString() + "?loop=1&origin=https://www.youtube.com&rel=0");
        }


        protected void dgvVideoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = (GridViewRow)e.Row;

            TableCell selectCell = row.Cells[0];
            if (selectCell.Controls.Count > 0)
            {
                LinkButton selectControl = selectCell.Controls[0] as LinkButton;

                if (selectControl != null)
                {
                    selectControl.Text = "觀看影片";
                }
            }

            TableCell VideoID = row.Cells[1];
            VideoID.Visible = false;
            TableCell VideoURL = row.Cells[4];
            VideoURL.Visible = false;
        }

        protected void LoadHealthEducationVideoList()
        {
            string mes = "";
            myDAL objmyDAL = new myDAL();
            DataTable VideoDatas = new DataTable();

            objmyDAL.getHealthEducationVideoDatas(ref VideoDatas, ref mes);

            if (VideoDatas != null && VideoDatas.Rows.Count > 0)
            {
                VideoDatas.Columns["VideoTitle"].ColumnName = "影片主題";
                VideoDatas.Columns["VideoCategories"].ColumnName = "影片類別";
                VideoDatas.Columns["VideoURL"].ColumnName = "網址";
                VideoDatas.Columns["initDate"].ColumnName = "上架日期";
                VideoDatas.Columns["updateDate"].ColumnName = "更新日期";

                dgvVideoList.DataSource = VideoDatas;
                dgvVideoList.DataBind();

                dgvVideoList.Attributes.Add("style", "word-break:break-word;word-wrap:normal;width:100%;");
            }
            else
            {
                dgvVideoList.DataSource = new DataTable();
                dgvVideoList.DataBind();
            }
        }

        /// <summary>
        /// 解析URL參數
        /// </summary>
        /// <param name="StrUrl" type="string"></param>
        /// <returns name="VideoKey" type="string"></returns>
        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<string> GetUrlArgument()
        {
            HttpContext.Current.Session["videoURL"] = Convert.ToString(HttpContext.Current.Session["videoURL"] ?? "").Trim();
            string StrUrl = HttpContext.Current.Session["videoURL"].ToString();

            if (StrUrl == "")
            {
                return new List<string>();
            }

            string VideoKey = string.Empty;
            try
            {
                Uri url = new Uri(StrUrl);
                string queryString = url.Query; //取得所有參數
                if (queryString != string.Empty)
                {
                    NameValueCollection col = GetQueryString(queryString);
                    VideoKey = col["v"];
                }
            }
            catch
            {
                VideoKey = string.Empty;
            }

            List<string> VideoKeyList = new List<string>() { VideoKey };

            return VideoKeyList;
        }

        /// <summary>
        /// 解析所有參數
        /// </summary>
        /// <param name="queryString" type="string"></param>
        /// <returns name="result" type="NameValueCollection"></returns>
        public static NameValueCollection GetQueryString(string queryString)
        {
            queryString = queryString.Replace("?", "");
            NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(queryString))
            {
                string[] Query = queryString.Split('&');
                foreach (string pars in Query)
                {
                    string[] pas = pars.Split('=');
                    result[pas[0]] = pas[1];
                }
            }
            return result;
        }
       
        protected void btnOrgVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["videoURL"].ToString()))
            {
                Response.Write("<script>alert('沒有影片被載入!!');</script>");
            }
            else
            {
                string VideoURI = Session["videoURL"].ToString();
                Response.Write("<script>alert('影片重新導入中......');</script>");
                Response.Write(String.Format("<script>var w = window.open('{0}','_blank',config='height=600,width=800'); w.focus();</script>", VideoURI));
            }
        }
    }
}