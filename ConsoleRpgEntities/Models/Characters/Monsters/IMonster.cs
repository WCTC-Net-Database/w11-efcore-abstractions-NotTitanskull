using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters.Monsters;

public interface IMonster
{
    int Id { get; set; }
    string Name { get; set; }
    int Health { get; set; }
    int AttackPower => AggressionLevel; // Default implementation
    int AggressionLevel { get; set; }


    void Attack(ITargetable target);
}