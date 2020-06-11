USE [skarpaotpdb]
GO
/****** Object:  Table [dbo].[Otps]    Script Date: 11/06/2020 6:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Otps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[RecordStatus] [int] NOT NULL,
	[AppId] [int] NOT NULL,
	[AppFeature] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[DialCode] [nvarchar](max) NULL,
	[OtpCode] [int] NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[TimeUsed] [datetime2](7) NULL,
	[ExpiryDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Otps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[otpmodel]    Script Date: 11/06/2020 6:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[otpmodel] as select x.* from Otps x where x.RecordStatus != 3 and x.RecordStatus != 4
GO
/****** Object:  Table [dbo].[OtpTypes]    Script Date: 11/06/2020 6:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtpTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[RecordStatus] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OtpTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[otptypemodel]    Script Date: 11/06/2020 6:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[otptypemodel] as select x.* from OtpTypes x where x.RecordStatus != 3 and x.RecordStatus != 4
GO
/****** Object:  Table [dbo].[Apps]    Script Date: 11/06/2020 6:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[RecordStatus] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AppSecret] [nvarchar](max) NOT NULL,
	[OtpTypeId] [int] NOT NULL,
	[OtpLength] [int] NOT NULL,
	[HasExpiry] [bit] NOT NULL,
	[ExpiryPeriod] [time](7) NULL,
 CONSTRAINT [PK_Apps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[appmodel]    Script Date: 11/06/2020 6:08:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[appmodel] as select x.* from Apps x where x.RecordStatus != 3 and x.RecordStatus != 4
GO
