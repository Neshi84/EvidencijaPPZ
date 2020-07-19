using EvidencijaPPZ.Models;
using EvidencijaPPZ.Repository;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EvidencijaPPZ
{
    public partial class UnosKorisnika : Form
    {
        private KorisnikRepository korisnikRepo = new KorisnikRepository();
        public UnosKorisnika()
        {
            InitializeComponent();
        }

        private void UnosKorisnika_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = korisnikRepo.getAll().OrderByDescending(k => k.id).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Korisnik korisnik = new Korisnik();

            korisnik.firma = firmaTextBox.Text.Trim();
            korisnik.ime = imeTextBox.Text.Trim();
            korisnik.prezime = prezimeTextBox.Text.Trim();
            korisnik.mobilni = mobilniTextBox.Text.Trim();
            korisnik.fiksni = fiksniTextBox.Text.Trim();
            korisnik.email = emailTextBox.Text.Trim();

            if (korisnikRepo.Create(korisnik))
            {
                dataGridView1.DataSource = korisnikRepo.getAll().OrderByDescending(k => k.id).ToList();
                MessageBox.Show("Uspešno sačuvan korisnik!");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
        }
    }
}
