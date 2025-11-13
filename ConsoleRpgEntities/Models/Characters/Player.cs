using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        
        public int? EquipmentId { get; set; }
        
        public virtual IEnumerable<Ability> Abilities { get; set; } = new List<Ability>();
        public virtual ConsoleRpgEntities.Models.Equipment.Equipment Equipment { get; set; }
        
        public int GetAttackPower() => Equipment?.Weapon?.Damage ?? 1;
        public void Attack(ITargetable target)
        {
            // Player-specific attack logic
            var weaponPower = GetAttackPower();
            Console.WriteLine($"{Name} attacks {target.Name} (AttackPower: {weaponPower})");
        }
        
        public virtual void TakeDamage(int amount)
        {
            var reduction = Equipment?.Armor?.Defense ?? 0;
            var net = Math.Max(0, amount - reduction);
            Health -= net;
            Console.WriteLine($"{Name} takes {net} damage (reduced by {reduction}). Health is now {Health}.");
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
