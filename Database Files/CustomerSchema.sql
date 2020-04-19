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
	FamilyMedicalHistoryItemcode char(5),
	FamilyMedicalHistoryItemname nvarchar(300),
	
	InternalMedicalHistory bit,
	InternalMedicalHistoryDescription nvarchar(500),
	InternalMedicalHistoryItemcode char(5),
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

