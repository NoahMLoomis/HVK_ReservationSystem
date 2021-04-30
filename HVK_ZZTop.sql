/*******************************************************************************
   HVK Database Winter 2021 Updated V2 version

CD - Jan 12, 2021 - converted from Oracle DB
CD - Feb 5 - updated reservation dates
CD - Feb 11 - updated date conversion
CD - March 9, 2021 - implemented updates requested for Web class 
   - added password to the owner table, and set the data entries to null
   - added the VaccinationChecked field to the PetVaccination table, made it
     BIT, no nulls, and defaulted it to false (0) as per last year.  Set it to 
     true / 1 for any pets who have been in during the last three months.
   - Removed Video field from the KennelLog table
   - Changed all boolean-like fields to BIT, no nulls:  Pet - Fixed, Climber, Barker
     and Run - Covered.  Removed constraints on Covered and Fixed, since BIT
     now takes care of that.  Climber, Barker default to 0 - false as per original.
     Covered and Fixed have no default as per original.
   - Changed the date aging at the end to keep converting / aging based on 
     today's date, and determined a delta to apply based on original script date.
CD - March 17th - changed pet, birthdate to varchar(10) and updated data inserts
     as requested for the Web class.  Strings were updated with the 
     raw dates, updated by 4 years.  It will make it easier to handle incomplete
     date entries.

********************************************************************************/
/*******************************************************************************
420-J20-HR Student Naming conventions

Ensure that before you create your Database, you replace the _xy in the DB name
with your initials.

For instance, my initials are cd, so the DB name throughout should be changed
from HVK_xy to HVK_cd.

Recommend that you save a copy of this file with these changes in your H drive.

********************************************************************************/

USE master;

/*******************************************************************************
   Drop database if it exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'HVK_ZZTop')
BEGIN
	ALTER DATABASE [HVK_ZZTop] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [HVK_ZZTop] SET ONLINE;
	DROP DATABASE [HVK_ZZTop];
END

GO

/*******************************************************************************
   Create database
********************************************************************************/
CREATE DATABASE [HVK_ZZTop];
GO

USE [HVK_ZZTop];
GO

/*******************************************************************************
   Create Tables
********************************************************************************/

/* List of Tables ported from Oracle
HVK_DAILY_RATE - DailyRate
HVK_DISCOUNT - Discount
HVK_KENNEL_LOG - KennelLog
HVK_MEDICATION - Medication
HVK_OWNER - Owner
HVK_PET - Pet
HVK_PET_RESERVATION - PetReservation
HVK_PET_RESERVATION_DISCOUNT - PetReservationDiscount
HVK_PET_RESERVATION_SERVICE - PetReservationService
HVK_PET_VACCINATION - PetVaccination
HVK_RESERVATION - Reservation
HVK_RESERVATION_DISCOUNT - ReservationDiscount
HVK_RUN - Run
HVK_SERVICE - Service
HVK_SPECIAL_NOTES - SpecialNotes
HVK_VACCINATION - Vaccination
HVK_VETERINARIAN - Veterinarian */


/* DDL for Table DailyRate */

CREATE TABLE 
[dbo].[DailyRate]
(
   [DailyRateId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Rate] NUMERIC (5, 2)  NOT NULL,
   [DogSize] CHAR(1)  NULL,
   [ServiceId] INT NOT NULL
);

GO

/* DDL for Table Discount */

CREATE TABLE 
[dbo].[Discount]
(
   [DiscountId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Desciption] VARCHAR(50)  NOT NULL,
   [Percentage] NUMERIC(3, 2)  NOT NULL,
   [Type] CHAR(1)  NOT NULL
);

GO

/* DDL for Table KennelLog */

CREATE TABLE 
[dbo].[KennelLog]
(
   [LogDate] DATE NOT NULL,
   [SequenceNumber] INT NOT NULL DEFAULT 1,
   [Notes] VARCHAR(200)  NOT NULL,
   [PetReservationId] INT  NOT NULL
);

GO

/* DDL for Table Medication */

CREATE TABLE 
[dbo].[Medication]
(
   [MedicationId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Name] VARCHAR(50), 
   [Dosage] VARCHAR(50), 
   [SpecialInstruct] VARCHAR(50), 
   [EndDate] DATE, 
   [PetReservationId] INT NOT NULL
);
  
GO 

/* DDL for Table Veterinarian */


CREATE TABLE 
[dbo].[Veterinarian]
(
   [VeterinarianId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Name] VARCHAR(50)  NOT NULL,
   [Phone] CHAR(10)  NOT NULL,
   [Street] VARCHAR(40)  NULL,
   [City] VARCHAR(25)  NULL,
   [Province] CHAR(2)  NULL,
   [PostalCode] CHAR(6)  NULL
);

GO

/* DDL for Table Owner */

CREATE TABLE 
[dbo].[Owner]
(
   [OwnerId] INT IDENTITY (1, 1) PRIMARY KEY,
   [FirstName] VARCHAR(25)  NOT NULL,
   [LastName] VARCHAR(25)  NOT NULL,
   [Street] VARCHAR(40)  NULL,
   [City] VARCHAR(25)  NULL,
   [Province] CHAR(2)  NULL,
   [PostalCode] CHAR(6)  NULL,
   [Phone] CHAR(10)  NULL,
   [CellPhone] CHAR(10)  NULL,
   [Email] VARCHAR(50)  NULL,
   [EmergencyContactFirstName] VARCHAR(25)  NULL,
   [EmergencyContactLastName] VARCHAR(25)  NULL,
   [EmergencyContactPhone] CHAR(10)  NULL,
   [VeterinarianId] INT  NULL,
   [Password] VARCHAR(50)  NULL
);

GO


/* DDL for Table Pet */


CREATE TABLE 
[dbo].[Pet]
(
   [PetId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Name] VARCHAR(25)  NOT NULL,
   [Gender] CHAR(1)  NOT NULL,
   [Fixed] BIT  NOT NULL,
   [Breed] VARCHAR(50)  NULL,
   [Birthdate] VARCHAR(10) NULL,
   [OwnerId] INT  NOT NULL,
   [DogSize] CHAR(1)  NULL,
   [Climber] BIT  NOT NULL DEFAULT 0,
   [Barker] BIT  NOT NULL DEFAULT 0
);

GO

/* DDL for Table PetReservation */

CREATE TABLE 
[dbo].[PetReservation]
(
   [PetReservationId] INT IDENTITY (1, 1) PRIMARY KEY,
   [PetId] INT NOT NULL,
   [ReservationId] INT NOT NULL,
   [RunId] INT NULL
);

GO

/* DDL for Table PetReservationDiscount */


CREATE TABLE 
[dbo].[PetReservationDiscount]
(
   [DiscountId] INT NOT NULL,
   [PetReservationId] INT NOT NULL
);

GO

/* DDL for Table PetReservationService */

CREATE TABLE 
[dbo].[PetReservationService]
(
   [PetReservationId] INT NOT NULL,
   [ServiceId] INT NOT NULL
);

GO

/* DDL for Table PetVaccination */

CREATE TABLE 
[dbo].[PetVaccination]
(
   [ExpiryDate] DATE  NOT NULL,
   [VaccinationId] INT NOT NULL,
   [PetId] INT NOT NULL,
   [VaccinationChecked] BIT NOT NULL DEFAULT 0
);

GO


/* DDL for Table Reservation */


CREATE TABLE 
[dbo].[Reservation]
(
   [ReservationId] INT IDENTITY (1, 1) PRIMARY KEY,
   [StartDate] DATE  NOT NULL,
   [EndDate] DATE  NOT NULL,
   [Status] NUMERIC(1, 0)  NOT NULL
);

GO

/* DDL for Table ReservationDiscount */

CREATE TABLE 
[dbo].[ReservationDiscount]
(
   [DiscountId] INT NOT NULL,
   [ReservationId] INT NOT NULL
);

GO

/* DDL for Table Run */

CREATE TABLE 
[dbo].[Run]
(
   [RunId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Size] CHAR(1)  NOT NULL,
   [Covered] INT  NOT NULL,
   [Location] CHAR(1)  NULL,
   [Status] NUMERIC(1, 0)  NULL
);

GO


/* DDL for Table Service */

CREATE TABLE 
[dbo].[Service]
(
   [ServiceId] INT IDENTITY (1, 1) PRIMARY KEY,
   [ServiceDescription] VARCHAR(50)  NOT NULL
);

GO

/* DDL for Table SpecialNotes */


CREATE TABLE 
[dbo].[SpecialNotes]
(
   [Notes] VARCHAR(200)  NULL,
   [PetId] INT NOT NULL
);

GO

/* DDL for Table Vaccination */


CREATE TABLE 
[dbo].[Vaccination]
(
   [VaccinationId] INT IDENTITY (1, 1) PRIMARY KEY,
   [Name] VARCHAR(50)  NOT NULL
);

GO


/*--------------------------------------------------------
  MIGRATING DATA FROM ORACLE COPY
--------------------------------------------------------*/
/* To ensure the data from Oracle is migrated with same primary key 
values for the tables, autogeneration of the the IDs for each table 
is turned off and then back on for each table.  */

SET IDENTITY_INSERT [dbo].[DailyRate] ON 
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (1,20,'S',1);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (2,22,'M',1);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (3,25,'L',1);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (4,2,'S',2);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (5,3,'M',2);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (6,4,'L',2);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (7,2,null,4);
Insert into DailyRate (DailyRateId,Rate,DogSize,ServiceId) values (11,1,null,5);
SET IDENTITY_INSERT [dbo].[DailyRate] OFF


SET IDENTITY_INSERT [dbo].[Discount] ON
Insert into Discount (DiscountId,Desciption,Percentage,Type) values (1,'House Trained',0.1,'D');
Insert into Discount (DiscountId,Desciption,Percentage,Type) values (2,'Multiple Pets',0.07,'T');
Insert into Discount (DiscountId,Desciption,Percentage,Type) values (3,'Own Food',0.1,'D');
SET IDENTITY_INSERT [dbo].[Discount] OFF

SET IDENTITY_INSERT [dbo].[Veterinarian] ON
Insert into Veterinarian (VeterinarianId,Name,Phone,Street,City,Province,PostalCode) values (3,'Dr. Frankenstein','8888888888',null,null,'QC',null);
Insert into Veterinarian (VeterinarianId,Name,Phone,Street,City,Province,PostalCode) values (4,'Dr. Jorge Potter','1234567890',null,null,'QC',null);
Insert into Veterinarian (VeterinarianId,Name,Phone,Street,City,Province,PostalCode) values (5,'Dr. Akura Petforu','1234567890',null,null,'QC',null);
Insert into Veterinarian (VeterinarianId,Name,Phone,Street,City,Province,PostalCode) values (1,'Dr. I. Care','8195552122',null,null,'QC',null);
Insert into Veterinarian (VeterinarianId,Name,Phone,Street,City,Province,PostalCode) values (2,'Dr. Sandy Beech','8195559238',null,null,'QC',null);
SET IDENTITY_INSERT [dbo].[Veterinarian] OFF

SET IDENTITY_INSERT [dbo].[Owner] ON
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (18,'Barb B.','Que','18 Sequel Row','Gatineau','QC','J8A1V3','8195554215','8195559999','bque@gmail.com',null,null,null,1,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (19,'Chester','Drawers',null,null,null,null,'8191234876','8195559998','cdrawers@gmail.com',null,null,null,2,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (20,'Anita','Alibi',null,null,null,null,'8191224876','8195559997','aalibi@gmail.com',null,null,null,3,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (8,'Amanda','Linn','23 Java Road','Gatineau','QC','J8Y6T5','8195552233','8195559996','alinn@gmail.com',null,null,null,4,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values  (6,'Jeff','Summers','62 Adams','Maniwaki','QC','J8Y8T3','8195551843','8195559995','jsummers@gmail.com',null,null,null,5,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(7,'Peter','Piper','107 Main','Gatineau','QC','J8Y6T3','8195554543','8195559994','ppiper@gmail.com',null,null,null,1,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(1,'Jane','Smith','202 Poodle Path','Gatineau','QC','J8A1R2','8195551111','8195559993','jsmith@gmail.com',null,null,null,2,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(2,'Mike','O''Phone','74 Benton','Gatineau','QC','J8Y6T3','8195552222','8195559992','mophone@gmail.com',null,null,null,3,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(3,'Dwight','Wong','384 Garten','Ottawa','ON','K8Y6T3','8195555222','8195559991','dwong@gmail.com',null,null,null,4,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(4,'Mahatma','Coate','1 Golfview','Ottawa','ON','K8Y6T3','8195559843','8195559990','mcoate@gmail.com',null,null,null,5,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(5,'Sue','Metu','3 Riverview','Ottawa','ON','K8Y6T3','8195556699','8195559989','smetu@gmail.com',null,null,null,1,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (10,'April','Showers',null,null,null,null,'8195558765','8195559988','ashowers@gmail.com',null,null,null,2,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (11,'Salton','Pepper',null,null,null,null,'8195555571','8195559987','spepper@gmail.com',null,null,null,3,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (12,'Ella','Mentary',null,null,null,null,'8195551839','8195559986','ementary@gmail.com',null,null,null,4,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (13,'Sam','Ovar',null,null,null,'W2W2W2','8195551652','8195559985','sovar@gmail.com',null,null,null,5,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (14,'Carrie','Mehome',null,null,null,null,'8195551232','8195559984','cmehome@gmail.com',null,null,null,1,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (15,'Bayo','Wolfe',null,null,null,null,'8195565832','8195559983','bwolfe@gmail.com',null,null,null,2,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (16,'Moe','Bilhome',null,null,null,null,'8195575332','8195559982','mbilhome@gmail.com',null,null,null,3,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values (17,'Polly','Morfek',null,null,null,null,'8195575332','8195559981','pmorfek@gmail.com',null,null,null,1,null);
Insert into Owner (OwnerId,FirstName,LastName,Street,City,Province,PostalCode,Phone,CellPhone,Email,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,VeterinarianId,Password) values 
(21,'Jim','Reed',null,null,'QC',null,null,null,'reed@hvk.ca',null,null,null,null,'1234');
SET IDENTITY_INSERT [dbo].[Owner] OFF

SET IDENTITY_INSERT [dbo].[Pet] ON
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (33,'Willie','M',1,'Great Pyrenees','17-04-15',18,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (34,'Aurora','F',1,'Beagle','17-08-20',19,'M',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (35,'Bella','F',1,'Chihuahua','16-05-21',20,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (14,'Grizzlie','F',1,'Shi Tzu','15-05-04',8,'S',0,1);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (9,'Parker','M',1,'Shepherd Mix',null,6,'M',1,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (10,'Pete','M',1,'Tibetan Spanial - Sheltie',null,7,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (11,'Max','M',1,'Samoyed',null,7,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (12,'Kitoo','F',1,'Samoyed',null,7,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (1,'Scrabble','F',1,'Llassapoo',null,1,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (2,'Archie','F',1,'Standard Poodle',null,1,'M',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (3,'Busker','M',1,'Rhodesian Ridgeback','14-04-04',2,'L',1,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (6,'Huxley','M',1,'Standard Poodle','15-09-20',2,'M',1,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (7,'Charlie','M',1,'Jack Russell Terrier',null,4,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (16,'Maggie','F',0,'Golden Retriever','14-03-02',10,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (26,'Skarpa','F',0,'Spaniel mix',null,15,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (27,'Bothvar','M',0,'Schnauzer',null,15,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (28,'Foxfire','F',0,'Beagle mix',null,15,'S',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (29,'Shaboo','F',0,'Rat Terrier',null,16,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (30,'Suki','F',0,'St Bernard',null,5,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (31,'Sam','M',0,'Border Collie',null,5,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (32,'Snoop Dogg','M',0,'Black Lab',null,5,'M',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (13,'Logan','M',1,'Bernese Mountain Dog','10-10-20',3,'L',0,0);
Insert into Pet (PetId,Name,Gender,Fixed,Breed,Birthdate,OwnerId,DogSize,Climber,Barker) values (20,'Poppy','F',0,'Jack Russell Terrier','11-05-21',12,'S',0,1);
SET IDENTITY_INSERT [dbo].[Pet] OFF

SET IDENTITY_INSERT [dbo].[PetReservation] ON
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (200,7,631,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (201,20,632,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (202,32,633,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (204,20,625,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (205,33,630,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (206,10,635,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (207,9,696,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (208,26,707,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (209,9,708,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (210,11,709,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (211,13,711,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (212,14,712,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (213,26,713,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (214,29,716,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (215,30,717,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (216,3,720,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (217,3,721,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (219,3,595,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (223,13,102,28);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (224,6,103,36);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (225,9,104,29);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (226,6,105,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (227,3,108,36);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (228,10,109,35);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (229,14,114,1);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (230,3,115,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (231,9,120,30);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (232,9,123,35);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (233,20,131,29);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (234,10,136,28);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (235,12,137,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (236,13,138,21);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (237,14,139,30);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (239,27,140,1);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (240,29,143,28);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (241,29,144,14);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (242,30,145,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (243,31,146,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (249,6,122,36);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (250,6,615,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (251,16,700,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (252,7,620,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (253,30,701,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (254,33,702,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (255,2,703,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (256,32,704,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (257,34,705,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (261,1,703,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (264,6,115,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (268,12,709,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (270,27,713,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (271,28,713,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (272,31,145,13);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (274,32,717,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (298,11,148,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (404,10,802,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (405,11,802,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (406,3,803,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (409,6,803,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (410,10,804,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (411,11,804,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (412,12,804,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (284,6,636,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (286,1,594,36);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (288,26,601,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (292,31,603,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (294,11,605,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (296,26,140,2);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (300,1,112,29);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (302,1,100,29);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (304,3,106,27);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (306,11,110,36);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (400,31,800,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (402,26,801,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (413,3,805,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (417,3,806,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (423,13,808,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (424,11,809,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (426,33,810,null);
Insert into PetReservation (PetReservationId,PetId,ReservationId,RunId) values (427,13,811,null);
SET IDENTITY_INSERT [dbo].[PetReservation] OFF

SET IDENTITY_INSERT [dbo].[Medication] ON
Insert into Medication (MedicationId,Name,Dosage,SpecialInstruct,EndDate,PetReservationId) values (2,'Tapzole','1/2 tablet once daily',null,null,264);
Insert into Medication (MedicationId,Name,Dosage,SpecialInstruct,EndDate,PetReservationId) values (4,'Medicam','36 kg',null,null,240);
Insert into Medication (MedicationId,Name,Dosage,SpecialInstruct,EndDate,PetReservationId) values (1,'Prednisone','1 tablet twice daily',null,null,300);
Insert into Medication (MedicationId,Name,Dosage,SpecialInstruct,EndDate,PetReservationId) values (5,'Tapzole','1/2 tablet once daily',null,null,300);
SET IDENTITY_INSERT [dbo].[Medication] OFF

Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,284);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,286);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,288);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,292);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,294);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,296);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,300);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,302);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,304);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (1,306);
Insert into PetReservationDiscount (DiscountId,PetReservationId) values (3,306);

Insert into PetReservationService (PetReservationId,ServiceId) values (200,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (201,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (202,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (204,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (205,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (206,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (207,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (208,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (209,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (210,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (211,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (212,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (213,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (214,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (215,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (216,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (217,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (219,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (223,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (223,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (224,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (224,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (225,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (225,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (226,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (227,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (228,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (228,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (229,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (229,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (230,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (230,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (231,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (231,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (232,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (232,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (233,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (233,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (234,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (234,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (234,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (235,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (236,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (237,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (239,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (240,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (240,4);
Insert into PetReservationService (PetReservationId,ServiceId) values (241,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (242,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (243,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (249,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (249,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (250,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (251,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (252,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (253,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (254,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (255,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (256,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (257,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (261,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (264,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (264,4);
Insert into PetReservationService (PetReservationId,ServiceId) values (264,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (268,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (270,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (271,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (272,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (274,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (284,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (286,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (288,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (292,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (294,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (296,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (296,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (296,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (298,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (300,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (300,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (300,4);
Insert into PetReservationService (PetReservationId,ServiceId) values (302,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (302,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (304,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (304,5);
Insert into PetReservationService (PetReservationId,ServiceId) values (306,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (306,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (400,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (402,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (404,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (405,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (405,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (406,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (409,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (410,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (411,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (412,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (413,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (417,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (423,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (423,2);
Insert into PetReservationService (PetReservationId,ServiceId) values (424,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (426,1);
Insert into PetReservationService (PetReservationId,ServiceId) values (427,1);



Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-04-12',2),1,33);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-04-12',2),2,33);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-04-12',2),3,33);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-04-12',2),4,33);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-04-12',2),5,33);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-04-12',2),6,33);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-12-10',2),1,35);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-12-10',2),2,35);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-12-10',2),3,35);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-12-10',2),4,35);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-12-10',2),5,35);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-12-10',2),6,35);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),1,13);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),2,13);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),3,13);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),4,13);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),5,13);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),1,9);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),2,9);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),1,1);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),2,1);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),3,1);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),4,1);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),5,1);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-02-05',2),6,1);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),1,2);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),2,2);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),3,2);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),4,2);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-05',2),5,2);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-02-05',2),6,2);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),1,3);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),2,3);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),3,3);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),4,3);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),5,3);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-02-07',2),1,6);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-09-03',2),2,6);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-02-07',2),3,6);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-02-07',2),4,6);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-02-07',2),5,6);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-07-07',2),6,6);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-07',2),1,7);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-07',2),2,7);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-06-07',2),4,7);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-10-17',2),6,7);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),3,9);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),4,9);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),5,9);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),1,12);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),2,12);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),3,12);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),4,12);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),5,12);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),1,11);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),2,11);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),3,11);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),4,11);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),5,11);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),1,14);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),2,14);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),3,14);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),4,14);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-08-05',2),5,14);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-21',2),1,16);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-02-02',2),3,16);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'18-02-21',2),4,16);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-03-02',2),1,20);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-03-02',2),2,20);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-02-21',2),5,20);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,26);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,26);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,26);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,26);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,26);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,26);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,27);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,27);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,27);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,27);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,27);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,27);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,28);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,28);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,28);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,28);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,28);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,28);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,29);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,29);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,29);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,29);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,29);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,29);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,30);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,30);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,30);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,30);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,30);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,30);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,31);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,31);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,31);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,31);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,31);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,31);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),1,32);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),2,32);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),3,32);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),4,32);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),5,32);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'19-11-08',2),6,32);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-08-05',2),6,13);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-08-05',2),6,3);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-08-05',2),6,9);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-08-05',2),6,12);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-08-05',2),6,11);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-05-02',2),6,20);
Insert into PetVaccination (ExpiryDate,VaccinationId,PetId) values (CONVERT(DATE,'20-05-02',2),6,16);


SET IDENTITY_INSERT [dbo].[Reservation] ON
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (800,CONVERT(DATE,'19-07-20',2),CONVERT(DATE,'19-07-26',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (801,CONVERT(DATE,'19-07-20',2),CONVERT(DATE,'19-07-26',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (802,CONVERT(DATE,'19-07-20',2),CONVERT(DATE,'19-07-26',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (803,CONVERT(DATE,'19-07-20',2),CONVERT(DATE,'19-07-26',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (804,CONVERT(DATE,'19-09-20',2),CONVERT(DATE,'19-09-26',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (805,CONVERT(DATE,'19-09-20',2),CONVERT(DATE,'19-09-30',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (806,CONVERT(DATE,'20-03-23',2),CONVERT(DATE,'20-04-03',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (100,CONVERT(DATE,'17-10-12',2),CONVERT(DATE,'17-10-19',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (102,CONVERT(DATE,'17-10-16',2),CONVERT(DATE,'17-10-18',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (103,CONVERT(DATE,'17-11-01',2),CONVERT(DATE,'17-12-05',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (104,CONVERT(DATE,'17-11-15',2),CONVERT(DATE,'17-11-22',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (105,CONVERT(DATE,'18-02-01',2),CONVERT(DATE,'18-02-20',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (106,CONVERT(DATE,'18-05-10',2),CONVERT(DATE,'18-05-17',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (108,CONVERT(DATE,'18-05-31',2),CONVERT(DATE,'18-06-04',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (109,CONVERT(DATE,'18-08-01',2),CONVERT(DATE,'18-08-18',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (110,CONVERT(DATE,'18-08-01',2),CONVERT(DATE,'18-08-18',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (112,CONVERT(DATE,'18-08-12',2),CONVERT(DATE,'18-08-19',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (114,CONVERT(DATE,'18-08-15',2),CONVERT(DATE,'18-08-18',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (115,CONVERT(DATE,'18-08-15',2),CONVERT(DATE,'18-08-17',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (120,CONVERT(DATE,'18-08-16',2),CONVERT(DATE,'18-08-18',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (122,CONVERT(DATE,'19-02-01',2),CONVERT(DATE,'19-02-05',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (123,CONVERT(DATE,'18-05-20',2),CONVERT(DATE,'18-05-27',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (131,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (136,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (137,CONVERT(DATE,'19-05-07',2),CONVERT(DATE,'19-05-15',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (138,CONVERT(DATE,'19-05-26',2),CONVERT(DATE,'19-06-02',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (139,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (140,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (143,CONVERT(DATE,'19-01-03',2),CONVERT(DATE,'19-01-05',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (144,CONVERT(DATE,'19-05-26',2),CONVERT(DATE,'19-06-02',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (145,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (146,CONVERT(DATE,'19-01-28',2),CONVERT(DATE,'19-02-01',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (148,CONVERT(DATE,'19-05-26',2),CONVERT(DATE,'19-06-02',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (594,CONVERT(DATE,'19-01-01',2),CONVERT(DATE,'19-02-05',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (595,CONVERT(DATE,'19-03-28',2),CONVERT(DATE,'19-04-01',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (601,CONVERT(DATE,'19-04-01',2),CONVERT(DATE,'19-04-07',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (603,CONVERT(DATE,'19-04-01',2),CONVERT(DATE,'19-04-07',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (605,CONVERT(DATE,'19-04-01',2),CONVERT(DATE,'19-04-07',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (615,CONVERT(DATE,'19-03-07',2),CONVERT(DATE,'19-03-14',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (620,CONVERT(DATE,'18-05-08',2),CONVERT(DATE,'18-06-09',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (625,CONVERT(DATE,'19-04-15',2),CONVERT(DATE,'19-04-20',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (630,CONVERT(DATE,'19-04-05',2),CONVERT(DATE,'19-04-13',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (631,CONVERT(DATE,'18-02-01',2),CONVERT(DATE,'18-02-04',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (632,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (633,CONVERT(DATE,'19-06-04',2),CONVERT(DATE,'19-06-16',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (635,CONVERT(DATE,'19-04-20',2),CONVERT(DATE,'19-04-25',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (636,CONVERT(DATE,'19-02-09',2),CONVERT(DATE,'19-02-12',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (696,CONVERT(DATE,'18-12-07',2),CONVERT(DATE,'18-12-16',2),5);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (700,CONVERT(DATE,'19-02-10',2),CONVERT(DATE,'19-02-12',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (701,CONVERT(DATE,'19-05-26',2),CONVERT(DATE,'19-06-02',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (702,CONVERT(DATE,'19-05-26',2),CONVERT(DATE,'19-06-02',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (703,CONVERT(DATE,'19-02-10',2),CONVERT(DATE,'19-02-12',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (704,CONVERT(DATE,'19-02-10',2),CONVERT(DATE,'19-02-12',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (705,CONVERT(DATE,'19-02-10',2),CONVERT(DATE,'19-02-12',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (707,CONVERT(DATE,'19-04-15',2),CONVERT(DATE,'19-04-20',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (708,CONVERT(DATE,'19-05-15',2),CONVERT(DATE,'19-05-20',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (709,CONVERT(DATE,'19-05-15',2),CONVERT(DATE,'19-05-20',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (711,CONVERT(DATE,'19-05-15',2),CONVERT(DATE,'19-05-20',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (712,CONVERT(DATE,'19-05-15',2),CONVERT(DATE,'19-05-20',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (713,CONVERT(DATE,'19-05-10',2),CONVERT(DATE,'19-05-25',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (716,CONVERT(DATE,'19-05-10',2),CONVERT(DATE,'19-05-25',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (717,CONVERT(DATE,'19-05-10',2),CONVERT(DATE,'19-05-25',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (720,CONVERT(DATE,'19-05-25',2),CONVERT(DATE,'19-05-31',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (721,CONVERT(DATE,'19-05-05',2),CONVERT(DATE,'19-05-09',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (808,CONVERT(DATE,'20-01-31',2),CONVERT(DATE,'20-02-12',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (809,CONVERT(DATE,'19-08-02',2),CONVERT(DATE,'19-08-09',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (810,CONVERT(DATE,'19-04-12',2),CONVERT(DATE,'19-04-17',2),1);
Insert into Reservation (ReservationId,StartDate,EndDate,Status) values (811,CONVERT(DATE,'19-07-26',2),CONVERT(DATE,'19-08-05',2),1);
SET IDENTITY_INSERT [dbo].[Reservation] OFF


Insert into ReservationDiscount (DiscountId,ReservationId) values (2,713);
Insert into ReservationDiscount (DiscountId,ReservationId) values (2,717);

SET IDENTITY_INSERT [dbo].[Run] ON
Insert into Run (RunId,Size,Covered,Location,Status) values (1,'R',0,'F',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (2,'R',0,'F',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (13,'L',0,'F',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (14,'L',0,'F',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (21,'L',0,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (22,'L',0,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (27,'L',1,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (28,'L',1,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (29,'R',1,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (30,'R',1,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (35,'R',0,'B',1);
Insert into Run (RunId,Size,Covered,Location,Status) values (36,'R',0,'B',1);
SET IDENTITY_INSERT [dbo].[Run] OFF

SET IDENTITY_INSERT [dbo].[Service] ON
Insert into Service (ServiceId,ServiceDescription) values (1,'Boarding');
Insert into Service (ServiceId,ServiceDescription) values (2,'Walk');
Insert into Service (ServiceId,ServiceDescription) values (4,'Medication');
Insert into Service (ServiceId,ServiceDescription) values (5,'Playtime');
SET IDENTITY_INSERT [dbo].[Service] OFF

Insert into SpecialNotes (Notes,PetId) values ('Scrabble is terrified of hot air balloons',1);
Insert into SpecialNotes (Notes,PetId) values ('Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime.',2);
Insert into SpecialNotes (Notes,PetId) values ('Huxley has an uncontrollable tendency to quote Shakespeare',6);

SET IDENTITY_INSERT [dbo].[Vaccination] ON
Insert into Vaccination (VaccinationId,Name) values (1,'Bordetella');
Insert into Vaccination (VaccinationId,Name) values (2,'Distemper');
Insert into Vaccination (VaccinationId,Name) values (3,'Hepatitis');
Insert into Vaccination (VaccinationId,Name) values (4,'Parainfluenza');
Insert into Vaccination (VaccinationId,Name) values (5,'Parovirus');
Insert into Vaccination (VaccinationId,Name) values (6,'Rabies');
SET IDENTITY_INSERT [dbo].[Vaccination] OFF
GO

--------------------------------------------------------
--  DDL for Index DAILY_RATE_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_DAILY_RATE_PK" ON "DailyRate" ("DailyRateId") 
GO

--------------------------------------------------------
--  DDL for Index DISCOUNT_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_DISCOUNT_PK" ON "Discount" ("DiscountId") 
GO

--------------------------------------------------------
--  DDL for Index PET_RES_DISC_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_PET_RES_DISC_PK" ON "PetReservationDiscount" ("DiscountId", "PetReservationId") 
GO

--------------------------------------------------------
--  DDL for Index KENNEL_LOG_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_KENNEL_LOG_PK" ON "KennelLog" ("LogDate", "SequenceNumber", "PetReservationId") 
GO

--------------------------------------------------------
--  DDL for Index RUN_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_RUN_PK" ON "Run" ("RunId") 
GO

--------------------------------------------------------
--  DDL for Index VACCINATION_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_VACCINATION_PK" ON "Vaccination" ("VaccinationId") 
GO
 
--------------------------------------------------------
--  DDL for Index PET_VACCINATION_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_PET_VACCINATION_PK" ON "PetVaccination" ("VaccinationId", "PetId") 
GO

--------------------------------------------------------
--  DDL for Index SPECIAL_NOTES_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_SPECIAL_NOTES_PK" ON "SpecialNotes" ("PetId") 
GO

--------------------------------------------------------
--  DDL for Index PET_RESERVATION_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_PET_RESERVATION_PK" ON "PetReservation" ("PetReservationId") 
GO

--------------------------------------------------------
--  DDL for Index OWNER_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_OWNER_PK" ON "Owner" ("OwnerId") 
GO

--------------------------------------------------------
--  DDL for Index SERVICE_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_SERVICE_PK" ON "Service" ("ServiceId") 
GO

--------------------------------------------------------
--  DDL for Index PET_RESERVATION_SERVICE_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_PET_RESERVATION_SERVICE_PK" ON "PetReservationService" ("PetReservationId", "ServiceId") 
GO

--------------------------------------------------------
--  DDL for Index RES_DISC_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_RES_DISC_PK" ON "ReservationDiscount" ("DiscountId", "ReservationId") 
GO

--------------------------------------------------------
--  DDL for Index RESERVATION_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_RESERVATION_PK" ON "Reservation" ("ReservationId") 
GO

--------------------------------------------------------
--  DDL for Index PET_PK
--------------------------------------------------------
CREATE UNIQUE INDEX "IX_PET_PK" ON "Pet" ("PetId") 
GO

--------------------------------
-- CONSTRAINTS
--------------------------------



--------------------------------------------------------
--  Constraints for Table Run
--------------------------------------------------------

ALTER TABLE [dbo].[Run]
 ADD CONSTRAINT [Location_CHK]
 CHECK (Location IN ( 'B', 'F' ))

GO


ALTER TABLE [dbo].[Run]
 ADD CONSTRAINT [Size_CHK]
 CHECK (Size IN ( 'L', 'R' ))

GO

ALTER TABLE [dbo].[Run]
 ADD CONSTRAINT [Status_CHK]
 CHECK (Status IN ( 1, 2, 3, 4 ))

GO


ALTER TABLE  [dbo].[Run]
 ADD DEFAULT 'R' FOR [Size]
GO

ALTER TABLE  [dbo].[Run]
 ADD DEFAULT 1 FOR [Status]
GO



--------------------------------------------------------
--  Constraints for Table SpecialNotes
--------------------------------------------------------

ALTER TABLE [dbo].[SpecialNotes]
 ADD CONSTRAINT [SPECIAL_NOTES_PK]
   PRIMARY KEY
   CLUSTERED ([PetId] ASC)

GO

--------------------------------------------------------
--  Constraints for Table PetReservationDiscount
--------------------------------------------------------

ALTER TABLE [dbo].[PetReservationDiscount]
 ADD CONSTRAINT [PET_RES_DISC_PK]
   PRIMARY KEY
   CLUSTERED ([DiscountId] ASC, [PetReservationId] ASC)

GO

ALTER TABLE [dbo].[PetReservationDiscount]
 ADD CONSTRAINT [PRD_PR_FK]
 FOREIGN KEY 
   ([PetReservationId])
 REFERENCES 
   [dbo].[PetReservation]     ([PetReservationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


ALTER TABLE [dbo].[PetReservationDiscount]
 ADD CONSTRAINT [PRD_DISC_FK]
 FOREIGN KEY 
   ([DiscountId])
 REFERENCES 
   [dbo].[Discount]     ([DiscountId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

--------------------------------------------------------
--  Constraints for Table DailyRate
--------------------------------------------------------

ALTER TABLE [dbo].[DailyRate]
 ADD CONSTRAINT [SYS_C00131069]
 CHECK (DogSize IN ( 'L', 'M', 'S' ))

GO

--------------------------------------------------------
--  Constraints for Table Reservation
--------------------------------------------------------

ALTER TABLE [dbo].[Reservation]
 ADD CONSTRAINT [RES_STATUS_CHK]
 CHECK (Status IN ( 
1, 
2, 
3, 
4, 
5 ))

GO

ALTER TABLE  [dbo].[Reservation]
 ADD DEFAULT 1 FOR [Status]
GO

--------------------------------------------------------
--  Constraints for Table PetVaccination
--------------------------------------------------------

ALTER TABLE [dbo].[PetVaccination]
 ADD CONSTRAINT [PET_VACCINATION_PK]
   PRIMARY KEY
   CLUSTERED ([VaccinationId] ASC, [PetId] ASC)

GO

ALTER TABLE [dbo].[PetVaccination]
 ADD CONSTRAINT [PV_VACC_FK]
 FOREIGN KEY 
   ([VaccinationId])
 REFERENCES 
   [dbo].[Vaccination]     ([VaccinationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

ALTER TABLE [dbo].[PetVaccination]
 ADD CONSTRAINT [PV_PET_FK]
 FOREIGN KEY 
   ([PetId])
 REFERENCES 
   [dbo].[Pet]     ([PetId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


--------------------------------------------------------
--  Constraints for Table KennelLog
--------------------------------------------------------

ALTER TABLE [dbo].[KennelLog]
 ADD CONSTRAINT [KENNEL_LOG_PK]
   PRIMARY KEY
   CLUSTERED ([LogDate] ASC, [SequenceNumber] ASC, [PetReservationId] ASC)

GO

--------------------------------------------------------
--  Constraints for Table ReservationDiscount
--------------------------------------------------------

ALTER TABLE [dbo].[ReservationDiscount]
 ADD CONSTRAINT [RES_DISC_PK]
   PRIMARY KEY
   CLUSTERED ([DiscountId] ASC, [ReservationId] ASC)

GO

--------------------------------------------------------
--  Constraints for Table Discount
--------------------------------------------------------


ALTER TABLE [dbo].[Discount]
 ADD CONSTRAINT [Type_CHK]
 CHECK (Type IN ( 'D', 'T' ))

GO

ALTER TABLE  [dbo].[Discount]
 ADD DEFAULT 'D' FOR [Type]
GO
  
  
--------------------------------------------------------
--  Constraints for Table PetReservationService
--------------------------------------------------------

ALTER TABLE [dbo].[PetReservationService]
 ADD CONSTRAINT [PET_RESERVATION_SERVICE_PK]
   PRIMARY KEY
   CLUSTERED ([PetReservationId] ASC, [ServiceId] ASC)

GO


--------------------------------------------------------
--  Constraints for Table Veterinarian
--------------------------------------------------------


ALTER TABLE [dbo].[Veterinarian]
 ADD CONSTRAINT [SYS_C00134665]
 CHECK (Province IN ( 'ON', 'QC' ))

GO

ALTER TABLE  [dbo].[Veterinarian]
 ADD DEFAULT 'QC' FOR [Province]
GO


--------------------------------------------------------
--  Ref Constraints for Table DailyRate
--------------------------------------------------------

ALTER TABLE [dbo].[DailyRate]
 ADD CONSTRAINT [DR_SERV_FK]
 FOREIGN KEY 
   ([ServiceId])
 REFERENCES 
   [dbo].[Service]     ([ServiceId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO
 
	  
--------------------------------------------------------
--  Ref Constraints for Table KennelLog
--------------------------------------------------------

 ALTER TABLE [dbo].[KennelLog]
 ADD CONSTRAINT [KL_PR_FK]
 FOREIGN KEY 
   ([PetReservationId])
 REFERENCES 
   [dbo].[PetReservation]     ([PetReservationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO	  

--------------------------------------------------------
--  Ref Constraints for Table PetReservation
--------------------------------------------------------

ALTER TABLE [dbo].[PetReservation]
 ADD CONSTRAINT [PR_RES_FK]
 FOREIGN KEY 
   ([ReservationId])
 REFERENCES 
   [dbo].[Reservation]     ([ReservationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


ALTER TABLE [dbo].[PetReservation]
 ADD CONSTRAINT [PR_RUN_FK]
 FOREIGN KEY 
   ([RunId])
 REFERENCES 
   [dbo].[Run]     ([RunId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

ALTER TABLE [dbo].[PetReservation]
 ADD CONSTRAINT [PR_PET_FK]
 FOREIGN KEY 
   ([PetId])
 REFERENCES 
   [dbo].[Pet]     ([PetId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

--------------------------------------------------------
--  Ref Constraints for Medication
--------------------------------------------------------

ALTER TABLE [dbo].[Medication]
 ADD CONSTRAINT [MED_PR_FK]
 FOREIGN KEY 
   ([PetReservationId])
 REFERENCES 
   [dbo].[PetReservation]     ([PetReservationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

--------------------------------------------------------
--  Ref Constraints for Table PetReservationService
--------------------------------------------------------

ALTER TABLE [dbo].[PetReservationService]
 ADD CONSTRAINT [PRS_PR_FK]
 FOREIGN KEY 
   ([PetReservationId])
 REFERENCES 
   [dbo].[PetReservation]     ([PetReservationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


ALTER TABLE [dbo].[PetReservationService]
 ADD CONSTRAINT [PRS_SERV_FK]
 FOREIGN KEY 
   ([ServiceId])
 REFERENCES 
   [dbo].[Service]     ([ServiceId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

 --------------------------------------------------------
--  Ref Constraints for Table ReservationDiscount
--------------------------------------------------------

ALTER TABLE [dbo].[ReservationDiscount]
 ADD CONSTRAINT [RD_DISC_FK]
 FOREIGN KEY 
   ([DiscountId])
 REFERENCES 
   [dbo].[Discount]     ([DiscountId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


ALTER TABLE [dbo].[ReservationDiscount]
 ADD CONSTRAINT [RD_RES_FK]
 FOREIGN KEY 
   ([ReservationId])
 REFERENCES 
   [dbo].[Reservation]     ([ReservationId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

--------------------------------------------------------
--  Ref Constraints for Table SpecialNotes
--------------------------------------------------------


ALTER TABLE [dbo].[SpecialNotes]
 ADD CONSTRAINT [SPECIAL_NOTES_PET_FK]
 FOREIGN KEY 
   ([PetId])
 REFERENCES 
   [dbo].[Pet]     ([PetId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO



--------------------------------------------------------
--  Ref Constraints for Table Owner
--------------------------------------------------------


ALTER TABLE [dbo].[Owner]
 ADD CONSTRAINT [SYS_C00134635]
 CHECK (Province IN ( 'ON', 'QC' ))

GO

ALTER TABLE [dbo].[Owner]
 ADD CONSTRAINT [OWNER_VET_FK]
 FOREIGN KEY 
   ([VeterinarianId])
 REFERENCES 
   [dbo].[Veterinarian]     ([VeterinarianId])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO

ALTER TABLE  [dbo].[Owner]
 ADD DEFAULT 'QC' FOR [Province]
GO

--------------------------------------------------------
--  Ref Constraints for Table Pet
--------------------------------------------------------

ALTER TABLE [dbo].[Pet]
 ADD CONSTRAINT [SYS_C00262057]
 CHECK (Gender IN ( 'F', 'M' ))

GO


ALTER TABLE [dbo].[Pet]
 ADD CONSTRAINT [SYS_C00134656]
 CHECK (DogSize = 'L' OR DogSize = 'M' OR DogSize = 'S')

GO

ALTER TABLE [dbo].[Pet]
 ADD CONSTRAINT [PET_OWN_FK]
 FOREIGN KEY 
   ([OwnerId])
 REFERENCES 
   [dbo].[Owner]     ([OwnerId])
    ON DELETE CASCADE
    ON UPDATE NO ACTION

GO


--------------------------------------------------------
-- Updates to raw data previously entered
--
-- Original script had some conversion done to age reservations,
-- vaccinations based on hardcoded values 
-- and dates.  Those continue to be aged now based on today's date
-- minus those starting points, as off 29-JAN-21.
--------------------------------------------------------

DECLARE @Today DATE;
DECLARE @ThreeMonthsAgo DATE;
DECLARE @DeltaMonths INT;

DECLARE @StartingDate DATE = CONVERT(DATE,'29-JAN-21',6);
SET @Today = CONVERT (DATE, GETDATE());
SET @DeltaMonths = DATEDIFF(MONTH,@StartingDate,@Today);
SET @ThreeMonthsAgo = DATEADD(MONTH,-3,@Today);

--- Bump up reservations by 2 years + Delta
UPDATE [dbo].[Reservation]
SET StartDate = DATEADD(month, (24 + @DeltaMonths), StartDate),
EndDate = DATEADD(month, (24 + @DeltaMonths), EndDate)
WHERE StartDate IS NOT NULL AND EndDate IS NOT NULL;

--- Mark anything in the past as completed (status = 5)
--- anything in the future or today (status = 1) pending
UPDATE [dbo].[Reservation]
SET Status=5 where EndDate < @Today;
UPDATE Reservation
SET Status=1 where StartDate >= @Today;

-- Bump up vaccination expiry dates by 2 years + delta
UPDATE [dbo].[PetVaccination]
SET ExpiryDate = DATEADD(month, (24 + @DeltaMonths), ExpiryDate)
WHERE ExpiryDate IS NOT NULL;

-- Mark vaccination as checked if the pet has been in during the last 3 months
UPDATE [dbo].[PetVaccination]
SET VaccinationChecked = 1
WHERE
PetId IN (
SELECT DISTINCT (pr.PetID) FROM PetReservation pr, Reservation r
WHERE ((r.ReservationId = pr.ReservationId)
AND (r.EndDate >= @ThreeMonthsAgo)));


UPDATE [dbo].[Owner]
SET Password = '1234'
where Password is null;