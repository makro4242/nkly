using myLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_KarlilikRaporu : System.Web.UI.UserControl
{
    public string turAdi = "";

    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            drpKriterlistesiicin();
        }
    }
    public void panelleriKapat()
    {
        foreach (Control item in pnlContainer.Controls)
        {
            if (item is Panel)
            {
                item.Visible = false;
            }
        }
    }
    protected void Raporla(object sender, EventArgs e)
    {
        panelleriKapat();
        myDbHelper db = new myDbHelper(new sqlDbHelper());
        string kolon = "aratoplam";
        if (rdbKdvli.Checked)
        {
            kolon = "geneltoplam";
        }

        if (drpKriterListesi.SelectedValue.ToString() == "0")
        {
            pnlAraclar.Visible = true;
            DataTable dt = f.GetDataTable("with chh (chh_AracPlaka, chh_" + kolon + ") as (select chh_AracPlaka, sum(chh_" + kolon + ") from cari_hesap_hareketleri where chh_hareket_cinsi=0 and chh_tarihi between '2000-01-01' and " + txtSonTarih.Text.tirnakla() + " group by chh_AracPlaka), mh (msr_arac_plaka, msr_" + kolon + ") as (select msr_arac_plaka, sum(msr_" + kolon + ") from haydar.masraf_hareketleri where msr_tarihi between '2000-01-01' and " + txtSonTarih.Text.tirnakla() + " group by msr_arac_plaka) select g.chh_AracPlaka, g.chh_" + kolon + " as SatisToplam,coalesce(c.msr_" + kolon + ", 0) as MasrafToplam, (g.chh_" + kolon + ") - coalesce(c.msr_" + kolon + ", 0) as Fark from chh g left join mh c on g.chh_AracPlaka = c.msr_arac_plaka");
            dt.Columns.Add(new DataColumn("test"));
            if (dt != null && dt.Rows.Count > 0)
            {
                rptAracKayitlari.DataSource = dt;
                rptAracKayitlari.DataBind();
            }
        }
        else if (drpKriterListesi.SelectedValue == "1")
        {
            string sorgu = "with ch(gelir,personel_kodu) as (select sum(c.chh_genelToplam),s.sefer_personel from cari_hesap_hareketleri c,seferler s where c.chh_tarihi between '2010-01-01' and @tarih and c.chH_seferNo=s.sefer_kodu group by s.sefer_personel),mh(gider,personel_kodu) as (select sum(msr_geneltoplam),msr_personel_kodu from haydar.masraf_hareketleri where msr_tarihi between '2010-01-01' and @tarih group by msr_personel_kodu) select ch.gelir-mh.gider as fark,ch.personel_kodu from ch,mh where ch.personel_kodu=mh.personel_kodu";
            DataTable dt = db.exReaderDT(CommandType.Text, sorgu, "tarih=" + txtSonTarih.Text);
            if (dt != null)
            {
                rptPersonel.DataSource = dt;
                rptPersonel.DataBind();
                pnlPersonel.Visible = true;
            }
        }
        else if (drpKriterListesi.SelectedValue == "3")
        {
            string sorgu = "with sf(sefer_kodu,sefer_km,sefer_personel,sefer_arac) as (select sefer_kodu,(sefer_bitkm-sefer_baskm),sefer_personel,sefer_arac from seferler where sefer_tarih between '2010-01-01' and @tarih),mh(masraf_tutar,masraf_arac) as (select (sum(msr_geneltoplam)),msr_arac_plaka from haydar.masraf_hareketleri where msr_arac_plaka!='' and msr_sefer_no=0 and msr_tarihi between '2010-01-01' and @tarih group by msr_arac_plaka),pe(personel_sefer,personel_maas,personel_kodu) as (select count(s.sefer_personel),p.personel_maasi,p.personel_kodu from seferler s,personeller p where s.sefer_personel=p.personel_kodu group by p.personel_kodu,p.personel_maasi),ar(arac_amortisman,arac_sefer_sayisi,arac_plaka) as (select a.amortisman,count(s.sefer_arac),a.arac_plaka from araclar a,seferler s where s.sefer_arac=a.arac_plaka and  s.sefer_tarih between '2010-01-01' and @tarih group by a.arac_plaka,a.amortisman),arkm(arac_yaptigi_km,arac_plaka) as (select sum(sefer_bitkm-sefer_baskm),sefer_arac from seferler group by sefer_arac) select sf.sefer_km*(coalesce(mh.masraf_tutar,0)/arkm.arac_yaptigi_km)+(((pe.personel_maas/30)*(select DATEDIFF(day,'2010-01-01','2016-10-22')))/pe.personel_sefer)+(ar.arac_amortisman/ar.arac_sefer_sayisi) as fark,sf.sefer_kodu from sf left join pe on sf.sefer_personel=pe.personel_kodu left join mh on sf.sefer_arac=mh.masraf_arac left join ar on sf.sefer_arac=ar.arac_plaka left join arkm on sf.sefer_arac=arkm.arac_plaka";
            DataTable dt = db.exReaderDT(CommandType.Text, sorgu, "tarih=" + txtSonTarih.Text);
            if (dt != null)
            {
                rptSefer.DataSource = dt;
                rptSefer.DataBind();
                pnlSefer.Visible = true;
            }
        }
    }

    public string seferKarHesapla(object seferKm,object aracMasraf)
    {
        return "";
    }
    public void drpKriterlistesiicin()
    {
        drpKriterListesi.Items.Add(new ListItem("Seçiniz", "-1"));
        drpKriterListesi.Items.Add(new ListItem("Araç Bazında", "0"));
        drpKriterListesi.Items.Add(new ListItem("Şoför Bazında", "1"));
        drpKriterListesi.Items.Add(new ListItem("Müşteri Bazında", "2"));
        drpKriterListesi.Items.Add(new ListItem("Sefer Bazında", "3"));
    }
    /*
    public void drpfiltreicin(object sender, EventArgs e)
    {
        drpFiltreListesi.Items.Clear();
        if (drpKriterListesi.SelectedValue.ToString() == "0")
        {
            pnlAraclar.Visible = true;
            DataTable dt = f.GetDataTable("SELECT * from ARACLAR");
            if (dt != null)
            {
                drpFiltreListesi.Items.Add(new ListItem("Seçiniz", "-1"));
                foreach (DataRow item in dt.Rows)
                {
                    drpFiltreListesi.Items.Add(new ListItem(item["Arac_Plaka"].ToString(), item[0].ToString()));
                }
            }

        }
        if (drpKriterListesi.SelectedValue.ToString() == "1")
        {
            DataTable dt = f.GetDataTable("SELECT * from Personeller");
            if (dt != null)
            {
                drpFiltreListesi.Items.Add(new ListItem("Seçiniz", "-1"));
                foreach (DataRow item in dt.Rows)
                {
                    drpFiltreListesi.Items.Add(new ListItem(item["Personel_AdiSoyadi"].ToString(), item[0].ToString()));
                }
            }
        }
        if (drpKriterListesi.SelectedValue.ToString() == "2")
        {
            DataTable dt = f.GetDataTable("SELECT * FROM Cariler");
            if (dt != null)
            {
                drpFiltreListesi.Items.Add(new ListItem("Seçiniz", "-1"));
                foreach (DataRow item in dt.Rows)
                {
                    drpFiltreListesi.Items.Add(new ListItem(item["Cari_Unvan"].ToString(), item[0].ToString()));
                }
            }
        }
        if (drpKriterListesi.SelectedValue.ToString() == "3")
        {
            DataTable dt = f.GetDataTable("select * from Seferler");
            if (dt != null)
            {
                drpFiltreListesi.Items.Add(new ListItem("Seçiniz", "-1"));
                foreach (DataRow item in dt.Rows)
                {
                    drpFiltreListesi.Items.Add(new ListItem(item["Sefer_Kodu"].ToString(), item[0].ToString()));

                }
            }
        }

    }
     */
}