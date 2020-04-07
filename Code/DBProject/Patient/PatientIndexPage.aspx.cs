using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject.Patient
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
            string Name = sName.Text;
            string BirthDate = sBirthDate.Text;
            string Email = sEmail.Text;
            
            string PhoneNo = sPhone.Text;
            string Addr = Address.Text;

            string gender = Request.Form["Gender"].ToString();



            myDAL objmyDAl = new myDAL();

            int id = 0;

            //int status = objmyDAl.validateUser(Name, BirthDate, Email, Password, PhoneNo, gender, Addr, ref id);
            int status=0;

            //status == 0 failure
            if (status == 0)
            {
                Response.Write("<script>alert('Email already exists. Please choose a different one.');</script>");
            }

            else if (status == 1)
            {
                Session["idoriginal"] = id;

                //Response.Write("<script>alert('Registration Successful !');</script>");

                Response.BufferOutput = true;
                Response.Redirect("~/Patient/PatientHome.aspx");
            }

            else if (status == -1)
            {
                Response.Write("<script>alert('There was some error. Try again !');</script>");
            }

        }

        //Enter new function here//
    }
}