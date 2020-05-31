using DBProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBProject.Patient
{
    public partial class PatientMeasurementDataAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessurementDataWarningValues(sender, e);

            int pid = (int)Session["idoriginal"];
            
            heightDateT.Attributes.Add("onfocus", "(this.type='date')");
            weightDateT.Attributes.Add("onfocus", "(this.type='date')");
            BMIDateT.Attributes.Add("onfocus", "(this.type='date')");
            temperatureDateT.Attributes.Add("onfocus", "(this.type='date')");
            heartbeatDateT.Attributes.Add("onfocus", "(this.type='date')");
            bloodoxygenDateT.Attributes.Add("onfocus", "(this.type='date')");
            plasmaglucoseDateT.Attributes.Add("onfocus", "(this.type='date')");
            bloodpressureDateT.Attributes.Add("onfocus", "(this.type='date')");

            MessurementDateForm.Attributes.Add("onfocus", "(this.type='date')");

            if (!IsPostBack) 
            {
                string Today = DateTime.Now.ToShortDateString();
                MessurementDateForm.Text = Today;
                heightDateT.Text = Today;
                weightDateT.Text = Today;
                BMIDateT.Text = Today;
                temperatureDateT.Text = Today;
                heartbeatDateT.Text = Today;
                bloodoxygenDateT.Text = Today;
                plasmaglucoseDateT.Text = Today;
                bloodpressureDateT.Text = Today;
            }
            //initialization();
        }

        protected void MessurementDataWarningValues(object sender, EventArgs e)
        {
            string mesPsp = "";
            myDAL objmyDAL = new myDAL();
            DataTable DTsp = new DataTable();
            objmyDAL.getPatientMessurementDataWarningValue(ref DTsp, ref mesPsp);

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

            temperatureSTT.Text = " ( " + TemperatureMin.ToString() + " ~ "+ TemperatureMax.ToString() + " ) ";
            heartbeatSTT.Text = " ( " + HeartBeatMin.ToString() +" ~ " + HeartBeatMax.ToString() +" ) "; 
            bloodoxygenSTT.Text = " ( " + BloodOxygenMin.ToString() +" ~ " + BloodOxygenMax.ToString() +" ) ";
            plasmaglucoseSTT.Text = " ( " + PlasmaGlucoseMin.ToString() +" ~ " + PlasmaGlucoseMax.ToString() +" ) ";
            systolicbloodpressureSTT.Text = " 收縮( " + SystolicBloodPressureMin.ToString() +" ~ " + SystolicBloodPressureMax.ToString() +" ) ";
            diastolicbloodpressureSTT.Text = " 舒張( " + DiastolicBloodPressureMin.ToString() +" ~ " + DiastolicBloodPressureMax.ToString() +" ) ";

            temperatureSTF.Text = " ( " + TemperatureMin.ToString() + " ~ " + TemperatureMax.ToString() + " ) ";
            heartbeatSTF.Text = " ( " + HeartBeatMin.ToString() + " ~ " + HeartBeatMax.ToString() + " ) ";
            bloodoxygenSTF.Text = " ( " + BloodOxygenMin.ToString() + " ~ " + BloodOxygenMax.ToString() + " ) ";
            plasmaglucoseSTF.Text = " ( " + PlasmaGlucoseMin.ToString() + " ~ " + PlasmaGlucoseMax.ToString() + " ) ";
            systolicbloodpressureSTF.Text = " 收縮( " + SystolicBloodPressureMin.ToString() + " ~ " + SystolicBloodPressureMax.ToString() + " ) ";
            diastolicbloodpressureSTF.Text = " 舒張( " + DiastolicBloodPressureMin.ToString() + " ~ " + DiastolicBloodPressureMax.ToString() + " ) ";
        }

        #region 按鈕事件
        protected void btnTableMode_Click(object sender, EventArgs e)
        {
            SignupTable.Visible = true;
            SignupForm.Visible = false;
            btnTableMode.BackColor = System.Drawing.Color.YellowGreen;
            btnFormMode.BackColor = System.Drawing.Color.Blue;
        }

        protected void btnFormMode_Click(object sender, EventArgs e)
        {
            SignupTable.Visible = false;
            SignupForm.Visible = true;
            btnTableMode.BackColor = System.Drawing.Color.Blue;
            btnFormMode.BackColor = System.Drawing.Color.YellowGreen;
        }

        protected void SentMessurementDataF_Click(object sender, EventArgs e)
        {
            int pid = (int)Session["idoriginal"];

            string MessurementDateF = MessurementDateForm.Text;
            float Height = strinngtofloat(heightF.Text);
            string HeightMessurementDate = MessurementDateF;
            float Weight = strinngtofloat(weightF.Text);
            string WeightMessurementDate = MessurementDateF;
            float BMI = strinngtofloat(BMIF.Text);
            string BMIMessurementDate = MessurementDateF;
            float Temperature = strinngtofloat(temperatureF.Text);
            string TemperatureMessurementDate = MessurementDateF;
            float HeartBeat = strinngtofloat(heartbeatF.Text);
            string HBMessurementDate = MessurementDateF;
            float BloodOxygen = strinngtofloat(bloodoxygenF.Text);
            string BOMessurementDate = MessurementDateF;
            float PlasmaGlucose = strinngtofloat(plasmaglucoseF.Text);
            string PGMessurementDate = MessurementDateF;
            string BloodPressure = bloodpressureF.Text;
            string BPMessurementDate = MessurementDateF;

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
            string BloodPressure = bloodpressureT.Text;
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

        #endregion

        protected void initialization()
        {
            heightF.Text = "";
            heightT.Text = "";
            weightF.Text = "";
            weightT.Text = "";
            BMIF.Text = "";
            BMIT.Text = "";
            temperatureF.Text = "";
            temperatureT.Text = "";
            heartbeatF.Text = "";
            heartbeatT.Text = "";
            bloodoxygenF.Text = "";
            bloodoxygenT.Text = "";
            plasmaglucoseF.Text = "";
            plasmaglucoseT.Text = "";
            bloodpressureF.Text = "";
            bloodpressureT.Text = "";

            string Today = DateTime.Now.ToShortDateString();
            MessurementDateForm.Text = Today;
            heightDateT.Text = Today;
            weightDateT.Text = Today;
            BMIDateT.Text = Today;
            temperatureDateT.Text = Today;
            heartbeatDateT.Text = Today;
            bloodoxygenDateT.Text = Today;
            plasmaglucoseDateT.Text = Today;
            bloodpressureDateT.Text = Today;
        }

        protected float strinngtofloat(string inputdata) 
        {
            float floatrlt;
            float.TryParse(inputdata, out floatrlt);
            return floatrlt;
        }

        protected void heightT_TextChanged(object sender, EventArgs e)
        {
            BMIT.Text = BMICalculation(heightT.Text, weightT.Text);
        }

        protected void weightT_TextChanged(object sender, EventArgs e)
        {
            BMIT.Text = BMICalculation(heightT.Text, weightT.Text);
        }

        protected string BMICalculation(string height, string weight)
        {
            double dheight, dweight, dBMI;

            dheight = strinngtofloat(height);
            dweight = strinngtofloat(weight);
            dBMI = dweight / (Math.Pow(dheight / 100, 2));

            return dBMI.ToString();
        }

        protected void MessurementDateForm_TextChanged(object sender, EventArgs e)
        {
            BMIF.Text = BMICalculation(heightF.Text, weightF.Text);
        }

        protected void heightF_TextChanged(object sender, EventArgs e)
        {
            BMIF.Text = BMICalculation(heightF.Text, weightF.Text);
        }

        protected void weightF_TextChanged(object sender, EventArgs e)
        {
            BMIF.Text = BMICalculation(heightF.Text, weightF.Text);
        }
    }
}