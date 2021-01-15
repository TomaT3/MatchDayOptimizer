using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.Model
{
    [DebuggerDisplay("{FirstPlayer} vs {SecondPlayer}")]
    public class Match
    {
        public Match(Player firstPlayer, Player secondPlayer) => (FirstPlayer, SecondPlayer) = (firstPlayer, secondPlayer);

        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }

        public override string ToString()
        {
            return string.Format($"{FirstPlayer} vs {SecondPlayer}");
        }
    }
}
