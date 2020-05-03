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
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = (int)Session["idoriginal"];

            string mes = "";
            myDAL objmyDAL = new myDAL();

            DataTable DT = new DataTable();            

            int status = objmyDAL.getPatientMessurementDataInfo(pid, ref DT, ref mes);


            if (status == -1)
            {
                Response.Write("<script>alert('" + mes.ToString() + "');</script>");
            }
            if(status == 1)
            {
                for (int i=0;i<TPatientMessurementDatasGrid.Columns.Count ;i++) 
                {                    
                    TPatientMessurementDatasGrid.Columns[i].ItemStyle.Width = Unit.Parse("80");
                }

                TPatientMessurementDatasGrid.Width = Unit.Parse("100%");
                DT.Columns["MessurementDateF"].ColumnName = "表單填寫時間";
                DT.Columns.Remove("MessurementRecordsSheetID");
                DT.Columns.Remove("PatientMRSID");
                TPatientMessurementDatasGrid.DataSource = DT;
                TPatientMessurementDatasGrid.DataBind();
            }

        }
    }
}