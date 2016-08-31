using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Fatura : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtFaturaTarihi.Text = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace(".", "/");
            carileriGetir();
            faturaNoGetir();
            evrakNoGetir();
            //aynı evrakno girilmesin
            seferleriGetir();
        }
    }
    public void evrakNoGetir()
    {
        DataTable dt = f.GetDataTable("select isNUll(max(chh_evrakno_sira),0) from cari_hesap_hareketleri where chh_hareket_cinsi=1");
        int evrakNo = 0;
        if (dt != null && dt.Rows.Count > 0)
        {
            evrakNo = Convert.ToInt32(dt.Rows[0][0]);
        }
        evrakNo++;
        txtEvrakNo.Text = evrakNo.ToString();
    }
    public void faturaNoGetir()
    {
        DataTable dt = f.GetDataTable("SELECT ISNULL(Max(chh_evrakno_sira),0) from Cari_Hesap_Hareketleri");
        if (dt != null && dt.Rows.Count > 0)
        {
            int sayi = Convert.ToInt32(dt.Rows[0][0]);
            sayi++;
            txtEvrakNo.Text = sayi.ToString();
        }
    }
    public void seferleriGetir()
    {
        DataTable dt = f.GetDataTable("select s.sefer_kodu,s.sefer_IrsaliyeNo,s.sefer_tarih,l.lok_fiyat as fiyat,lk.lokasyon_aciklama,s.Sefer_Kodu,s.Sefer_BasKm,s.Sefer_BitKm,s.Sefer_Miktar,s.Sefer_Cari,a.arac_plaka,p.Personel_AdiSoyadi,substring(c.Cari_Unvan,0,25) as cari_unvan from Lokasyon lk, LokasyonCariFiyat l,Seferler s, Araclar a,Personeller p,Cariler c where s.Sefer_Fatura=0 and a.Arac_Plaka=s.Sefer_Arac and p.Personel_Kodu=s.Sefer_Personel and c.Cari_Kodu=s.Sefer_Cari and l.lok_lokasyon=s.sefer_lokasyon and l.lok_cari=s.sefer_cari and lk.Lokasyon_Kodu=s.Sefer_Lokasyon and s.sefer_miktar!=0");
        if (dt != null)
        {
            rptSeferler.DataSource = dt;
            rptSeferler.DataBind();
        }
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        string[] arr = hdnSeferler.Value.Split(',');
        foreach (string item in arr)
        {
            string fiyat = f.GetDataTable("select l.lok_fiyat from lokasyonCariFiyat l,seferler s where l.lok_cari=s.Sefer_Cari and l.Lok_lokasyon=s.Sefer_lokasyon and s.sefer_kodu=" + item.tirnakla()).Rows[0][0].ToString();
            decimal fiyatInt = 0;
            if (fiyat.Length > 0)
            {
                try
                {
                    fiyatInt = Convert.ToDecimal(fiyat);
                }
                catch (Exception)
                {
                    fiyatInt = 0;
                }
            }
            string sorgu = "INSERT INTO Cari_Hesap_Hareketleri VALUES(";
            string tarih = "'" + Convert.ToDateTime(txtFaturaTarihi.Text).ToString("yyyy-MM-dd") + "'";
            string HareketCinsi = "0";
            string evraknoseri = "''";
            string evraknosira = txtEvrakNo.Text;
            string caricins = "1";
            string carikodu = "''";



            int seferMiktar = Convert.ToInt32(f.GetDataTable("select sefer_miktar from seferler s WHERE S.Sefer_Kodu=" + item.tirnakla()).Rows[0][0]);

            decimal aratoplam = (fiyatInt * seferMiktar);
            decimal kdv = (aratoplam * 18 / 100);
            decimal gentoplam = aratoplam + kdv;
            string seferno = item;
            sorgu += tarih + "," + HareketCinsi + "," + evraknoseri + "," + evraknosira + "," + caricins + "," + carikodu + "," + aratoplam + "," + kdv + "," + gentoplam + "," + seferno;
            sorgu += ")";
            f.cmd(sorgu);
            f.cmd("update seferler set sefer_fatura=" + f.Temizle(txtEvrakNo.Text).tirnakla() + ", sefer_aktifPasif=0 where sefer_kodu=" + item);
            //f.cmd("update Seferler set Sefer_Fatura=1 where Sefer_Kodu=" + item);
            Helper.mesaj(1, "Kayıt Başarılı");
            string id = f.GetDataTable("select top 1 chh_kay_no from Cari_Hesap_Hareketleri order by id desc").Rows[0][0].ToString();
            Response.Redirect("default.aspx?sayfa=fatura-goruntule&id=" + id);
        }
    }

    public void carileriGetir()
    {
        /*
        DataTable dt = f.GetDataTable("SELECT Cari_Kodu,Cari_Unvan from Cariler");
        if (dt != null)
        {
            drpCariUnvan.Items.Add(new ListItem("Seçiniz", "0"));
            drpCariUnvan.SelectedValue = "0";
            foreach (DataRow item in dt.Rows)
            {
                drpCariUnvan.Items.Add(new ListItem(item["Cari_Unvan"].ToString(), item[0].ToString()));
            }
        }
         * */
    }
}