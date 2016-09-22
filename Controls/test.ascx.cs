using myLibrary;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_test : System.Web.UI.UserControl
{
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["evrakno1"] != null && Request.QueryString["evrakno2"] != null)
        {
            faturalariGetir();
        }
    }
    public void faturalariGetir()
    {
        DataTable dt = db.exReaderDT(CommandType.Text, "select ca.cari_unvan,ca.cari_adres, ch.chh_tarihi,sum(ch.chh_aratoplam) as aratoplam,sum(ch.chh_ft_kdv) as kdv,sum(ch.chh_geneltoplam) as geneltoplam,ch.chh_evrakno_sira from cari_hesap_hareketleri ch,cariler ca where ca.cari_kodu=ch.chh_cari_kodu and ch.chh_evrakno_sira in(select distinct(chh_evrakno_sira) from cari_hesap_hareketleri where chh_evrakno_sira>=@evrakno1 and chh_evrakno_sira<=@evrakno2) group by chh_evrakno_sira,chh_cari_kodu,chh_tarihi,cari_unvan,cari_adres", "evrakno1=" + Request.QueryString["evrakno1"].ToString() + ",evrakno2=" + Request.QueryString["evrakno2"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptFatura.DataSource = dt;
            rptFatura.DataBind();
        }
    }
    protected void fatura_bagla(object sender, RepeaterItemEventArgs e)
    {
        Repeater rp = (Repeater)e.Item.FindControl("rptgoruntule");
        string evrakno = DataBinder.Eval(e.Item.DataItem, "chh_evrakno_sira").ToString();
        DataTable dt = db.exReaderDT(CommandType.Text, "select ch.chh_tarihi,c.Cari_Unvan,c.cari_adres,ch.chh_evrakno_sira,sf.Sefer_MiktarKG as sefer_miktar,ch.chh_geneltoplam,ch.chh_aratoplam,ch.chh_ft_kdv,ch.chh_geneltoplam from Cari_Hesap_Hareketleri ch, Cariler c, Seferler sf where ch.chh_SeferNo=sf.Sefer_Kodu and ch.chh_cari_kodu=c.Cari_Kodu and ch.chh_evrakno_sira=" + evrakno);
        if (dt != null)
        {
            rp.DataSource = dt;
            rp.DataBind();
        }
    }
}