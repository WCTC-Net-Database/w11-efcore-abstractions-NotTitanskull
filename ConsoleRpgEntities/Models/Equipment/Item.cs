using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Equipment;

public abstract class Item
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public virtual List<Player> Players { get; set; }
    
    override public string ToString()
    {
        return $"{Name} (Id: {Id}): {Description}";
    }
}

public class Weapon : Item
{
    public int Damage { get; set; }
}

public class Armor : Item
{
    public int Defense { get; set; }
}