using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.Model
{
    [DebuggerDisplay("{PlaydayMatches}")]
    public class PlaydaySchedule
    {
        public PlaydaySchedule(List<ScheduledMatch> playdayMatches) => (PlaydayMatches) = (playdayMatches);
        public List<ScheduledMatch> PlaydayMatches { get; set; }

        public override string ToString()
        {
            return string.Format($"{PlaydayMatches}");
        }
    }
}
