using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace PhoneTester
{
    public partial class Form1 : Form
    {
        ViewRequest vr;

        string test_string = "<html><body><h1>привет тест</h1></body></html>";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (InternetTester.TestInternetConnection() != ConnectionStatus.NotConnected)
            {
                lbInternetStatus.BackColor = Color.Green;
            }
            else {
                lbInternetStatus.BackColor = Color.Red;
            }
        }

        private void окноВизуализацииЗапросовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vr != null) { vr.Close(); vr = null; }
            vr = new ViewRequest();
            vr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tel = "79234176493";
            string page = Requester.Instance.LoadStartPage("http://www.kody.su/check-tel?number="+tel+"#text");
           // vr.ShowPage(page);
            //Страна: <strong>Россия</strong></td><td>Код сотового оператора: <br><strong>Мегафон [Томская область]
            string Patern = @"Страна:\s.\w{6}.(\w+)..\w{6}...\w{2}..\w{2}.+\[(.+)\]";
            Regex reg = new Regex(Patern, RegexOptions.IgnoreCase);
            Match match = reg.Match(page);
            MessageBox.Show(String.Format("Страна - {0} | Локализация номера - {1}",match.Groups[1].Value,match.Groups[2].Value));
            
        }

        private void просмотреВсехЗаписейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBase vb = new ViewBase();

            vb.Show();
        }
    }
}
