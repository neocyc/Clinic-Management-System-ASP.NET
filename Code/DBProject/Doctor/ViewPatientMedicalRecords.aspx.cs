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
                table.Columns["Name"].ColumnName = "病人姓名";
                table.Columns["Phone"].ColumnName = "聯絡電話";

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
            string medicalcertificatecategory = "";
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

            int status = objmyDAL.patientMedicalRecordsInfoDisplayer(pid, ref Name, ref IDcard, ref Phone, ref Mobile, ref gender, ref maritalstatus, ref Height, ref Weight, ref BirthDate, ref medicalcertificatecategory, ref ZipCode, ref Addr, ref Email, ref NameCE, ref CERelationship, ref PhoneHEC, ref MobileMEC,
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
                sName.Text = (Name.ToString() == "" ? "(尚無資料)" : Name.ToString());
                sIDNo.Text = (IDcard.ToString() == "" ? "(尚無資料)" : IDcard.ToString());
                sPhoneH.Text = (Phone.ToString() == "" ? "(尚無資料)" : Phone.ToString());
                sPhoneM.Text = (Mobile.ToString() == "" ? "(尚無資料)" : Mobile.ToString());
                sGender.Text = (gender.ToString() == "" ? "(尚無資料)" : gender.ToString());
                sMaritalStatus.Text = (maritalstatus.ToString() == "" ? "(尚無資料)" : maritalstatus.ToString());
                sHeight.Text = (Height.ToString() == "" ? "(尚無資料)" : Height.ToString());
                sWeight.Text = (Weight.ToString() == "" ? "(尚無資料)" : Weight.ToString());

                DateTime stBirthDate;
                DateTime.TryParse(BirthDate.ToString(), out stBirthDate);
                sBirthDate.Text = (stBirthDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "(尚無資料)" : stBirthDate.ToString("yyyy-MM-dd"));
                
                sMedicalCertificateCategory.Text = (medicalcertificatecategory.ToString() == "" ? "(尚無資料)" : medicalcertificatecategory.ToString());

                sZipcode.Text = (ZipCode.ToString() == "" ? "(尚無資料)" : ZipCode.ToString());
                Address.Text = (Addr.ToString() == "" ? "(尚無資料)" : Addr.ToString());
                sEmail.Text = (Email.ToString() == "" ? "(尚無資料)" : Email.ToString());
                sNameCE.Text = (NameCE.ToString() == "" ? "(尚無資料)" : NameCE.ToString());
                sCERelationship.Text = (CERelationship.ToString() == "" ? "(尚無資料)" : CERelationship.ToString());
                sPhoneHEC.Text = (PhoneHEC.ToString() == "" ? "(尚無資料)" : PhoneHEC.ToString());
                sPhoneMEC.Text = (MobileMEC.ToString() == "" ? "(尚無資料)" : MobileMEC.ToString());
                sJob.Text = (JobName.ToString() == "" ? "(尚無資料)" : JobName.ToString());
                sNationality.Text = (nationality.ToString() == "" ? "(尚無資料)" : nationality.ToString());
                sChineseNationalityTouring.Text = (BooltoChinese(chinesenationalitytouring.ToString()) == "" ? "(尚無資料)" : BooltoChinese(chinesenationalitytouring.ToString()));
                TouringNo.Text = (TouringNumber.ToString() == "" ? "(尚無資料)" : TouringNumber.ToString());
                sForeignNationality.Text = (ForeignNationalityName.ToString() == "" ? "(尚無資料)" : ForeignNationalityName.ToString());
                sFamilyMedicalHistory.Text = (BooltoChinese(familymedicalhistory.ToString()) == "" ? "(尚無資料)" : BooltoChinese(familymedicalhistory.ToString()));
                sFamilyMedicalHistoryDescription.Text = (familymedicalhistorydescription.ToString() == "" ? "(尚無資料)" : familymedicalhistorydescription.ToString());
                sPersonalMedicalHistory.Text = (internalmedicalhistorydescription.ToString() == "" ? "(尚無資料)" : internalmedicalhistorydescription.ToString());
                sSurgeryMedical.Text = (BooltoChinese(surgerymedicalhistory.ToString()) == "" ? "(尚無資料)" : BooltoChinese(surgerymedicalhistory.ToString()));

                DateTime stSurgeryDate;
                DateTime.TryParse(SurgeryDate.ToString(), out stSurgeryDate);
                sSurgeryDate.Text = (stSurgeryDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "(尚無資料)" : stSurgeryDate.ToString("yyyy-MM-dd"));
                
                sDiseaseName.Text = (DiseaseName.ToString() == "" ? "(尚無資料)" : DiseaseName.ToString());
                sAllergyMedical.Text = (BooltoChinese(allergymedicalhistory.ToString()) == "" ? "(尚無資料)" : BooltoChinese(allergymedicalhistory.ToString()));
                sAllergyMedicalSymptom.Text = (AllergyMedicalSymptomDescription.ToString() == "" ? "(尚無資料)" : AllergyMedicalSymptomDescription.ToString());
                sTourResume.Text = (TouringHistoryDescription.ToString() == "" ? "(尚無資料)" : TouringHistoryDescription.ToString());
                sMedicinalName.Text = (MedicinalName.ToString() == "" ? "(尚無資料)" : MedicinalName.ToString());
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