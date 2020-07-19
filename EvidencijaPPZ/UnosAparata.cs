using EvidencijaPPZ.Models;
using EvidencijaPPZ.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EvidencijaPPZ
{
    public partial class UnosAparata : Form
    {
        private TipRepository tipRepo = new TipRepository();
        private KorisnikRepository korisnikRepo = new KorisnikRepository();
        private AparatRepository aparatRepo = new AparatRepository();
        public UnosAparata()
        {
            InitializeComponent();
            tipComboBox.DataSource = tipRepo.getAll();
            tipComboBox.DisplayMember = "tip";
            tipComboBox.ValueMember = "id";

            korisnikComboBox.DataSource = korisnikRepo.getAll();
            korisnikComboBox.DisplayMember = "firma";
            korisnikComboBox.ValueMember = "id";
        }

        private void UnosAparata_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource= aparatRepo.getAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Image img = b.Encode(BarcodeLib.TYPE.CODE128, textBox1.Text, Color.Black, Color.White, 290, 120);
            pictureBox1.Image = img;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guid barcode = Guid.NewGuid();

            Aparat aparat = new Aparat();
            aparat.tip =int.Parse(tipComboBox.SelectedValue.ToString());
            aparat.korisnik_id = int.Parse(korisnikComboBox.SelectedValue.ToString());
            aparat.barkod = barcode.ToString();
            aparat.model = modelTextBox.Text;

            if (aparatRepo.Create(aparat))
            {
                MessageBox.Show("Aparat uspesno sacuvan!");
                dataGridView1.DataSource = aparatRepo.getAll();
            }
            else 
            {
                MessageBox.Show("Doslo je do greske!");
            };
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            var servisForma = new UnosServisa(id);
            servisForma.Show();
        }
    }
}
