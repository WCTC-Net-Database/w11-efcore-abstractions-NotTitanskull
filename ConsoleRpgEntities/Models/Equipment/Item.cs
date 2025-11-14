using ConsoleRpgEntities.Models.Characters;

namespace ConsoleRpgEntities.Models.Equipment;

public abstract class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public override string ToString() => $"{Name} (Id: {Id}): {Description}";
}
