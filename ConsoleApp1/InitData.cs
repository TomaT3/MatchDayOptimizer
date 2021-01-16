using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Extensions;

namespace ConsoleApp1
{
    public class InitData
    {
        public static List<Match> GetPossibleMatches(List<Player> allPlayers)
        {
            return new List<Match>()
            {
                new Match(allPlayers.GetPlayer(1), allPlayers.GetPlayer(2)),
                new Match(allPlayers.GetPlayer(1), allPlayers.GetPlayer(3)),
                new Match(allPlayers.GetPlayer(2), allPlayers.GetPlayer(4)),
                new Match(allPlayers.GetPlayer(3), allPlayers.GetPlayer(5)),
                new Match(allPlayers.GetPlayer(4), allPlayers.GetPlayer(6)),
                new Match(allPlayers.GetPlayer(5), allPlayers.GetPlayer(7)),
                new Match(allPlayers.GetPlayer(6), allPlayers.GetPlayer(8)),
                new Match(allPlayers.GetPlayer(7), allPlayers.GetPlayer(9)),
                new Match(allPlayers.GetPlayer(8), allPlayers.GetPlayer(9)),
            };
        }


        public static List<TimeSlot> GetTimeSlots()
        {
            return new List<TimeSlot>()
            {
                new TimeSlot() { Number = 1 },
                new TimeSlot() { Number = 2 },
                new TimeSlot() { Number = 3 },
                new TimeSlot() { Number = 4 },
                new TimeSlot() { Number = 5 },
                new TimeSlot() { Number = 6 },
                new TimeSlot() { Number = 7 },
                new TimeSlot() { Number = 8 },
                new TimeSlot() { Number = 9 },
                new TimeSlot() { Number = 10 },
                new TimeSlot() { Number = 11 },
                //new TimeSlot() { Number = 12 },
                //new TimeSlot() { Number = 13 },
            };
        }
    }
}
