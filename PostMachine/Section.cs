using System;

namespace PostMachine
{
    public class Section
    {
        private int? index;
        private bool checkedState;

        public Section(int inputIndex)
        {
            index = inputIndex;
            checkedState = false;
        }

        public void Check()
        {
            checkedState = !checkedState;
        }

        public void SetCheck()
        {
            checkedState = true;
        }

        public void SetUncheck()
        {
            checkedState = false;
        }

        public bool GetChecked()
        {
            return checkedState;
        }

        public int GetIndex()
        {
            return index ?? 0;
        }
    }
}
