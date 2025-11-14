using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Equipment;

public class Equipment
{
    public int Id { get; set; }
    public int? WeaponId { get; set; }
    public virtual Weapon? Weapon { get; set; }
    public int? ArmorId { get; set; }
    public virtual Armor? Armor { get; set; }
    public virtual Characters.Player? Player { get; set; }
}