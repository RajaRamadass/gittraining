using System;
using System.Collections.Generic;
using CommandManager;


namespace CommandConsole
{
   public class CommandExecutor
   {
      private static readonly log4net.ILog Log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      public static void Main(string[] args)
      {
         var availableCommands = GetAvailableCommands();
         if (args.Length == 0)
         {
            PrintUsage(availableCommands);
            return;
         }
         var parser = new CommandParser(GetAvailableCommands());
         var command = parser.ParseCommand(args);
         Log.InfoFormat("About to execute the command {0}", command.CommandName);
         command.Execute();
      }
      private static IEnumerable<ICommand> GetAvailableCommands()
      {
         return new ICommand[]
         {
            new AddItemCommand(),
         };
      }

      private static void PrintUsage(IEnumerable<ICommand> availableCommands)
      {
         Log.InfoFormat("Usage: CommandExecutor CommandName Arguments");
         Console.WriteLine("Commands:");
         foreach (var command in availableCommands)
            Console.WriteLine("  {0}", command.Description);
      }
   }
}
