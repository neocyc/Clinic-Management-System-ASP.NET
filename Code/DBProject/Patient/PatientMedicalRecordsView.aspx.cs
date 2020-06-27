using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject.Patient
{
    public partial class PatientMedicalRecordsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myDAL objmyDAL = new myDAL();

            int pid = (int)Session["idoriginal"];
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

            int status = objmyDAL.patientMedicalRecordsInfoDisplayer(pid, ref Name, ref IDcard, ref Phone, ref Mobile, ref gender, ref maritalstatus, ref Height, ref Weight, ref BirthDate,ref medicalcertificatecategory, ref ZipCode, ref Addr, ref Email, ref NameCE, ref CERelationship, ref PhoneHEC, ref MobileMEC,
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

                float ControlTextTotalNull = 0;
                float ControlTextTotal = 0;
                foreach (Control subControl in Form.Controls[1].Controls)
                {
                    if (subControl is TextBox)
                    {
                        ControlTextTotal++;
                        if (string.IsNullOrEmpty((subControl as TextBox).Text.ToString()) || (subControl as TextBox).Text == "(尚無資料)") 
                        {
                            ControlTextTotalNull++;
                        }
                    }
                }

                float FinishItemRate = (ControlTextTotalNull/ControlTextTotal);
                float CheckRate = ((ControlTextTotal-4)/ ControlTextTotal);

                if (FinishItemRate >= CheckRate) 
                {
                    Response.Write("<script>alert('資料尚未填寫完畢，請重新填寫個人病歷資料!');</script>");
                    Response.BufferOutput = true;
                    Response.Write("<script type='text/javascript'> location.href = 'PatientMedicalRecordsAdd.aspx';</script>");
                }
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
    }
}