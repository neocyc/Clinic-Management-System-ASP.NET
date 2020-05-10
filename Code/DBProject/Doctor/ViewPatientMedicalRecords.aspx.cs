using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject.Doctor
{
    public partial class ViewPatientMedicalRecords : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            int did = (int)Session["idoriginal"];
            if (!IsPostBack) 
            {
                LoadGrid("");
            }

            ((ContentPlaceHolder)Master.FindControl("Cp2")).Visible = false;
        }		

		/*THIS FUNCTION WILL SEARCH THE NAME AND GIVE RESULTS OR RETURN ALL TUPLES FROM DATABASE IN THE GRID VIE*/
		protected void Search_btn(object sender, EventArgs e)
		{
			LoadGrid(txtSearch.Text);
            hfSearchState.Value = txtSearch.Text;
            ClearData();
		}

		/*THIS FUNTION WILL LOAD THE INFORMATION OF ALL Patient AND BIND THEM TO THE GRID*/
		protected void LoadGrid(string SearchQuery)
		{
			myDAL objmyDaL = new myDAL();
			DataTable table = new DataTable();


			objmyDaL.LoadPatient(ref table, SearchQuery);

			if (table != null && table.Rows.Count > 0)
			{
				dgvPatientListInfo.DataSource = table;
				dgvPatientListInfo.DataBind();
			}
			else
			{
				Msg.Text = "No Pateints to show";
			}

            ClearData();
		}

		protected void LoadPatientMRinfo(int pid) 
		{
            myDAL objmyDAL = new myDAL();

            string Name = sName.Text.ToString();
            string IDcard = sIDNo.Text.ToString();
            string Phone = sPhoneH.Text.ToString();
            string Mobile = sPhoneM.Text.ToString();
            string gender = "";
            string maritalstatus = "";
            int Height;
            int Weight;
            Int32.TryParse(sHeight.Text.ToString(), out Height);
            Int32.TryParse(sWeight.Text.ToString(), out Weight);
            string BirthDate = sBirthDate.Text.ToString();
            string ZipCode = sZipcode.Text.ToString();
            string Addr = Address.Text.ToString();
            string Email = sEmail.Text.ToString();
            string NameCE = sNameCE.Text.ToString();
            string CERelationship = sCERelationship.Text.ToString();
            string PhoneHEC = sPhoneHEC.Text.ToString();
            string MobileMEC = sPhoneMEC.Text.ToString();
            string JobName = sJob.Text.ToString();
            string nationality = "";
            Boolean chinesenationalitytouring = false;
            string TouringNumber = "";
            string ForeignNationalityName = "";
            Boolean familymedicalhistory = false;
            string familymedicalhistorydescription = "";
            string FamilyMedicalHistoryItemcode = "";
            string FamilyMedicalHistoryItemname = "";
            Boolean internalmedicalhistory = false;
            string internalmedicalhistorydescription = "";
            string InternalMedicalHistoryItemcode = "";
            string InternalMedicalHistoryItemname = "";
            Boolean surgerymedicalhistory = false;
            string SurgeryDate = "";
            string DiseaseName = "";
            Boolean allergymedicalhistory = false;
            string AllergyMedicalSymptomDescription = "";
            Boolean touringhistory = false;
            string TouringHistoryDescription = "";
            string MedicinalName = sMedicinalName.Text.ToString();

            int status = objmyDAL.patientMedicalRecordsInfoDisplayer(pid, ref Name, ref IDcard, ref Phone, ref Mobile, ref gender, ref maritalstatus, ref Height, ref Weight, ref BirthDate, ref ZipCode, ref Addr, ref Email, ref NameCE, ref CERelationship, ref PhoneHEC, ref MobileMEC,
                ref JobName,
                ref nationality, ref chinesenationalitytouring, ref TouringNumber, ref ForeignNationalityName,
                ref familymedicalhistory, ref familymedicalhistorydescription, ref FamilyMedicalHistoryItemcode, ref FamilyMedicalHistoryItemname,
                ref internalmedicalhistory, ref internalmedicalhistorydescription, ref InternalMedicalHistoryItemcode, ref InternalMedicalHistoryItemname,
                ref surgerymedicalhistory, ref SurgeryDate, ref DiseaseName,
                ref allergymedicalhistory, ref AllergyMedicalSymptomDescription,
                ref touringhistory, ref TouringHistoryDescription,
                ref MedicinalName);

            if (status == -1)
            {
                Response.Write("<script>alert('There was some error in retrieving the Patient's Medical Records Info.');</script>");
            }

            else if (status == 0)
            {
                sName.Text = Name.ToString();
                sIDNo.Text = IDcard.ToString();
                sPhoneH.Text = Phone.ToString();
                sPhoneM.Text = Mobile.ToString();
                sGender.Text = gender.ToString();
                sMaritalStatus.Text = maritalstatus.ToString();
                sHeight.Text = Height.ToString();
                sWeight.Text = Weight.ToString();

                DateTime stBirthDate;
                DateTime.TryParse(BirthDate.ToString(), out stBirthDate);
                sBirthDate.Text = stBirthDate.ToString("yyyy-mm-dd");

                sZipcode.Text = ZipCode.ToString();
                Address.Text = Addr.ToString();
                sEmail.Text = Email.ToString();
                sNameCE.Text = NameCE.ToString();
                sCERelationship.Text = CERelationship.ToString();
                sPhoneHEC.Text = PhoneHEC.ToString();
                sPhoneMEC.Text = MobileMEC.ToString();
                sJob.Text = JobName.ToString();
                sNationality.Text = nationality.ToString();
                sChineseNationalityTouring.Text = BooltoChinese(chinesenationalitytouring.ToString());
                TouringNo.Text = TouringNumber.ToString();
                sForeignNationality.Text = ForeignNationalityName.ToString();
                sFamilyMedicalHistory.Text = BooltoChinese(familymedicalhistory.ToString());
                sFamilyMedicalHistoryDescription.Text = familymedicalhistorydescription.ToString();
                sPersonalMedicalHistory.Text = BooltoChinese(internalmedicalhistorydescription.ToString());
                sSurgeryMedical.Text = BooltoChinese(surgerymedicalhistory.ToString());

                DateTime stSurgeryDate;
                DateTime.TryParse(SurgeryDate.ToString(), out stSurgeryDate);
                sSurgeryDate.Text = stSurgeryDate.ToString("yyyy-mm-dd");

                sDiseaseName.Text = DiseaseName.ToString();
                sAllergyMedical.Text = BooltoChinese(allergymedicalhistory.ToString());
                sAllergyMedicalSymptom.Text = AllergyMedicalSymptomDescription.ToString();
                sTourResume.Text = TouringHistoryDescription.ToString();
                sMedicinalName.Text = MedicinalName.ToString();
            }
        }

        protected string BooltoChinese(string controlertext)
        {
            if (controlertext == "True")
            {
                controlertext = "是";
            }

            if (controlertext == "False")
            {
                controlertext = "否";
            }
            return controlertext;
        }

        protected void ClearData() 
        {
            sName.Text = "";
            sIDNo.Text = "";
            sPhoneH.Text = "";
            sPhoneM.Text = "";
            sGender.Text = "";
            sMaritalStatus.Text = "";
            sHeight.Text = "";
            sWeight.Text = "";
            sBirthDate.Text = "";
            sZipcode.Text = "";
            Address.Text = "";
            sEmail.Text = "";
            sNameCE.Text = "";
            sCERelationship.Text = "";
            sPhoneHEC.Text = "";
            sPhoneMEC.Text = "";
            sJob.Text = "";
            sNationality.Text = "";
            sChineseNationalityTouring.Text = "";
            TouringNo.Text = "";
            sForeignNationality.Text = "";
            sFamilyMedicalHistory.Text = "";
            sFamilyMedicalHistoryDescription.Text = "";
            sPersonalMedicalHistory.Text = "";
            sSurgeryMedical.Text = "";
            sSurgeryDate.Text = "";
            sDiseaseName.Text = "";
            sAllergyMedical.Text = "";
            sAllergyMedicalSymptom.Text = "";
            sTourResume.Text = "";
            sMedicinalName.Text = "";
        }

        protected void dgvPatientListInfo_RowCommand(object sender, GridViewCommandEventArgs e)
		{
            ((ContentPlaceHolder)Master.FindControl("Cp2")).Visible = true;

            LoadGrid(hfSearchState.Value);
			int num = Convert.ToInt32(e.CommandArgument);		
			int pid = Convert.ToInt32(dgvPatientListInfo.Rows[num].Cells[1].Text);

            LoadPatientMRinfo(pid);
        }

		protected void dgvPatientListInfo_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			GridViewRow row = (GridViewRow)e.Row;

			TableCell selectCell = row.Cells[0];

			if (selectCell.Controls.Count > 0)
			{
				LinkButton selectControl = selectCell.Controls[0] as LinkButton;

				if (selectControl != null)
				{
					selectControl.Text = "顯示病歷資料";
				}
			}

			TableCell PID = row.Cells[1];
			PID.Visible = false;
		}
	}
}