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
            int did = 6;

            string DoctorName = "";
            string DeptName = "";

            float TemperatureMax = strinngtofloat(temperatureMax.Text);
            float TemperatureMin = strinngtofloat(temperatureMin.Text);
            float HeartBeatMax = strinngtofloat(heartbeatMax.Text);
            float HeartBeatMin = strinngtofloat(heartbeatMin.Text);
            float BloodOxygenMax = strinngtofloat(bloodoxygenMax.Text);
            float BloodOxygenMin = strinngtofloat(bloodoxygenMin.Text);
            float PlasmaGlucoseMax = strinngtofloat(plasmaglucoseMax.Text);
            float PlasmaGlucoseMin = strinngtofloat(plasmaglucoseMin.Text);
            float SystolicBloodPressureMax = strinngtofloat(systolicbloodpressureMax.Text);
            float SystolicBloodPressureMin = strinngtofloat(systolicbloodpressureMin.Text);
            float DiastolicBloodPressureMax = strinngtofloat(diastolicbloodpressureMax.Text);
            float DiastolicBloodPressureMin = strinngtofloat(diastolicbloodpressureMin.Text);

            string mes = "";
            myDAL objmyDAL = new myDAL();

            objmyDAL.insertPatientMessurementDataEvaluate(did, DoctorName, DeptName, TemperatureMax, TemperatureMin, HeartBeatMax, HeartBeatMin, BloodOxygenMax, BloodOxygenMin, PlasmaGlucoseMax, PlasmaGlucoseMin, SystolicBloodPressureMax, SystolicBloodPressureMin, DiastolicBloodPressureMax, DiastolicBloodPressureMin, ref mes);

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