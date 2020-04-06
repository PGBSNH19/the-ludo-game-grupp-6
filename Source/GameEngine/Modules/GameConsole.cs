using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Modules
{
    public class GameConsole
    {
        private int linesCount = 0;

        private readonly int CONSOLE_CAPACITY = 20;

        private readonly int PADDING_LEFT = 30;
        private readonly int PADDING_TOP = 3;

        private readonly int WIDTH = 50;
        private readonly int HEIGHT = 21;

        public GameConsole() => Clear();

        public void ConsolePrint(Player player, string data)
        {
            if(linesCount > CONSOLE_CAPACITY - 1)
                Clear();

            Console.SetCursorPosition(PADDING_LEFT, linesCount + PADDING_TOP);
            Console.Write(player.Name + " [");
            Console.ForegroundColor = player.GetColor();
            Console.Write(player.PlayerType);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"] {data}");
            linesCount++;
        }

        public void DrawBorder()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int x = 0; x < WIDTH; x++)
            {
                Console.SetCursorPosition((PADDING_LEFT - 2) + x, 1);
                Console.Write(" ");
                Console.SetCursorPosition((PADDING_LEFT - 2) + x, HEIGHT + PADDING_TOP);
                Console.Write(" ");
            }
            for (int y = 0; y < HEIGHT + PADDING_TOP; y++)
            {
                Console.SetCursorPosition((PADDING_LEFT - 2), y + 1);
                Console.Write(" ");
                Console.SetCursorPosition((PADDING_LEFT - 2) + WIDTH, y + 1);
                Console.Write(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void Clear()
        {
            Console.Clear();
            DrawBorder();
            Reset();
        }

        internal void Reset() => linesCount = 0;
    }
}
