using System;

namespace CommandManager
{
   public class InvalidCommandParameterException : Exception
   {
      public InvalidCommandParameterException(string message) : base(message)
      {
      }

      public InvalidCommandParameterException(string message, Exception innerException) : base(message, innerException)
      {
      }
   }
}
