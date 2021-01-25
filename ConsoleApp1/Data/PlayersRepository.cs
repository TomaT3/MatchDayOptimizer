using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Data
{
    public class PlayersRepository
    {
        public PlayersRepository()
        {
            Players = new List<Player>()
            {
                { new Player() { Name= "Player 1", Number=1} },
                { new Player() { Name= "Player 2", Number=2} },
                { new Player() { Name= "Player 3", Number=3} },
                { new Player() { Name= "Player 4", Number=4} },
                { new Player() { Name= "Player 5", Number=5} },
                { new Player() { Name= "Player 6", Number=6} },
                { new Player() { Name= "Player 7", Number=7} },
                { new Player() { Name= "Player 8", Number=8} },
                { new Player() { Name= "Player 9", Number=9} },
                { new Player() { Name= "Player 10", Number=10} },
                { new Player() { Name= "Player 11", Number=11} },
                { new Player() { Name= "Player 12", Number=12} },
                { new Player() { Name= "Player 13", Number=13} },
                { new Player() { Name= "Player 14", Number=14} },
                { new Player() { Name= "Player 15", Number=15} },
                { new Player() { Name= "Player 16", Number=16} },
                { new Player() { Name= "Player 17", Number=17} },
                { new Player() { Name= "Player 18", Number=18} },
                { new Player() { Name= "Player 19", Number=19} },
                { new Player() { Name= "Player 20", Number=20} },
                { new Player() { Name= "Player 21", Number=21} },
                { new Player() { Name= "Player 22", Number=22} },
                { new Player() { Name= "Player 23", Number=23} },
                { new Player() { Name= "Player 24", Number=24} },
                { new Player() { Name= "Player 25", Number=25} },
                { new Player() { Name= "Player 26", Number=26} },
                { new Player() { Name= "Player 27", Number=27} },
                { new Player() { Name= "Player 28", Number=28} },
                { new Player() { Name= "Player 29", Number=29} },
                { new Player() { Name= "Player 30", Number=30} },
                { new Player() { Name= "Player 31", Number=31} },
                { new Player() { Name= "Player 31", Number=31} },
                { new Player() { Name= "Player 32", Number=32} },
                { new Player() { Name= "Player 33", Number=33} },
                { new Player() { Name= "Player 34", Number=34} },
                { new Player() { Name= "Player 35", Number=35} },
                { new Player() { Name= "Player 36", Number=36} },
                { new Player() { Name= "Player 37", Number=37} },
                { new Player() { Name= "Player 38", Number=38} },
                { new Player() { Name= "Player 39", Number=39} },
                { new Player() { Name= "Player 40", Number=40} },

            };
        }

        public List<Player> Players { get; internal set; }
    }
}
