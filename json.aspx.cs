using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class json : System.Web.UI.Page
{
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        string json = "";
        DataTable dt = f.GetDataTable("select l.lok_fiyat as fiyat,lk.lokasyon_aciklama,s.Sefer_Kodu,s.Sefer_BasKm,s.Sefer_BitKm,s.Sefer_Miktar,s.Sefer_Cari,a.arac_plaka,p.Personel_AdiSoyadi,c.Cari_Unvan from Lokasyon lk, LokasyonCariFiyat l,Seferler s, Araclar a,Personeller p,Cariler c where s.Sefer_Fatura=0 and a.Arac_Plaka=s.Sefer_Arac and p.Personel_Kodu=s.Sefer_Personel and c.Cari_Kodu=s.Sefer_Cari and l.lok_lokasyon=s.sefer_lokasyon and l.lok_cari=s.sefer_cari and lk.Lokasyon_Kodu=s.Sefer_Lokasyon and s.Sefer_Cari=" + Request.QueryString["id"].tirnakla());
        if (dt != null)
        {
            List<sefer> lstSeferler = new List<sefer>();

            int say = 0;
            foreach (DataRow item in dt.Rows)
            {

                say++;
                sefer s = new sefer(item["Sefer_Kodu"],item["Sefer_Miktar"], item["fiyat"], "Nakliye Bedeli", item["Arac_Plaka"], item["Personel_AdiSoyadi"], item["Sefer_BasKm"], item["Sefer_BitKm"],item["lokasyon_aciklama"]);
                lstSeferler.Add(s);


            }
            json = new JavaScriptSerializer().Serialize(lstSeferler);

        }

        Response.Clear();
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write("{\n \"data\":\n" + json + "\n\n}");
        Response.End();
    }
    class sefer
    {
        public string miktar { get; set; }
        public int tutarSayi { get; set; }
        public string fiyat { get; set; }
        public int fiyatSayi { get; set; }
        public string tutar { get; set; }
        public string hizmet { get; set; }
        public string arac { get; set; }
        public string personel { get; set; }
        public int id { get; set; }
        public int km { get; set; }

        public string lokasyon { get; set; }
        public sefer(object id,object miktar, object fiyat, object hizmet, object arac, object personel,object BasKm,object BitKm,object lokasyon)
        {
            this.id=Convert.ToInt32(id);
            this.miktar = formatYap(miktar.ToString());
            this.fiyatSayi = Convert.ToInt32(fiyat);
            this.fiyat = formatYap(fiyat.ToString());
            this.tutar = formatYap((Convert.ToInt32(miktar) * this.fiyatSayi).ToString());
            this.tutarSayi = Convert.ToInt32(miktar) * this.fiyatSayi;
            this.hizmet = Convert.ToString(hizmet);
            this.arac = Convert.ToString(arac);
            this.personel = Convert.ToString(personel);
            this.km = Convert.ToInt32(BitKm) - Convert.ToInt32(BasKm);
            this.lokasyon = lokasyon.ToString();

        }
        public string formatYap(string deger)
        {
            int islem = 0;
            string yeni = "";
            for (int i = deger.Length-1; i >=0; i--)
            {
                islem++;
                yeni = deger[i]+yeni;
                if (islem%3==0&&i>0)
                {
                    yeni = "." + yeni;
                }
                

            }
            yeni += ",00";
            return yeni;


        }
    }
}