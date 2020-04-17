using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject
{
	public partial class PatientIndexPage : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["idoriginal"] = "";
            sBirthDate.Attributes.Add("onfocus", "(this.type='date')");
            sSurgeryDate.Attributes.Add("onfocus", "(this.type='date')");            
        }

        //-----------------------Function2--------------------------//
        protected void signupV(object sender, EventArgs e)
        {

        }
    }
}