USE [RSVP]
GO
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([GuestID], [GuestGroupID], [FirstName], [LastName], [IsChild]) VALUES (3, NULL, N'Lauren', N'Rosentzveig', 0)
INSERT [dbo].[Guest] ([GuestID], [GuestGroupID], [FirstName], [LastName], [IsChild]) VALUES (4, NULL, N'Jordana', N'Rosentzveig', 0)
SET IDENTITY_INSERT [dbo].[Guest] OFF
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventID], [Title], [Subtitle], [Description], [EventStartDate], [EventEndDate], [Venue], [Address], [EventStartTime], [EventEndTime], [Details]) VALUES (1, N'Ceremony', N'ceremony & brunch', N'Welcome drinks will be served at 10:00. Ceremony will commence at 10:30. Cocktails and hor d''oeuvres will be passed at 11:00. Brunch will be served at 12:30.', CAST(N'2020-08-30' AS Date), CAST(N'2020-08-30' AS Date), N'Graydon Hall Manor', N'185 Graydon Hall Drive, Toronto', CAST(N'10:00:00' AS Time), CAST(N'15:00:00' AS Time), N'Free parking will be provided in the designated parking lot closest to the building. Signage will be present.')
INSERT [dbo].[Events] ([EventID], [Title], [Subtitle], [Description], [EventStartDate], [EventEndDate], [Venue], [Address], [EventStartTime], [EventEndTime], [Details]) VALUES (2, N'Reception', N'cocktails & dancing', N'Help us celebrate from 9:00 onwards with lots of drinks, dancing and a beautiful view.', CAST(N'2020-08-30' AS Date), CAST(N'2020-08-31' AS Date), N'The One Eighty', N'55 Bloor St W, 51st Floor, Toronto', CAST(N'21:00:00' AS Time), CAST(N'02:00:00' AS Time), N'Entrance to the restaurant is on the second floor, to the right of the escalators. Parking is available underneath the building. Entrance to the lot is on the (East side of Bay Street).')
SET IDENTITY_INSERT [dbo].[Events] OFF
INSERT [dbo].[GuestEventJunction] ([GuestID], [EventID], [RepliesID]) VALUES (3, 1, NULL)
INSERT [dbo].[GuestEventJunction] ([GuestID], [EventID], [RepliesID]) VALUES (3, 2, NULL)
INSERT [dbo].[GuestEventJunction] ([GuestID], [EventID], [RepliesID]) VALUES (4, 1, NULL)
