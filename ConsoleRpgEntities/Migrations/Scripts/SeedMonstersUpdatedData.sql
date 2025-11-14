-- Seed Monsters with AttackPower
INSERT INTO Monsters (Name, Health, AggressionLevel, MonsterType, AttackPower)
VALUES
    ('Goblin Scout', 30, 4, 'Goblin', 5),
    ('Goblin Raider', 40, 6, 'Goblin', 8),
    ('Orc Grunt', 55, 7, 'Orc', 10),
    ('Orc Berserker', 70, 9, 'Orc', 15),
    ('Forest Wolf', 25, 5, 'Beast', 7),
    ('Dire Wolf', 45, 8, 'Beast', 12),
    ('Cave Troll', 120, 6, 'Troll', 18),
    ('Skeleton Warrior', 35, 5, 'Undead', 6),
    ('Skeleton Archer', 28, 5, 'Undead', 8),
    ('Wraith', 60, 8, 'Undead', 11),
    ('Bandit Thief', 38, 6, 'Human', 7),
    ('Bandit Leader', 65, 7, 'Human', 10),
    ('Giant Spider', 50, 7, 'Beast', 9),
    ('Lava Imp', 42, 7, 'Elemental', 10),
    ('Fire Drake', 150, 10, 'Dragonkin', 25);
