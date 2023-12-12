using System;

namespace PostMachine
{
    public class Operation
    {
        /*
        0 - <--
        1 - -->
        2 - V
        3 - X
        4 - ?
        5 - !
        */
        private int? index;
        private int? commandId;
        private int? link;
        private int? link2;

        public Operation(int inputIndex, int inputCommandId, int inputLink)
        {
            index = inputIndex;
            commandId = inputCommandId;
            link = inputLink;
        }

        public Operation(int inputIndex, int inputCommandId, int inputLink, int inputLink2)
        {
            index = inputIndex;
            commandId = inputCommandId;
            link = inputLink;
            link2 = inputLink2;
        }

        public string GetOperationIcon()
        {
            if (commandId == 0)
                return "←";
            if (commandId == 1)
                return "→";
            if (commandId == 2)
                return "V";
            if (commandId == 3)
                return "X";
            if (commandId == 4)
                return "?";
            if (commandId == 5)
                return "!";

            return "";
        }

        public int GetOperationId()
        {
            return commandId ?? 0;
        }

        public int GetLink()
        {
            return link ?? 0;
        }

        public int GetLink2()
        {
            return link2 ?? 0;
        }
    }
}
