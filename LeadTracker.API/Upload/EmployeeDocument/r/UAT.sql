USE [UAT]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressDetails] [varchar](250) NULL,
	[City] [varchar](250) NULL,
	[State] [varchar](250) NULL,
	[Zip] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[UnitId] [int] NULL,
	[CodeId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK__Address__7F4FF737758BB134] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[LoginDate] [datetime] NULL,
	[LoginLatitude] [varchar](250) NULL,
	[LoginLongitude] [varchar](250) NULL,
	[LogoutDate] [datetime] NULL,
	[LogoutLatitude] [varchar](250) NULL,
	[LogoutLongitude] [varchar](250) NULL,
	[IsApproved] [bit] NULL,
	[Status] [varchar](250) NULL,
	[ApprovedBy] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK__Attendan__8B69261CF8D3D8FA] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[EnquiryId] [int] NULL,
	[BookingDate] [datetime] NULL,
	[ClientName] [varchar](250) NULL,
	[ClientPhone] [varchar](250) NULL,
	[ClientEmail] [varchar](250) NULL,
	[ProjectId] [int] NULL,
	[Wing] [varchar](250) NULL,
	[UnitId] [int] NULL,
	[AgreementCost] [decimal](19, 2) NULL,
	[BrokerageSlab] [varchar](250) NULL,
	[AssignedTo] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[ParentBranchId] [int] NULL,
	[OrgId] [int] NULL,
	[CodeId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code](
	[CodeId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](250) NULL,
	[CodesGroup] [varchar](250) NULL,
	[Value] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentId] [int] IDENTITY(1,1) NOT NULL,
	[EnquiryId] [int] NULL,
	[TrackerId] [int] NULL,
	[ModuleType] [int] NULL,
	[Location] [nvarchar](500) NULL,
	[UserId] [int] NULL,
	[OrgId] [int] NULL,
	[Comment] [nvarchar](500) NULL,
	[WorkFlowId] [int] NULL,
	[WorkFlowStepId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[EmailId] [varchar](250) NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[MPIN] [varchar](250) NULL,
	[Mobile] [varchar](250) NULL,
	[ParentUserId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[Gender] [varchar](50) NULL,
	[RoleId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[Photo] [varbinary](max) NULL,
	[DeviceId] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRole](
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[OrgId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lead]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lead](
	[EnquiryId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[LeadSource] [varchar](250) NULL,
	[LeadSourceProject] [varchar](250) NULL,
	[Name] [varchar](250) NULL,
	[MobNo] [varchar](250) NULL,
	[EmailID] [varchar](250) NULL,
	[Requirement] [varchar](250) NULL,
	[Budget] [decimal](19, 2) NULL,
	[Description] [varchar](250) NULL,
	[Status] [int] NULL,
	[FinalRemark] [varchar](250) NULL,
	[EnquiryType] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[TrackerFlowStepId] [int] NULL,
	[AssignedTo] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK__Lead__0A019B7DE448629C] PRIMARY KEY CLUSTERED 
(
	[EnquiryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeadSource]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadSource](
	[LeadSourceId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[LeadsSource] [varchar](250) NULL,
	[LeadSourceProject] [varchar](250) NULL,
	[Name] [varchar](250) NULL,
	[MobNo] [varchar](250) NULL,
	[EmailID] [varchar](250) NULL,
	[Requirement] [varchar](250) NULL,
	[Budget] [decimal](19, 2) NULL,
	[Status] [varchar](250) NULL,
	[Remark] [varchar](250) NULL,
	[EnquiryType] [varchar](250) NULL,
	[TrakerId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[IsProcessed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeadSourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](100) NULL,
	[ZoneId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organisation]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organisation](
	[OrgId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrgId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgAttendanceLocation]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgAttendanceLocation](
	[OrgLocationId] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[Latitude] [varchar](250) NULL,
	[Longitude] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrgLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](250) NULL,
	[LocationId] [int] NULL,
	[Address] [varchar](500) NULL,
	[BuilderName] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectDetail]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectDetail](
	[ProjectDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[Wing] [varchar](250) NULL,
	[Floor] [varchar](250) NULL,
	[Unit] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[ParentRoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[RolePermissionId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[PermissionId] [int] NULL,
	[OrgId] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RolePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tracker]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tracker](
	[TrackerId] [int] IDENTITY(1,1) NOT NULL,
	[EnquiryId] [int] NULL,
	[CodeId] [int] NULL,
	[Remark] [varchar](250) NULL,
	[Date] [datetime] NULL,
	[VisitExpected] [bit] NULL,
	[VisitExpectedDate] [datetime] NULL,
	[VisitedProjectId] [int] NULL,
	[VisitRemark] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AssignedTo] [int] NULL,
	[WorkFlowId] [int] NULL,
	[WorkFlowStepId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsStepCompleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK__Tracker__DEF88A01B0151E11] PRIMARY KEY CLUSTERED 
(
	[TrackerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLocation]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLocation](
	[UserLocationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Date] [datetime] NULL,
	[CurrentLatitude] [varchar](250) NULL,
	[CurrentLongitude] [varchar](250) NULL,
	[StartLatitude] [varchar](250) NULL,
	[StartLongitude] [varchar](250) NULL,
	[OrgId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkFlow]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkFlow](
	[WorkFlowId] [int] IDENTITY(1,1) NOT NULL,
	[WorkFlowName] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkFlowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkFlowDetails]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkFlowDetails](
	[WorkFlowDetailId] [int] IDENTITY(1,1) NOT NULL,
	[WorkFlowId] [int] NULL,
	[PreviousStep] [int] NULL,
	[CurrentStep] [int] NULL,
	[NextStep] [int] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK__WorkFlow__025B35FB8909F460] PRIMARY KEY CLUSTERED 
(
	[WorkFlowDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkFlowStep]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkFlowStep](
	[WorkFlowStepId] [int] IDENTITY(1,1) NOT NULL,
	[WorkFlowId] [int] NOT NULL,
	[StepName] [varchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[OrgId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_WorkFlowStep] PRIMARY KEY CLUSTERED 
(
	[WorkFlowStepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zone]    Script Date: 11/23/2023 1:05:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zone](
	[ZoneId] [int] IDENTITY(1,1) NOT NULL,
	[ZoneName] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressId], [AddressDetails], [City], [State], [Zip], [IsActive], [IsDeleted], [UnitId], [CodeId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'Bhumkar Chowk', N'Pune', N'Maharashtra', N'456412', 1, 0, 10, 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Address] ([AddressId], [AddressDetails], [City], [State], [Zip], [IsActive], [IsDeleted], [UnitId], [CodeId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'Wakad Chowk', N'Pune', N'Maharashtra', N'456412', 1, 0, 10, 4, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([BranchId], [Name], [IsActive], [IsDeleted], [ParentBranchId], [OrgId], [CodeId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'Kothrud', 1, 0, 1, 1, 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Branch] ([BranchId], [Name], [IsActive], [IsDeleted], [ParentBranchId], [OrgId], [CodeId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'Hinjewadi 3', 1, 0, 1, 1, 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Branch] ([BranchId], [Name], [IsActive], [IsDeleted], [ParentBranchId], [OrgId], [CodeId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, N'Kharadi', 1, 0, 3, 2, 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Branch] ([BranchId], [Name], [IsActive], [IsDeleted], [ParentBranchId], [OrgId], [CodeId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (4, N'Aundh', 1, 0, 3, 2, 4, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Branch] OFF
GO
SET IDENTITY_INSERT [dbo].[Code] ON 

INSERT [dbo].[Code] ([CodeId], [Type], [CodesGroup], [Value], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'ModuleType', N'Document', N'File', 1, 0, 1, CAST(N'2023-10-17T07:11:45.487' AS DateTime), CAST(N'2023-10-17T07:11:45.487' AS DateTime), NULL, NULL)
INSERT [dbo].[Code] ([CodeId], [Type], [CodesGroup], [Value], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'ModuleType', N'Document', N'Audio', 1, 0, 1, CAST(N'2023-10-17T07:11:45.487' AS DateTime), CAST(N'2023-10-17T07:11:45.487' AS DateTime), NULL, NULL)
INSERT [dbo].[Code] ([CodeId], [Type], [CodesGroup], [Value], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, N'ModuleType', N'Document', N'Video', 1, 0, 1, CAST(N'2023-10-17T07:11:45.487' AS DateTime), CAST(N'2023-10-17T07:11:45.487' AS DateTime), NULL, NULL)
INSERT [dbo].[Code] ([CodeId], [Type], [CodesGroup], [Value], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (4, N'SDR', N'BHJ', N'187897', 1, 0, 1, CAST(N'2023-10-17T07:11:45.487' AS DateTime), CAST(N'2023-10-17T07:11:45.487' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Code] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [Name], [EmailId], [UserName], [Password], [MPIN], [Mobile], [ParentUserId], [IsActive], [IsDeleted], [OrgId], [Gender], [RoleId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [Photo], [DeviceId]) VALUES (1, N'Vikram Ahinave', N'MD1@gmail.com', N'vikram123', N'1234', N'1234', N'8830817450', 10, 1, 0, 1, N'Male', 1, NULL, CAST(N'2023-11-20T18:42:50.327' AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [LocationName], [ZoneId], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'YY', 1, 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Location] ([LocationId], [LocationName], [ZoneId], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'ZZ', 2, 1, 0, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Organisation] ON 

INSERT [dbo].[Organisation] ([OrgId], [Name], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'Vardha', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Organisation] ([OrgId], [Name], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'Jadhav', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Organisation] ([OrgId], [Name], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, N'Vighnharta', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Organisation] ([OrgId], [Name], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (4, N'Phoenix', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Organisation] ([OrgId], [Name], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (5, N'Swift', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Organisation] ([OrgId], [Name], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (6, N'Manus', 1, 1, CAST(N'2023-11-06T09:16:39.283' AS DateTime), CAST(N'2023-11-06T14:47:13.357' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[Organisation] OFF
GO
SET IDENTITY_INSERT [dbo].[OrgAttendanceLocation] ON 

INSERT [dbo].[OrgAttendanceLocation] ([OrgLocationId], [OrgId], [Latitude], [Longitude]) VALUES (1, 1, N'18.60', N'73.75')
SET IDENTITY_INSERT [dbo].[OrgAttendanceLocation] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([PermissionId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'AG', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Permission] ([PermissionId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'UG', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Permission] ([PermissionId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, N'GR', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Permission] ([PermissionId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (4, N'OD', 1, 0, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'Platinum Glory', 1, N'Pune', N'Anil Patil', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'V-top Valonia', 2, N'Pune', N'Kishor Patil', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (6, N'Verdict-Plaza', 3, N'Mumbai', N'Bharat Lokhande', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (7, N'Amora', 4, N'Kothrud', N'Amol Rakshe', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (8, N'Alora', 5, N'Kharadi', N'Jitendra Dhole', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (9, N'MangoSoft', 6, N'Wakad', N'Anup Jain', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (10, N'Modi-Tower', 7, N'Hinjewadi-3', N'Bhausaheb Kate', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (11, N'Unicorn', 8, N'Baner', N'Vidya Satav', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (12, N'Gold-Society', 9, N'Aundh', N'Gaurav Mathe', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [LocationId], [Address], [BuilderName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (13, N'Silver-Heights', 10, N'Saswad', N'Anup Japtap', 1, 0, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectDetail] ON 

INSERT [dbo].[ProjectDetail] ([ProjectDetailsId], [ProjectId], [Wing], [Floor], [Unit], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, 1, N'B', N'Ground', N'TT', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[ProjectDetail] ([ProjectDetailsId], [ProjectId], [Wing], [Floor], [Unit], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, 2, N'C', N'Fifth', N'OP', 1, 0, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProjectDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (1, N'Admin', 1, 0, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (2, N'MD', 1, 0, 1, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (3, N'HR', 1, 0, 1, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (4, N'BranchHead', 1, 0, 1, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (5, N'Manager', 1, 0, 1, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (6, N'TeamLead', 1, 0, 1, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Role] ([RoleId], [Name], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy], [ParentRoleId]) VALUES (7, N'TeleCaller', 1, 0, 1, NULL, NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
--SET IDENTITY_INSERT [dbo].[RolePermission] ON 

--INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [OrgId], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, 1, 5, 1, 1, 0, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [OrgId], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, 2, 8, 1, 1, 0, NULL, NULL, NULL, NULL)
--INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [OrgId], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, 3, 7, 1, 1, 0, NULL, NULL, NULL, NULL)
--SET IDENTITY_INSERT [dbo].[RolePermission] OFF
--GO
SET IDENTITY_INSERT [dbo].[WorkFlow] ON 

INSERT [dbo].[WorkFlow] ([WorkFlowId], [WorkFlowName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, N'TrackingWorkFlow', 1, 0, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[WorkFlow] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkFlowDetails] ON 

INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, 3, NULL, 1, 2, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, 3, 1, 2, 3, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, 3, 2, 3, 4, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (4, 3, 4, 5, NULL, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (5, 3, 1, 2, 6, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (6, 3, 1, 2, 7, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (7, 3, 2, 3, 6, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (8, 3, 2, 3, 7, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (9, 3, 2, 3, 8, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (10, 3, 3, 4, 6, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (11, 3, 3, 4, 7, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (12, 3, 3, 4, 8, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (13, 3, 2, 6, 2, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (14, 3, 3, 6, 2, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (15, 3, 4, 6, 2, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (16, 3, 2, 7, 2, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (17, 3, 3, 7, 3, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (18, 3, 4, 7, 4, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (19, 3, 2, 8, 2, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (20, 3, 3, 8, 3, 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowDetails] ([WorkFlowDetailId], [WorkFlowId], [PreviousStep], [CurrentStep], [NextStep], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (29, 3, 3, 4, 5, 1, 0, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[WorkFlowDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkFlowStep] ON 

INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, 3, N'Lead', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, 3, N'Call', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (3, 3, N'Visit', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (4, 3, N'Booking', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (5, 3, N'Close', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (6, 3, N'Reject', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (7, 3, N'On Hold', 1, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[WorkFlowStep] ([WorkFlowStepId], [WorkFlowId], [StepName], [IsActive], [IsDeleted], [OrgId], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (8, 3, N'Re-Schedule', 1, 0, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[WorkFlowStep] OFF
GO
SET IDENTITY_INSERT [dbo].[Zone] ON 

INSERT [dbo].[Zone] ([ZoneId], [ZoneName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (1, N'XY', 1, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Zone] ([ZoneId], [ZoneName], [IsActive], [IsDeleted], [CreatedDate], [ModifiedDate], [CreatedBy], [ModifiedBy]) VALUES (2, N'YZ', 1, 0, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Zone] OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([CodeId])
REFERENCES [dbo].[Code] ([CodeId])
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK__Attendanc__UserI__67DE6983] FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK__Attendanc__UserI__67DE6983]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Employee] FOREIGN KEY([ApprovedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Employee]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK__Booking__Enquiry__58D1301D] FOREIGN KEY([EnquiryId])
REFERENCES [dbo].[Lead] ([EnquiryId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK__Booking__Enquiry__58D1301D]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Branch]  WITH CHECK ADD FOREIGN KEY([CodeId])
REFERENCES [dbo].[Code] ([CodeId])
GO
ALTER TABLE [dbo].[Code]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD FOREIGN KEY([EnquiryId])
REFERENCES [dbo].[Lead] ([EnquiryId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD FOREIGN KEY([ModuleType])
REFERENCES [dbo].[Code] ([CodeId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD FOREIGN KEY([TrackerId])
REFERENCES [dbo].[Tracker] ([TrackerId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD FOREIGN KEY([WorkFlowId])
REFERENCES [dbo].[WorkFlow] ([WorkFlowId])
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_WorkFlowStep] FOREIGN KEY([WorkFlowStepId])
REFERENCES [dbo].[WorkFlowStep] ([WorkFlowStepId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_WorkFlowStep]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[EmployeeRole]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[Lead]  WITH CHECK ADD  CONSTRAINT [FK_Lead_WorkFlowStep] FOREIGN KEY([TrackerFlowStepId])
REFERENCES [dbo].[WorkFlowStep] ([WorkFlowStepId])
GO
ALTER TABLE [dbo].[Lead] CHECK CONSTRAINT [FK_Lead_WorkFlowStep]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zone] ([ZoneId])
GO
ALTER TABLE [dbo].[OrgAttendanceLocation]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[ProjectDetail]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Tracker]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[Tracker]  WITH CHECK ADD FOREIGN KEY([WorkFlowId])
REFERENCES [dbo].[WorkFlow] ([WorkFlowId])
GO
ALTER TABLE [dbo].[Tracker]  WITH CHECK ADD  CONSTRAINT [FK_Tracker_Project] FOREIGN KEY([VisitedProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Tracker] CHECK CONSTRAINT [FK_Tracker_Project]
GO
ALTER TABLE [dbo].[Tracker]  WITH CHECK ADD  CONSTRAINT [FK_Tracker_WorkFlowStep] FOREIGN KEY([WorkFlowStepId])
REFERENCES [dbo].[WorkFlowStep] ([WorkFlowStepId])
GO
ALTER TABLE [dbo].[Tracker] CHECK CONSTRAINT [FK_Tracker_WorkFlowStep]
GO
ALTER TABLE [dbo].[UserLocation]  WITH CHECK ADD FOREIGN KEY([OrgId])
REFERENCES [dbo].[Organisation] ([OrgId])
GO
ALTER TABLE [dbo].[UserLocation]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[WorkFlowDetails]  WITH CHECK ADD  CONSTRAINT [FK__WorkFlowS__WorkF__6FB49575] FOREIGN KEY([WorkFlowId])
REFERENCES [dbo].[WorkFlow] ([WorkFlowId])
GO
ALTER TABLE [dbo].[WorkFlowDetails] CHECK CONSTRAINT [FK__WorkFlowS__WorkF__6FB49575]
GO
ALTER TABLE [dbo].[WorkFlowDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkFlowDetails_WorkFlowStep] FOREIGN KEY([CurrentStep])
REFERENCES [dbo].[WorkFlowStep] ([WorkFlowStepId])
GO
ALTER TABLE [dbo].[WorkFlowDetails] CHECK CONSTRAINT [FK_WorkFlowDetails_WorkFlowStep]
GO
ALTER TABLE [dbo].[WorkFlowDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkFlowDetails_WorkFlowStep1] FOREIGN KEY([NextStep])
REFERENCES [dbo].[WorkFlowStep] ([WorkFlowStepId])
GO
ALTER TABLE [dbo].[WorkFlowDetails] CHECK CONSTRAINT [FK_WorkFlowDetails_WorkFlowStep1]
GO
ALTER TABLE [dbo].[WorkFlowDetails]  WITH CHECK ADD  CONSTRAINT [FK_WorkFlowDetails_WorkFlowStep2] FOREIGN KEY([PreviousStep])
REFERENCES [dbo].[WorkFlowStep] ([WorkFlowStepId])
GO
ALTER TABLE [dbo].[WorkFlowDetails] CHECK CONSTRAINT [FK_WorkFlowDetails_WorkFlowStep2]
GO
ALTER TABLE [dbo].[WorkFlowStep]  WITH CHECK ADD  CONSTRAINT [FK_WorkFlowStep_WorkFlow] FOREIGN KEY([WorkFlowId])
REFERENCES [dbo].[WorkFlow] ([WorkFlowId])
GO
ALTER TABLE [dbo].[WorkFlowStep] CHECK CONSTRAINT [FK_WorkFlowStep_WorkFlow]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeesAndChildren]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeesAndChildren]
    @ParentUserId INT,
	@OrgId INT
AS
BEGIN
    WITH CTE AS
    (
        SELECT E.EmployeeId, E.[Name], E.RoleId, E.IsActive, E.IsDeleted, 1 AS Level
        FROM Employee AS E
        WHERE E.EmployeeId = @ParentUserId AND E.OrgId = @OrgId
        
        UNION ALL
        
        SELECT p.EmployeeId, p.[Name], p.RoleId, p.IsActive, p.IsDeleted, c.Level + 1
        FROM CTE c
        JOIN Employee AS p ON p.ParentUserId = c.EmployeeId AND p.OrgId = @OrgId
        WHERE c.Level < 10  -- Set a limit on the recursion level
    )
   
    SELECT E.EmployeeId, E.[Name], E.RoleId, E.IsActive, E.IsDeleted, R.Name AS RoleName
    FROM CTE AS E
    LEFT JOIN Role AS R ON E.RoleId = R.RoleId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetTrackerStepCounts]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTrackerStepCounts]
    @EmployeeId INT,
    @OrgId INT
AS
BEGIN
    SELECT
        W.WorkFlowStepId AS Id,
        W.StepName, COUNT(*) AS StepCount, SUM(CASE WHEN ISNULL(T.IsStepCompleted, 0) = 0 THEN 1 ELSE 0 END) AS StepCountIsFalse
        FROM WorkFlowStep AS W
        LEFT JOIN Tracker AS T ON W.WorkFlowStepId = T.WorkFlowStepId
        AND T.AssignedTo = @EmployeeId AND T.OrgId = @OrgId
        GROUP BY W.StepName, W.WorkFlowStepId;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetActivities]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetActivities]
    @RowsPerPage INT,
    @PageIndex INT,
    @WorkFlowId INT,
    @WorkFlowStepId INT,
    @AssignedTo INT,
    @ExpectedFromDate DATETIME,
    @ExpectedToDate DATETIME,
    @SearchTerm NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartRow INT = (@PageIndex - 1) * @RowsPerPage;
    DECLARE @Next INT = @RowsPerPage;

    WITH PagedTrackers AS (
        SELECT
            T.TrackerId,
            T.EnquiryId,
            T.CodeId,
            T.Remark,
            T.Date,
            T.VisitExpected,
            T.VisitExpectedDate,
            T.VisitedProjectId,
            T.VisitRemark,
            T.IsActive,
            T.IsDeleted,
            T.AssignedTo,
            T.WorkFlowId,
            T.WorkFlowStepId,
            T.CreatedDate,
            T.ModifiedDate,
            T.IsStepCompleted,
            T.CreatedBy,
            T.ModifiedBy,
            T.OrgId,
            L.LeadSource AS LeadSource,
            L.LeadSourceProject AS LeadSourceProject,
            L.Name AS LeadName,  
            L.MobNo AS LeadMobNo,
            L.EmailID AS LeadEmail,
            L.Requirement AS LeadRequirement,
            L.Budget AS LeadBudget,
            L.Description AS LeadDescription,
            ROW_NUMBER() OVER (ORDER BY T.TrackerId) AS RowNum
        FROM Tracker AS T
        LEFT JOIN Lead AS L ON T.EnquiryId = L.EnquiryId
        WHERE
            (@WorkFlowId IS NULL OR T.WorkFlowId = @WorkFlowId)
            AND (@WorkFlowStepId IS NULL OR T.WorkFlowStepId = @WorkFlowStepId)
            AND (@AssignedTo IS NULL OR T.AssignedTo = @AssignedTo)
            AND (@ExpectedFromDate IS NULL OR (@ExpectedFromDate IS NOT NULL AND T.VisitExpectedDate >= @ExpectedFromDate))
            AND (@ExpectedToDate IS NULL OR (@ExpectedToDate IS NOT NULL AND T.VisitExpectedDate <= @ExpectedToDate))
            AND (
                @SearchTerm IS NULL 
                OR L.Name LIKE '%' + @SearchTerm + '%'
                OR L.LeadSource LIKE '%' + @SearchTerm + '%'
                OR L.LeadSourceProject LIKE '%' + @SearchTerm + '%'
                OR L.MobNo LIKE '%' + @SearchTerm + '%'
                OR L.EmailID LIKE '%' + @SearchTerm + '%'
                OR L.Requirement LIKE '%' + @SearchTerm + '%'
                OR L.Budget LIKE '%' + @SearchTerm + '%'
            )
			 AND T.IsStepCompleted = 0
    )
    
    SELECT *
    FROM PagedTrackers
    WHERE RowNum > @StartRow AND RowNum <= (@StartRow + @RowsPerPage);
END

GO
/****** Object:  StoredProcedure [dbo].[spGetAllAttendance]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetAllAttendance]
    @UserId INT,
    @StartDate DATETIME,
    @EndDate DATETIME
AS
BEGIN
    
    SET @EndDate = DATEADD(DAY, 1, @EndDate); 
    SELECT *
    FROM Attendance
    WHERE UserId = @UserId
    AND LoginDate >= @StartDate
    AND LoginDate < @EndDate; 
END


GO
/****** Object:  StoredProcedure [dbo].[spGetAllParents]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[spGetAllParents]
AS
BEGIN
     SELECT E.EmployeeId AS EmployeeId, E.Name AS EmployeeName, E.RoleId AS RoleId, R.Name AS Role
     FROM Employee E
     INNER JOIN Role R
     ON E.RoleId = R.RoleId
     WHERE E.RoleId IN (4, 5, 6, 7)
END


--Alter PROCEDURE spGetAllParents
--AS
--BEGIN
--    SELECT E.EmployeeId AS EmployeeId, E.Name AS EmployeeName, E.RoleId AS RoleId, R.Name AS Role
--    FROM Employee E
--    INNER JOIN Role R 
--	ON E.RoleId = R.RoleId
--    WHERE E.EmployeeId IN (SELECT DISTINCT ParentUserId FROM Employee)
--END







GO
/****** Object:  StoredProcedure [dbo].[spGetTimeline]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetTimeline]
    @RowsPerPage INT,
    @PageIndex INT,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @WorkFlowStepId INT = NULL,
    @AssignedTo INT = NULL,
    @SearchTerm NVARCHAR(250)
AS 
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartRow INT = (@PageIndex - 1) * @RowsPerPage;
    DECLARE @Next INT = @RowsPerPage;

    WITH PagedTrackers AS (
        SELECT
            T.TrackerId,
            T.EnquiryId,
            T.AssignedTo,
            T.WorkFlowId,
            T.WorkFlowStepId,
            T.ModifiedDate,
            T.ModifiedBy,
            T.IsStepCompleted,
            T.OrgId,
            E.Name AS EmployeeName,
            E.EmailId,
            E.UserName,
            E.RoleId,
            L.LeadSource,
            L.LeadSourceProject,
            L.Name AS LeadName,
            L.Requirement,
            L.Budget,
            D.DocumentId,
            D.Location AS DocLocation,
            W.StepName,
            ROW_NUMBER() OVER (ORDER BY T.ModifiedDate DESC) AS RowNum
        FROM Tracker AS T
        INNER JOIN Employee AS E ON T.AssignedTo = E.EmployeeId OR @AssignedTo IS NULL
        LEFT JOIN Lead AS L ON T.EnquiryId = L.EnquiryId
        LEFT JOIN Document AS D ON T.TrackerId = D.TrackerId AND T.WorkFlowStepId = D.WorkFlowStepId
        LEFT JOIN WorkFlowStep AS W ON T.WorkFlowStepId = W.WorkFlowStepId OR @WorkFlowStepId IS NULL
        WHERE
            T.ModifiedDate >= @StartDate
            AND T.ModifiedDate <= @EndDate
            AND (T.WorkFlowStepId = @WorkFlowStepId OR @WorkFlowStepId IS NULL)
            AND (T.AssignedTo = @AssignedTo OR @AssignedTo IS NULL)
            AND T.IsStepCompleted = 1
            AND (
                @SearchTerm IS NULL 
                OR T.AssignedTo LIKE '%' + @SearchTerm + '%'
                OR E.Name LIKE '%' + @SearchTerm + '%'
                OR E.EmailId LIKE '%' + @SearchTerm + '%'
                OR E.UserName LIKE '%' + @SearchTerm + '%'
                OR L.Name LIKE '%' + @SearchTerm + '%'
                OR W.StepName LIKE '%' + @SearchTerm + '%'
            )
    )

    SELECT *
    FROM PagedTrackers
    WHERE RowNum > @StartRow AND RowNum <= (@StartRow + @RowsPerPage);
END

GO
/****** Object:  StoredProcedure [dbo].[spUpdateAttendance]    Script Date: 11/23/2023 1:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spUpdateAttendance]
   @EmployeeId INT,
   @StartDate DATETIME,
   @EndDate DATETIME,
   @ApprovedBy INT
AS
BEGIN
    UPDATE Attendance
    SET IsApproved = 1,
	    Status = 'PRESENT',
        ApprovedBy = @ApprovedBy,
        ModifiedDate = GETDATE(),
        ModifiedBy = @ApprovedBy
    WHERE UserId = @EmployeeId
    AND LoginDate >= @StartDate
    AND LoginDate <= @EndDate;

	 SELECT *
    FROM Attendance
    WHERE UserId = @EmployeeId
    AND LoginDate >= @StartDate
    AND LoginDate <= @EndDate;
END
GO
ALTER PROC spGetAllParents
AS
BEGIN
     SELECT E.EmployeeId AS EmployeeId, E.Name AS EmployeeName, E.RoleId AS RoleId, R.Name AS Role
     FROM Employee E
     INNER JOIN Role R
     ON E.RoleId = R.RoleId
     WHERE E.RoleId IN (1,2,3,4) 
END


select * from employee