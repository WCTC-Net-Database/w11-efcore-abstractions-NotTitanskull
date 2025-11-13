using ConsoleRpgEntities.Models.Equipment;
using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Data
{
    public static class SeedData
    {
        public static void Initialize(GameContext context)
        {
            // Check if Items already exist
            if (context.Items.Any())
            {
                return; // DB has been seeded
            }

            // Add Weapons
            var weapons = new[]
            {
                new Weapon { Name = "Short Sword", Description = "A basic sword for beginners.", Damage = 5 },
                new Weapon { Name = "Longsword", Description = "A sturdy sword for experienced fighters.", Damage = 8 },
                new Weapon { Name = "Battle Axe", Description = "A heavy axe that deals massive damage.", Damage = 10 },
                new Weapon { Name = "Greatsword", Description = "A two-handed sword for warriors.", Damage = 12 }
            };
            
            // Add Armor
            var armors = new[]
            {
                new Armor { Name = "Leather Armor", Description = "Basic protection made of leather.", Defense = 3 },
                new Armor { Name = "Chainmail", Description = "Metal rings provide good protection.", Defense = 5 },
                new Armor { Name = "Plate Armor", Description = "Heavy metal armor for maximum defense.", Defense = 8 }
            };

            context.Items.AddRange(weapons.Cast<Item>());
            context.Items.AddRange(armors.Cast<Item>());
            context.SaveChanges();

            // Create Equipment sets
            var equipment = new Equipment
            {
                WeaponId = weapons[0].Id, // Short Sword
                ArmorId = armors[0].Id    // Leather Armor
            };
            
            context.Equipment.Add(equipment);
            context.SaveChanges();

            // Assign equipment to existing player if one exists
            var player = context.Players.FirstOrDefault();
            if (player != null)
            {
                player.EquipmentId = equipment.Id;
                context.SaveChanges();
            }
        }
    }
}
