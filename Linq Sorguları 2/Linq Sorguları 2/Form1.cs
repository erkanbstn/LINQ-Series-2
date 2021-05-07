using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Sorguları_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBSınavEntityEntities db = new DBSınavEntityEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            lblmax.Text = db.TblNotlar.Max(x=>x.Ortalama).ToString();

            lblmin.Text = db.TblNotlar.Min(x=>x.Ortalama).ToString();

            label1.Text = db.TblNotlar.Where(x => x.Durum == false).Max(x => x.Ortalama).ToString();

            label2.Text = db.TblNotlar.Where(x => x.Durum == true).Min(x => x.Ortalama).ToString();

            label3.Text = db.TblÖğrenci.Count().ToString();

            label4.Text = db.TblNotlar.Sum(x => x.Sınav1).ToString();

            label5.Text = db.TblÖğrenci.Count(x=>x.Ad=="Erkan").ToString();

            label6.Text = (from x in db.TblNotlar orderby x.Sınav1 descending select x.Ders).First().ToString();

            dataGridView2.DataSource = db.notta().ToList();


            if (radioButton1.Checked == true)
            {
                //var s = db.TblÖğrenci.
                //    OrderBy(x => x.Şehir).
                //    GroupBy(y => y.Şehir).
                //    Select(v => new { Şehir = v.Key, Toplam = v.Count() }).
                //    OrderByDescending(c=>c.Toplam);
                //dataGridView2.DataSource = s.ToList();
            }
            if (radioButton1.Checked == true)
            {
                var x = db.TblÖğrenci.OrderBy(g => g.Şehir).GroupBy(z => z.Şehir).Select(v => new { Şehir = v.Key, Toplam = v.Count() }).OrderByDescending(b=>b.Toplam);
                dataGridView2.DataSource = x.ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
