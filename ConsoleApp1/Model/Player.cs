using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleApp1.Model
{
    [DebuggerDisplay("{Number}({Name})")]
    public class Player
    {
        public string Team { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return string.Format($"{Number}({Name})");
        }
    }
}
