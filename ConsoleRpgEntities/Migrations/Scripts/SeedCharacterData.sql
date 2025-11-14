-- Seed initial player
SET IDENTITY_INSERT Players ON;
INSERT INTO Players (Id, Name, Health, Experience)
VALUES
    (1, 'Sir Lancelot', 100, 0),
    (2, 'Aragorn', 100, 150),
    (3, 'Legolas', 80, 120),
    (4, 'Gandalf', 90, 500),
    (5, 'Gimli', 110, 200),
    (6, 'Frodo', 60, 50),
    (7, 'Sam', 70, 45),
    (8, 'Boromir', 95, 180);
SET IDENTITY_INSERT Players OFF;

-- Seed initial monster
SET IDENTITY_INSERT Monsters ON;
INSERT INTO Monsters (Id, Name, MonsterType, Health, AggressionLevel)
VALUES
    (1, 'Bob Goblin', 'Goblin', 20, 10);
SET IDENTITY_INSERT Monsters OFF;

-- Seed initial ability
SET IDENTITY_INSERT Abilities ON;
INSERT INTO Abilities (Id, Name, Description, AbilityType, Damage, Distance)
VALUES
    (1, 'Shove', 'Power Shove', 'ShoveAbility', 10, 5);
SET IDENTITY_INSERT Abilities OFF;

-- Seed Weapons
SET IDENTITY_INSERT Items ON;
INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense)
VALUES
    (1, 'Iron Sword', 'A sturdy iron blade', 'Weapon', 15, NULL),
    (2, 'Elven Bow', 'A finely crafted bow', 'Weapon', 12, NULL),
    (3, 'Wizard Staff', 'A magical staff crackling with energy', 'Weapon', 20, NULL),
    (4, 'Battle Axe', 'A heavy dwarven axe', 'Weapon', 18, NULL),
    (5, 'Dagger', 'A small, sharp blade', 'Weapon', 8, NULL);

-- Seed Armor
INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense)
VALUES
    (6, 'Iron Plate Armor', 'Heavy iron protection', 'Armor', NULL, 10),
    (7, 'Leather Armor', 'Light and flexible', 'Armor', NULL, 5),
    (8, 'Wizard Robes', 'Enchanted robes', 'Armor', NULL, 7),
    (9, 'Dwarven Mail', 'Sturdy chainmail', 'Armor', NULL, 12),
    (10, 'Cloth Tunic', 'Basic cloth protection', 'Armor', NULL, 3);
SET IDENTITY_INSERT Items OFF;

-- Seed Equipment
SET IDENTITY_INSERT Equipments ON;
INSERT INTO Equipments (Id, WeaponId, ArmorId)
VALUES
    (1, 1, 6),  -- Sir Lancelot: Iron Sword + Iron Plate
    (2, 1, 6),  -- Aragorn: Iron Sword + Iron Plate
    (3, 2, 7),  -- Legolas: Elven Bow + Leather Armor
    (4, 3, 8),  -- Gandalf: Wizard Staff + Wizard Robes
    (5, 4, 9),  -- Gimli: Battle Axe + Dwarven Mail
    (6, 5, 10), -- Frodo: Dagger + Cloth Tunic
    (7, 5, 7),  -- Sam: Dagger + Leather Armor
    (8, 1, 6);  -- Boromir: Iron Sword + Iron Plate
SET IDENTITY_INSERT Equipments OFF;

-- Link equipment to players
UPDATE Players SET EquipmentId = 1 WHERE Id = 1;
UPDATE Players SET EquipmentId = 2 WHERE Id = 2;
UPDATE Players SET EquipmentId = 3 WHERE Id = 3;
UPDATE Players SET EquipmentId = 4 WHERE Id = 4;
UPDATE Players SET EquipmentId = 5 WHERE Id = 5;
UPDATE Players SET EquipmentId = 6 WHERE Id = 6;
UPDATE Players SET EquipmentId = 7 WHERE Id = 7;
UPDATE Players SET EquipmentId = 8 WHERE Id = 8;
