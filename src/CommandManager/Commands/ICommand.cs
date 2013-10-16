using System.Collections.Generic;

namespace CommandManager
{
   public interface ICommand
   {
      string CommandName { get; }
      string Description { get; }
      void Execute();
      void SetParameters(List<string> parameterList);
   }
}