using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    public interface IPlayer
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
    }
}
