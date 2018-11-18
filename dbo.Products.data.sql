SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (1, N'Dog Food', N'Generic Dog Food', CAST(10.5000 AS Money), 4, N'Pet', N'Pet.Inc')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (2, N'Shirt', N'Generic shirt', CAST(20.0000 AS Money), 12, N'Clothing', N'Hot Topic')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (3, N'Bike', N'adult bike', CAST(130.0000 AS Money), 2, N'Sport', N'Rolling Co.')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (4, N'Roller Blades', N'kids roller blades', CAST(75.0000 AS Money), 2, N'Sport', N'Rolling Co.')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (5, N'Chips', N'Generic Chips', CAST(3.0000 AS Money), 12, N'Food', N'Yum Yums')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (6, N'Soda', N'Generic Soda', CAST(1.2000 AS Money), 12, N'Food', N'Yum Yums')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (7, N'Video Game 1', N'Generic Video Game', CAST(60.0000 AS Money), 6, N'Electronics', N'Games.Inc')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (8, N'DVD Movie', N'Generic Movie', CAST(15.0000 AS Money), 6, N'Electronics', N'Movies.Inc')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (9, N'Desk', N'Generic Desk', CAST(200.0000 AS Money), 2, N'Furniture', N'NoKea')
INSERT INTO [dbo].[Products] ([id], [Name], [Description], [Price], [Quantity], [Category], [Seller]) VALUES (10, N'Chair', N'Generic chair', CAST(30.0000 AS Money), 4, N'Furniture', N'NoKea')
SET IDENTITY_INSERT [dbo].[Products] OFF
