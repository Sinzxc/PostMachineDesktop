using System;
using System.Collections.Generic;

namespace PostMachine
{
    public class Commands
    {
        private List<Operation> commandsList = new List<Operation>();

        public List<Operation> GetCommands()
        {
            return commandsList;
        }

        public void AddCommand(int inputOperationId, int inputLink)
        {
            commandsList.Add(new Operation(commandsList.Count, inputOperationId, inputLink));
        }

        public void AddCommand(int inputOperationId, int inputLink, int inputLink2)
        {
            commandsList.Add(new Operation(commandsList.Count, inputOperationId, inputLink, inputLink2));
        }

        public void RemoveLastCommand()
        {
            if (commandsList.Count > 0)
            {
                commandsList.RemoveAt(commandsList.Count - 1);
            }
        }
    }
}
