using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject.Patient
{
    public partial class PatientMeasurementDatasView : System.Web.UI.Page
    {
        DataTable DT = new DataTable();
        DataTable DTsp = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            patientMessurementInfo(sender, e);                       
        }

        protected void patientMessurementInfo(object sender, EventArgs e)
        {
            int pid = (int)Session["idoriginal"];

            string mesPInfo = "";
            string mesPsp = "";
            myDAL objmyDAL = new myDAL();            

            int status = objmyDAL.getPatientMessurementDataInfo(pid, ref DT, ref mesPInfo);

            objmyDAL.getPatientMessurementDataWarningValue(ref DTsp, ref mesPsp);

            if (status == -1)
            {
                Response.Write("<script>alert('" + mesPInfo.ToString() + "');</script>");
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

            lbMessurementDateF.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[1].ToString()).ToShortDateString();
            /*
            lbHeightMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[2].ToString()).ToShortDateString();
            lbWeightMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[3].ToString()).ToShortDateString();
            lbBMIMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[4].ToString()).ToShortDateString();
            lbTemperatureMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[5].ToString()).ToShortDateString();
            lbHBMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[6].ToString()).ToShortDateString();
            lbBOMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[7].ToString()).ToShortDateString();
            lbPGMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[8].ToString()).ToShortDateString();
            lbBPMessurementDate.Text = DateTime.Parse(DTSelest.Rows[selectitem].ItemArray[9].ToString()).ToShortDateString();
            */    
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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                float TemperatureMax = float.Parse((DTsp.Rows[0].ItemArray[0].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[0].ToString()));
                float TemperatureMin = float.Parse((DTsp.Rows[0].ItemArray[1].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[1].ToString()));
                float HeartBeatMax = float.Parse((DTsp.Rows[0].ItemArray[2].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[2].ToString()));
                float HeartBeatMin = float.Parse((DTsp.Rows[0].ItemArray[3].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[3].ToString()));
                float BloodOxygenMax = float.Parse((DTsp.Rows[0].ItemArray[4].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[4].ToString()));
                float BloodOxygenMin = float.Parse((DTsp.Rows[0].ItemArray[5].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[5].ToString()));
                float PlasmaGlucoseMax = float.Parse((DTsp.Rows[0].ItemArray[6].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[6].ToString()));
                float PlasmaGlucoseMin = float.Parse((DTsp.Rows[0].ItemArray[7].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[7].ToString()));
                float SystolicBloodPressureMax = float.Parse((DTsp.Rows[0].ItemArray[8].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[8].ToString()));
                float SystolicBloodPressureMin = float.Parse((DTsp.Rows[0].ItemArray[9].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[9].ToString()));
                float DiastolicBloodPressureMax = float.Parse((DTsp.Rows[0].ItemArray[10].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[10].ToString()));
                float DiastolicBloodPressureMin = float.Parse((DTsp.Rows[0].ItemArray[11].ToString() == "" ? "0.0" : DTsp.Rows[0].ItemArray[11].ToString()));

                foreach (TableCell c in e.Row.Cells)
                {
                    if (e.Row.Cells.GetCellIndex(c) > 2 && e.Row.Cells.GetCellIndex(c) < (e.Row.Cells.Count - 1))
                    {
                        int cellsIndex = e.Row.Cells.GetCellIndex(c);
                        Single f = Single.Parse((c.Text == "" ? "0.0" : c.Text));
                        if (f == 0)
                        {
                            e.Row.Cells[cellsIndex].Text = "0";
                        }
                        else
                        {
                            e.Row.Cells[cellsIndex].Text = f.ToString("#.###");
                        }

                        switch (cellsIndex)
                        {
                            case 6:
                                if (f > TemperatureMax)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                else if (f < TemperatureMin)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                break;
                            case 7:
                                if (f > HeartBeatMax)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                else if (f < HeartBeatMin)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                break;
                            case 8:
                                if (f > BloodOxygenMax)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                else if (f < BloodOxygenMin)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                break;
                            case 9:
                                if (f > PlasmaGlucoseMax)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                else if (f < PlasmaGlucoseMin)
                                {
                                    e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                }
                                break;
                        }
                    }
                    else if (e.Row.Cells.GetCellIndex(c) == (e.Row.Cells.Count - 1))
                    {
                        string[] BloodPressure = c.Text.Split('/');

                        if (BloodPressure.Length < 2)
                        {
                            int cellsIndex = e.Row.Cells.GetCellIndex(c);
                            e.Row.Cells[cellsIndex].Text += "(填入的資料格式不正確)";
                        }
                        else
                        {                            
                            int cellsIndex = e.Row.Cells.GetCellIndex(c);
                            e.Row.Cells[cellsIndex].Text = "";
                            string SystolicBloodPressure = BloodPressure[0]; //收縮壓
                            string DiastolicBloodPressure = BloodPressure[1]; //舒張壓

                            Single fs = Single.Parse((SystolicBloodPressure == "" ? "0.0" : SystolicBloodPressure));
                            if (fs > SystolicBloodPressureMax)
                            {
                                //e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                e.Row.Cells[cellsIndex].Text = "<font color=red>" + fs.ToString() + "</font>";
                            }
                            else if (fs < SystolicBloodPressureMin)
                            {
                                if (fs == 0)
                                {
                                    e.Row.Cells[cellsIndex].Text = "<font color=red>0</font>";
                                }
                                else
                                {
                                    //e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                    e.Row.Cells[cellsIndex].Text = "<font color=red>" + fs.ToString() + "</font>";
                                }
                            }
                            else 
                            {
                                e.Row.Cells[cellsIndex].Text = fs.ToString();
                            }

                            Single fd = Single.Parse((DiastolicBloodPressure == "" ? "0.0" : DiastolicBloodPressure));
                            if (fd > DiastolicBloodPressureMax)
                            {
                                //e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                e.Row.Cells[cellsIndex].Text += " / <font color=red>" + fd.ToString() + "</font>";
                            }
                            else if (fd < DiastolicBloodPressureMin)
                            {
                                if (fd == 0)
                                {
                                    e.Row.Cells[cellsIndex].Text += " / <font color=red>0</font>";
                                }
                                else
                                {
                                    //e.Row.Cells[cellsIndex].ForeColor = Color.Red;
                                    e.Row.Cells[cellsIndex].Text += " / <font color=red>" + fd.ToString() + "</font>";
                                }
                            }
                            else
                            {
                                e.Row.Cells[cellsIndex].Text += " / " + fd.ToString();
                            }
                        }
                    }
                }
            }
        }        
    }
}