using System;
using System.IO;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.Handlers;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ToyRobotSimulator
{
  

   
  

   

   

   

 
    
  
    

  

  

  
  


 

 

  

  


    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var settings = config.GetSection("TableSettings").Get<TableSettings>();
            var robot = new Robot();
            var services = new ServiceCollection();

            services.AddSingleton(settings);
            services.AddSingleton(robot);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
            services.AddTransient<IRequestHandler<PlaceCommand, Unit>, PlaceCommandHandler>();
            services.AddTransient<IRequestHandler<MoveCommand, Unit>, MoveCommandHandler>();
            services.AddTransient<IRequestHandler<LeftCommand, Unit>, LeftCommandHandler>();
            services.AddTransient<IRequestHandler<RightCommand, Unit>, RightCommandHandler>();
            services.AddTransient<IRequestHandler<ReportCommand, Unit>, ReportCommandHandler>();
            services.AddLogging(configure => configure.AddConsole());
            services.AddValidatorsFromAssemblyContaining<Program>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

       

            var provider = services.BuildServiceProvider();
            var mediator = provider.GetRequiredService<IMediator>();

            Console.WriteLine("Enter commands (type END to finish or type FILE <filename>):");
            while (true)
            {
                var input = Console.ReadLine();
                if (string.Equals(input?.Trim(), "END", StringComparison.OrdinalIgnoreCase)) break;

                if (input?.Trim().StartsWith("FILE", StringComparison.OrdinalIgnoreCase) == true)
                {
                    var parts = input.Split(' ', 2);
                    if (parts.Length == 2 && File.Exists(parts[1]))
                    {
                        foreach (var line in File.ReadAllLines(parts[1]))
                        {
                            await ProcessCommand(line, mediator);
                        }
                    }
                    else Console.WriteLine("Invalid FILE command or file not found.");
                }
                else if  (input?.Trim().ToUpper() == "TESTDATA")
                    {
                        var testLines = new[]
                        {
                        "PLACE 0,0,NORTH",
                        "MOVE",
                        "REPORT",
                        "PLACE 1,2,EAST",
                        "MOVE",
                        "MOVE",
                        "LEFT",
                        "MOVE",
                        "REPORT"
                       };
                        foreach (var line in testLines)
                            await ProcessCommand(line, mediator);
                    }
                else
                {
                    await ProcessCommand(input, mediator);
                }
            }
        }

        private static async Task ProcessCommand(string input, IMediator mediator)
        {
            var command = CommandParser.Parse(input);
            if (command != null)
            {
                await mediator.Send(command);
            }
        }
    }
}
