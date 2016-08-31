using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_LokasyonCariFiyatTanitim : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();

    protected void Page_Load(object sender, EventArgs e)
    {
        kartlarilistele();
        if (!Page.IsPostBack)
        {
            carileriGetir();
            LokasyonlariGetir();
        }
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        if (!Helper.boskontrol(frm))
        {
            Helper.mesaj(0, "Kayıt Başarısız");
        }
        else
        {
            if (Request.QueryString["id"] == null)
            {
                string sorgu = "INSERT INTO [dbo].[LokasyonCariFiyat]([Lok_Lokasyon],[Lok_Cari],Lok_Fiyat)VALUES('" + drpLokasyon.SelectedValue + "','" + drpMusteri.SelectedValue + "', '" + txtLokFiyat.Text + "')";
                int sonuc = f.cmd(sorgu);
                if (sonuc > 0)
                {
                    Helper.mesaj(1, "Kayıt Başarılı");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    Helper.mesaj(0, "Kayıt Başarısız");
                }
            }
            else
            {
                string sorgu = "UPDATE [dbo].[LokasyonCariFiyat] SET [Lok_Lokasyon]=" + drpLokasyon.SelectedValue + ",[Lok_Cari]=" + drpMusteri.SelectedValue + ",[Lok_Fiyat]=" + txtLokFiyat.Text + ", where Id=" + Request.QueryString["id"];
                int sonuc = f.cmd(sorgu);
                if (sonuc > 0)
                {
                    Helper.mesaj(1, "Güncelleme Başarılı");  //sql e kayıt girildiği zaman yani işlem başarılı ise ...  
                    Response.Redirect(Request.RawUrl.Split('&')[0]);
                }
                else
                {
                    Helper.mesaj(0, "Güncelleme Başarısız"); //herhangi bir sebepden dolayı sql e kayıt girilememesi durumunda
                }
            }
        }
    }
    public void carileriGetir()
    {
        DataTable dt = f.GetDataTable("SELECT Cari_Kodu,Cari_Unvan from Cariler");
        if (dt != null)
        {
            drpMusteri.Items.Add(new ListItem("Seçiniz", "-1"));
            drpMusteri.SelectedValue = "-1";
            foreach (DataRow item in dt.Rows)
            {
                drpMusteri.Items.Add(new ListItem(item["Cari_Unvan"].ToString(), item[0].ToString()));
            }
        }
    }
    public void LokasyonlariGetir()
    {
        DataTable dt = f.GetDataTable("SELECT * FROM Lokasyon");
        if (dt != null)
        {
            drpLokasyon.Items.Add(new ListItem("Seçiniz", "-1"));
            drpLokasyon.SelectedValue = "-1";
            foreach (DataRow item in dt.Rows)
            {
                drpLokasyon.Items.Add(new ListItem(item["Lokasyon_Aciklama"].ToString(), item[1].ToString()));
            }
        }
    }
    public void kartlarilistele()
    {
        DataTable dt = f.GetDataTable("SELECT LCF.Id,LCF.Lok_Fiyat,L.Lokasyon_Aciklama,C.Cari_Unvan,LCF.Lok_Lokasyon,LCF.Lok_Cari FROM LokasyonCariFiyat LCF left join Cariler c on LCF.Lok_Cari=c.Cari_Kodu left join Lokasyon L on LCF.Lok_Lokasyon=L.Lokasyon_Kodu");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }

    }
}