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
            heightDateT.Attributes.Add("onfocus", "(this.type='date')");
            weightDateT.Attributes.Add("onfocus", "(this.type='date')");
            temperatureDateT.Attributes.Add("onfocus", "(this.type='date')");
            heartbeatDateT.Attributes.Add("onfocus", "(this.type='date')");
            bloodoxygenDateT.Attributes.Add("onfocus", "(this.type='date')");
            plasmaglucoseDateT.Attributes.Add("onfocus", "(this.type='date')");
            bloodpressureDateT.Attributes.Add("onfocus", "(this.type='date')");
            
            MessurementDateF.Attributes.Add("onfocus", "(this.type='date')");
        }

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
            
        }

        protected void SentMessurementDataT_Click(object sender, EventArgs e)
        {
            
        }
    }
}