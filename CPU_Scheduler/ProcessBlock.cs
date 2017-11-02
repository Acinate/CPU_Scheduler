using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Scheduler
{
    class ProcessBlock
    {
        public SolidBrush brush_color { get; set; }
        public int x_position { get; set; }
        public int y_position { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
