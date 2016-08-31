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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            faturagetir();
        }

    }
    public void faturagetir()
    {
        DataTable dt = f.GetDataTable("select ch.chh_tarihi,c.Cari_Unvan,ch.chh_evrakno_sira,sf.Sefer_Miktar,c.Cari_Tutar,ch.chh_aratoplam,ch.chh_ft_kdv,ch.chh_geneltoplam from Cari_Hesap_Hareketleri ch, Cariler c, Seferler sf where ch.chh_SeferNo=sf.Sefer_Kodu and ch.chh_cari_kodu=c.Cari_Kodu and ch.chh_kay_no=" + Request.QueryString["id"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            rptgoruntule.DataSource = dt;
            rptgoruntule.DataBind();
            int aratoplam = 0;
            foreach (DataRow item in dt.Rows)
            {
                aratoplam += Convert.ToInt32(item["Cari_Tutar"])*Convert.ToInt32(item["Sefer_Miktar"]);
            }
            int kdv = aratoplam * 18 / 100;
            int geneltoplam = kdv + aratoplam;
            lblGenToplam.Text = geneltoplam.ToString();
            lblKdv.Text = kdv.ToString();
            lblAraToplam.Text = aratoplam.ToString();
        }
    }
    public int fiyatmiktarcarp(object fiyat, object miktar)
    {
        return Convert.ToInt32(fiyat) * Convert.ToInt32(miktar);
    }
}