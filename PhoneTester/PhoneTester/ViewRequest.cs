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
    public partial class ViewRequest : Form
    {
        public ViewRequest()
        {
            InitializeComponent();
        }

        private void ViewRequest_Load(object sender, EventArgs e)
        {

        }

        public void ShowPage(string page) {
            webBrowser1.DocumentText=page;
        }
    }
}
