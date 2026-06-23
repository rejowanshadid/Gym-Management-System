USE [GreyGym]
GO
/** Object:  Table [dbo].[Amount]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Method] [nvarchar](500) NOT NULL,
	[PaymentStatus] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Amount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[DietPlan]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DietPlan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TrainerID] [int] NULL,
	[CurrentWeight] [int] NULL,
	[TargetWeight] [int] NULL,
	[Goal] [nvarchar](500) NULL,
	[FoodPlan] [nvarchar](max) NULL,
	[StartDate] [date] NULL,
 CONSTRAINT [PK_DietPlan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/** Object:  Table [dbo].[Package]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](500) NOT NULL,
	[Duration] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Description] [nvarchar](800) NOT NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[TrainerUser]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainerUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TrainerID] [int] NULL,
	[PackID] [int] NOT NULL,
	[DietID] [int] NULL,
	[WorkOutID] [int] NULL,
	[AssignDate] [date] NULL,
 CONSTRAINT [PK_TrainerUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[UserInfo]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Gmail] [nvarchar](500) NOT NULL,
	[Phone] [int] NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Gender] [nvarchar](250) NOT NULL,
	[UserType] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[UserPackage]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPackage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[IsActive] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserPackage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[WorkoutPlan]    Script Date: 1/20/2026 2:34:17 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkoutPlan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [nvarchar](500) NOT NULL,
	[Workout] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_WorkoutPlan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amount] ON 
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (1, 7, 1, 1000, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (2, 9, 1, 750, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (3, 8, 1, 750, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (4, 10, 1, 750, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (5, 10, 1, 750, N'Bkash', N'Pending')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (6, 12, 2, 1000, N'Bkash', N'Pending')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (7, 13, 2, 1000, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (8, 14, 2, 1000, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (9, 15, 2, 1000, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (10, 16, 2, 1000, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (11, 17, 5, 2500, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (12, 9, 4, 1500, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (13, 9, 4, 1500, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (14, 9, 1, 750, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (15, 9, 5, 2500, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (16, 7, 5, 2500, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (17, 7, 2, 1000, N'Bkash', N'Confirmed')
GO
INSERT [dbo].[Amount] ([ID], [UserId], [PackageId], [Amount], [Method], [PaymentStatus]) VALUES (18, 7, 1, 750, N'Bkash', N'Pending')
GO
SET IDENTITY_INSERT [dbo].[Amount] OFF
GO
SET IDENTITY_INSERT [dbo].[DietPlan] ON 
GO
INSERT [dbo].[DietPlan] ([ID], [UserID], [TrainerID], [CurrentWeight], [TargetWeight], [Goal], [FoodPlan], [StartDate]) VALUES (1, 9, 18, 78, 65, N'WeightLoss', N'Breakfast:
- 1 cup oatmeal with skim milk
- 1 boiled egg
- 1 small apple
- Green tea (no sugar)

Mid-Morning Snack:
- 10 almonds
- 1 cup cucumber slices

Lunch:
- Grilled chicken breast (100-150g)
- 1 cup steamed vegetables (broccoli, carrots, beans)
- 1 small serving of brown rice or quinoa
- 1 glass water

Afternoon Snack:
- 1 cup low-fat yogurt
- 1 small handful of berries

Dinner:
- Baked fish or tofu (100-150g)
- Large green salad with lemon dressing
- 1 glass water', CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[DietPlan] ([ID], [UserID], [TrainerID], [CurrentWeight], [TargetWeight], [Goal], [FoodPlan], [StartDate]) VALUES (2, 15, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[DietPlan] ([ID], [UserID], [TrainerID], [CurrentWeight], [TargetWeight], [Goal], [FoodPlan], [StartDate]) VALUES (3, 16, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[DietPlan] ([ID], [UserID], [TrainerID], [CurrentWeight], [TargetWeight], [Goal], [FoodPlan], [StartDate]) VALUES (4, 17, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[DietPlan] ([ID], [UserID], [TrainerID], [CurrentWeight], [TargetWeight], [Goal], [FoodPlan], [StartDate]) VALUES (5, 7, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-01-17' AS Date))
GO
SET IDENTITY_INSERT [dbo].[DietPlan] OFF
GO
SET IDENTITY_INSERT [dbo].[Package] ON 
GO
INSERT [dbo].[Package] ([ID], [PackageName], [Duration], [Price], [Description]) VALUES (1, N'STARTER', 1, 750, N'Short-term gym access 

Basic equipment usage

No long-term commitment')
GO
INSERT [dbo].[Package] ([ID], [PackageName], [Duration], [Price], [Description]) VALUES (2, N'BASIC', 3, 1000, N'Access to gym equipment

Cardio & strength training area

Locker room access

Fixed operating hours
')
GO
INSERT [dbo].[Package] ([ID], [PackageName], [Duration], [Price], [Description]) VALUES (3, N'STUDENT', 3, 500, N'Full gym access

Off-peak hour usage

Group classes

Discounted pricing')
GO
INSERT [dbo].[Package] ([ID], [PackageName], [Duration], [Price], [Description]) VALUES (4, N'STANDARD', 6, 1500, N'Full gym access

Group fitness classes 

Basic trainer guidance

Locker and shower facilities
')
GO
INSERT [dbo].[Package] ([ID], [PackageName], [Duration], [Price], [Description]) VALUES (5, N'PREMIUM', 12, 2500, N'Unlimited gym access

Personal trainer sessions
(limited per month)

Customized workout plan

Basic nutrition guidance
')
GO
SET IDENTITY_INSERT [dbo].[Package] OFF
GO
SET IDENTITY_INSERT [dbo].[TrainerUser] ON 
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (1, 8, NULL, 1, 2, 2, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (2, 10, NULL, 1, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (3, 9, 18, 5, 1, 1, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (4, 15, NULL, 2, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (5, 16, NULL, 2, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (6, 17, NULL, 5, NULL, NULL, CAST(N'2026-01-15' AS Date))
GO
INSERT [dbo].[TrainerUser] ([ID], [CustomerID], [TrainerID], [PackID], [DietID], [WorkOutID], [AssignDate]) VALUES (7, 7, NULL, 2, 5, NULL, CAST(N'2026-01-17' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TrainerUser] OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON 
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (7, N'Nisha', N'nisha@gmail.com', 1611616116, N'nisha12', N'Female', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (8, N'Tanzim', N'Tanzim@gmail.com', 1610309486, N'Tanzim12', N'Female', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (9, N'Omi ', N'omi@gmail.com', 1610309486, N'omi1234', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (10, N'Imran salehin sady', N'sady@gmail.com', 1610309486, N'sady12', N'Male', N'Admin')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (11, N'Tanzim', N'tanzimul@gmail.com', 23123123, N'1234', N'Male', N'Admin')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (12, N'Khaled Tanoy', N'tanoy@gmail.com', 1234567890, N'123456', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (13, N'MRx', N'x@gmail.com', 1234567890, N'1234567', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (14, N'MrY', N'y@gmail.com', 1098765432, N'098765', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (15, N'MrZ', N'z@gmail.com', 1983475610, N'12345678', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (16, N'MrA', N'a@gmail.com', 1234567890, N'1234567', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (17, N'zoro', N'zoro@gmail.com', 1987666381, N'zoro123', N'Male', N'Customer')
GO
INSERT [dbo].[UserInfo] ([ID], [Name], [Gmail], [Phone], [Password], [Gender], [UserType]) VALUES (18, N'Akib', N'akib@gmail.com', 1234445611, N'akib123', N'Male', N'Trainer')
GO
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPackage] ON 
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (1, 8, 1, CAST(N'2026-01-15' AS Date), CAST(N'2026-02-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (2, 10, 1, CAST(N'2026-01-15' AS Date), CAST(N'2026-02-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (3, 9, 5, CAST(N'2026-01-15' AS Date), CAST(N'2027-02-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (4, 12, 2, CAST(N'2026-01-15' AS Date), CAST(N'2026-04-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (5, 13, 2, CAST(N'2026-01-15' AS Date), CAST(N'2026-04-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (6, 14, 2, CAST(N'2026-01-15' AS Date), CAST(N'2026-04-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (7, 15, 2, CAST(N'2026-01-15' AS Date), CAST(N'2026-04-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (8, 16, 2, CAST(N'2026-01-15' AS Date), CAST(N'2026-04-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (9, 17, 5, CAST(N'2026-01-15' AS Date), CAST(N'2027-01-15' AS Date), N'Yes')
GO
INSERT [dbo].[UserPackage] ([ID], [UserId], [PackId], [StartDate], [EndDate], [IsActive]) VALUES (10, 7, 2, CAST(N'2026-01-17' AS Date), CAST(N'2027-04-17' AS Date), N'Yes')
GO
SET IDENTITY_INSERT [dbo].[UserPackage] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkoutPlan] ON 
GO
INSERT [dbo].[WorkoutPlan] ([ID], [PlanName], [Workout]) VALUES (1, N'WeightLoss', N'Squats – 3×12

Push-ups – 3×10

Lunges – 3×10 (each leg)

Plank – 3×30 sec

Jumping jacks – 3×30 sec

Brisk walk / Cardio – 20 min')
GO
INSERT [dbo].[WorkoutPlan] ([ID], [PlanName], [Workout]) VALUES (2, N'MuscleBuild', N'Bench press / Push-ups – 4×8

Squats – 4×8

Deadlift – 3×6

Shoulder press – 3×10

Pull-ups / Lat pulldown – 3×8')
GO
INSERT [dbo].[WorkoutPlan] ([ID], [PlanName], [Workout]) VALUES (3, N'WeightGain', N'Squats – 4×10

Bench press – 4×10

Rows – 3×10

Overhead press – 3×10

Bicep curls – 3×12

Tricep dips – 3×12')
GO
SET IDENTITY_INSERT [dbo].[WorkoutPlan] OFF
GO
ALTER TABLE [dbo].[Amount]  WITH CHECK ADD  CONSTRAINT [FK_Amount_UserInfo] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Package] ([ID])
GO
ALTER TABLE [dbo].[Amount] CHECK CONSTRAINT [FK_Amount_UserInfo]
GO
ALTER TABLE [dbo].[TrainerUser]  WITH CHECK ADD  CONSTRAINT [FK_TrainerUser_UserInfo] FOREIGN KEY([TrainerID])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[TrainerUser] CHECK CONSTRAINT [FK_TrainerUser_UserInfo]
GO
ALTER TABLE [dbo].[TrainerUser]  WITH CHECK ADD  CONSTRAINT [FK_TrainerUser_WorkoutPlan] FOREIGN KEY([WorkOutID])
REFERENCES [dbo].[WorkoutPlan] ([ID])
GO
ALTER TABLE [dbo].[TrainerUser] CHECK CONSTRAINT [FK_TrainerUser_WorkoutPlan]
GO
ALTER TABLE [dbo].[UserPackage]  WITH CHECK ADD  CONSTRAINT [FK_UserPackage_Package] FOREIGN KEY([PackId])
REFERENCES [dbo].[Package] ([ID])
GO
ALTER TABLE [dbo].[UserPackage] CHECK CONSTRAINT [FK_UserPackage_Package]
GO
ALTER TABLE [dbo].[UserPackage]  WITH CHECK ADD  CONSTRAINT [FK_UserPackage_UserInfo] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[UserPackage] CHECK CONSTRAINT [FK_UserPackage_UserInfo]
GO.