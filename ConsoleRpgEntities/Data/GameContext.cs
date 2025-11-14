using Microsoft.EntityFrameworkCore;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Equipment;
using ConsoleRpgEntities.Models.Characters.Monsters;

namespace ConsoleRpgEntities.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Monster> Monsters => Set<Monster>();
        public DbSet<Ability> Abilities => Set<Ability>();
        public DbSet<Equipment> Equipments => Set<Equipment>();
        public DbSet<Item> Items => Set<Item>();

        public GameContext(DbContextOptions<GameContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>()
                .HasDiscriminator<string>(m => m.MonsterType)
                .HasValue<Goblin>("Goblin");

            modelBuilder.Entity<Ability>()
                .HasDiscriminator<string>(a => a.AbilityType)
                .HasValue<ShoveAbility>("ShoveAbility");

            modelBuilder.Entity<Player>()
                .HasMany(p => p.Abilities)
                .WithMany(a => a.Players)
                .UsingEntity(j => j.ToTable("PlayerAbilities"));

            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>("ItemType")
                .HasValue<Weapon>("Weapon")
                .HasValue<Armor>("Armor");

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Equipment)
                .WithOne(e => e.Player)
                .HasForeignKey<Player>(p => p.EquipmentId);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Weapon)
                .WithMany()
                .HasForeignKey(e => e.WeaponId);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Armor)
                .WithMany()
                .HasForeignKey(e => e.ArmorId);
        }
    }
}