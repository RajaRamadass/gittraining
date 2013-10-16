using System.Collections.Generic;
using System.Linq;

namespace CommandManager
{
   public class CommandParser
   {

      private readonly IEnumerable<ICommand> availableCommands;

      public CommandParser(IEnumerable<ICommand> availableCommands)
      {
         this.availableCommands = availableCommands;
      }

      public ICommand ParseCommand(string[] args)
      {
         var requestedCommandName = args[0];

         var command = FindRequestedCommand(requestedCommandName);
         var parameters = new List<string>();
         for (var i = 1; i < args.Length; i++)
         {
            parameters.Add(args[i]);
         }
         command.SetParameters(parameters);
         return command;
      }

      private ICommand FindRequestedCommand(string commandName)
      {
         return availableCommands
            .FirstOrDefault(cmd => cmd.CommandName.ToLower() == commandName.ToLower());
      }
   }
}
