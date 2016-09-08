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
    public enum OptionView {ALL,FROM_COUNTRY}
    public partial class ViewBase : Form
    {

        public ViewBase()
        {
            InitializeComponent();
        }

        private void ViewBase_Load(object sender, EventArgs e)
        {
            LoadAllBase();
            
        }

        public void LoadAllBase() {
            dataGridView1.DataSource= DBAdapter.Instance.GetAllPhones();
            lb_count.Text = dataGridView1.RowCount.ToString();
            comboBox1.DataSource = DBAdapter.Instance.GetCountries();
            comboBox1.DisplayMember = "country";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.Enabled = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBAdapter.Instance.GetPhonesFromCountry((comboBox1.SelectedItem as PhoneInfo).country);
            lb_count.Text = dataGridView1.RowCount.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                dataGridView1.DataSource = DBAdapter.Instance.GetAllPhones();
                lb_count.Text = dataGridView1.RowCount.ToString();
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
                dataGridView1.DataSource = DBAdapter.Instance.GetPhonesFromCountry((comboBox1.SelectedItem as PhoneInfo).country);
                lb_count.Text = dataGridView1.RowCount.ToString();
            }
        }
    }
}
