USE [PlantVisit]
GO
INSERT [dbo].[PlantList] ([PlantID], [PlantName], [PlantDescription], [PlantLocation], [PlantNumber], [PlantEmail]) VALUES (1, N'Amul Dairy', N'Amul, is an Indian dairy cooperative society, based at Anand in the state of Gujarat. Formed in 1946', N'Amul Dairy, Popati Nagar, Anand, Gujarat, India', N'02692-225443', N'pro@amuldairy.com')
GO
INSERT [dbo].[PlantList] ([PlantID], [PlantName], [PlantDescription], [PlantLocation], [PlantNumber], [PlantEmail]) VALUES (2, N'Amul Chocolate Plant', N'Chocolate plant is fully automatic and the visitors can see the manufacturing and packing of chocolates through transparent window glass.', N'Amul Chocolate Unit-Food Complex, Mogar, Gujarat, India', N'02692-226785', N'pro@amuldairy.com')
GO
INSERT [dbo].[PlantList] ([PlantID], [PlantName], [PlantDescription], [PlantLocation], [PlantNumber], [PlantEmail]) VALUES (3, N'AmulFed Dairy', N'Amul, is an Indian dairy cooperative society, based at Anand in the state of Gujarat', N'Indira Bridge, GIDC Bhat, Hansol, Ahmedabad, Gujarat, India', N'079-23969055', N'hradm.afd@amul.coop')
GO
INSERT [dbo].[PlantList] ([PlantID], [PlantName], [PlantDescription], [PlantLocation], [PlantNumber], [PlantEmail]) VALUES (4, N'Panchmahal DCMPU Ltd', N'The Panchmahal District Co-operative Milk Producers’ Union Ltd. was registered in year 1973, Popularly known as “PANCHAMRUT”.', N'Lunawada Road, Bhaibhav Nagar, Godhra, Gujarat, India', N'6352976801', N'hr@panchmahalunion.coop')
GO
INSERT [dbo].[PlantList] ([PlantID], [PlantName], [PlantDescription], [PlantLocation], [PlantNumber], [PlantEmail]) VALUES (5, N'Sarhad Dairy - Cattelfeed Plant', N'Sarhad Dairy - Cattelfeed Plant is started in 2018 Kutch 1st Fully Automized Solar Energy operated Cattelfeed plant', N'Sarhad Dairy Cattle Feed Plant, Anjar, Gujarat, India', N'9687655943', N'hr@sarhaddairy.coop')
GO
INSERT [dbo].[VisitSlot] ([VisitID], [PlantID], [VisitTime], [Capacity]) VALUES (1, 1, CAST(N'08:00:00' AS Time), 50)
GO
INSERT [dbo].[VisitSlot] ([VisitID], [PlantID], [VisitTime], [Capacity]) VALUES (2, 2, CAST(N'10:00:00' AS Time), 30)
GO
INSERT [dbo].[VisitSlot] ([VisitID], [PlantID], [VisitTime], [Capacity]) VALUES (3, 3, CAST(N'12:00:00' AS Time), 20)
GO
INSERT [dbo].[VisitSlot] ([VisitID], [PlantID], [VisitTime], [Capacity]) VALUES (4, 4, CAST(N'14:00:00' AS Time), 40)
GO
INSERT [dbo].[VisitSlot] ([VisitID], [PlantID], [VisitTime], [Capacity]) VALUES (5, 5, CAST(N'16:00:00' AS Time), 60)
GO
SET IDENTITY_INSERT [dbo].[UserData] ON 
GO
INSERT [dbo].[UserData] ([UserID], [UserNumber]) VALUES (2, 123)
GO
INSERT [dbo].[UserData] ([UserID], [UserNumber]) VALUES (3, 456)
GO
INSERT [dbo].[UserData] ([UserID], [UserNumber]) VALUES (4, 789)
GO
INSERT [dbo].[UserData] ([UserID], [UserNumber]) VALUES (5, 147)
GO
INSERT [dbo].[UserData] ([UserID], [UserNumber]) VALUES (6, 369)
GO
SET IDENTITY_INSERT [dbo].[UserData] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingTable] ON 
GO
INSERT [dbo].[BookingTable] ([BookingID], [UserID], [PlantID], [VisitID], [BookingDate], [Capacity]) VALUES (2, 2, 1, 1, CAST(N'2025-01-23' AS Date), 50)
GO
INSERT [dbo].[BookingTable] ([BookingID], [UserID], [PlantID], [VisitID], [BookingDate], [Capacity]) VALUES (3, 3, 2, 2, CAST(N'2025-01-24' AS Date), 30)
GO
INSERT [dbo].[BookingTable] ([BookingID], [UserID], [PlantID], [VisitID], [BookingDate], [Capacity]) VALUES (4, 2, 3, 3, CAST(N'2025-01-25' AS Date), 20)
GO
INSERT [dbo].[BookingTable] ([BookingID], [UserID], [PlantID], [VisitID], [BookingDate], [Capacity]) VALUES (5, 3, 4, 4, CAST(N'2025-01-26' AS Date), 40)
GO
INSERT [dbo].[BookingTable] ([BookingID], [UserID], [PlantID], [VisitID], [BookingDate], [Capacity]) VALUES (6, 2, 5, 5, CAST(N'2025-01-27' AS Date), 60)
GO
SET IDENTITY_INSERT [dbo].[BookingTable] OFF
GO
INSERT [dbo].[Facilities] ([FacilitiesID], [FacilitiesName]) VALUES (1, N'Car Parking')
GO
INSERT [dbo].[Facilities] ([FacilitiesID], [FacilitiesName]) VALUES (2, N'Public Toilet')
GO
INSERT [dbo].[Facilities] ([FacilitiesID], [FacilitiesName]) VALUES (3, N'Amul Parlour')
GO
INSERT [dbo].[Facilities] ([FacilitiesID], [FacilitiesName]) VALUES (4, N'Amul Foodland')
GO
INSERT [dbo].[Facilities] ([FacilitiesID], [FacilitiesName]) VALUES (5, N'Amul Finedine')
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (1, 1, 1)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (2, 1, 2)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (3, 1, 3)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (4, 1, 4)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (5, 1, 5)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (6, 2, 1)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (7, 2, 2)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (8, 2, 3)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (9, 3, 1)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (10, 3, 2)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (11, 4, 1)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (12, 4, 2)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (13, 4, 3)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (14, 5, 1)
GO
INSERT [dbo].[PFMapping] ([PFID], [PlantID], [FacilitiesID]) VALUES (15, 5, 2)
GO
