GO
use DBProject

go

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

create table DoctorFeedbackMessageBoard
(
	FeedbackMessageBoardID int identity(1,1) primary key,
	MessageTitle nvarchar(50),
	DoctorFMBID int,
	TargetPatientID int,
	DoctorName nvarchar(30) not null,
	MessageInfo nvarchar(1000),
	initDate Date

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
	initDate Date

	foreign key (ReplyMessageBoardID) references DoctorFeedbackMessageBoard(FeedbackMessageBoardID)
)

