using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject.Patient
{
    public partial class PatientMeasurementDatasView : System.Web.UI.Page
    {
        DataTable DT = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {           
            patientMessurementInfo(sender, e);                       
        }

        protected void patientMessurementInfo(object sender, EventArgs e)
        {
            int pid = (int)Session["idoriginal"];

            string mes = "";
            myDAL objmyDAL = new myDAL();            

            int status = objmyDAL.getPatientMessurementDataInfo(pid, ref DT, ref mes);

            if (status == -1)
            {
                Response.Write("<script>alert('" + mes.ToString() + "');</script>");
            }
            if (status == 1)
            {
                DataTable DTClName = DT.Copy();

                for (int i = 0; i < DT.Columns.Count; i++)
                {
                    //remove datime fields
                    if (((!(i % 2 != 0)) && i != 0))
                    {
                        DTClName.Columns.Remove(DT.Columns[i].ColumnName);
                    }
                }

                DTClName.Columns.Remove("PatientMRSID");

                DTClName.Columns[0].ColumnName = "量測表單編號";
                DTClName.Columns[1].ColumnName = "身高";
                DTClName.Columns[2].ColumnName = "體重";
                //DTClNam.Columns[3].ColumnName = "BMI";
                DTClName.Columns[4].ColumnName = "體溫";
                DTClName.Columns[5].ColumnName = "心跳脈搏";
                DTClName.Columns[6].ColumnName = "血氧";
                DTClName.Columns[7].ColumnName = "血糖";
                DTClName.Columns[8].ColumnName = "血壓";

                TPatientMessurementDatasGrid.DataSource = DTClName;
                TPatientMessurementDatasGrid.DataBind();
                
                TPatientMessurementDatasGrid.Attributes.Add("style", "word-break:break-word;word-wrap:normal;width:100%;");
            }

            return;
        }

        protected void TPatientMessurementDatasGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable DTSelest = DT.Copy();

            for (int i = 0; i < DT.Columns.Count; i++)
            {
                //remove datime fields
                if (((i % 2 != 0) && i != 0))
                {
                    DTSelest.Columns.Remove(DT.Columns[i].ColumnName);
                }
            }

            int selectitem;
            int.TryParse(e.CommandArgument.ToString(), out selectitem);
            lbMessurementDateF.Text = DTSelest.Rows[selectitem].ItemArray[1].ToString();
            lbHeightMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[2].ToString();
            lbWeightMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[3].ToString();
            lbBMIMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[4].ToString();
            lbTemperatureMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[5].ToString();
            lbHBMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[6].ToString();
            lbBOMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[7].ToString();
            lbPGMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[8].ToString();
            lbBPMessurementDate.Text = DTSelest.Rows[selectitem].ItemArray[9].ToString();
        }

        protected void TPatientMessurementDatasGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = (GridViewRow)e.Row;

            TableCell selectCell = row.Cells[0]; 

            if (selectCell.Controls.Count > 0)
            {
                LinkButton selectControl = selectCell.Controls[0] as LinkButton;

                if (selectControl != null)
                {
                    selectControl.Text = "顯示量測時間";
                }
            }
        }        
    }
}