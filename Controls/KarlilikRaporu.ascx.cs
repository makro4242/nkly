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
            DataTable dt = f.GetDataTable("with chh (chh_AracPlaka, chh_" + kolon + ") as (select chh_AracPlaka, sum(chh_" + kolon + ") from cari_hesap_hareketleri where chh_hareket_cinsi=0 and chh_tarihi between '2000-01-01' and " + txtSonTarih.Text.tirnakla() + " group by chh_AracPlaka), mh (msr_arac_plaka, msr_" + kolon + ") as (select msr_arac_plaka, sum(msr_" + kolon + ") from masraf_hareketleri where msr_tarihi between '2000-01-01' and " + txtSonTarih.Text.tirnakla() + " group by msr_arac_plaka) select g.chh_AracPlaka, g.chh_" + kolon + " as SatisToplam,coalesce(c.msr_" + kolon + ", 0) as MasrafToplam, (g.chh_" + kolon + ") - coalesce(c.msr_" + kolon + ", 0) as Fark from chh g left join mh c on g.chh_AracPlaka = c.msr_arac_plaka");
            dt.Columns.Add(new DataColumn("test"));
            if (dt != null && dt.Rows.Count > 0)
            {
                rptAracKayitlari.DataSource = dt;
                rptAracKayitlari.DataBind();
            }
        }
        else if (drpKriterListesi.SelectedValue == "1")
        {
            string sorgu = "with ch(gelir,personel_kodu) as (select sum(c.chh_genelToplam),s.sefer_personel from cari_hesap_hareketleri c,seferler s where c.chh_tarihi between '2010-01-01' and @tarih and c.chH_seferNo=s.sefer_kodu group by s.sefer_personel),mh(gider,personel_kodu) as (select sum(msr_geneltoplam),msr_personel_kodu from masraf_hareketleri where msr_tarihi between '2010-01-01' and @tarih group by msr_personel_kodu) select ch.gelir-mh.gider as fark,ch.personel_kodu from ch,mh where ch.personel_kodu=mh.personel_kodu";
            DataTable dt = db.exReaderDT(CommandType.Text, sorgu, "tarih=" + txtSonTarih.Text);
            if (dt != null)
            {
                rptPersonel.DataSource = dt;
                rptPersonel.DataBind();
                pnlPersonel.Visible = true;
            }
        }
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