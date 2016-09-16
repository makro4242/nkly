using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_KarlilikRaporu : System.Web.UI.UserControl
{

    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            drpKriterlistesiicin();
            pnlAraclar.Visible = false;
            pnlPersonel.Visible = false;

        }
    }

    protected void Raporla(object sender, EventArgs e)
    {
        if (drpKriterListesi.SelectedValue.ToString() == "0")
        {
            DataTable dt = f.GetDataTable("with chh (chh_AracPlaka, chh_aratoplam) as (select chh_AracPlaka, sum(chh_aratoplam) from cari_hesap_hareketleri where chh_tarihi between"+txtilkTarih.Text.tirnakla()+" between"+txtSonTarih.Text.tirnakla()+" group by chh_AracPlaka), mh (msr_arac_plaka, msr_aratoplam) as (select msr_arac_plaka, sum(msr_aratoplam) from masraf_hareketleri where msr_tarihi="+txtilkTarih.Text.tirnakla()+" between"+txtSonTarih.Text.tirnakla()+" group by msr_arac_plaka) select g.chh_AracPlaka, g.chh_aratoplam as SatisToplam,coalesce(c.msr_aratoplam, 0) as MasrafToplam, g.chh_aratoplam - coalesce(c.msr_aratoplam, 0) as Fark from chh g left join mh c on g.chh_AracPlaka = c.msr_arac_plaka");
            if (dt != null && dt.Rows.Count > 0)
            {
                rptAracKayitlari.DataSource = dt;
                rptAracKayitlari.DataBind();
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
}