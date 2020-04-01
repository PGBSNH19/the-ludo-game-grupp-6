using GameEngine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLudoGame
{
    class LudoContext: DbContext

    {
       
        public DbSet<BoardSquare> BoardSquares { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
       
    }
}
