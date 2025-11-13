﻿using ConsoleRpg.Services;
using ConsoleRpgEntities.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleRpg;

public static class Program
{
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        Startup.ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Seed the database
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<GameContext>();
            SeedData.Initialize(context);
        }

        var gameEngine = serviceProvider.GetService<GameEngine>();
        gameEngine?.Run();
    }
}

