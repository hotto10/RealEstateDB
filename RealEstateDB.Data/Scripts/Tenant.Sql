
--             DATABASE ASSIGNMENT

-- ===============================================================================================

USE [RealEstateDB]

GO

 

 

 

-- ===============================================================================================

--             REMOVE TABLE

-- ===============================================================================================

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tenant]') )

DROP TABLE [dbo].[Tenant]

GO

 

 

SET ANSI_NULLS ON

GO

 

SET QUOTED_IDENTIFIER ON

GO

 

-- ===============================================================================================

--             CREATE TABLE

-- ===============================================================================================

 

CREATE TABLE [dbo].[Tenant](

                [PersonId] [int] IDENTITY(1,1) NOT NULL,

                [FirstName] varchar(50) not null,

                [MiddleName] varchar(50) null,

                [LastName] varchar(50) not null,

                [Address1] varchar(80) not null,

                [Address2] varchar(80) null,

                [City] varchar(30) not null,

                [StateAbr] varchar(2) not null,

                [ZipCode] nvarchar(5) not null,

                [EmailAddress] varchar(120) null,

                [PhoneNumber] nvarchar(15) null,

                [DriverLicense] varchar(20) null,

CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED

(

                [PersonId] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]

) ON [PRIMARY]

GO

 

SET ANSI_PADDING OFF

GO