using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduler
{
    class Task
    {
        public Process process { get; set; }
        public int timeslice { get; set; }
        public ProcessBlock block { get; set; }
        public PointF draw_point { get; set; }
        public Font font = new Font(FontFamily.GenericSansSerif, 5.0F, FontStyle.Regular);
        public SolidBrush text_brush = new SolidBrush(Color.White);
    }
}
