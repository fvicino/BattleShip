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
            Console.WriteLine("Welcome to Battleship!");

            //Load a command centre
            var blueCommand = serviceProvider.GetService<ICommandCentre>();

            blueCommand.AddShip(3, new Point(5,5), Direction.North);

            blueCommand.AttackLocation(new Point(5, 5));


            //Define ship locations for Blue/Red team
            //bool exit = false;
            //while (true)
            //{
            //    switch (Console.ReadLine().ToLower())
            //    {
            //        case "q":
            //            exit = true;
            //            break;
            //    }
            //    if (exit) break;
            //}

            //Take turns
            bool exit = false;
            while (true) {
                switch (Console.ReadLine().ToLower()) {
                    case "q":
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
                .AddSingleton<IShip,Ship>()
                .AddSingleton<IShipyard,Shipyard>()
                .AddTransient<ICommandCentre,CommandCentre>();

            //return a service provider
            return collection.BuildServiceProvider();
        }
    }
}
