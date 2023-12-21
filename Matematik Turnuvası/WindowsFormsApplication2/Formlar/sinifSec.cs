using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication2
{
    public partial class sinifSec : Form
    {
        public sinifSec()
        {
            InitializeComponent();
        }

        private void sinifSec_Load(object sender, EventArgs e)
        {
            button1.Text = "Onayla";
            try
            {
                SQLiteConnection baglan = new SQLiteConnection();
                baglan.ConnectionString = ("Data Source=Veritabani/veri_tabani.sqlite");
                baglan.Open();
                SQLiteCommand cmd = baglan.CreateCommand();

                cmd.CommandText = "SELECT * FROM siniflar";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["sinif"].ToString());
                }

                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //ilk sınıfı otomatik seç
            listBox1.SetSelected(0,true);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex != -1)
            {
                this.Visible = false;

                grupCalismasi sorular1 = new grupCalismasi();
                sorular1.sinif = listBox1.SelectedItem.ToString(); //gecici olarak bu sekilde yazildi
                sorular1.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Sınıf Seçiniz!");
            }

        }
    }
}
