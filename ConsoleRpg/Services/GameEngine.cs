using ConsoleRpg.Helpers;
using ConsoleRpgEntities.Data;
using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Characters.Monsters;


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
        if (_goblin is ITargetable targetableGoblin)
        {
            _player.Attack(targetableGoblin);
            var ability = _player.Abilities?.FirstOrDefault();
            if (ability != null)
            {
                _player.UseAbility(ability, targetableGoblin);
            }
            else
            {
                _outputManager.WriteLine("No ability available to use.", ConsoleColor.Yellow);
            }
        }
        
    }

    private void SetupGame()
    {
        _player = _context.Players.OfType<Player>().FirstOrDefault();
        if (_player == null)
        {
            _outputManager.WriteLine("No player found. Seed data before running.", ConsoleColor.Red);
            _outputManager.Display();
            Environment.Exit(1);
        }

        _outputManager.WriteLine($"{_player.Name} has entered the game.", ConsoleColor.Green);

        // Ensure abilities collection is initialized
        if (_player.Abilities == null || !_player.Abilities.Any())
        {
            _player.Abilities = new List<Ability>(); // Or load defaults here
            _outputManager.WriteLine("Player has no abilities loaded.", ConsoleColor.Yellow);
        }

        LoadMonsters();
        Thread.Sleep(500);
        GameLoop();
    }

    private void LoadMonsters()
    {
        _goblin = _context.Monsters.OfType<Goblin>().FirstOrDefault();
    } 
}