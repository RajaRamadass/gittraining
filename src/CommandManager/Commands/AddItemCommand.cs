using System;
using System.Collections.Generic;

namespace CommandManager
{
   public class AddItemCommand : ICommand
   {
      private List<string> parameterList;
      private static readonly log4net.ILog Log =
                                     log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      public AddItemCommand()
      {
      }

      public string CommandName { get { return "AddItem"; } }
      public string Description { get { return "AddItem Id Name Quantity Price"; } }

      public void Execute()
      {
         if (ValidateParameters())
         {
            Log.InfoFormat("About to add item");
            //TODO: add item logic goes here
         }
      }

      public void SetParameters(List<string> parameters)
      {
         parameterList = parameters;
      }

      public bool ValidateParameters()
      {
         if (parameterList.Count < 4)
         {
            throw new InvalidCommandParameterException("Invalid number of parameters. AddItemCommand requires 4 parameters.");
         }
         string id = parameterList[0];
         string name = parameterList[1];
         int qty ;
         var parsed = Int32.TryParse(parameterList[2], out qty);
         if (!parsed)
         {
            throw new InvalidCommandParameterException("Invalid value for  parameter Quantity.");
         }
         decimal price;
         parsed = decimal.TryParse(parameterList[3], out price);
         if (!parsed)
         {
            throw new InvalidCommandParameterException("Invalid value for  parameter Price.");
         }
         return true;
      }
   }
}
