using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Rules
{
    public static class PlayerShouldPlayInGivenTimeslotsRule
    {
        public static int GetRatedNumber(PlaydaySchedule playdaySchedule, Player player, int[] timeSlots, int importance)
        {
            var scheduledMatches = playdaySchedule.PlaydayMatches;
            var matchesPlayerShouldNotPlay = scheduledMatches.Where(m => !timeSlots.Any(t => t == m.Timeslot.Number));
            foreach (var match in matchesPlayerShouldNotPlay)
            {
                if (match.Match.FirstPlayer == player ||
                    match.Match.SecondPlayer == player)
                {
                    return 100 - importance;
                }
            }

            return 100;
        }
    }
}
