using DBProject.DAL;
using System;
using System.Collections.Generic;
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
            float BloodPressure = strinngtofloat(bloodpressureF.Text);
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
    }
}