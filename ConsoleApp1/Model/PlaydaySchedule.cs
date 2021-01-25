using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.Model
{
    [DebuggerDisplay("{PlaydayMatches}")]
    public class PlaydaySchedule
    {
        public PlaydaySchedule(Dictionary<int, Match[]> playdayMatches) => (PlaydayMatches) = (playdayMatches);
        //public List<ScheduledMatches> PlaydayMatches { get; set; }

        public Dictionary<int, Match[]> PlaydayMatches { get; set; }

        public override string ToString()
        {
            return string.Format($"{PlaydayMatches}");
        }
    }
}
