using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.Model
{
    [DebuggerDisplay("Timeslot {Number}")]
    public class TimeSlot
    {
        public int Number { get; set; }

        public override string ToString()
        {
            return string.Format($"Timeslot {Number}");
        }
    }
}
