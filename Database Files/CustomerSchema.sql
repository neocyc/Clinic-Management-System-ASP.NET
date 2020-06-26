GO
use DBProject

go

-- 病人病歷資料Table
create table PatientMedicalRecords
(
	PatientMRID int primary key,
	Name nvarchar(30) not null,
	IDCard char(10) not null,
	Phone varchar(11) not null,
	Mobile char(10) not null,
	Gender nchar(1) not null,
	MaritalStatus nchar(2) not null,
	Height int not null,
	Weight int not null,
	BirthDate Date not null,
	MedicalCertificateCategory nvarchar(100),
	Zipcode char(3) not null,
	Address nvarchar(500),
	Email varchar(30) not null unique,
	ContactEmergencyName nvarchar(30) not null,
	PatientRelationship nchar(10) not null,
	ContactEmergencyPhone varchar(11) not null,
	ContactEmergencyMobile char(10) not null,
	JobName nvarchar(30) not null,
	
	Nationality nvarchar(30) not null,
	ChineseNationalityTouring bit,
	TouringNumber varchar(50),
	ForeignNationalityName nvarchar(100),
	
	FamilyMedicalHistory bit,
	FamilyMedicalHistoryDescription nvarchar(500),
	FamilyMedicalHistoryItemcode char(300),
	FamilyMedicalHistoryItemname nvarchar(300),
	
	InternalMedicalHistory bit,
	InternalMedicalHistoryDescription nvarchar(500),
	InternalMedicalHistoryItemcode char(300),
	InternalMedicalHistoryItemname nvarchar(300),

	SurgeryMedicalHistory bit,
	SurgeryDate Date,
	DiseaseName nvarchar(500),

	AllergyMedicalHistory bit,
	AllergyMedicalSymptomDescription nvarchar(500),

	TouringHistory bit,
	TouringHistoryDescription nvarchar(500),

	MedicinalName nvarchar(500) not null

	foreign key(PatientMRID) references Patient(PatientID)
)

GO

use DBProject

go

-- 病人量測資料Table
create table PatientMessurementRecordsSheet
(	
    MessurementRecordsSheetID int identity(1,1) primary key,
	PatientMRSID int,	
	MessurementDateF Date,
	
	Height float,
	HeightMessurementDate Date,
	Weight float,
	WeightMessurementDate Date,
	BMI float,
	BMIMessurementDate Date,
	Temperature float,
	TemperatureMessurementDate Date,
	HeartBeat float,
	HBMessurementDate Date,
	BloodOxygen float,
	BOMessurementDate Date,
	PlasmaGlucose float,
	PGMessurementDate Date,
	BloodPressure varchar(20),
	BPMessurementDate Date

	foreign key (PatientMRSID) references Patient(PatientID)
)

GO

use DBProject

go

-- 醫生留言Table
create table DoctorFeedbackMessageBoard
(
	FeedbackMessageBoardID int identity(1,1) primary key,
	MessageTitle nvarchar(50),
	DoctorFMBID int,
	TargetPatientID int,
	DoctorName nvarchar(30) not null,
	MessageInfo nvarchar(1000),
	initDate DateTime

	foreign key (DoctorFMBID) references Doctor(DoctorID)
)

GO
use DBProject

go
create table PatientReplyMessageBoard
(
	ReplyMessageBoardID int primary key,	
	PatientRMBID int,
	PatientName nvarchar(30) not null,
	MessageInfo nvarchar(1000),
	initDate DateTime

	foreign key (ReplyMessageBoardID) references DoctorFeedbackMessageBoard(FeedbackMessageBoardID)
)



use DBProject

go

-- 系統量測警訊值Table
create table PatientMessurementDataEvaluate
(	
	DoctorMEID int primary key,	
	Name nvarchar(30) not null,
	DeptName nvarchar(30) not null unique,
	TemperatureMax float,
	TemperatureMin float,
	HeartBeatMax float,
	HeartBeatMin float,
	BloodOxygenMax float,
	BloodOxygenMin float,
	PlasmaGlucoseMax float,
	PlasmaGlucoseMin float,
	SystolicBloodPressureMax float,
	SystolicBloodPressureMin float,
	DiastolicBloodPressureMax float,
	DiastolicBloodPressureMin float

	foreign key (DoctorMEID) references Doctor(DoctorID)
)

use DBProject

go

-- 系統衛教影片資料Table
create table HealthEducationVideoDatas
(
	UploadVideoID  int identity(1,1) primary key,
	VideoTitle nvarchar(100) not null,
	VideoCategories nvarchar(50),
	VideoURL nvarchar(max),
	initDate DateTime,
	updateDate Datetime
)