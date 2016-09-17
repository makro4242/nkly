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
        Response.Redirect("default.aspx?sayfa=EvrakMasrafFaturasi");
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
        DataTable dt = f.GetDataTable("select c.cari_unvan,ch.chh_tarihi,ch.chh_evrakno_sira,sum(ch.chh_aratoplam) as araToplam,sum(ch.chh_ft_kdv) as kdv,sum(ch.chh_genelToplam) as genelToplam from cari_hesap_hareketleri ch,cariler c where ch.chh_cari_kodu=c.cari_kodu and ch.chh_hareket_cinsi=1 and chh_cari_cins=0 group by chh_evrakno_sira,chh_tarihi,cari_unvan");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
}