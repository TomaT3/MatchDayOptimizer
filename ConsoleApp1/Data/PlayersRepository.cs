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
                { new Player() { Name= "Paul", Number=1} },
                { new Player() { Name= "Anton", Number=2} },
                { new Player() { Name= "Leo", Number=3} },
                { new Player() { Name= "Klaus", Number=4} },
                { new Player() { Name= "Kopp", Number=5} },

                { new Player() { Name= "Name1", Number=6} },
                { new Player() { Name= "Name2", Number=7} },
                { new Player() { Name= "Name3", Number=8} },
                { new Player() { Name= "Name4", Number=9} },
            };
        }

        public List<Player> Players { get; internal set; }
    }
}
