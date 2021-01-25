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
                new Match(allPlayers.GetPlayer(8), allPlayers.GetPlayer(10)),
                new Match(allPlayers.GetPlayer(9), allPlayers.GetPlayer(11)),
                new Match(allPlayers.GetPlayer(10), allPlayers.GetPlayer(12)),
                new Match(allPlayers.GetPlayer(11), allPlayers.GetPlayer(13)),
                new Match(allPlayers.GetPlayer(12), allPlayers.GetPlayer(14)),
                new Match(allPlayers.GetPlayer(13), allPlayers.GetPlayer(15)),
                new Match(allPlayers.GetPlayer(14), allPlayers.GetPlayer(16)),
                new Match(allPlayers.GetPlayer(15), allPlayers.GetPlayer(17)),
                new Match(allPlayers.GetPlayer(16), allPlayers.GetPlayer(18)),
                new Match(allPlayers.GetPlayer(17), allPlayers.GetPlayer(19)),
                new Match(allPlayers.GetPlayer(18), allPlayers.GetPlayer(20)),
                new Match(allPlayers.GetPlayer(19), allPlayers.GetPlayer(20)),
                new Match(allPlayers.GetPlayer(21), allPlayers.GetPlayer(22)),
                new Match(allPlayers.GetPlayer(21), allPlayers.GetPlayer(23)),
                new Match(allPlayers.GetPlayer(22), allPlayers.GetPlayer(24)),
                new Match(allPlayers.GetPlayer(23), allPlayers.GetPlayer(25)),
                new Match(allPlayers.GetPlayer(24), allPlayers.GetPlayer(26)),
                new Match(allPlayers.GetPlayer(25), allPlayers.GetPlayer(27)),
                new Match(allPlayers.GetPlayer(26), allPlayers.GetPlayer(28)),
                new Match(allPlayers.GetPlayer(27), allPlayers.GetPlayer(29)),
                new Match(allPlayers.GetPlayer(28), allPlayers.GetPlayer(30)),
                new Match(allPlayers.GetPlayer(29), allPlayers.GetPlayer(31)),
                new Match(allPlayers.GetPlayer(30), allPlayers.GetPlayer(32)),
                new Match(allPlayers.GetPlayer(31), allPlayers.GetPlayer(33)),
                new Match(allPlayers.GetPlayer(32), allPlayers.GetPlayer(34)),
                new Match(allPlayers.GetPlayer(33), allPlayers.GetPlayer(35)),
                new Match(allPlayers.GetPlayer(34), allPlayers.GetPlayer(36)),
                new Match(allPlayers.GetPlayer(35), allPlayers.GetPlayer(37)),
                new Match(allPlayers.GetPlayer(36), allPlayers.GetPlayer(38)),
                new Match(allPlayers.GetPlayer(37), allPlayers.GetPlayer(39)),
                new Match(allPlayers.GetPlayer(38), allPlayers.GetPlayer(30)),
                new Match(allPlayers.GetPlayer(39), allPlayers.GetPlayer(30)),
                new Match(null, null),
                new Match(null, null),
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
                //new TimeSlot() { Number = 8 },
                //new TimeSlot() { Number = 9 },
                //new TimeSlot() { Number = 10 },
                //new TimeSlot() { Number = 11 },
                //new TimeSlot() { Number = 12 },
                //new TimeSlot() { Number = 13 },
            };
        }
    }
}
