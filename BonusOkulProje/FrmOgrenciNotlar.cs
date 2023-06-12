﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusOkulProje
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        public string adsoyad;
        public string numara;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-EVMO9DR\\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD, SINAV1, SINAV2, SINAV3, PROJE, ORTALAMA, DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRid= 1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            //ad soyad yazdırma
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select OGRAD,OGRSOYAD from TBLOGRENCILER where OGRID=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1",numara);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            { 
                this.Text = dr2[0] + " " + dr2[1];
            }
            baglanti.Close();
        }
    }
}
