using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduler
{
    public partial class NewProcess : Form
    {
        Form1 form;
        public NewProcess(Form form)
        {
            this.form = form as Form1;
            InitializeComponent();
        }

        

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
