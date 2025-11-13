SET IDENTITY_INSERT [dbo].[Items] ON
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (1, N'Short Sword', N'A balanced short blade.', N'Weapon', 6, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (2, N'Longsword', N'A versatile blade for slashing and thrusting.', N'Weapon', 10, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (3, N'Dagger', N'Small, quick, and easy to conceal.', N'Weapon', 4, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (4, N'Greatsword', N'A heavy two-handed sword with powerful strikes.', N'Weapon', 14, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (5, N'Club', N'A crude wooden club, blunt but reliable.', N'Weapon', 5, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (6, N'Warhammer', N'A hammer designed to crush armor.', N'Weapon', 11, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (7, N'Short Bow', N'A compact bow for quick shots.', N'Weapon', 7, NULL)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (8, N'Crossbow', N'A powerful ranged weapon with slow reload.', N'Weapon', 9, NULL)

INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (9, N'Leather Armor', N'Light leather armor offering basic protection.', N'Armor', NULL, 3)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (10, N'Chainmail', N'Interlinked rings offering good protection.', N'Armor', NULL, 7)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (11, N'Plate Armor', N'Heavy plate armor with excellent defense.', N'Armor', NULL, 12)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (12, N'Shield', N'A sturdy shield for blocking attacks.', N'Armor', NULL, 6)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (13, N'Buckler', N'A small round shield, light and quick.', N'Armor', NULL, 2)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (14, N'Padded Cloak', N'A cloak that softens blows.', N'Armor', NULL, 1)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (15, N'Tower Shield', N'A large shield offering superior coverage.', N'Armor', NULL, 10)
INSERT INTO [dbo].[Items] ([Id], [Name], [Description], [ItemType], [Damage], [Defense]) VALUES (16, N'Great Axe', N'A massive axe that deals devastating damage.', N'Weapon', 13, NULL)
SET IDENTITY_INSERT [dbo].[Items] OFF

-- Insert Equipment combinations
SET IDENTITY_INSERT [dbo].[Equipment] ON
INSERT INTO [dbo].[Equipment] ([Id], [WeaponId], [ArmorId]) VALUES (1, 1, 9)  -- Short Sword + Leather Armor
INSERT INTO [dbo].[Equipment] ([Id], [WeaponId], [ArmorId]) VALUES (2, 2, 10) -- Longsword + Chainmail
INSERT INTO [dbo].[Equipment] ([Id], [WeaponId], [ArmorId]) VALUES (3, 4, 11) -- Greatsword + Plate Armor
SET IDENTITY_INSERT [dbo].[Equipment] OFF

-- Assign equipment to existing players (assuming Player ID 1 exists)
UPDATE [dbo].[Players] SET [EquipmentId] = 1 WHERE [Id] = 1
