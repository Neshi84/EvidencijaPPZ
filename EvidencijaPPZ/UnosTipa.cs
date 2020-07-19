using EvidencijaPPZ.Repository;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EvidencijaPPZ
{
    public partial class UnosTipa : Form
    {
        private TipRepository tipRepo = new TipRepository();
        public UnosTipa()
        {
            InitializeComponent();
        }

        private void UnosTipa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tipRepo.getAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (tipRepo.Create(textBox1.Text.Trim()))
                {
                    dataGridView1.DataSource = tipRepo.getAll().OrderBy(p => p.id).ToList();
                    MessageBox.Show("Uspešno dodat tip!");
                }
            }
            else
            {
                MessageBox.Show("Unesite tip!");
            }
        }
    }
}
