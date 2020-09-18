using EvidencijaPPZ.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvidencijaPPZ
{
    public partial class Form1 : Form
    {
        ServisRepository servisRepo = new ServisRepository();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = servisRepo.getServisReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formaTip = new UnosTipa();
            formaTip.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formaKorisnik = new UnosKorisnika();
            formaKorisnik.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var formaAparat = new UnosAparata();
            formaAparat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servisRepo.getServisReport();
        }

       
    }
}
