using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Rules
{
    public static class PlayerWithDefinedTimeSlotRule
    {
        public static int GetRatedNumber(PlaydaySchedule playdaySchedule,Player player, int[] timeSlots, int importance)
        {
            var scheduledMatches = playdaySchedule.PlaydayMatches;
            foreach(var timeslotNumber in timeSlots)
            {
                if (scheduledMatches[timeslotNumber].Match.FirstPlayer != player &&
                    scheduledMatches[timeslotNumber].Match.SecondPlayer != player)
                {
                    return 100 - importance;
                }
            }

            return 100;
        }
    }
}
