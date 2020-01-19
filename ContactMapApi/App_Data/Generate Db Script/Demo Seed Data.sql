USE [ContactMap]
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 
GO
INSERT [dbo].[Contact] ([Id], [FullName], [Phone], [Email], [Title], [Company]) VALUES (1, N'Full Name 1', N'0123456789', N'email_1@email.gr', N'Job Title', N'Company')
GO
INSERT [dbo].[Contact] ([Id], [FullName], [Phone], [Email], [Title], [Company]) VALUES (2, N'Full Name 22', N'2234567890', N'email_22@email.com', N'Jot Title 22', N'Company 22')
GO
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Address] ON 
GO
INSERT [dbo].[Address] ([Id], [RoadName], [RoadNumber], [ZipCode], [City], [Area], [Country], [ContactId]) VALUES (1, N'Road Name', N'1', N'12345', N'City 1', N'Area 1', N'Country 1', 1)
GO
INSERT [dbo].[Address] ([Id], [RoadName], [RoadNumber], [ZipCode], [City], [Area], [Country], [ContactId]) VALUES (2, N'Road Name ', N'2', N'22345', N'City 2', N'Area 2', N'Country 2', 1)
GO
INSERT [dbo].[Address] ([Id], [RoadName], [RoadNumber], [ZipCode], [City], [Area], [Country], [ContactId]) VALUES (3, N'Road name', N'22', N'22233', N'City 22', N'Area 22', N'Country 22', 2)
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
