using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Modules
{
    public class GameConsole
    {
        static int linesCount;
        private readonly int PADDING_LEFT = Board.BOARD_WIDTH;

        public GameConsole() => Reset();

        public void ConsolePrint(string data)
        {
            Console.SetCursorPosition(PADDING_LEFT, linesCount);
            Console.WriteLine(data);
            linesCount++;
        }

        internal void Reset() => linesCount = 0;
    }
}
