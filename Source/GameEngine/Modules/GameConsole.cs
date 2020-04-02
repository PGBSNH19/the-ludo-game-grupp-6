using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Modules
{
    public class GameConsole
    {
        private int linesCount;

        private readonly int CONSOLE_CAPACITY = 10;
        private readonly int PADDING_LEFT = 30;

        public GameConsole() => Reset();

        public void ConsolePrint(string data)
        {
            FloodControl();
            Console.SetCursorPosition(PADDING_LEFT, linesCount);
            Console.WriteLine(data);
            linesCount++;
        }

        private void FloodControl()
        {
            if(linesCount > CONSOLE_CAPACITY - 1)
            {
                Console.Clear();
                Reset();
            }
        }

        internal void Reset() => linesCount = 0;
    }
}
