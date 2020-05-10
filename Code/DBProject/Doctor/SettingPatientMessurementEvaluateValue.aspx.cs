using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject.Doctor
{
    public partial class SettingPatientMessurementEvaluateValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int did = (int)Session["idoriginal"];
        }

        protected void SentMessurementData_Click(object sender, EventArgs e)
        {
            //int did = (int)Session["idoriginal"];
            int pid = 12;
            
            float Temperature = strinngtofloat(temperatureT.Text);
            string TemperatureMessurementDate = temperatureDateT.Text;
            float HeartBeat = strinngtofloat(heartbeatT.Text);
            string HBMessurementDate = heartbeatDateT.Text;
            float BloodOxygen = strinngtofloat(bloodoxygenT.Text);
            string BOMessurementDate = bloodoxygenDateT.Text;
            float PlasmaGlucose = strinngtofloat(plasmaglucoseT.Text);
            string PGMessurementDate = plasmaglucoseDateT.Text;
            float BloodPressure = strinngtofloat(bloodpressureT.Text);
            string BPMessurementDate = bloodpressureDateT.Text;

            string mes = "";
            myDAL objmyDAL = new myDAL();

            objmyDAL.insertPatientMessurementDatas(did, MessurementDateF, Height, HeightMessurementDate, Weight, WeightMessurementDate, BMI, BMIMessurementDate, Temperature, TemperatureMessurementDate, HeartBeat, HBMessurementDate, BloodOxygen, BOMessurementDate, PlasmaGlucose, PGMessurementDate, BloodPressure, BPMessurementDate, ref mes);

            if (mes != "")
            {
                Response.Write("<script>alert('" + mes.ToString() + "');</script>");
            }
            else
            {
                Response.Write("<script>alert('資料已送出，資料寫入成功!!');</script>");
            }
        }

        protected float strinngtofloat(string inputdata)
        {
            float floatrlt;
            float.TryParse(inputdata, out floatrlt);
            return floatrlt;
        }
    }
}