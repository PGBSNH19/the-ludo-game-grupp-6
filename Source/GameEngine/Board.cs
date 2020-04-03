﻿using GameEngine.Modules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine
{
    public class Board
    {
        public List<Piece> Pieces { get; set; }

        public OuterPath OuterPath { get; set; }
        public RedInnerPath RedPath { get; set; }
        public BlueInnerPath BluePath { get; set; }
        public GreenInnerPath GreenPath { get; set; }
        public YellowInnerPath YellowPath { get; set; }
        public List<Player> Players { get; set; }

        private readonly int PADDING_LEFT = 5;
        private readonly int PADDING_TOP = 2;

        public Board()
        {
            Pieces = new List<Piece>();
        }

        public void Build(List<Player> players)
        {
            OuterPath = (OuterPath)new OuterPath().Build();
            RedPath = (RedInnerPath)new RedInnerPath().Build();
            BluePath = (BlueInnerPath)new BlueInnerPath().Build();
            GreenPath = (GreenInnerPath)new GreenInnerPath().Build();
            YellowPath = (YellowInnerPath)new YellowInnerPath().Build();

            players.ForEach(p => {
                if (p.GetType().ToString() == "GameEngine.BluePlayer")
                {
                    p.InnerPath = BluePath;
                }
            });
        }

        public void Draw() 
        {
            DrawPath(OuterPath);
            DrawPath(RedPath);
            DrawPath(BluePath);
            DrawPath(GreenPath);
            DrawPath(YellowPath);
            Pieces.Where(p => p.InPlay).ToList().ForEach(p =>
            {
                Console.ForegroundColor = p.Player.GetColor();
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(p.X + PADDING_LEFT, p.Y + PADDING_TOP);
                Console.WriteLine(p.Visual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            });
        }

        private void DrawPath(Path pathObj)
        {
            pathObj.Tiles.ForEach(t =>
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = t.BackgroundColor;
                Console.SetCursorPosition(t.X + PADDING_LEFT, t.Y + PADDING_TOP);
                Console.WriteLine(t.Visual);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            });
        }

        public void MovePiece(Player player, int steps, GameConsole gc)
        {
            var piece = Pieces.Where(p => p.Player == player).FirstOrDefault();

            if(piece.Steps > 49)
            {
                var path = player.GetColor();
            }

            else if(piece.Steps + steps > 49)
            {

            }

            else
            {
                var path = OuterPath.Tiles;
                var currentTile = path.First(t => t.Equals(piece));

                var desiredLocationIndex = path.IndexOf(currentTile) + steps;

                if (desiredLocationIndex >= path.Count)
                    desiredLocationIndex -= path.Count;

                piece.Move(path[desiredLocationIndex].X, path[desiredLocationIndex].Y, steps);
                gc.ConsolePrint(" ");
                gc.ConsolePrint("Total of " + piece.Steps + " steps");
            }
        }

        public void PlacePiece(Player activePlayer)
        {
            var piece = Pieces
               .Where(p => p.Player == activePlayer && !p.InPlay)
               .First();
            piece.Move(activePlayer.StartX, activePlayer.StartY);
        }
    }
}
