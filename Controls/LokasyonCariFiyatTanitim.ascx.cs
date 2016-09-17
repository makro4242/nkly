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
            rdbKG.Checked = true;
            carileriGetir();
            LokasyonlariGetir();
            if (Request.QueryString["id"]!=null)
            {
                bilgileriGetir();
            }
        }
    }
    public void bilgileriGetir()
    {
        DataTable dt = f.GetDataTable("select * from lokasyoncarifiyat where Id=" + f.Temizle(Request.QueryString["id"]));
        if (dt != null && dt.Rows.Count > 0)
        {
            txtLokFiyat.Text = dt.Rows[0]["Lok_Fiyat"].ToString();
            drpLokasyon.SelectedValue = dt.Rows[0]["Lok_Lokasyon"].ToString();
            drpMusteri.SelectedValue = dt.Rows[0]["Lok_Cari"].ToString();
            byte tip = Convert.ToByte(dt.Rows[0]["Lok_Fiyat_tip"]);
            rdbKG.Checked = tip == 1 ? true : false;
            rdbLT.Checked = tip == 0 ? true : false;
            byte paket = Convert.ToByte(dt.Rows[0]["Lok_Paket"]);
            chxPaketFiyati.Checked = paket == 1 ? true : false;
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
            int tip = rdbKG.Checked ? 1 : 0;
            int paket = chxPaketFiyati.Checked ? 1 : 0;
            if (Request.QueryString["id"] == null)
            {

                string sorgu = "INSERT INTO [dbo].[LokasyonCariFiyat]([Lok_Lokasyon],[Lok_Cari],Lok_Fiyat,Lok_Fiyat_Tip,Lok_Paket)VALUES('" + drpLokasyon.SelectedValue + "','" + drpMusteri.SelectedValue + "', '" + txtLokFiyat.Text + "'," + tip + "," + paket + ")";
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
                string sorgu = "UPDATE [dbo].[LokasyonCariFiyat] SET [Lok_Lokasyon]=" + drpLokasyon.SelectedValue.tirnakla() + ",[Lok_Cari]=" + drpMusteri.SelectedValue.tirnakla() + ",[Lok_Fiyat]=" + txtLokFiyat.Text.tirnakla() + ",Lok_Fiyat_Tip=" + tip + ",Lok_paket=" + paket + " where Id=" + Request.QueryString["id"];
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