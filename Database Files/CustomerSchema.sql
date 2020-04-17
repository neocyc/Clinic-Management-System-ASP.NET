GO
use DBProject

go

create table PatientMedicalRecords
(
	PatientMRID int primary key,
	Name nvarchar(30) not null,
	IDCard char(10) not null,
	Phone nchar(11) not null,
	Mobile char(10) not null,
	Gender nchar(1) not null,
	MaritalStatus nchar(2) not null,
	Height int not null,
	Weight int not null,
	BirthDate Date not null,
	Zipcode char(3) not null,
	Address nvarchar,
	Email varchar(30) not null unique,
	ContactEmergencyName nvarchar(30) not null,
	PatientRelationship nchar not null,
	ContactEmergencyPhone nchar(11) not null,
	ContactEmergencyMobile char(10) not null,
	JobName nvarchar(30) not null,
	
	Nationality nvarchar not null,
	ChineseNationality bit,
	TouringNumber varchar,
	ForeignNationalityName nvarchar,
	
	FamilyMedicalHistory bit,
	FamilyMedicalHistoryDescription nvarchar,
	FamilyMedicalHistoryItemcode char(5),
	FamilyMedicalHistoryItemname nvarchar,
	
	InternalMedicalHistory bit,
	InternalMedicalHistoryDescription nvarchar,
	InternalMedicalHistoryItemcode char(5),
	InternalMedicalHistoryItemname nvarchar,

	SurgeryMedicalHistory bit,
	SurgeryDate Date,
	DiseaseName nvarchar,

	AllergyMedicalHistory bit,
	AllergyMedicalSymptomDescription nvarchar,

	TouringHistory bit,
	TouringHistoryDescription nvarchar,

	MedicinalName nvarchar not null

	foreign key(PatientMRID) references Patient(PatientID)
)

