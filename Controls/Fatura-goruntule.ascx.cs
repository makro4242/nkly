using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Fatura_goruntule : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    public string cariUnvan = "", cariAdres = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            faturagetir();
        }

    }
    public decimal geneltoplam = 0;

    public void faturagetir()
    {
        DataTable dt = f.GetDataTable("select ch.chh_tarihi,c.Cari_Unvan,c.cari_adres,ch.chh_evrakno_sira,sf.Sefer_MiktarKG as sefer_miktar,ch.chh_geneltoplam,ch.chh_aratoplam,ch.chh_ft_kdv,ch.chh_geneltoplam from Cari_Hesap_Hareketleri ch, Cariler c, Seferler sf where ch.chh_SeferNo=sf.Sefer_Kodu and ch.chh_cari_kodu=c.Cari_Kodu and ch.chh_evrakno_sira=" + Request.QueryString["id"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            cariAdres = dt.Rows[0]["cari_adres"].ToString();
            cariUnvan = dt.Rows[0]["cari_unvan"].ToString();
            rptgoruntule.DataSource = dt;
            rptgoruntule.DataBind();
            decimal aratoplam = 0;
            decimal kdv = 0;
            foreach (DataRow item in dt.Rows)
            {
                aratoplam += Convert.ToDecimal(item["chh_aratoplam"]);
                kdv += Convert.ToDecimal(item["chh_ft_kdv"]);
                geneltoplam += Convert.ToDecimal(item["chh_geneltoplam"]);

            }
            lblGenToplam.Text = String.Format("{0:N}", geneltoplam);
            lblKdv.Text = String.Format("{0:N}", kdv);
            lblAraToplam.Text = String.Format("{0:N}", aratoplam);
        }
    }
    public decimal fiyatmiktarcarp(object fiyat, object miktar)
    {
        return Convert.ToDecimal(fiyat) * Convert.ToDecimal(miktar);
    }
}