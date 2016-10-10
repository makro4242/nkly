using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myLibrary;

public partial class Controls_Fatura : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable dtFaturaNoDuzelt = db.exReaderDT(CommandType.Text, "select chh_evrakno_sira,chh_seferno from cari_hesap_hareketleri where chh_seferno!=0");
        foreach (DataRow item in dtFaturaNoDuzelt.Rows)
        {
            db.nonQuery(CommandType.Text, "update seferler set sefer_fatura=@fatura where sefer_kodu=@sefer", "fatura=" + item["chh_evrakno_sira"] + ",sefer=" + item["chh_seferno"]);
        }
        /*
        DataTable dt = db.exReaderDT(CommandType.Text, "select sefer_kodu,ID from seferler order by ID");
        int seferKodu = 0;
        foreach (DataRow item in dt.Rows)
        {
            seferKodu++;
            db.nonQuery(CommandType.Text, "update seferler set sefer_kodu=@yeni where ID=@id", "yeni=" + seferKodu + ",id=" + item["ID"]);
            db.nonQuery(CommandType.Text, "update cari_hesap_hareketleri set chh_seferNo=@yeni where chh_seferNo=@eski", "yeni=" + seferKodu + ",eski=" + item["sefer_kodu"]);
        }*/
        if (!Page.IsPostBack)
        {
            txtFaturaTarihi.Text = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace(".", "/");
            carileriGetir();
            faturaNoGetir();
            evrakNoGetir();
            //aynı evrakno girilmesin
            seferleriGetir();
            faturaListele();
        }
    }
    public void evrakNoGetir()
    {
        DataTable dt = f.GetDataTable("select ISNULL(Max(chh_evrakno_sira),0),chh_seriNo from cari_hesap_hareketleri where chh_serino=(select top 1 chh_serino from cari_hesap_hareketleri order by chh_kayno desc) group by chh_serino");
        int evrakNo = 0;
        if (dt != null && dt.Rows.Count > 0)
        {
            evrakNo = Convert.ToInt32(dt.Rows[0][0]);
            txtSeriNo.Text = dt.Rows[0]["chh_seriNo"].ToString();
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
    public float tutarBelirle(object seferMiktarKg, object SeferMiktarLt, object FiyatTip, object fiyat, object lok_Paket)
    {
        decimal tutar = 0;
        fiyat = fiyat.ToString().Replace(".", ",");
        if (lok_Paket.ToString().Trim().Length > 0 && Convert.ToByte(lok_Paket) == 0)
        {
            if (Convert.ToByte(FiyatTip) == 1)
            {
                tutar = Convert.ToDecimal(fiyat) * Convert.ToDecimal(seferMiktarKg);
            }
            else
            {
                tutar = Convert.ToDecimal(fiyat) * Convert.ToDecimal(SeferMiktarLt);
            }
        }
        else
        {
            tutar = Convert.ToDecimal(fiyat);
        }

        return (float)tutar;
    }
    public void seferleriGetir()
    {
        DataTable dt = f.GetDataTable("select l.Lok_Fiyat_Tip,L.Lok_Paket,s.sefer_kodu,s.sefer_IrsaliyeNo,s.sefer_tarih,l.lok_fiyat as fiyat,lk.lokasyon_aciklama,s.Sefer_Kodu,s.Sefer_BasKm,s.Sefer_BitKm,s.Sefer_MiktarKG,s.Sefer_MiktarLt,s.Sefer_Cari,a.arac_plaka,p.Personel_AdiSoyadi,substring(c.Cari_Unvan,0,25) as cari_unvan from Lokasyon lk, LokasyonCariFiyat l,Seferler s, Araclar a,Personeller p,Cariler c where s.Sefer_Fatura=0 and a.Arac_Plaka=s.Sefer_Arac and p.Personel_Kodu=s.Sefer_Personel and c.Cari_Kodu=s.Sefer_Cari and l.lok_lokasyon=s.sefer_lokasyon and l.lok_cari=s.sefer_cari and lk.Lokasyon_Kodu=s.Sefer_Lokasyon and s.sefer_miktarKG!=0 and s.sefer_miktarLT!=0");
        if (dt != null)
        {
            rptSeferler.DataSource = dt;
            rptSeferler.DataBind();
        }
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        string[] arr = hdnSeferler.Value.Split(',');
        string id = "";
        string HareketCinsi = "0";
        string evraknoseri = "''";
        string evraknosira = txtEvrakNo.Text;
        string caricins = "1";
        string kayitAdet = db.exReaderTekSutun(CommandType.Text, "select count(*) from cari_hesap_hareketleri where chh_evrakno_sira=@evrakno and chh_seriNo=@serino", "evrakno=" + evraknosira + ",serino=" + txtSeriNo.Text);
        if (kayitAdet == "0")
        {
            foreach (string item in arr)
            {
                string sorgu = "INSERT INTO Cari_Hesap_Hareketleri VALUES(";
                string tarih = "'" + Convert.ToDateTime(txtFaturaTarihi.Text).ToString("yyyy-MM-dd") + "'";

                string carikodu = "(select sefer_cari from seferler where sefer_kodu=" + item.tirnakla() + ")";

                string aracPlaka = "(select sefer_arac from seferler where sefer_kodu=" + item.tirnakla() + ")";

                DataTable dtFiyatBilgileri = db.exReaderDT(CommandType.Text, "select s.sefer_miktarKG,s.Sefer_MiktarLT,l.lok_fiyat,l.lok_fiyat_tip,l.Lok_paket from seferler s,lokasyonCariFiyat l where s.sefer_lokasyon=l.lok_lokasyon and s.sefer_cari=l.lok_cari and s.sefer_kodu=@seferKodu", "seferKodu=" + item);

                decimal aratoplam = 0;
                if (dtFiyatBilgileri != null && dtFiyatBilgileri.Rows.Count > 0)
                {
                    aratoplam = Convert.ToDecimal(tutarBelirle(dtFiyatBilgileri.Rows[0]["sefer_miktarKG"], dtFiyatBilgileri.Rows[0]["sefer_miktarLT"], dtFiyatBilgileri.Rows[0]["lok_Fiyat_tip"], dtFiyatBilgileri.Rows[0]["lok_Fiyat"], dtFiyatBilgileri.Rows[0]["lok_paket"]));
                }

                decimal kdv = (aratoplam * 18 / 100);
                decimal gentoplam = aratoplam + kdv;
                string seferno = item;
                sorgu += tarih + "," + HareketCinsi + "," + evraknoseri + "," + evraknosira + "," + caricins + "," + carikodu + "," + aratoplam.ToString().Replace(",", ".").tirnakla() + "," + kdv.ToString().Replace(",", ".").tirnakla() + "," + gentoplam.ToString().Replace(",", ".").tirnakla() + "," + seferno + "," + aracPlaka + "," + txtSeriNo.Text.tirnakla();
                sorgu += ")";
                f.cmd(sorgu);
                f.cmd("update seferler set sefer_fatura=" + f.Temizle(txtEvrakNo.Text).tirnakla() + ", sefer_aktifPasif=0 where sefer_kodu=" + item);

                Helper.mesaj(1, "Kayıt Başarılı");
                id = f.GetDataTable("select top 1 chh_kayno from Cari_Hesap_Hareketleri order by chh_kayno desc").Rows[0][0].ToString();

            }
        }
        Response.Redirect("default.aspx?sayfa=fatura");
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
    public void faturaListele()
    {
        DataTable dt = f.GetDataTable("select c.cari_unvan,chh_kayno,ch.chh_tarihi,ch.chh_evrakno_sira,ch.chh_aratoplam,ch.chh_ft_kdv,ch.chh_genelToplam from cari_hesap_hareketleri ch,cariler c where ch.chh_cari_kodu=c.cari_kodu and ch.chh_hareket_cinsi=0 order by ch.chh_tarihi,ch.chh_evrakno_sira asc");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
}