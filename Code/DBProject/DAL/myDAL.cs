using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

 
namespace DBProject.DAL
{
	//Database Layer of 3 tier architecture
	public class myDAL
    {
		//connection string of the server database
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;






		//-----------------------------------------------------------------------------------//
		//																					 //
		//									SIGNUP											 //
		//																					 //
		//-----------------------------------------------------------------------------------//



		/*CHECKS WHETHER IT IS A VALID USER AND RETURN ITS TYPE*/
		public int validateLogin (string Email, string Password, ref int type , ref int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                SqlCommand cmd1 = new SqlCommand("Login", con);     
                cmd1.CommandType = CommandType.StoredProcedure;

				/*
                 procedure Login
                 @email varchar(30),
                 @password varchar(20),
                 @status int output,
                 @ID int output,
                 @type int output
                 */


				cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
                cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password; 

                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@type", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();
				
                int status = (int)cmd1.Parameters["@status"].Value;
                type = (int)cmd1.Parameters["@type"].Value;
                id = (int)cmd1.Parameters["@ID"].Value;

                return status;
            }

            catch(SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();   
            }
        }

        




		/*THIS FUNCTION WILL VALIDATE ALL THE INFORMAIION OF OF USER (PATIENT)*/
        public int validateUser (string Name, string BirthDate, string Email , string Password , string PhoneNo , string gender , string Address, ref int id)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {

                /*
                  Procedure  PatientSignup
                  @name varchar(20),
                  @phone char(15),
                  @address varchar(40),
                  @date Date,
                  @gender char(1),
                  @password varchar(20),
                  @email varchar(30),
                  @status int output,
                  @ID int output
                  */


                SqlCommand cmd1 = new SqlCommand("PatientSignup", con);              
                cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = Name;
				cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Value = Address;
				cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;
				cmd1.Parameters.Add("@date", SqlDbType.Date).Value = BirthDate;
				cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = Email;
				cmd1.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = Password;
				cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Value = PhoneNo;
				
                cmd1.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
				
                cmd1.ExecuteNonQuery();           

                int status = (int)cmd1.Parameters["@status"].Value;

                if (status != 0)
                {
                    id = (int)cmd1.Parameters["@ID"].Value;
                }


                return status; 
            }

            catch(SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();   
            }
        }







        //-----------------------------------------------------------------------------------//
        //                                                                                   //
        //                                       ADMIN                                       //
        //                                                                                   //
        //-----------------------------------------------------------------------------------//



        /*THIS FUNCTION CHECKS WHEATHER EMAIL OF A DOCTOR ALREADY EXISTS IN THE DATABASE */

        public int DoctorEmailAlreadyExist(string Email)
        {
            int status = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            /*
             @Email
             @status OUTPUT
             */


            SqlCommand cmd = new SqlCommand("CheckDoctorEmail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = Email;
            cmd.Parameters.Add("@status", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            status = (int)cmd.Parameters["@status"].Value;
            con.Close();

            return status;
        }







        /*THIS FUNCTION WILL ADD THE DOCTOR TO THE DATA BASE */
        public void AddDoctor(string Name, string Email, string Password, string BirthDate, int dept, string Phone, char gender, string Address, int exp, int salary, int Charges_per_visit, string spec, string qual)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();


            SqlCommand cmd = new SqlCommand("AddDoctor", con);
            cmd.CommandType = CommandType.StoredProcedure;

            /*
            @Name 
            @Email
            @Password 
            @BirthDate 
            @dept
            @gender
            @Address 
            @Exp
            @Salary
            @qualification
            @phone
            @spec
             */


            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 30).Value = Email;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30).Value = Password;
            cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = BirthDate;
            cmd.Parameters.Add("@dept", SqlDbType.VarChar, 30).Value = dept;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = Address;
            cmd.Parameters.Add("@Exp", SqlDbType.VarChar, 30).Value = exp;
            cmd.Parameters.Add("@Salary", SqlDbType.VarChar, 30).Value = salary;
            cmd.Parameters.Add("@charges", SqlDbType.VarChar, 30).Value = Charges_per_visit;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar, 30).Value = Phone;
            cmd.Parameters.Add("@spec", SqlDbType.VarChar, 30).Value = spec;
            cmd.Parameters.Add("@qual", SqlDbType.VarChar, 30).Value = qual;

            cmd.ExecuteNonQuery();
            con.Close();


        }





        /*THIS FUNCTION WILL ADD STAFF TO THE DATA BASE*/
        public int AddStaff(string Name, string BirthDate, string Phone, char gender, string Address, int salary, string Qual, string Designation)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();

            SqlCommand cmd = new SqlCommand("AddStaff", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {


                /*
                @Name 
                @BirthDate 
                @phone
                @gender
                @designation
                @Address 
                @Salary
                @phone
                @qualification
                */


                /*INPUTS*/
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 30).Value = Name;
                cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = BirthDate;
                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 30).Value = Phone;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 1).Value = gender;
                cmd.Parameters.Add("@salary", SqlDbType.Int, 30).Value = salary;
                cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 30).Value = Designation;
                cmd.Parameters.Add("@Qualification", SqlDbType.VarChar, 1).Value = Qual;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address;

                cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            con.Close();
            return 1;

        }







        /*THIS FUNCTION WILL RUN MULTIPLE QUERIES AND GET ALL THE INFORMATION NEEDED TO DISPLAY AT ADMIN HOME*/
        public void GetAdminHomeInformation(ref DataTable[] arrTable)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();


            SqlCommand cmd = new SqlCommand("SELECT * FROM Total_Patient", con);
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(arrTable[0]);

            cmd.CommandText = "SELECT * FROM Total_Doctors";
            Adapter.Fill(arrTable[1]);

            cmd.CommandText = "SELECT * FROM Income";
            Adapter.Fill(arrTable[2]);

            cmd.CommandText = "SELECT * FROM Department_View";
            Adapter.Fill(arrTable[3]);

            cmd.CommandText = "SELECT * FROM Appointment_view";
            Adapter.Fill(arrTable[4]);


            con.Close();

        }






        /*THIS FUNCTION IS INTENDED TO DELETE DOCTOR BUT SECRETLY IT ONLY UPDATE THE STATUS*/
        public int DeleteDoctor(int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            con.Close();
            return 1;

        }


        public void insertHealthEducationVideoDatas(int vid,string VideoTitle,string VideoCategories,string VideoURL,string UploadDate, ref string mes)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {
                /*
                    insertInHealthEducationVideoDatasTable      
                 
                    @vid
                    @videoTitle 
                    @videoCategories
                    @videoURL
                    @initDate
                    @updateDate

                */

                string sql_s = " BEGIN "
                             + " if not exists(select * from HealthEducationVideoDatas where UploadVideoID = @vid) "
                             + " BEGIN "
                             + " insert into HealthEducationVideoDatas values(@videoTitle, @videoCategories, @videoURL, GETDATE(), GETDATE()) "
                             + " END "
                             + @" UPDATE [dbo].[HealthEducationVideoDatas]
                                  SET [VideoTitle] = @videoTitle
                                     ,[VideoCategories] = @videoCategories
                                     ,[VideoURL] = @videoURL
                                     ,[updateDate] = @updateDate
                                  WHERE UploadVideoID = @vid "
                             + " END ";

                cmd1 = new SqlCommand(sql_s, con);

                //datetime string is "" or null
                object datenull = null;
                if (UploadDate.ToString() == "")
                {
                    UploadDate = Convert.ToDateTime(datenull).ToString();
                }                
                
                //Input
                cmd1.Parameters.Add("@vid", SqlDbType.Int).Value = vid;
                cmd1.Parameters.Add("@videoTitle", SqlDbType.NVarChar,100).Value = VideoTitle;
                cmd1.Parameters.Add("@videoCategories", SqlDbType.NVarChar,50).Value = VideoCategories;
                cmd1.Parameters.Add("@videoURL", SqlDbType.NVarChar).Value = VideoURL;
                cmd1.Parameters.Add("@updateDate", SqlDbType.DateTime).Value = UploadDate;        
                cmd1.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
            }

            finally
            {
                con.Close();
            }
        }




        public int DeleteHealthEducationVideo(int id, ref string mes)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {
                string sql_s = " BEGIN "
                             + " delete from HealthEducationVideoDatas where UploadVideoID = @id "
                             + " END ";

                SqlCommand cmd = new SqlCommand(sql_s, con);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
                return -1;
            }

            con.Close();
            return 1;

        }


        /*THIS FUNCTION WILL DELLETE STAFF FROM THE DOCTOR */
        public int DeleteStaff(int id)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DELETESTAFF", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }

            return 1;
        }


        /*LOADS THE TABLE OF DOCTOR / SPECIFIED DOCTORS ON THE BASIS OF SEARCH QUERY*/
        public void LoadDoctor(ref DataTable table, String SearchQuery)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            con.Open();


            if (SearchQuery == "")
            {
                cmd = new SqlCommand(
                "SELECT Doctor.DoctorID as ID , Doctor.Name , D.DeptName as Department FROM Doctor JOIN Department D ON D.DeptNo = Doctor.DeptNo" +
                " WHERE Doctor.Status = 1",
                con);

            }
            else
            {
                cmd = new SqlCommand(
                "SELECT a.DoctorID as ID,  a.Name, D.DeptName as Department FROM department D join (SELECT * FROM Doctor WHERE Doctor.Status = 1 AND Doctor.Name like  '%' + @DName + '%')  a ON a.DeptNo = D.DeptNo",
                con);
                cmd.Parameters.AddWithValue("@DName", SearchQuery);
            }


            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(table);
            con.Close();
        }






        /*LOADS THE TABLE OF PATIENT ON THE BASIS OF SEARCH QUERY*/
        /*FOR EMPTY QUERY RETURN ALL INFORMATION OTHERWISE RETURN ONLY REQUIRED TUPLE*/
        public void LoadPatient(ref DataTable table, String SearchQuery)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            con.Open();


            if (SearchQuery == "")
            {
                cmd = new SqlCommand("SELECT * FROM PATIENT_VIEW", con);

            }
            else
            {
                cmd = new SqlCommand("SELECT Patient.PatientID, Patient.Name, Patient.Phone from Patient" +
                " WHERE patient.name like '%' + @SName + '%' ", con);
                cmd.Parameters.AddWithValue("@SName", SearchQuery.Trim());

            }


            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(table);
            con.Close();
        }





        /*LOADS THE TABLE OF OTHER STAFF ON THE BASIS OF SEARCH QUERY*/
        /*IF THE QUERY IS EMPTY THEN LOAD ALL STAFF MEMBERS OTHER WISE ONLY SPECIFIED*/
        public void LoadOtherStaff(ref DataTable table, String SearchQuery)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            con.Open();


            if (SearchQuery == "")
            {
                cmd = new SqlCommand("SELECT * FROM STAFF_VIEW", con);

            }
            else
            {
                cmd = new SqlCommand("SELECT StaffID as ID , Name , Designation from OtherStaff WHERE Name like '%' + @pName + '%'", con);
                cmd.Parameters.AddWithValue("@PName", SearchQuery.Trim());
            }


            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(table);
            con.Close();
        }





        public int GETPATIENT(int pid, ref string name, ref string phone, ref string address, ref string birthDate, ref int age, ref string gender)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            try
            {

                /*
				 * PROCEDURE RetrievePatientData
				 * 
                 @ID int,
                 @name varchar(20) output,
                 @phone char(15) output,
                 @address varchar(40) output,
                 @birthDate varchar (10) output,
                 @age int output,
                 @gender char(1)
                 */


                SqlCommand cmd1 = new SqlCommand("RetrievePatientData", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@id", SqlDbType.Int).Value = pid;

                /*PUTTING OUTPUTS*/
                cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@birthDate", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@gender", SqlDbType.Char, 1).Direction = ParameterDirection.Output;

                cmd1.ExecuteNonQuery();

                /* GETTING OUTPUTS*/
                name = (string)cmd1.Parameters["@name"].Value.ToString();
                phone = (string)cmd1.Parameters["@phone"].Value.ToString();
                address = (string)cmd1.Parameters["@address"].Value.ToString();
                birthDate = (string)cmd1.Parameters["@birthDate"].Value.ToString();
                age = Convert.ToInt32((cmd1.Parameters["@age"].Value));
                gender = (string)cmd1.Parameters["@gender"].Value.ToString();


                return 0;
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }










        public int GET_DOCTOR_PROFILE(int dID, ref string name, ref string phone, ref string gender, ref float charges_Per_Visit, ref float ReputeIndex, ref int PatientsTreated, ref string qualification, ref string specialization, ref int workE, ref int age)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            try
            {
                /*
                procedure GET_DOCTOR_PROFILE

                @dID int,

                @name varchar(20) output,
                @phone char(15) output,
                @gender varchar(2) output,
                @charges float output,
                @RI float output,
                @PTreated int output,
                @qualification varchar(100) output,
                @specialization varchar(50) output,
                @workE int output,
                @age int output
                 */

                SqlCommand cmd1 = new SqlCommand("GET_DOCTOR_PROFILE", con);

                cmd1.CommandType = CommandType.StoredProcedure;


                //Inputs
                cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;

                //Outputs
                cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@charges", SqlDbType.Float).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@RI", SqlDbType.Float).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@PTreated", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@qualification", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@specialization", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@workE", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;


                cmd1.ExecuteNonQuery();

                /*GETTING OUTPUT*/
                name = (string)cmd1.Parameters["@name"].Value;
                phone = (string)cmd1.Parameters["@phone"].Value;
                gender = (string)cmd1.Parameters["@gender"].Value;
                charges_Per_Visit = Convert.ToSingle(cmd1.Parameters["@charges"].Value);
                ReputeIndex = Convert.ToSingle(cmd1.Parameters["@RI"].Value);
                PatientsTreated = (int)cmd1.Parameters["@PTreated"].Value;
                qualification = (string)cmd1.Parameters["@qualification"].Value;
                specialization = (string)cmd1.Parameters["@specialization"].Value;
                workE = (int)cmd1.Parameters["@workE"].Value;
                age = (int)cmd1.Parameters["@age"].Value;



            }

            catch (SqlException ex)
            {
                return -1;
            }

            con.Close();
            return 1;
        }



        public int GETSATFF(int id, ref string name, ref string phone, ref string address, ref string gender, ref string desig, ref int sal)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("GET_STAFF", con);
            cmd1.CommandType = CommandType.StoredProcedure;


            //Inputs
            cmd1.Parameters.Add("@id", SqlDbType.Int).Value = id;

            //Outputs
            cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@address", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@desig", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            cmd1.Parameters.Add("@sal", SqlDbType.Int).Direction = ParameterDirection.Output;

            //try
            {
                cmd1.ExecuteNonQuery();


                /*GETTING OUTPUT*/
                name = (string)cmd1.Parameters["@name"].Value;
                phone = (string)cmd1.Parameters["@phone"].Value;
                gender = (string)cmd1.Parameters["@gender"].Value;
                address = (string)cmd1.Parameters["@address"].Value;
                desig = (string)cmd1.Parameters["@desig"].Value;
                sal = (int)cmd1.Parameters["@sal"].Value;

            }
            //catch
            {
                //return -1;
            }


            return 1;


        }





        //-----------------------------------------------------------------------------------//
        //                                                                                   //
        //                                       PATIENT                                     //
        //                                                                                   //
        //-----------------------------------------------------------------------------------//









        public void patientMessageBoardInfoDisplayer(int pid,ref DataTable messageInfo, ref string mes) 
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                string sql = "select DoctorName, initDate, MessageInfo from DoctorFeedbackMessageBoard where TargetPatientID = @pID ";

                cmd = new SqlCommand(sql, con);

                cmd.Parameters.Add("@pID", SqlDbType.Int).Value = pid;


                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds);

                messageInfo = ds.Tables[0];

            }

            catch (SqlException ex)
            {
                mes = ex.ToString();
            }

            finally
            {
                con.Close();
            }
        }

        /*-------------------DISPLAYS PATIENT INFORMATION AT PATIENT HOME--------------------------------------- */

        public int patientInfoDisplayer(int pid, ref string name, ref string phone, ref string address, ref string birthDate, ref int age, ref string gender)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();


			try
			{

				/*
				 * PROCEDURE RetrievePatientData
				 * 
                 @ID int,
                 @name varchar(20) output,
                 @phone char(15) output,
                 @address varchar(40) output,
                 @birthDate varchar (10) output,
                 @age int output,
                 @gender char(1)
                 */


				SqlCommand cmd1 = new SqlCommand("RetrievePatientData", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				cmd1.Parameters.Add("@id", SqlDbType.Int).Value = pid;

				/*PUTTING OUTPUTS*/
				cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@phone", SqlDbType.Char, 15).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@birthDate", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@address", SqlDbType.VarChar, 40).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@gender", SqlDbType.Char, 1).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();            

				/* GETTING OUTPUTS*/
				name = (string)cmd1.Parameters["@name"].Value;
				phone = (string)cmd1.Parameters["@phone"].Value;
				address = (string)cmd1.Parameters["@address"].Value;
				birthDate = (string)cmd1.Parameters["@birthDate"].Value;
				age = (int)cmd1.Parameters["@age"].Value;
				gender = (string)cmd1.Parameters["@gender"].Value;


				return 0;
			}

			catch (SqlException ex)
			{
				return -1;
			}

			finally
			{
				con.Close();
			}
		}


        /*-------------------DISPLAYS PATIENT Medical Record INFORMATION AT PATIENT HOME--------------------------------------- */

        public int patientMedicalRecordsInfoDisplayer(int pid, ref string Name, ref string IDcard, ref string Phone, ref string Mobile, ref string gender, ref string maritalstatus, ref int Height, ref int Weight, ref string BirthDate, ref string medicalcertificatecategory, ref string ZipCode, ref string Addr, ref string Email, ref string NameCE, ref string CERelationship, ref string PhoneHEC, ref string MobileMEC, ref string JobName, ref string nationality, ref Boolean chinesenationalitytouring, ref string TouringNumber, ref string ForeignNationalityName, ref Boolean familymedicalhistory, ref string familymedicalhistorydescription, ref string FamilyMedicalHistoryItemcode, ref string FamilyMedicalHistoryItemname, ref Boolean internalmedicalhistory, ref string internalmedicalhistorydescription, ref string InternalMedicalHistoryItemcode, ref string InternalMedicalHistoryItemname, ref Boolean surgerymedicalhistory, ref string SurgeryDate, ref string DiseaseName, ref Boolean allergymedicalhistory, ref string AllergyMedicalSymptomDescription, ref Boolean touringhistory, ref string TouringHistoryDescription, ref string MedicinalName)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();


            try
            {

                /*
                 * RetrievePatientMedicalRecordsTable
                 *
                 * 

                 @pmrID int,
                 @name nvarchar(30),
                 @cardID char(10),
                 @phone varchar(11),
                 @mobile char(10),
                 @gender nchar(1),
                 @maritalStatus nchar(2),
                 @height int,
                 @weight int,
                 @birthDate date,
                 @medicalCertificateCategory nvarchar(100),
                 @zipcode char(3),
                 @address nvarchar(500),
                 @email varchar(30),
                 @contactEmergencyName nvarchar(30),
                 @patientRelationship nchar(10),
                 @contactEmergencyPhone varchar(11),
                 @contactEmergencyMobile char(10),
                 @jobName nvarchar(30),
                 @nationality nvarchar(30),
                 @chineseNationalityTouring bit,
                 @touringNumber varchar(50),
                 @foreignNationalityName nvarchar(100),
                 @familyMedicalHistory bit,
                 @familyMedicalHistoryDescription nvarchar(500),
                 @familyMedicalHistoryItemcode char(300),
                 @familyMedicalHistoryItemname nvarchar(300),
                 @internalMedicalHistory bit,
                 @internalMedicalHistoryDescription nvarchar(500),
                 @internalMedicalHistoryItemcode char(300),
                 @internalMedicalHistoryItemname nvarchar(300),
                 @surgeryMedicalHistory bit,
                 @surgeryDate date,
                 @diseaseName nvarchar(500),
                 @allergyMedicalHistory bit,
                 @allergyMedicalSymptomDescription nvarchar(500),
                 @touringHistory bit,
                 @touringHistoryDescription nvarchar(500),
                 @medicinalName nvarchar(500)                             
                */

                //select @name=Name, @phone=Phone, @address=Address, @gender=Gender, @age=DATEDIFF(YEAR, BirthDate, GETDATE()), @birthDate = BirthDate from Patient where PatientID = @ID


                string sql_s = " BEGIN "                             
                             + " select @pmrID=PatientMRID, @name=Name, @cardID=IDCard, @phone=Phone, @mobile=Mobile, @gender=Gender, @maritalStatus=MaritalStatus, @height=Height, @weight=Weight, @birthDate=BirthDate, @medicalcertificatecategory=MedicalCertificateCategory, @zipcode=Zipcode, @address=Address, @email=Email, @contactEmergencyName=ContactEmergencyName, @patientRelationship=PatientRelationship, @contactEmergencyPhone=ContactEmergencyPhone, @contactEmergencyMobile=ContactEmergencyMobile, @jobName=JobName, @nationality=Nationality, @chineseNationalityTouring=ChineseNationalityTouring, @touringNumber=TouringNumber, @foreignNationalityName=ForeignNationalityName, @familyMedicalHistory=FamilyMedicalHistory, @familyMedicalHistoryDescription=FamilyMedicalHistoryDescription, @familyMedicalHistoryItemcode=FamilyMedicalHistoryItemcode, @familyMedicalHistoryItemname=FamilyMedicalHistoryItemname, @internalMedicalHistory=InternalMedicalHistory, @internalMedicalHistoryDescription=InternalMedicalHistoryDescription, @internalMedicalHistoryItemcode=InternalMedicalHistoryItemcode, @internalMedicalHistoryItemname=InternalMedicalHistoryItemname, @surgeryMedicalHistory=SurgeryMedicalHistory, @surgeryDate=SurgeryDate, @diseaseName=DiseaseName, @allergyMedicalHistory=AllergyMedicalHistory, @allergyMedicalSymptomDescription=AllergyMedicalSymptomDescription, @touringHistory=TouringHistory, @touringHistoryDescription=TouringHistoryDescription, @medicinalName=MedicinalName from PatientMedicalRecords where PatientMRID = @pmrID"
                             + " END ";

                SqlCommand cmd1 = new SqlCommand(sql_s, con);

                cmd1.Parameters.Add("@pmrID", SqlDbType.Int).Value = pid;

                /*PUTTING OUTPUTS*/
                cmd1.Parameters.Add("@name", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@cardID", SqlDbType.Char, 10).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 11).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@mobile", SqlDbType.Char, 10).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@gender", SqlDbType.NChar, 1).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@maritalStatus", SqlDbType.NChar, 2).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@height", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@weight", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@birthDate", SqlDbType.Date).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@medicalcertificatecategory", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@zipcode", SqlDbType.Char, 3).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@address", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@email", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@contactEmergencyName", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@patientRelationship", SqlDbType.NChar, 10).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@contactEmergencyPhone", SqlDbType.VarChar, 11).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@contactEmergencyMobile", SqlDbType.Char, 10).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@jobName", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@nationality", SqlDbType.NVarChar, 30).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@chineseNationalityTouring", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@touringNumber", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@foreignNationalityName", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@familyMedicalHistory", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@familyMedicalHistoryDescription", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@familyMedicalHistoryItemcode", SqlDbType.Char, 300).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@familyMedicalHistoryItemname", SqlDbType.NVarChar, 300).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@internalMedicalHistory", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@internalMedicalHistoryDescription", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@internalMedicalHistoryItemcode", SqlDbType.Char, 300).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@internalMedicalHistoryItemname", SqlDbType.NVarChar, 300).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@surgeryMedicalHistory", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@surgeryDate", SqlDbType.Date).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@diseaseName", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@allergyMedicalHistory", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@allergyMedicalSymptomDescription", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@touringHistory", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@touringHistoryDescription", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add("@medicinalName", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;               

                cmd1.ExecuteNonQuery();

                /* GETTING OUTPUTS*/
                Name = cmd1.Parameters[1].Value.ToString();
                IDcard = cmd1.Parameters[2].Value.ToString();
                Phone = cmd1.Parameters[3].Value.ToString();
                Mobile = cmd1.Parameters[4].Value.ToString();
                gender = cmd1.Parameters[5].Value.ToString();
                maritalstatus = cmd1.Parameters[6].Value.ToString();                
                Int32.TryParse(cmd1.Parameters[7].Value.ToString(), out Height);
                Int32.TryParse(cmd1.Parameters[8].Value.ToString(), out Weight);
                BirthDate = cmd1.Parameters[9].Value.ToString();
                medicalcertificatecategory = cmd1.Parameters[10].Value.ToString();
                ZipCode = cmd1.Parameters[11].Value.ToString();
                Addr = cmd1.Parameters[12].Value.ToString();
                Email = cmd1.Parameters[13].Value.ToString();
                NameCE = cmd1.Parameters[14].Value.ToString();
                CERelationship = cmd1.Parameters[15].Value.ToString();
                PhoneHEC = cmd1.Parameters[16].Value.ToString();
                MobileMEC = cmd1.Parameters[17].Value.ToString();
                JobName = cmd1.Parameters[18].Value.ToString();
                nationality = cmd1.Parameters[19].Value.ToString();
                Boolean.TryParse(cmd1.Parameters[20].Value.ToString(), out chinesenationalitytouring);
                TouringNumber = cmd1.Parameters[21].Value.ToString();
                ForeignNationalityName = cmd1.Parameters[22].Value.ToString();
                Boolean.TryParse(cmd1.Parameters[23].Value.ToString(), out familymedicalhistory);
                familymedicalhistorydescription = cmd1.Parameters[24].Value.ToString();
                FamilyMedicalHistoryItemcode = cmd1.Parameters[25].Value.ToString();
                FamilyMedicalHistoryItemname = cmd1.Parameters[26].Value.ToString();
                Boolean.TryParse(cmd1.Parameters[27].Value.ToString(), out internalmedicalhistory);
                internalmedicalhistorydescription = cmd1.Parameters[28].Value.ToString();
                InternalMedicalHistoryItemcode = cmd1.Parameters[29].Value.ToString();
                InternalMedicalHistoryItemname = cmd1.Parameters[30].Value.ToString();
                Boolean.TryParse(cmd1.Parameters[31].Value.ToString(), out surgerymedicalhistory);
                SurgeryDate = cmd1.Parameters[32].Value.ToString();
                DiseaseName = cmd1.Parameters[33].Value.ToString();
                Boolean.TryParse(cmd1.Parameters[34].Value.ToString(), out allergymedicalhistory);
                AllergyMedicalSymptomDescription = cmd1.Parameters[35].Value.ToString();
                Boolean.TryParse(cmd1.Parameters[36].Value.ToString(), out touringhistory);
                TouringHistoryDescription = cmd1.Parameters[37].Value.ToString();
                MedicinalName = cmd1.Parameters[38].Value.ToString();

                /*
                name = (string)cmd1.Parameters["@name"].Value;
                phone = (string)cmd1.Parameters["@phone"].Value;
                address = (string)cmd1.Parameters["@address"].Value;
                birthDate = (string)cmd1.Parameters["@birthDate"].Value;
                age = (int)cmd1.Parameters["@age"].Value;
                gender = (string)cmd1.Parameters["@gender"].Value;
                */

                return 0;
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }



        /*---------------------------GENERATE BILL HISTORY--------------------------------------*/

        public int getBillHistory(int id, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
				 * 
				 * procedure RetrieveBillHistory
                  
				@pID int,
                  @count int OUTPUT
                 */


				cmd1 = new SqlCommand("RetrieveBillHistory", con); 
				cmd1.CommandType = CommandType.StoredProcedure;

				/*INPUT*/
				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = id;

				/*OUTPUT*/
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);  
				}

				result = ds.Tables[0];     
				return (int)cmd1.Parameters["@count"].Value;



			}
			/*ON ERROR RETURN -1*/
			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}





		//-------------------------------------CURRENT APPOINTMENTS------------------------------------------//

		public int appointmentTodayDisplayer(int pid, ref string dName, ref string timings)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
				 *  procedure RetrieveCurrentAppointment
				 * 
                    @pID int,
                    @dName varchar(30) OUTPUT,
                    @timings varchar(30) OUTPUT,
                    @count int OUTPUT

                 */

				cmd1 = new SqlCommand("RetrieveCurrentAppointment", con);
				cmd1.CommandType = CommandType.StoredProcedure;

                cmd1.Parameters.Add("@pid", SqlDbType.Int).Value = pid;

                //Outputs
                cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@timings", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@dName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();   //Execute the cmd query

				int status = (int)cmd1.Parameters["@count"].Value;

				if (status == 0)
				{
					return status;
				}

				else
				{
					dName = (string)cmd1.Parameters["@dName"].Value;
					timings = (string)cmd1.Parameters["@timings"].Value;
					return status;
				}
			}

			catch (SqlException ex)
			{
				return -1;  //if any error, return -1
			}

			finally
			{
				con.Close();
			}
		}




		//-------------------------------------TREATMENT HISTORY------------------------------------------//
		public int getTreatmentHistory(int id, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
                  @pID int,
                  @count int OUTPUT
                 */

				cmd1 = new SqlCommand("RetrieveTreatmentHistory", con);   //Name of your SQL Procedure
				cmd1.CommandType = CommandType.StoredProcedure;

				//INPUTS
				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = id;
				
				//OUTPUTS
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				
				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);  
				}

				result = ds.Tables[0];      
				return (int)cmd1.Parameters["@count"].Value;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}




		/*-------------------------TAKE APPOINMENT------------------------------------*/
		public int getdeptInfo(ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{
				/*EXECUTING QUERY*/
				cmd1 = new SqlCommand("select* from deptInfo", con);
				cmd1.CommandType = CommandType.Text;
				
				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);  
				}

				result = ds.Tables[0];
				return 1;
			}

			catch (SqlException ex)
			{
				return -1;
			}

			finally
			{
				con.Close();
			}
		}




		//-------------------------------------VIEW DOCTORS------------------------------------------//

		public int getDeptDoctorInfo(string deptName, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
                  Procedure RetrieveDeptDoctorInfo

                  @deptName varchar (30)
                 */


				cmd1 = new SqlCommand("RetrieveDeptDoctorInfo", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				//Input
				cmd1.Parameters.Add("@deptName", SqlDbType.VarChar, 30).Value = deptName;
				
				cmd1.ExecuteNonQuery();  

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);   
				}

				/*FILL TABLE*/
				result = ds.Tables[0];

				return 1;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}






        //-------------------------------------VIEW PATIENT MESSUREMENT DATA------------------------------------------//

        public int getPatientMessurementDataInfo(int pid, ref DataTable result, ref string mes)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {

                /*
                  Retrieve PatientMessurementRecordsSheet

                  @pmrsID int
                 */

                string sql_s = " BEGIN "
                             + " select * from PatientMessurementRecordsSheet where PatientMRSID = @pmrsID "
                             + " END ";

                cmd1 = new SqlCommand(sql_s, con);
                
                //Input
                cmd1.Parameters.Add("@pmrsID", SqlDbType.Int).Value = pid;

                cmd1.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    da.Fill(ds);
                }

                /*FILL TABLE*/
                result = ds.Tables[0];

                return 1;
            }
            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
                return -1;
            }

            finally
            {
                con.Close();
            }
        }


        public int getPatientMessurementDataWarningValue(ref DataTable result, ref string mes)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {

                /*
                  Retrieve PatientMessurementDataEvaluate
                */

                string sql_s = @" BEGIN 
                                      select AVG([TemperatureMax]) as [TemperatureMax]
                                            ,AVG([TemperatureMin]) as [TemperatureMin]
                                            ,AVG([HeartBeatMax]) as [HeartBeatMax]
                                            ,AVG([HeartBeatMin]) as [HeartBeatMin]
                                            ,AVG([BloodOxygenMax]) as [BloodOxygenMax]
                                            ,AVG([BloodOxygenMin]) as [BloodOxygenMin]
                                            ,AVG([PlasmaGlucoseMax]) as [PlasmaGlucoseMax]
                                            ,AVG([PlasmaGlucoseMin]) as [PlasmaGlucoseMin]
                                            ,AVG([SystolicBloodPressureMax]) as [SystolicBloodPressureMax]
                                            ,AVG([SystolicBloodPressureMin]) as [SystolicBloodPressureMin]
                                            ,AVG([DiastolicBloodPressureMax]) as [DiastolicBloodPressureMax]
                                            ,AVG([DiastolicBloodPressureMin]) as [DiastolicBloodPressureMin]
                                      from PatientMessurementDataEvaluate
                                  END ";

                cmd1 = new SqlCommand(sql_s, con);               

                cmd1.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    da.Fill(ds);
                }

                /*FILL TABLE*/
                result = ds.Tables[0];

                return 1;
            }
            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
                return -1;
            }

            finally
            {
                con.Close();
            }
        }


        public int getHealthEducationVideoDatas(ref DataTable result, ref string mes)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {

                /*
                  Retrieve HealthEducationVideoDatas
                */

                string sql_s = " BEGIN "
                             + " select * from HealthEducationVideoDatas "
                             + " END ";     

                cmd1 = new SqlCommand(sql_s, con);

                cmd1.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    da.Fill(ds);
                }

                /*FILL TABLE*/
                result = ds.Tables[0];

                return 1;
            }
            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
                return -1;
            }

            finally
            {
                con.Close();
            }
        }


        //-------------------------------------DOCTOR PROFILE------------------------------------------//


        public int doctorInfoDisplayer(int dID, ref string name, ref string phone, ref string gender, ref float charges_Per_Visit, ref float ReputeIndex, ref int PatientsTreated, ref string qualification, ref string specialization, ref int workE, ref int age)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();


			try
			{
				/*
                procedure RetrieveDoctorData

                @dID int,

                @name varchar(20) output,
                @phone char(15) output,
                @gender varchar(2) output,
                @charges float output,
                @RI float output,
                @PTreated int output,
                @qualification varchar(100) output,
                @specialization varchar(50) output,
                @workE int output,
                @age int output
                 */

				SqlCommand cmd1 = new SqlCommand("RetrieveDoctorData", con);             

				cmd1.CommandType = CommandType.StoredProcedure;


				//Inputs
				cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;
				
				//Outputs
				cmd1.Parameters.Add("@name", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@phone", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@gender", SqlDbType.VarChar, 2).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@charges", SqlDbType.Float).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@RI", SqlDbType.Float).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@PTreated", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@qualification", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@specialization", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@workE", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@age", SqlDbType.Int).Direction = ParameterDirection.Output;


				cmd1.ExecuteNonQuery();    

				/*GETTING OUTPUT*/
				name = (string)cmd1.Parameters["@name"].Value;
				phone = (string)cmd1.Parameters["@phone"].Value;
				gender = (string)cmd1.Parameters["@gender"].Value;
				charges_Per_Visit = Convert.ToSingle(cmd1.Parameters["@charges"].Value);
				ReputeIndex = Convert.ToSingle(cmd1.Parameters["@RI"].Value);
				PatientsTreated = (int)cmd1.Parameters["@PTreated"].Value;
				qualification = (string)cmd1.Parameters["@qualification"].Value;
				specialization = (string)cmd1.Parameters["@specialization"].Value;
				workE = (int)cmd1.Parameters["@workE"].Value;
				age = (int)cmd1.Parameters["@age"].Value;


				return 0;
			}

			catch (SqlException ex)
			{
				return -1;
			}

			finally
			{
				con.Close();    
			}
		}


		//-------------------------------------APPOINTMENT TAKER------------------------------------------//

		public int getFreeSlots(int dID, int pID, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
                  Procedure RetrieveFreeSlots

                  @dID int,
                  @pID int,
                  @count int OUTPUT
                 */


				cmd1 = new SqlCommand("RetrieveFreeSlots", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				//Input
				cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;
				cmd1.Parameters.Add("@pID", SqlDbType.Int).Value = pID;

				//Output
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				
				cmd1.ExecuteNonQuery();   

				using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
				{
					da.Fill(ds);   
				}
				result = ds.Tables[0];     

				return (int)cmd1.Parameters["@count"].Value;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}




		//-------------------------------------APPOINTMENT REQUEST SENT------------------------------------------//

		public int insertAppointment(int dID, int pID, int freeSlot, ref string mes)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			string m = "";

			con.InfoMessage += delegate (object sender, SqlInfoMessageEventArgs e)
			{
				m += "\n" + e.Message;
			};


			try
			{

				/*
                  Procedure insertInAppointmentTable

                  @dID int,
                  @pID int,
                  @freeSlot int
                 */


				cmd1 = new SqlCommand("insertInAppointmentTable", con);
				cmd1.CommandType = CommandType.StoredProcedure;

				//Input
				cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = dID;
				cmd1.Parameters.Add("@pID", SqlDbType.Int).Value = pID;
				cmd1.Parameters.Add("@freeSlot", SqlDbType.Int).Value = freeSlot;
				
				cmd1.ExecuteNonQuery();   
				mes = m;

				return 0;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}




        //-------------------------------------PATIENT MEDICALRECORDS------------------------------------------//
        public void insertPatientMedicalRecords(int pid,string Name,string IDcard,string Phone,string Mobile,string gender,string maritalstatus,int Height,int Weight,string BirthDate,string medicalcertificatecategory, string ZipCode,string Addr,string Email,string NameCE,string CERelationship,string PhoneHEC,string MobileMEC,string JobName,string nationality,Boolean chinesenationalitytouring,string TouringNumber,string ForeignNationalityName,Boolean familymedicalhistory,string familymedicalhistorydescription,string FamilyMedicalHistoryItemcode,string FamilyMedicalHistoryItemname,Boolean internalmedicalhistory,string internalmedicalhistorydescription,string InternalMedicalHistoryItemcode,string InternalMedicalHistoryItemname,Boolean surgerymedicalhistory,string SurgeryDate,string DiseaseName,Boolean allergymedicalhistory,string AllergyMedicalSymptomDescription,Boolean touringhistory,string TouringHistoryDescription,string MedicinalName,ref string mes)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {
                /*
                 insertInPatientMedicalRecordsTable
                 
                 @pmrID int,
                 @name nvarchar(30),
                 @cardID char(10),
                 @phone varchar(11),
                 @mobile char(10),
                 @gender nchar(1),
                 @maritalStatus nchar(2),
                 @height int,
                 @weight int,
                 @birthDate date,
                 @medicalCertificateCategory nvarchar(100),
                 @zipcode char(3),
                 @address nvarchar(500),
                 @email varchar(30),
                 @contactEmergencyName nvarchar(30),
                 @patientRelationship nchar(10),
                 @contactEmergencyPhone varchar(11),
                 @contactEmergencyMobile char(10),
                 @jobName nvarchar(30),
                 @nationality nvarchar(30),
                 @chineseNationalityTouring bit,
                 @touringNumber varchar(50),
                 @foreignNationalityName nvarchar(100),
                 @familyMedicalHistory bit,
                 @familyMedicalHistoryDescription nvarchar(500),
                 @familyMedicalHistoryItemcode char(300),
                 @familyMedicalHistoryItemname nvarchar(300),
                 @internalMedicalHistory bit,
                 @internalMedicalHistoryDescription nvarchar(500),
                 @internalMedicalHistoryItemcode char(300),
                 @internalMedicalHistoryItemname nvarchar(300),
                 @surgeryMedicalHistory bit,
                 @surgeryDate date,
                 @diseaseName nvarchar(500),
                 @allergyMedicalHistory bit,
                 @allergyMedicalSymptomDescription nvarchar(500),
                 @touringHistory bit,
                 @touringHistoryDescription nvarchar(500),
                 @medicinalName nvarchar(500)                             
                */

                string sql_s = " BEGIN "
                             + " if not exists(select * from PatientMedicalRecords where PatientMRID=@pmrID) "
                             + " BEGIN "
                             + " insert into PatientMedicalRecords values(@pmrID,@name,@cardID,@phone,@mobile,@gender,@maritalStatus,@height,@weight,@birthDate,@medicalCertificateCategory,@zipcode,@address,@email,@contactEmergencyName,@patientRelationship,@contactEmergencyPhone,@contactEmergencyMobile,@jobName,@nationality,@chineseNationalityTouring,@touringNumber,@foreignNationalityName,@familyMedicalHistory,@familyMedicalHistoryDescription,@familyMedicalHistoryItemcode,@familyMedicalHistoryItemname,@internalMedicalHistory,@internalMedicalHistoryDescription,@internalMedicalHistoryItemcode,@internalMedicalHistoryItemname,@surgeryMedicalHistory,@surgeryDate,@diseaseName,@allergyMedicalHistory,@allergyMedicalSymptomDescription,@touringHistory,@touringHistoryDescription,@medicinalName)"
                             + " END "
                             + " update PatientMedicalRecords set PatientMRID = @pmrID, Name = @name, IDCard = @cardID, Phone = @phone, Mobile = @mobile, Gender = @gender, MaritalStatus = @maritalStatus, Height = @height, Weight = @weight, BirthDate = @birthDate, MedicalCertificateCategory = @medicalCertificateCategory, Zipcode = @zipcode, Address = @address, Email = @email, ContactEmergencyName = @contactEmergencyName, PatientRelationship = @patientRelationship, ContactEmergencyPhone = @contactEmergencyPhone, ContactEmergencyMobile = @contactEmergencyMobile, JobName = @jobName, Nationality = @nationality, ChineseNationalityTouring = @chineseNationalityTouring, TouringNumber = @touringNumber, ForeignNationalityName = @foreignNationalityName, FamilyMedicalHistory = @familyMedicalHistory, FamilyMedicalHistoryDescription = @familyMedicalHistoryDescription, FamilyMedicalHistoryItemcode = @familyMedicalHistoryItemcode, FamilyMedicalHistoryItemname = @familyMedicalHistoryItemname, InternalMedicalHistory = @internalMedicalHistory, InternalMedicalHistoryDescription = @internalMedicalHistoryDescription, InternalMedicalHistoryItemcode = @internalMedicalHistoryItemcode, InternalMedicalHistoryItemname = @internalMedicalHistoryItemname, SurgeryMedicalHistory = @surgeryMedicalHistory, SurgeryDate = @surgeryDate, DiseaseName = @diseaseName, AllergyMedicalHistory =@allergyMedicalHistory, AllergyMedicalSymptomDescription = @allergyMedicalSymptomDescription, TouringHistory = @touringHistory, TouringHistoryDescription = @touringHistoryDescription, MedicinalName = @medicinalName where PatientMRID = @pmrID"
                             + " END ";

                cmd1 = new SqlCommand(sql_s, con);

                //datetime string is "" or null
                object datenull = null;
                if (BirthDate.ToString() == "") 
                {
                    BirthDate = Convert.ToDateTime(datenull).ToString();
                }

                if (SurgeryDate.ToString() == "") 
                {
                    SurgeryDate = Convert.ToDateTime(datenull).ToString();
                }

                //Input
                cmd1.Parameters.Add("@pmrID", SqlDbType.Int).Value = pid;
                cmd1.Parameters.Add("@name", SqlDbType.NVarChar,30).Value = Name;
                cmd1.Parameters.Add("@cardID", SqlDbType.Char,10).Value = IDcard;
                cmd1.Parameters.Add("@phone", SqlDbType.VarChar,11).Value = Phone;
                cmd1.Parameters.Add("@mobile", SqlDbType.Char,10).Value = Mobile;
                cmd1.Parameters.Add("@gender", SqlDbType.NChar,1).Value = gender;
                cmd1.Parameters.Add("@maritalStatus", SqlDbType.NChar,2).Value = maritalstatus;
                cmd1.Parameters.Add("@height", SqlDbType.Int).Value = Height;
                cmd1.Parameters.Add("@weight", SqlDbType.Int).Value = Weight;
                cmd1.Parameters.Add("@birthDate", SqlDbType.Date).Value = BirthDate;
                cmd1.Parameters.Add("@medicalCertificateCategory", SqlDbType.NVarChar, 100).Value = medicalcertificatecategory;
                cmd1.Parameters.Add("@zipcode", SqlDbType.Char,3).Value = ZipCode;
                cmd1.Parameters.Add("@address", SqlDbType.NVarChar,500).Value = Addr;
                cmd1.Parameters.Add("@email", SqlDbType.VarChar,30).Value = Email;
                cmd1.Parameters.Add("@contactEmergencyName", SqlDbType.NVarChar,30).Value = NameCE;
                cmd1.Parameters.Add("@patientRelationship", SqlDbType.NChar,10).Value = CERelationship;
                cmd1.Parameters.Add("@contactEmergencyPhone", SqlDbType.VarChar,11).Value = PhoneHEC;
                cmd1.Parameters.Add("@contactEmergencyMobile", SqlDbType.Char,10).Value = MobileMEC;
                cmd1.Parameters.Add("@jobName", SqlDbType.NVarChar,30).Value = JobName;
                cmd1.Parameters.Add("@nationality", SqlDbType.NVarChar,30).Value = nationality;
                cmd1.Parameters.Add("@chineseNationalityTouring", SqlDbType.Bit).Value = chinesenationalitytouring;
                cmd1.Parameters.Add("@touringNumber", SqlDbType.VarChar,50).Value = TouringNumber;
                cmd1.Parameters.Add("@foreignNationalityName", SqlDbType.NVarChar,100).Value = ForeignNationalityName;
                cmd1.Parameters.Add("@familyMedicalHistory", SqlDbType.Bit).Value = familymedicalhistory;
                cmd1.Parameters.Add("@familyMedicalHistoryDescription", SqlDbType.NVarChar,500).Value = familymedicalhistorydescription;
                cmd1.Parameters.Add("@familyMedicalHistoryItemcode", SqlDbType.Char,300).Value = FamilyMedicalHistoryItemcode;
                cmd1.Parameters.Add("@familyMedicalHistoryItemname", SqlDbType.NVarChar,300).Value = FamilyMedicalHistoryItemname;
                cmd1.Parameters.Add("@internalMedicalHistory", SqlDbType.Bit).Value = internalmedicalhistory;
                cmd1.Parameters.Add("@internalMedicalHistoryDescription", SqlDbType.NVarChar,500).Value = internalmedicalhistorydescription;
                cmd1.Parameters.Add("@internalMedicalHistoryItemcode", SqlDbType.Char,300).Value = InternalMedicalHistoryItemcode;
                cmd1.Parameters.Add("@internalMedicalHistoryItemname", SqlDbType.NVarChar,300).Value = InternalMedicalHistoryItemname;
                cmd1.Parameters.Add("@surgeryMedicalHistory", SqlDbType.Bit).Value = surgerymedicalhistory;
                cmd1.Parameters.Add("@surgeryDate", SqlDbType.Date).Value = SurgeryDate;
                cmd1.Parameters.Add("@diseaseName", SqlDbType.NVarChar,500).Value = DiseaseName;
                cmd1.Parameters.Add("@allergyMedicalHistory", SqlDbType.Bit).Value = allergymedicalhistory;
                cmd1.Parameters.Add("@allergyMedicalSymptomDescription", SqlDbType.NVarChar,500).Value = AllergyMedicalSymptomDescription;
                cmd1.Parameters.Add("@touringHistory", SqlDbType.Bit).Value = touringhistory;
                cmd1.Parameters.Add("@touringHistoryDescription", SqlDbType.NVarChar,500).Value = TouringHistoryDescription;
                cmd1.Parameters.Add("@medicinalName", SqlDbType.NVarChar,500).Value = MedicinalName;

                cmd1.ExecuteNonQuery();                
            }

            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
            }

            finally
            {
                con.Close();
            }
        }






        //-------------------------------------PATIENT MESSUREMENTDATA ------------------------------------------//
        public void insertPatientMessurementDatas(int pid, string MessurementDateF, float Height, string HeightMessurementDate, float Weight, string WeightMessurementDate, float BMI, string BMIMessurementDate, float Temperature, string TemperatureMessurementDate, float HeartBeat, string HBMessurementDate, float BloodOxygen, string BOMessurementDate, float PlasmaGlucose, string PGMessurementDate, string BloodPressure, string BPMessurementDate,ref string mes)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {
                /*
                 insertInPatientMessurementRecordsSheetTable
                 
                 @pmrsID int,
                 @messurementDateF date,
                 @height float,
                 @heightMessurementDate date
                 @weight float,
                 @weightMessurementDate date,
                 @BMI float,
                 @BMImessurementDate date,
                 @temperature float,
                 @temperatureMessurementDate date,
                 @heartBeat float,
                 @hbMessurementDate date,
                 @bloodOxygen float,
                 @boMessurementDate date,
                 @plasmaGlucose float,
                 @pgMessurementDate date,
                 @bloodPressure float,
                 @bpMessurementDate date
                 
                */

                string sql_s = " BEGIN "                             
                             + " BEGIN "
                             + " insert into PatientMessurementRecordsSheet values(@pmrsID, @messurementDateF, @height, @heightMessurementDate, @weight, @weightMessurementDate, @BMI, @BMImessurementDate, @temperature, @temperatureMessurementDate, @heartBeat, @hbMessurementDate, @bloodOxygen, @boMessurementDate, @plasmaGlucose, @pgMessurementDate, @bloodPressure, @bpMessurementDate) "
                             + " END "                            
                             + " END ";

                cmd1 = new SqlCommand(sql_s, con);

                //datetime string is "" or null
                object datenull = null;
                if (MessurementDateF.ToString() == "")
                {
                    MessurementDateF = Convert.ToDateTime(datenull).ToString();
                }
                if (HeightMessurementDate.ToString() == "")
                {
                    HeightMessurementDate = Convert.ToDateTime(datenull).ToString();
                }
                if (WeightMessurementDate.ToString() == "")
                {
                    WeightMessurementDate = Convert.ToDateTime(datenull).ToString();
                }
                if (BMIMessurementDate.ToString() == "")
                {
                    BMIMessurementDate = Convert.ToDateTime(datenull).ToString();
                }
                if (TemperatureMessurementDate.ToString() == "")
                {
                    TemperatureMessurementDate = Convert.ToDateTime(datenull).ToString();
                }
                if (BOMessurementDate.ToString() == "")
                {
                    BOMessurementDate = Convert.ToDateTime(datenull).ToString();
                }
                if (PGMessurementDate.ToString() == "")
                {
                    PGMessurementDate = Convert.ToDateTime(datenull).ToString();
                }
                if (BPMessurementDate.ToString() == "")
                {
                    BPMessurementDate = Convert.ToDateTime(datenull).ToString();
                }

                //Input
                cmd1.Parameters.Add("@pmrsID", SqlDbType.Int).Value = pid;
                cmd1.Parameters.Add("@messurementDateF", SqlDbType.Date).Value = MessurementDateF;
                cmd1.Parameters.Add("@height", SqlDbType.Float).Value = Height;
                cmd1.Parameters.Add("@heightMessurementDate", SqlDbType.Date).Value = HeightMessurementDate;
                cmd1.Parameters.Add("@weight", SqlDbType.Float).Value = Weight;
                cmd1.Parameters.Add("@weightMessurementDate", SqlDbType.Date).Value = WeightMessurementDate;
                cmd1.Parameters.Add("@BMI", SqlDbType.Float).Value = BMI;
                cmd1.Parameters.Add("@BMImessurementDate", SqlDbType.Date).Value = BMIMessurementDate;
                cmd1.Parameters.Add("@temperature", SqlDbType.Float).Value = Temperature;
                cmd1.Parameters.Add("@temperatureMessurementDate", SqlDbType.Date).Value = TemperatureMessurementDate;
                cmd1.Parameters.Add("@heartBeat", SqlDbType.Float).Value = HeartBeat;
                cmd1.Parameters.Add("@hbMessurementDate", SqlDbType.Date).Value = HBMessurementDate;
                cmd1.Parameters.Add("@bloodOxygen", SqlDbType.Float).Value = BloodOxygen;
                cmd1.Parameters.Add("@boMessurementDate", SqlDbType.Date).Value = BOMessurementDate;
                cmd1.Parameters.Add("@plasmaGlucose", SqlDbType.Float).Value = PlasmaGlucose;
                cmd1.Parameters.Add("@pgMessurementDate", SqlDbType.Date).Value = PGMessurementDate;
                cmd1.Parameters.Add("@bloodPressure", SqlDbType.VarChar,20).Value = BloodPressure;
                cmd1.Parameters.Add("@bpMessurementDate", SqlDbType.Date).Value = BPMessurementDate;

                cmd1.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
            }

            finally
            {
                con.Close();
            }
        }







        //-------------------------------------PATIENT NOTIFICATIONS------------------------------------------//

        public int getNotifications(int pid, ref string dName, ref string timings)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
                  procedure RetrievePatientNotifications

                    @pID int,
                    @dName varchar(30) OUTPUT,
                    @timings varchar(30) OUTPUT,
                    @count int OUTPUT

                 */

				cmd1 = new SqlCommand("RetrievePatientNotifications", con);   //Name of your SQL Procedure
				cmd1.CommandType = CommandType.StoredProcedure;

				//Inputs
				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = pid;
			
				//Outputs
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@timings", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@dName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				
				cmd1.ExecuteNonQuery();   


				int status = (int)cmd1.Parameters["@count"].Value;

				if (status == 0)
				{
					return status;
				}

				else
				{
					dName = (string)cmd1.Parameters["@dName"].Value;
					timings = (string)cmd1.Parameters["@timings"].Value;
					return status;
				}
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}






		//-------------------------------------PATIENT FEEDBACK------------------------------------------//
		//-------------------------------------FUNCTION 1------------------------------------------//

		public int isFeedbackPending(int pid, ref string dName, ref string timings, ref int aID)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
                  procedure RetrievePendingFeedback

                    @pID int,
                    @dName varchar(30) OUTPUT,
                    @timings varchar(30) OUTPUT,
                    @count int OUTPUT

                 */

				cmd1 = new SqlCommand("RetrievePendingFeedback", con);   
				cmd1.CommandType = CommandType.StoredProcedure;

				//Inputs
				cmd1.Parameters.Add("@pId", SqlDbType.Int).Value = pid;
				
				//Outputs
				cmd1.Parameters.Add("@count", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@timings", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@dName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
				cmd1.Parameters.Add("@aID", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmd1.ExecuteNonQuery();   
				
				int status = (int)cmd1.Parameters["@count"].Value;

				if (status == 0)
				{
					return status;
				}

				else
				{
					dName = (string)cmd1.Parameters["@dName"].Value;
					timings = (string)cmd1.Parameters["@timings"].Value;
					aID = (int)cmd1.Parameters["@aID"].Value;

					return status;
				}
			}

			catch (SqlException ex)
			{
				return -1; 
			}

			finally
			{
				con.Close();
			}
		}




		//-------------------------------------FUNCTION 2------------------------------------------//

		public int givePendingFeedback(int aID)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd1;

			try
			{

				/*
                  procedure storeFeedback

                    @aID int
                 */

				cmd1 = new SqlCommand("storeFeedback", con);   
				cmd1.CommandType = CommandType.StoredProcedure;

				//Inputs
				cmd1.Parameters.Add("@aId", SqlDbType.Int).Value = aID;

				cmd1.ExecuteNonQuery();


				return 0;
			}

			catch (SqlException ex)
			{
				return -1;  
			}

			finally
			{
				con.Close();
			}
		}

















        //-----------------------------------------------------------------------------------//
        //                                                                                   //
        //                                       DOCTOR                                      //
        //                                                                                   //
        //-----------------------------------------------------------------------------------//

        //-------------------------------------DOCTOR SETTING  PatientMessurementData Evaluate Value------------------------------------------//
        public void insertPatientMessurementDataEvaluate(int did, string DoctorName, string DeptName, float TemperatureMax, float TemperatureMin, float HeartBeatMax, float HeartBeatMin, float BloodOxygenMax, float BloodOxygenMin, float PlasmaGlucoseMax, float PlasmaGlucoseMin, float SystolicBloodPressureMax, float SystolicBloodPressureMin, float DiastolicBloodPressureMax, float DiastolicBloodPressureMin, ref string mes)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {
                /*
                 insertInPatientMessurementDataEvaluateTable
                 
                 @dID int,   
                 @name nvarchar(30),
                 @deptName nvarchar(30),
                 @temperatureMax float,
                 @temperatureMin float,
                 @heartBeatMax float,
                 @heartBeatMin float,
                 @bloodOxygenMax float,
                 @bloodOxygenMin float,
                 @plasmaGlucoseMax float,
                 @plasmaGlucoseMin float,
                 @systolicBloodPressureMax float,
                 @systolicBloodPressureMin float,
                 @diastolicBloodPressureMax float,
                 @diastolicBloodPressureMin float,
                 
                */

                string sql_s = " BEGIN "
                             + " if not exists(select * from PatientMessurementDataEvaluate where DoctorMEID=@dID) "
                             + " BEGIN "
                             + " insert into PatientMessurementDataEvaluate values( @dID, @name, @deptName, @temperatureMax, @temperatureMin, @heartBeatMax, @heartBeatMin, @bloodOxygenMax, @bloodOxygenMin, @plasmaGlucoseMax, @plasmaGlucoseMin, @systolicBloodPressureMax, @systolicBloodPressureMin, @diastolicBloodPressureMax, @diastolicBloodPressureMin )"
                             + " END "
                             + @" 
                               UPDATE [dbo].[PatientMessurementDataEvaluate]
                               SET [DoctorMEID] = @dID
                                  ,[Name] = @name
                                  ,[DeptName] = @deptName
                                  ,[TemperatureMax] = @temperatureMax
                                  ,[TemperatureMin] = @temperatureMin
                                  ,[HeartBeatMax] = @heartBeatMax
                                  ,[HeartBeatMin] = @heartBeatMin
                                  ,[BloodOxygenMax] = @bloodOxygenMax
                                  ,[BloodOxygenMin] = @bloodOxygenMin
                                  ,[PlasmaGlucoseMax] = @plasmaGlucoseMax
                                  ,[PlasmaGlucoseMin] = @plasmaGlucoseMin
                                  ,[SystolicBloodPressureMax] = @systolicBloodPressureMax
                                  ,[SystolicBloodPressureMin] = @systolicBloodPressureMin
                                  ,[DiastolicBloodPressureMax] = @diastolicBloodPressureMax
                                  ,[DiastolicBloodPressureMin] = @diastolicBloodPressureMin "

                             + " END ";

                cmd1 = new SqlCommand(sql_s, con);

                //Input
                cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = did;
                cmd1.Parameters.Add("@name", SqlDbType.NVarChar, 30).Value = DoctorName;
                cmd1.Parameters.Add("@deptName", SqlDbType.NVarChar, 30).Value = DeptName;
                cmd1.Parameters.Add("@temperatureMax", SqlDbType.Float).Value = TemperatureMax;
                cmd1.Parameters.Add("@temperatureMin", SqlDbType.Float).Value = TemperatureMin;
                cmd1.Parameters.Add("@heartBeatMax", SqlDbType.Float).Value = HeartBeatMax;
                cmd1.Parameters.Add("@heartBeatMin", SqlDbType.Float).Value = HeartBeatMin;
                cmd1.Parameters.Add("@bloodOxygenMax", SqlDbType.Float).Value = BloodOxygenMax;
                cmd1.Parameters.Add("@bloodOxygenMin", SqlDbType.Float).Value = BloodOxygenMin;
                cmd1.Parameters.Add("@plasmaGlucoseMax", SqlDbType.Float).Value = PlasmaGlucoseMax;
                cmd1.Parameters.Add("@plasmaGlucoseMin", SqlDbType.Float).Value = PlasmaGlucoseMin;
                cmd1.Parameters.Add("@systolicBloodPressureMax", SqlDbType.Float).Value = SystolicBloodPressureMax;
                cmd1.Parameters.Add("@systolicBloodPressureMin", SqlDbType.Float).Value = SystolicBloodPressureMin;
                cmd1.Parameters.Add("@diastolicBloodPressureMax", SqlDbType.Float).Value = DiastolicBloodPressureMax;
                cmd1.Parameters.Add("@diastolicBloodPressureMin", SqlDbType.Float).Value = DiastolicBloodPressureMin;

                cmd1.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
            }

            finally
            {
                con.Close();
            }
        }



        public void insertDoctorFeedbackMessage(int DoctorID, int PatientID, string DoctorName, string MessageInfo ,DateTime initDate, ref string mes) 
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {
                /*
                 insertInDoctorFeedbackMessageBoardTable
                 
                 @dID int,
                 @pID int,
                 @dName nvarchar(30),
                 @messageInfo nvarchar(1000)
                 @initDate Date                 
                */


                string sql_s = " BEGIN "
                             + " BEGIN "
                             + " insert into DoctorFeedbackMessageBoard values( ' ', @dID, @pID, @dName, @messageInfo, @initDate ) "
                             + " END "
                             + " END ";

                cmd1 = new SqlCommand(sql_s, con);     
                
                //Input
                cmd1.Parameters.Add("@dID", SqlDbType.Int).Value = DoctorID;
                cmd1.Parameters.Add("@pID", SqlDbType.Int).Value = PatientID;
                cmd1.Parameters.Add("@dName", SqlDbType.NVarChar,30).Value = DoctorName;
                cmd1.Parameters.Add("@messageInfo", SqlDbType.NVarChar,1000).Value = MessageInfo;
                cmd1.Parameters.Add("@initDate", SqlDbType.DateTime).Value = initDate;                

                cmd1.ExecuteNonQuery();
                
            }

            catch (SqlException ex)
            {
                string m = "資料無法寫入資料庫，請聯絡工程師: 錯誤訊息->" + ex.ToString();
                mes = m;
            }

            finally
            {
                con.Close();
            }
        }

        /*THIS FUNCITON WILL RETRIEVE THE INFORMATION OF CURRENT LOGGED IN DOCTOR*/
        public int docinfo_DAL(int doctorid, ref DataTable result)
		{

			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;

			try
			{

				cmd = new SqlCommand("Doctor_Information_By_ID1", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ID", SqlDbType.Int);
				cmd.Parameters["@id"].Value = doctorid;
				cmd.ExecuteNonQuery();

				using (SqlDataAdapter da = new SqlDataAdapter(cmd))
				    da.Fill(ds);

				result = ds.Tables[0];

			}

			catch (SqlException ex)
			{
				return 0;
			}

			finally
			{ 
			    con.Close();
			}

			return 1;
		}






		/*THIS FUNCTION WILL RETURN PENDING APPOINTMENT FORM THE DATABASE IN THE FORM OF DATASET*/
		public void GetAllpendingappointments_DAL(int doctorid, ref DataTable DT)
		{

			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			
			try
			{
                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand("PENDING_APPOINTMENTS2", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DOCTOR_ID", SqlDbType.Int);
				cmd.Parameters["@DOCTOR_ID"].Value = doctorid;
				cmd.ExecuteNonQuery();

                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }

               DT = ds.Tables[0];

            }

            catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
			}

			finally
			{
				con.Close();
			}
		}




		/*THIS FUNCTION WILL BE CALLED WHEN DOCTOR APPROVE THE REQUEST OF PATIENT*/
		public int UpdateAppointment_DAL(int Appointmentid)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			int result = 0;


            try
            {
                cmd = new SqlCommand("APPROVE_APPOINTMENT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@APPOINT_ID", SqlDbType.Int).Value = Appointmentid;

                result = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

			return result;
		}



		/*DELETES THE APPOINTMENT*/
		public int Deleteappointment_DAL(int appointmentid)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			


			try
			{
				cmd = new SqlCommand("delete_APPOINTMENT", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@APPOINT_ID", SqlDbType.Int).Value = appointmentid;
				cmd.ExecuteNonQuery();
			}

			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
				return -1;
			}

			finally
			{
				con.Close();

			}
			return 1;
			
		}




		/*THIS FUNTION RETURN CURRENT DAY APPONTMENT*/
		public int search_patient_DAL(int did, ref DataTable result)
		{

			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();

			SqlCommand cmd;

            try
            {
                //close show bill information of Field
                string sql_s =  " BEGIN "
                                + " SELECT A.AppointID, P.Name as [Patient's Name], A.[Date], isnull( convert( varchar(2),Disease) ,  'NA') as [Disease], isnull( convert( varchar(2),Progress) ,  'NA') as [Progress], isnull( convert( varchar(2),Prescription) ,  'NA') as [Prescription], Appointment_Status  FROM Appointment A "
                                + " JOIN Patient P ON A.PatientID = P.PatientID "
                                + " WHERE A.DoctorID = @DOC_ID AND A.Appointment_Status = 1 and DATEDIFF(DAY, A.Date, GETDATE()) = 0 "
                                + " END ";
                cmd = new SqlCommand(sql_s, con);

                /*
                cmd = new SqlCommand("TODAYS_APPOINTMENTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                */

                cmd.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = did;

                cmd.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }

                result = ds.Tables[0];
            }

            catch (SqlException ex)
            {

            }
            
            finally
            {
                con.Close();
            }

            return 1;
		}






		/*UPDATE THE PRESCRIPTION WHEN APPOINTMENT IS GOING ON BY DOCTOR*/
		public int update_prescription_DAL(int did, int appointid, string disease, string progres, string prescrip)
		{
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			try
			{
				cmd = new SqlCommand("UpdatePrescription", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@docId", SqlDbType.Int).Value = did;
				cmd.Parameters.Add("@appointid", SqlDbType.Int).Value = appointid;
				cmd.Parameters.Add("@Disease", SqlDbType.VarChar, 30).Value = disease;
				cmd.Parameters.Add("@progress", SqlDbType.VarChar, 50).Value = progres;
				cmd.Parameters.Add("@prescription", SqlDbType.VarChar, 60).Value = prescrip;

				cmd.ExecuteNonQuery();
			}
			
			catch (SqlException ex)
			{
				return 0;
			}
			finally
			{ 
			con.Close();
			}

			return 1;
			

		}


		/*GENERATES BILL*/

		public int generate_bill_DAL(int docid, ref DataTable result)
		{
			DataSet ds = new DataSet();
			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("generate_bill", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@dId", SqlDbType.Int);
                cmd.Parameters["@did"].Value = docid;


                cmd.ExecuteNonQuery();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);

                }

                result = ds.Tables[0];
              
            }

            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }

            return 1;
		}




		public void paid_bill_DAL(int did, int appoint)
		{

			SqlConnection con = new SqlConnection(connString);
			con.Open();
			SqlCommand cmd;
			
			cmd = new SqlCommand("finishedPaid", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@docId", SqlDbType.Int).Value = did;
			cmd.Parameters.Add("@appointid", SqlDbType.Int).Value = appoint;
			
			cmd.ExecuteNonQuery();

            con.Close();
		}


        public void Unpaid_bill_DAL(int did, int appoint)
        {

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            cmd = new SqlCommand("finishedUnPaid", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@docId", SqlDbType.Int).Value = did;
            cmd.Parameters.Add("@appointid", SqlDbType.Int).Value = appoint;

            cmd.ExecuteNonQuery();

            con.Close();
        }


        public int getPHistory(int id, ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd1;

            try
            {

                /*
				 * 
				 * procedure RetrievePHistory
                  
				@dID int,
                  @count int OUTPUT
                 */


                cmd1 = new SqlCommand("RetrievePHistory", con);
                cmd1.CommandType = CommandType.StoredProcedure;

                /*INPUT*/
                cmd1.Parameters.Add("@dId", SqlDbType.Int).Value = id;

                cmd1.ExecuteNonQuery();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                {
                    da.Fill(ds);
                }

                result = ds.Tables[0];
                return 1;
            }

            /*ON ERROR RETURN -1*/
            catch (SqlException ex)
            {
                return -1;
            }

            finally
            {
                con.Close();
            }
        }


    }


}
