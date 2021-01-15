using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Rules
{
    public static class NoMatchWithoutABreakRule
    {
        public static bool IsPlayDayScheduleValid(PlaydaySchedule playdaySchedule)
        {
            var scheduledMatches = playdaySchedule.PlaydayMatches;
            for (int i = 0; i < scheduledMatches.Count; i++)
            {
                if (i + 1 == scheduledMatches.Count)
                    break;
                var currentMatch = scheduledMatches[i];
                var nextMatch = scheduledMatches[i + 1];

                if((currentMatch.Match.FirstPlayer != null &&
                    currentMatch.Match.FirstPlayer == nextMatch.Match.FirstPlayer ||
                    currentMatch.Match.FirstPlayer == nextMatch.Match.SecondPlayer) ||
                    (currentMatch.Match.SecondPlayer != null &&
                    currentMatch.Match.SecondPlayer == nextMatch.Match.FirstPlayer ||
                    currentMatch.Match.SecondPlayer == nextMatch.Match.SecondPlayer))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
