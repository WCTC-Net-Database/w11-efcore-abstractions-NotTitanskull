-- Seed basic weapon and armor
SET IDENTITY_INSERT Items ON;
INSERT INTO Items (Id, Name, Description, ItemType, Damage, Defense)
VALUES
    (1, 'Iron Sword', 'A sturdy iron blade', 'Weapon', 15, NULL),
    (2, 'Iron Plate Armor', 'Heavy iron protection', 'Armor', NULL, 10);
SET IDENTITY_INSERT Items OFF;

-- Seed equipment
SET IDENTITY_INSERT Equipments ON;
INSERT INTO Equipments (Id, WeaponId, ArmorId)
VALUES
    (1, 1, 2);
SET IDENTITY_INSERT Equipments OFF;

-- Link equipment to player
UPDATE Players SET EquipmentId = 1 WHERE Id = 1;