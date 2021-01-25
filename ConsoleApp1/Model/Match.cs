using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Model
{
    [DebuggerDisplay("{FirstPlayer} vs {SecondPlayer}")]
    public class Match
    {
        public Match(Player firstPlayer, Player secondPlayer) => (FirstPlayer, SecondPlayer) = (firstPlayer, secondPlayer);

        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }

        public List<Player> Players { get => new List<Player>() { FirstPlayer, SecondPlayer }; } 

        public override string ToString()
        {
            return string.Format($"{FirstPlayer} vs {SecondPlayer}");
        }
    }

    public static class MatchExtensions
    {
        public static bool IsOk(this Match[] matches, int[] matchNumbers, int numberOfCourts)
        {
           var playersInPreviousTimeSlot = new List<Player>();
            for (int i = 0; i < matchNumbers.Length;)
            {
                int toArrayNumber;
                if (i + numberOfCourts >= matchNumbers.Length)
                {
                    toArrayNumber = matchNumbers.Length;
                }
                else
                {
                    toArrayNumber = i + numberOfCourts;
                }
                var matchNumbersAtSameTime = matchNumbers[i..toArrayNumber];
                var matchesAtSameTime = matchNumbersAtSameTime.Select((m) => matches.ElementAt(m)).ToArray();

                var playersInOneTimeSlot = matchesAtSameTime.SelectMany(m => m.Players).ToArray();
                var duplicates = playersInOneTimeSlot.Where(p => p != null).GroupBy(p => p).SelectMany(g => g.Skip(1));
                if(duplicates.Any())
                {
                    return false;
                }

                if(playersInPreviousTimeSlot.Any())
                {
                    var playersWithoutBreak = playersInPreviousTimeSlot.Any(pp => playersInOneTimeSlot.Contains(pp));
                    if (playersWithoutBreak)
                    {
                        return false;
                    }
                }

                playersInPreviousTimeSlot = playersInOneTimeSlot.ToList();

                i = toArrayNumber;
            }

            return true;
        }
    }
}
