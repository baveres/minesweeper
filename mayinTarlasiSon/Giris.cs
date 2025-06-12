using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mayinTarlasiSon
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string alinandeger2=comboBox1.Text;
            string alinandeger=textBox1.Text;
            Form1 gecis = new Form1(alinandeger,alinandeger2);
            gecis.Show();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
