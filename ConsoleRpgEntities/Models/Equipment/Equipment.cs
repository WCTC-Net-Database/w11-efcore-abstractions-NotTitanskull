namespace ConsoleRpgEntities.Models.Equipment;

public class Equipment
{
    public int Id { get; set; }
    
    public virtual Weapon? Weapon { get; set; }
    public virtual Armor? Armor { get; set; }

    override public string ToString()
    {
        return$"Equipment(Id={Id}, Weapon={Weapon}, Armor={Armor})";
    }
    
    public void EquipWeapon(Weapon weapon)
    {

        Weapon = weapon;
    }

    public void EquipArmor(Armor armor)
    {
        Armor = armor;
    }
}