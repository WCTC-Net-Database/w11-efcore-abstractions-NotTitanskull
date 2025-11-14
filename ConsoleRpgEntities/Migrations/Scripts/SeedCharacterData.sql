-- Players (only insert if not present)
IF NOT EXISTS (SELECT 1 FROM Players WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Players ON;
    
    INSERT INTO Players (Id, Name, Health, Experience) VALUES
        (1, 'Sir Lancelot', 100, 0),
        (2, 'Aragorn', 100, 150),
        (3, 'Legolas', 80, 120),
        (4, 'Gandalf', 90, 500),
        (5, 'Gimli', 110, 200),
        (6, 'Frodo', 60, 50),
        (7, 'Sam', 70, 45),
        (8, 'Boromir', 95, 180);
    
    SET IDENTITY_INSERT Players OFF;
END;

-- Monster
IF NOT EXISTS (SELECT 1 FROM Monsters WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Monsters ON;
    INSERT INTO Monsters (
        Id,
        Name,
        MonsterType,
        Health,
        AggressionLevel,
        AttackPower
    )
    VALUES (
        1, 
        'Bob Goblin', 
        'Goblin', 
        20, 
        10, 
        10
    );
    
    SET IDENTITY_INSERT Monsters OFF;
END;

-- Ability
IF NOT EXISTS (SELECT 1 FROM Abilities WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Abilities ON;
        
    INSERT INTO Abilities (
        Id, 
        Name, 
        Description, 
        AbilityType, 
        Damage, 
        Distance
    )
    VALUES (
        1, 
        'Shove', 
        'Power Shove', 
        'ShoveAbility', 
        10, 
        5
    );
    SET IDENTITY_INSERT Abilities OFF;
END;

-- Items (skip Ids 1,2 already seeded)
SET IDENTITY_INSERT Items ON;

IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 3)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (3, 'Wizard Staff', 'A magical staff crackling with energy', 'Weapon', 20, NULL);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 4)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (4, 'Battle Axe', 'A heavy dwarven axe', 'Weapon', 18, NULL);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 5)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (5, 'Dagger', 'A small, sharp blade', 'Weapon', 8, NULL);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 6)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (6, 'Iron Plate Armor', 'Heavy iron protection', 'Armor', NULL, 10);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 7)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (7, 'Leather Armor', 'Light and flexible', 'Armor', NULL, 5);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 8)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (8, 'Wizard Robes', 'Enchanted robes', 'Armor', NULL, 7);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 9)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (9, 'Dwarven Mail', 'Sturdy chainmail', 'Armor', NULL, 12);
IF NOT EXISTS (SELECT 1 FROM Items WHERE Id = 10)
    INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense) VALUES
        (10, 'Cloth Tunic', 'Basic cloth protection', 'Armor', NULL, 3);
SET IDENTITY_INSERT Items OFF;

-- Equipments (avoid duplicate Id 1)
SET IDENTITY_INSERT Equipments ON;
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 2)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (2, 1, 6);  -- Aragorn
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 3)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (3, 2, 7);  -- Legolas
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 4)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (4, 3, 8);  -- Gandalf
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 5)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (5, 4, 9);  -- Gimli
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 6)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (6, 5, 10); -- Frodo
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 7)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (7, 5, 7);  -- Sam
IF NOT EXISTS (SELECT 1 FROM Equipments WHERE Id = 8)
    INSERT INTO Equipments (Id, WeaponId, ArmorId) VALUES (8, 1, 6);  -- Boromir
SET IDENTITY_INSERT Equipments OFF;

-- Link equipment (only if player exists and not linked)
UPDATE Players SET EquipmentId = 1 WHERE Id = 1 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 2 WHERE Id = 2 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 3 WHERE Id = 3 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 4 WHERE Id = 4 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 5 WHERE Id = 5 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 6 WHERE Id = 6 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 7 WHERE Id = 7 AND EquipmentId IS NULL;
UPDATE Players SET EquipmentId = 8 WHERE Id = 8 AND EquipmentId IS NULL;