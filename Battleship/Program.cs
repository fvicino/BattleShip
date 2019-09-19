using Battleship;
using Battleship.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create service collection and register services
            var serviceProvider = InitialiseServiceCollection();

            //Start the game
            Console.WriteLine("Welcome to Battleship!\n");

            //
            //Execute a simple demonstration of ship state management
            //
            Console.WriteLine("This is a simple attack simulation to demonstrate ship state management\n");
            //Define ship locations for Blue/Red team

            //Create the blue team
            //
            var blueCommand = serviceProvider.GetService<ICommandCentre>();
            blueCommand.Team = Color.Blue;

            Console.WriteLine("Blue team has added ships at point (5,5) and at (0,0)\n");
            blueCommand.AddShip(3, new Point(5,5), Direction.North);
            blueCommand.AddShip(6, new Point(0, 0), Direction.West);

            
            //Create the red team
            //
            var redCommand = serviceProvider.GetService<ICommandCentre>();
            redCommand.Team = Color.Red;

            //attack on ship 1
            Console.WriteLine("Red attacks ship 1 at points (5,5),(5,6),(5,7),(5,8)");
            redCommand.AttackLocation(new Point(5, 5));
            redCommand.AttackLocation(new Point(5, 6));
            redCommand.AttackLocation(new Point(5, 7));
            redCommand.AttackLocation(new Point(5, 8));
            
            //attack on ship 2
            Console.WriteLine("\nRed attacks on ship 2 at points (1,0),(0,0),(0,1),(0,2),(0,3),(0,4),(0,5)");
            redCommand.AttackLocation(new Point(1, 0));
            redCommand.AttackLocation(new Point(0, 0));
            redCommand.AttackLocation(new Point(0, 1));
            redCommand.AttackLocation(new Point(0, 2));
            redCommand.AttackLocation(new Point(0, 3));
            redCommand.AttackLocation(new Point(0, 4));
            redCommand.AttackLocation(new Point(0, 5));

            Console.WriteLine("press q to quit ...");

            //Wait for user input
            bool exit = false;
            while (true) {
                switch (Console.ReadKey().Key) {
                    case ConsoleKey.Q:
                        exit = true;
                        break;
                }
                if (exit) break;
            }

        }

        static IServiceProvider InitialiseServiceCollection() {

            //register services
            var collection = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IBattleTheatre, BattleTheatre>()
                .AddSingleton<IRadio,Radio>()
                .AddSingleton<IShipyard,Shipyard>()
                .AddTransient<IShip, Ship>()
                .AddTransient<ICommandCentre,CommandCentre>();

            //return a service provider
            return collection.BuildServiceProvider();
        }
    }
}
