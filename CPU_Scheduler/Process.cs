﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduler
{
    public class Process
    {
        public int id { get; set; }
        public string state { get; set; }
        public int arrivalTime { get; set; }
        public long runtime { get; set; }
        public int priority { get; set; }
        public int timeleft { get; set; }
        public int contextSwitches { get; set; }
        public int timeStarted { get; set; }
        public int timeEnded { get; set; }
        public ProcessBlock block { get; set; }
    }
}
