using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mayinTarlasiSon
{
    public partial class Form1 : Form
    {
        private Tahta tahta;
        private OyunZorlugu zorluk;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new object[] { "Kolay", "Orta", "Zor" });
            comboBox1.SelectedIndex = 0;
        }

        public Form1(string alinandeger,string alinandeger2)
        {
            InitializeComponent();
            label1.Text = alinandeger;
            comboBox1.Items.AddRange(new object[] { "Kolay", "Orta", "Zor" });
            comboBox1.SelectedItem= alinandeger2;

        }

        private void TahtayiCiz()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = zorluk.Satir;
            tableLayoutPanel1.ColumnCount = zorluk.Sutun;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            if (comboBox1.SelectedItem == "Kolay")
            {
                tableLayoutPanel1.Width = 150;
                tableLayoutPanel1.Height = 150;
            }
            else if (comboBox1.SelectedItem == "Orta")
            {
                tableLayoutPanel1.Width = 480;
                tableLayoutPanel1.Height = 480;
            }
            else
            {
                tableLayoutPanel1.Width = 900;
                tableLayoutPanel1.Height = 480;
            }

            for (int i = 0; i < zorluk.Satir; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            for (int j = 0; j < zorluk.Sutun; j++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));

            for (int i = 0; i < zorluk.Satir; i++)
            {
                for (int j = 0; j < zorluk.Sutun; j++)
                {
                    System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Tag = new Point(i, j);
                    btn.MouseUp += Btn_MouseUp;
                    tableLayoutPanel1.Controls.Add(btn, j, i);
                }
            }
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            Point point = (Point)btn.Tag;
            var hucre = tahta.Hucreler[point.X, point.Y];

            if (e.Button == MouseButtons.Left)
                if (hucre.MayinVar)
                {
                    hucre.Ac();
                    ButonlariGuncelle();
                    MessageBox.Show("💥 Kaybettiniz!");
                    comboBox1.Enabled = true;
                    return;
                }
                else
                {
                    tahta.BosluklariAc(point.X, point.Y);
                }
            else if (e.Button == MouseButtons.Right)
                hucre.Isaretle();

           
           btn.Text = hucre.Acildi ? (hucre.MayinVar ? "💣" : hucre.CevreMayinSayisi.ToString()) : (hucre.Isaretli ? "🚩" : "");
            ButonlariGuncelle();
            if (tahta.OyunKazandiMi())
            {
                MessageBox.Show("🎉 Kazandınız!");
                comboBox1.Enabled = true;
            }
        }
        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Kolay": zorluk = new KolayZorluk(); break;
                case "Orta": zorluk = new OrtaZorluk(); break;
                case "Zor": zorluk = new ZorZorluk(); break;
                case "": zorluk = new KolayZorluk(); break;
            }

            tahta = new Tahta(zorluk.Satir, zorluk.Sutun, zorluk.MayinSayisi);
            TahtayiCiz();
        }
        private void ButonlariGuncelle()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is System.Windows.Forms.Button btn)
                {
                    Point p = (Point)btn.Tag;
                    var hucre = tahta.Hucreler[p.X, p.Y];

                    if (hucre.Acildi)
                    {
                        if (hucre.MayinVar)
                            btn.Text = "💣";
                        else
                            btn.Text = hucre.CevreMayinSayisi > 0 ? hucre.CevreMayinSayisi.ToString() : "";
                        btn.Enabled = false;
                    }
                    else
                    {
                        btn.Text = hucre.Isaretli ? "🚩" : "";
                        btn.Enabled = true;
                    }
                }
            }
        }

    }
}
