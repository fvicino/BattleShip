using Battleship.Abstraction;
using Battleship.Implementation;
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
                .AddSingleton<IShipyard>()
                .AddSingleton<IRadio>()
                .AddTransient<CommandCentre>()
                .AddSingleton<IShip>();

            //return a service provider
            return collection.BuildServiceProvider();
        }
    }
}
