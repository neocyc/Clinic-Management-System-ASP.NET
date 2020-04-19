using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DBProject.DAL;

namespace DBProject
{
    public partial class PatientIndexPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sBirthDate.Attributes.Add("onfocus", "(this.type='date')");
            sSurgeryDate.Attributes.Add("onfocus", "(this.type='date')");

            int pid = (int)Session["idoriginal"];            
            string name = "";
            string phone = "";
            string address = "";
            string birthDate = "";
            int age = 0;
            string gender = "";

            if (!IsPostBack)
            {
                myDAL objmyDAL = new myDAL();
                objmyDAL.patientInfoDisplayer(pid, ref name, ref phone, ref address, ref birthDate, ref age, ref gender);
                sName.Text = name;
                sPhoneM.Text = phone;
                sBirthDate.Text = birthDate;
                Address.Text = address;


                if (gender.ToString() == "M")
                {
                    HtmlInputRadioButton Gradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("M");
                    Gradiobox.Checked = true;
                };

                if (gender.ToString() == "F")
                {
                    HtmlInputRadioButton Gradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("F");
                    Gradiobox.Checked = true;
                };

                Response.Write("<script>alert('註冊會員資料已載入.');</script>");
            }
        }

        //-----------------------Function2--------------------------//
        protected void signupV(object sender, EventArgs e)
        {
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
            Boolean surgerymedicalhistory =false;
            string SurgeryDate = "";
            string DiseaseName = "";
            Boolean allergymedicalhistory = false;
            string AllergyMedicalSymptomDescription = "";
            Boolean touringhistory = false;
            string TouringHistoryDescription = "";
            string MedicinalName = sMedicinalName.Text.ToString();

            string HtmltagName = "", AspMasterHtmltagName = "", AspHtmltagName = "";
            
            AspMasterHtmltagName = this.Master.ClientID.ToString() + "$" + this.Master.FindControl("body").ClientID.ToString() + "$";

            AspHtmltagName = "Gender";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if(this.Request.Form[HtmltagName].ToString() != null)
            {
                gender = this.Request.Form[HtmltagName].ToString();
            }            

            AspHtmltagName = "MaritalStatus";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if (this.Request.Form[HtmltagName] != null)
            {
                maritalstatus = this.Request.Form[HtmltagName].ToString();
            }                       
            
            if (this.Request.Form[AspMasterHtmltagName + "NationalityDefault"] != null || this.Request.Form[AspMasterHtmltagName + "NationalityChineseDefault"] != null || this.Request.Form[AspMasterHtmltagName + "NationalityForeignDefault"] != null) 
            {
                HtmlInputCheckBox Ncheckbox = (HtmlInputCheckBox)this.Master.FindControl("body").FindControl("NationalityDefault");
                string Nationality = "",  Chinese = "",  Foreign = "";
                if (Ncheckbox.Checked == true) 
                {
                   Nationality = Ncheckbox.Value.ToString() + ",";
                }
                
                Ncheckbox = (HtmlInputCheckBox)this.Master.FindControl("body").FindControl("NationalityChineseDefault");
                if (Ncheckbox.Checked == true)
                {
                    Chinese = Ncheckbox.Value.ToString() + ",";
                    
                    AspHtmltagName = "ChineseNationalityTouring";
                    HtmltagName = AspMasterHtmltagName + AspHtmltagName;
                    if (this.Request.Form[HtmltagName] != null) 
                    {
                        Boolean.TryParse(this.Request.Form[HtmltagName].ToString(), out chinesenationalitytouring);
                        HtmlInputRadioButton CNTradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("CNTy");
                        if (CNTradiobox.Checked == true) 
                        {
                            TouringNumber = TouringNo.Text.ToString();
                        }
                    }
                }
                
                Ncheckbox = (HtmlInputCheckBox)this.Master.FindControl("body").FindControl("NationalityForeignDefault");
                if (Ncheckbox.Checked == true)
                {
                    Foreign = Ncheckbox.Value.ToString() + ",";
                    ForeignNationalityName = sForeignNationality.Text.ToString();
                }

                nationality = (Nationality + Chinese + Foreign).TrimEnd(',');
            }

            AspHtmltagName = "FamilyMedicalHistoryR";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if (this.Request.Form[HtmltagName] != null)
            {
                Boolean.TryParse(this.Request.Form[HtmltagName].ToString(), out familymedicalhistory);
                HtmlInputRadioButton FMHradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("FMHy");
                if (FMHradiobox.Checked == true)
                {
                    AspHtmltagName = "FamilyMedicalHistoryChk";
                    if (this.Request.Form[AspHtmltagName] != null) 
                    {
                        List<string> FamilyMedicalHistory = this.Request.Form[AspHtmltagName].ToString().Split(',').ToList();
                        int i = 0;
                        string FMHItemcode = "";
                        string FMHDescription = "";
                        string FMHItemname = "";
                        foreach (string FMHitem in FamilyMedicalHistory) 
                        {                            
                            if (FMHitem.Length == 5 && (i%2) == 0)
                            {
                                string Itemcode = FMHitem.ToString() + ",";                                
                                FMHItemcode += Itemcode;                                     
                            }
                            else 
                            {
                                string Description = FMHitem.ToString() + ",";
                                FMHDescription += Description;

                                string Itemname = FMHitem.ToString().Substring(3) + ",";

                                if (FMHItemname.Contains(FMHitem.ToString().Substring(3).ToString()) == false) 
                                {
                                    FMHItemname += Itemname;
                                };                                
                            }

                            i++;
                        }

                        FamilyMedicalHistoryItemname = FMHItemname.ToString().TrimEnd(',').ToString();
                        FamilyMedicalHistoryItemcode = FMHItemcode.ToString().TrimEnd(',').ToString();
                        familymedicalhistorydescription = FMHDescription.ToString().TrimEnd(',').ToString();
                    }
                }
            }

            AspHtmltagName = "InternalMedicalR";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if (this.Request.Form[HtmltagName] != null)
            {
                Boolean.TryParse(this.Request.Form[HtmltagName].ToString(), out internalmedicalhistory);
                HtmlInputRadioButton PMHradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("IMy");
                if (PMHradiobox.Checked == true)
                {
                    AspHtmltagName = "PersonalMedicalHistoryChk";
                    if (this.Request.Form[AspHtmltagName] != null)
                    {
                        List<string> PersonalMedicalHistory = this.Request.Form[AspHtmltagName].ToString().Split(',').ToList();
                        int i = 0;
                        string PMHItemcode = "";
                        string PMHDescription = "";
                        string PMHItemname = "";
                        foreach (string PMHitem in PersonalMedicalHistory)
                        {
                            if (PMHitem.Length == 5 && (i % 2) == 0)
                            {
                                string Itemcode = PMHitem.ToString() + ",";
                                PMHItemcode += Itemcode;
                            }
                            else
                            {
                                string Description = PMHitem.ToString() + ",";
                                PMHDescription += Description;

                                string Itemname = PMHitem.ToString() + ",";

                                if (PMHItemname.Contains(PMHitem.ToString()) == false)
                                {
                                    PMHItemname += Itemname;
                                };
                            }

                            i++;
                        }

                        InternalMedicalHistoryItemname = PMHItemname.ToString().TrimEnd(',').ToString();
                        InternalMedicalHistoryItemcode = PMHItemcode.ToString().TrimEnd(',').ToString();
                        internalmedicalhistorydescription = PMHDescription.ToString().TrimEnd(',').ToString();
                    }
                }
            }

            AspHtmltagName = "SurgeryMedical";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if (this.Request.Form[HtmltagName] != null)
            {
                Boolean.TryParse(this.Request.Form[HtmltagName].ToString(), out surgerymedicalhistory);
                HtmlInputRadioButton SMradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("SMy");
                if (SMradiobox.Checked == true)
                {
                    SurgeryDate = sSurgeryDate.Text.ToString();
                    DiseaseName = sDiseaseName.Text.ToString();
                }
            }

            AspHtmltagName = "AllergyMedical";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if (this.Request.Form[HtmltagName] != null)
            {
                Boolean.TryParse(this.Request.Form[HtmltagName].ToString(), out allergymedicalhistory);
                HtmlInputRadioButton AMradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("AMy");
                if (AMradiobox.Checked == true)
                {
                    AllergyMedicalSymptomDescription = sAllergyMedicalSymptom.Text.ToString();
                }
            }

            AspHtmltagName = "Touring";
            HtmltagName = AspMasterHtmltagName + AspHtmltagName;
            if (this.Request.Form[HtmltagName] != null)
            {
                Boolean.TryParse(this.Request.Form[HtmltagName].ToString(), out touringhistory);
                HtmlInputRadioButton Tradiobox = (HtmlInputRadioButton)this.Master.FindControl("body").FindControl("Ty");
                if (Tradiobox.Checked == true)
                {
                    TouringHistoryDescription = sTourResume.Text.ToString();
                }
            }

            string mes = "";
            myDAL objmyDAL = new myDAL();
            objmyDAL.insertPatientMedicalRecords(
                pid,Name,IDcard,Phone,Mobile,gender,maritalstatus,Height,Weight,BirthDate,ZipCode,Addr,Email,NameCE,CERelationship,PhoneHEC,MobileMEC,
                JobName,
                nationality, chinesenationalitytouring, TouringNumber,ForeignNationalityName,
                familymedicalhistory,familymedicalhistorydescription,FamilyMedicalHistoryItemcode,FamilyMedicalHistoryItemname,
                internalmedicalhistory,internalmedicalhistorydescription,InternalMedicalHistoryItemcode,InternalMedicalHistoryItemname,
                surgerymedicalhistory,SurgeryDate,DiseaseName,
                allergymedicalhistory,AllergyMedicalSymptomDescription,
                touringhistory,TouringHistoryDescription,
                MedicinalName,
                ref mes
            );

            Response.BufferOutput = true;
            Response.Redirect("~/Patient/PatientHome.aspx");
        }
    }
}