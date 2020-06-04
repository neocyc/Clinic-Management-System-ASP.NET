using DBProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject.Doctor
{
    public partial class UploadHealthEducationVideos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHealthEducationVideoList();
        }

        protected void dgvVideoList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void dgvVideoList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = (GridViewRow)e.Row;

            TableCell selectCell = row.Cells[0];

            if (selectCell.Controls.Count > 0)
            {
                LinkButton selectControl = selectCell.Controls[2] as LinkButton;

                if (selectControl != null)
                {
                    selectControl.Text = "編輯";
                }
            }

            TableCell VideoID = row.Cells[1];
            VideoID.Visible = false;
            TableCell VideoURL = row.Cells[4];
            VideoURL.Visible = false;
        }

        protected void DeleteVideo_Click(Object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = dgvVideoList.Rows[e.RowIndex];
            string id = row.Cells[1].Text;
            myDAL objDAL = new myDAL();
            string mes = "";

            if (objDAL.DeleteHealthEducationVideo(Convert.ToInt32(id), ref mes) == 1)
            {
                Response.Write("<script>alert('影片 : " + row.Cells[2].Text + " 已成功刪除!!');</script>");
                LoadHealthEducationVideoList();
            }
            else
            {                
                Response.Write("<script>alert('影片 : " + row.Cells[2].Text + " 刪除失敗!! " + mes.ToString() + " ');</script>");
            }
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
        }
    }
}