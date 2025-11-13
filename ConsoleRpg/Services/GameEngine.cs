﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using ConsoleRpg.Helpers;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;
using ConsoleRpgEntities.Models.Attributes;
using Microsoft.EntityFrameworkCore;

namespace ConsoleRpg.Services;

public class GameEngine
{
    private readonly GameContext _context;
    private readonly MenuManager _menuManager;
    private readonly OutputManager _outputManager;

    private IPlayer _player;
    private IMonster _goblin;

    public GameEngine(GameContext context, MenuManager menuManager, OutputManager outputManager)
    {
        _menuManager = menuManager;
        _outputManager = outputManager;
        _context = context;
    }

    public void Run()
    {
        if (_menuManager.ShowMainMenu())
        {
            SetupGame();
        }
    }

    private void GameLoop()
    {
        _outputManager.Clear();

        while (true)
        {
            _outputManager.WriteLine("Choose an action:", ConsoleColor.Cyan);
            _outputManager.WriteLine("1. Attack");
            _outputManager.WriteLine("2. Quit");

            _outputManager.Display();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AttackCharacter();
                    break;
                case "2":
                    _outputManager.WriteLine("Exiting game...", ConsoleColor.Red);
                    _outputManager.Display();
                    Environment.Exit(0);
                    break;
                default:
                    _outputManager.WriteLine("Invalid selection. Please choose 1.", ConsoleColor.Red);
                    break;
            }
        }
    }

    private void AttackCharacter()
    {
        if (_player == null || _goblin == null) return;

        // prefer ITargetable for name access (if available)
        var targetableGoblin = _goblin as object;
        string goblinName = GetStringMemberValueFallback(_goblin, new[] { "Name" }) ?? "Monster";
        string playerName = GetStringMemberValueFallback(_player, new[] { "Name" }) ?? "Player";

        // Determine player's attack power (prefer concrete method)
        int playerAttack = 1;
        if (_player is ConsoleRpgEntities.Models.Characters.Player concretePlayer)
        {
            playerAttack = concretePlayer.GetAttackPower();
        }
        else
        {
            playerAttack = GetAttackPowerFallback(_player) ?? 1;
        }

        // Apply damage to goblin via reflection-safe helper
        bool appliedToGoblin = InvokeTakeDamage(_goblin, playerAttack);
        _outputManager.WriteLine($"{playerName} deals {playerAttack} damage to {goblinName}.", ConsoleColor.Green);

        // Use first ability if present
        var ability = _player?.Abilities?.FirstOrDefault();
        if (ability != null)
        {
            _player.UseAbility(ability, _goblin as ConsoleRpgEntities.Models.Attributes.ITargetable ?? null);
        }

        // Goblin retaliation if still alive
        int goblinHealth = GetHealthFallback(_goblin) ?? 0;
        if (goblinHealth > 0)
        {
            int goblinAttack = GetAttackPowerFallback(_goblin) ?? 1;

            // Determine player's armor defense (prefer concrete Player)
            int defense = 0;
            if (_player is ConsoleRpgEntities.Models.Characters.Player p)
            {
                defense = p.Equipment?.Armor?.Defense ?? 0;
            }
            else
            {
                defense = GetIntMemberValueFallback(_player, new[] { "ArmorDefense", "Defense" }) ?? 0;
            }

            int netDamage = Math.Max(0, goblinAttack - defense);

            // Apply damage to player via reflection-safe helper
            bool appliedToPlayer = InvokeTakeDamage(_player, netDamage);
            _outputManager.WriteLine($"{goblinName} retaliates for {netDamage} damage (reduced by {defense}).", ConsoleColor.Red);
        }
        else
        {
            _outputManager.WriteLine($"{goblinName} has been defeated.", ConsoleColor.Yellow);
        }
    }

    private void SetupGame()
    {
        _player = _context.Players
            .Include(p => p.Equipment)
            .ThenInclude(e => e.Weapon)
            .Include(p => p.Equipment)
            .ThenInclude(e => e.Armor)
            .OfType<Player>()
            .FirstOrDefault();
            
        _outputManager.WriteLine($"{_player?.Name ?? "Player"} has entered the game.", ConsoleColor.Green);
        
        // Display equipment info
        if (_player is ConsoleRpgEntities.Models.Characters.Player concretePlayer && concretePlayer.Equipment != null)
        {
            var weapon = concretePlayer.Equipment.Weapon;
            var armor = concretePlayer.Equipment.Armor;
            
            _outputManager.WriteLine($"Equipped with: {weapon?.Name ?? "No weapon"} (Attack: {weapon?.Damage ?? 0}), {armor?.Name ?? "No armor"} (Defense: {armor?.Defense ?? 0})", ConsoleColor.Cyan);
        }

        LoadMonsters();

        Thread.Sleep(500);
        GameLoop();
    }

    private void LoadMonsters()
    {
        _goblin = _context.Monsters.OfType<Goblin>().FirstOrDefault();
    }

    // Reflection-safe invoker for TakeDamage
    private bool InvokeTakeDamage(object target, int amount)
    {
        if (target == null) return false;

        var type = target.GetType();
        var method = type.GetMethod("TakeDamage", BindingFlags.Public | BindingFlags.Instance);
        if (method != null)
        {
            method.Invoke(target, new object[] { amount });
            return true;
        }

        // Fallback: try to find an interface-declared method (unlikely if interface doesn't declare it)
        foreach (var iface in type.GetInterfaces())
        {
            var ifaceMethod = iface.GetMethod("TakeDamage");
            if (ifaceMethod != null)
            {
                method = type.GetInterfaceMap(iface).TargetMethods
                    .FirstOrDefault(m => m.Name == ifaceMethod.Name);
                if (method != null)
                {
                    method.Invoke(target, new object[] { amount });
                    return true;
                }
            }
        }

        return false;
    }

    // Reflection helpers to support flexible shapes
    private int? GetAttackPowerFallback(object obj)
    {
        if (obj == null) return null;
        var m = obj.GetType().GetMethod("GetAttackPower", BindingFlags.Public | BindingFlags.Instance);
        if (m != null && m.ReturnType == typeof(int))
        {
            return (int?)m.Invoke(obj, null);
        }

        return GetIntMemberValueFallback(obj, new[] { "AttackPower", "Damage", "AggressionLevel" });
    }

    private int? GetHealthFallback(object obj)
    {
        return GetIntMemberValueFallback(obj, new[] { "Health", "Hp" });
    }

    private string GetStringMemberValueFallback(object obj, string[] candidateNames)
    {
        if (obj == null) return null;
        var t = obj.GetType();

        foreach (var name in candidateNames)
        {
            var prop = t.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop != null && prop.PropertyType == typeof(string))
            {
                return prop.GetValue(obj) as string;
            }

            var field = t.GetField(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (field != null && field.FieldType == typeof(string))
            {
                return field.GetValue(obj) as string;
            }
        }

        return null;
    }

    private int? GetIntMemberValueFallback(object obj, string[] candidateNames)
    {
        if (obj == null) return null;
        var t = obj.GetType();

        foreach (var name in candidateNames)
        {
            var prop = t.GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (prop != null && (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?)))
            {
                var val = prop.GetValue(obj);
                if (val != null) return Convert.ToInt32(val);
            }

            var field = t.GetField(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (field != null && (field.FieldType == typeof(int) || field.FieldType == typeof(int?)))
            {
                var val = field.GetValue(obj);
                if (val != null) return Convert.ToInt32(val);
            }
        }

        return null;
    }
}
