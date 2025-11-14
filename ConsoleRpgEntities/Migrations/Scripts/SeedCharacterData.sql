-- First, seed Weapons (Items table with Weapon discriminator)
INSERT INTO Items (Name, Description, ItemType, Damage)
VALUES
    ('Iron Sword', 'A sturdy iron blade', 'Weapon', 15),
    ('Elven Bow', 'A finely crafted bow', 'Weapon', 12),
    ('Wizard Staff', 'A magical staff crackling with energy', 'Weapon', 20),
    ('Battle Axe', 'A heavy dwarven axe', 'Weapon', 18),
    ('Dagger', 'A small, sharp blade', 'Weapon', 8);

-- Seed Armor (Items table with Armor discriminator)
INSERT INTO Items (Name, Description, ItemType, Defense)
VALUES
    ('Iron Plate Armor', 'Heavy iron protection', 'Armor', 10),
    ('Leather Armor', 'Light and flexible', 'Armor', 5),
    ('Wizard Robes', 'Enchanted robes', 'Armor', 7),
    ('Dwarven Mail', 'Sturdy chainmail', 'Armor', 12),
    ('Cloth Tunic', 'Basic cloth protection', 'Armor', 3);

-- Seed Equipment (linking Weapons and Armor)
INSERT INTO Equipments (WeaponId, ArmorId)
VALUES
    (1, 1),  -- Iron Sword + Iron Plate
    (2, 2),  -- Elven Bow + Leather Armor
    (3, 3),  -- Wizard Staff + Wizard Robes
    (4, 4),  -- Battle Axe + Dwarven Mail
    (5, 5);  -- Dagger + Cloth Tunic

-- Finally, seed Players
INSERT INTO Players (Name, Health, Experience, EquipmentId)
VALUES
    ('Aragorn', 100, 150, 1),
    ('Legolas', 80, 120, 2),
    ('Gandalf', 90, 500, 3),
    ('Gimli', 110, 200, 4),
    ('Frodo', 60, 50, 5),
    ('Sam', 70, 45, NULL),
    ('Boromir', 95, 180, NULL);
