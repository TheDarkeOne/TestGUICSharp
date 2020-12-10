using System;
using System.Collections.Generic;
using System.Text;

namespace TestGUICSharp.Data
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}
