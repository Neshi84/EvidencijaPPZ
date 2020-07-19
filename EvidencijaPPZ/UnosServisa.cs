using EvidencijaPPZ.Models;
using EvidencijaPPZ.Repository;
using System;
using System.Windows.Forms;

namespace EvidencijaPPZ
{
    public partial class UnosServisa : Form
    {
        private int _id { get; set; }
        ServisRepository servisRepo = new ServisRepository();
       
        public UnosServisa(int id)
        {
            _id = id;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Text = DateTime.Today.ToString("dd.MM.yyyy");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Servis servis = new Servis();
            servis.aparat_id = _id;
            servis.datum = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            servis.napomena = richTextBox1.Text;

            servisRepo.Create(servis);
        }
    }
}
