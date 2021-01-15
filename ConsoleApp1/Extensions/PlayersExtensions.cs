using ConsoleApp1.Model;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Extensions
{
    public static class PlayersExtensions
    {
        public static Player GetPlayer(this List<Player> players,  int number)
        {
            return players.First(p => p.Number == number);
        }
    }
}
