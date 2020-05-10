using DBProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject.Doctor
{
    public partial class PatientMeasurementValueSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SentMessurementDataT_Click(object sender, EventArgs e)
        {
            int pid = (int)Session["idoriginal"];

            string MessurementDateF = DateTime.Now.ToShortDateString();
            float Height = strinngtofloat(heightT.Text);
            string HeightMessurementDate = heightDateT.Text;
            float Weight = strinngtofloat(weightT.Text);
            string WeightMessurementDate = weightDateT.Text;
            float BMI = strinngtofloat(BMIT.Text);
            string BMIMessurementDate = BMIDateT.Text;
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

            objmyDAL.insertPatientMessurementDatas(pid, MessurementDateF, Height, HeightMessurementDate, Weight, WeightMessurementDate, BMI, BMIMessurementDate, Temperature, TemperatureMessurementDate, HeartBeat, HBMessurementDate, BloodOxygen, BOMessurementDate, PlasmaGlucose, PGMessurementDate, BloodPressure, BPMessurementDate, ref mes);

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