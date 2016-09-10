using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_EvrakMasrafFaturasi : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    public string drpCariler = "", drpAraclar = "", drpMasraflar = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dropDownGetir("masraflar", "masraf_aciklama", "masraf_kodu", ref drpMasraflar);
            dropDownGetir("araclar", "arac_plaka", "arac_plaka", ref drpAraclar);
            dropDownGetir("Cariler", "Cari_Unvan", "Cari_Kodu", ref drpCariler);


            faturaListele();
        }
    }
    protected void Kaydet(object sender, EventArgs E)
    {
        if (!Helper.boskontrol(frm))
        {
            Helper.mesaj(0, "Boş Alan Bırakmayın");
        }
        else
        {
            /*
            string evrakNo = f.Temizle(txtEvrakNo.Text).tirnakla();
            DateTime dtTarih = Convert.ToDateTime(txtFaturaTarihi.Text);
            string cins = "1";
            string cari = drpCariUnvan.SelectedValue.tirnakla();
            string masraf = drpMasraf.SelectedValue.tirnakla();
            string arac = drpArac.SelectedValue.tirnakla();
            int taksitAy = Convert.ToInt32(drpTaksit.SelectedValue);
            string km = f.Temizle(txtKM.Text).tirnakla();
            int kdv = Convert.ToInt32(drpKDV.SelectedValue);
            decimal tutar = Convert.ToDecimal(txtTutar.Text);
            decimal tutarKdv = Math.Round((tutar * kdv / 100), 2);
            decimal tutarToplam = tutar + tutarKdv;
            string cariEkle = "insert into cari_hesap_hareketleri values(" + dtTarih.ToString("yyyy-MM-dd").tirnakla() + "," + cins + "," + "''," + evrakNo + ",0," + cari + "," + tutar.ToString().Replace(",", ".") + "," + tutarKdv.ToString().Replace(",", ".").tirnakla() + "," + tutarToplam.ToString().Replace(",", ".").tirnakla() + ",0," + arac + "," + km + ")";
            int cariSonuc = f.cmd(cariEkle);
            if (cariSonuc == 1)
            {
                for (int i = 0; i < taksitAy; i++)
                {
                    decimal taksitTutar = Math.Round((tutar / taksitAy), 2);
                    decimal taksitKdv = Math.Round(taksitTutar * kdv / 100, 2);
                    decimal taksitToplam = Math.Round((taksitTutar + taksitKdv), 2);
                    string sorgu = "insert into cari_hesap_hareketleri values(" + dtTarih.AddMonths((i + 1)).ToString("yyyy-MM-dd").tirnakla() + "," + cins + ",''," + evrakNo + ",1," + masraf + "," + taksitTutar.ToString().Replace(",", ".").tirnakla() + "," + taksitKdv.ToString().Replace(",", ".").tirnakla() + "," + taksitToplam.ToString().Replace(",", ".").tirnakla() + "," + "0," + arac + "," + km + ")";
                    int sonuc = f.cmd(sorgu);
                    if (sonuc == 1)
                    {
                        Helper.mesaj(1, "Kayıt Başarılı");
                    }
                    else
                    {
                        Helper.mesaj(0, "Kayıt Yapılamadı");

                    }
                }
            }
            else
            {
                Helper.mesaj(0, "Kayıt Yapılamadı");
            }
             * */
            /*
             *  ([chh_tarihi]
       ,[chh_Hareket_Cinsi]
       ,[chh_evrakno_seri]
       ,[chh_evrakno_sira]
       ,[chh_cari_cins]
       ,[chh_cari_kodu]
       ,[chh_aratoplam]
       ,[chh_ft_kdv]
       ,[chh_geneltoplam]
       ,[chh_SeferNo])*/
            faturaListele();
        }
    }
    public void dropDownGetir(string tablo, string kolonText, string kolonValue, ref string output)
    {

        DataTable dt = f.GetDataTable("select " + kolonValue + " as kolon1," + kolonText + " as kolon2 from " + tablo);

        if (dt != null)
        {
            output += "<option value=''>Seçiniz</option>";
            foreach (DataRow item in dt.Rows)
            {
                output += "<option value=" + item["kolon1"] + ">" + item["kolon2"] + "</option>";
            }
        }

    }

  
    public void faturaListele()
    {
        DataTable dt = f.GetDataTable("select ch.km,c.cari_unvan,chh_kayno,ch.chh_tarihi,ch.chh_evrakno_sira,ch.chh_aratoplam,ch.chh_ft_kdv,ch.chh_genelToplam from cari_hesap_hareketleri ch,cariler c where ch.chh_cari_kodu=c.cari_kodu and ch.chh_hareket_cinsi=1 and chh_cari_cins=0");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
}