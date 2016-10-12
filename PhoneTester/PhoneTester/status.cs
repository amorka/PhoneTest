using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneTester
{
    public partial class status : Form
    {

        public delegate void dlg();
        public dlg dlgFunc;
        public static status instance;

        public static int val = 0;
        public status()
        {
            InitializeComponent();
        }

        private void status_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 567777;
            progressBar1.Step = 1;
            Worker.Instance.UpdateCounter += Instance_UpdateCounter;
            dlgFunc = Instance_UpdateCounter;
        }

        public void Instance_UpdateCounter()
        {

            progressBar1.Value++;
            lb_count.Text = progressBar1.Value.ToString();
        }
    }
}
