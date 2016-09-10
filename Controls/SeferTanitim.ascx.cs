using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_SeferTanitim : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtSeferTarihi.Text = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace(".", "/");
            carileriGetir();
            personelleriGetir();
            araclariGetir();
            seferSayisiGetir();
            SeferleriGetir();
            LokasyonlariGetir();
            chcAktifPasif.Checked = false;
            if (Request.QueryString["id"] != null)
            {
                seferBilgileriniGetir();
            }
        }
    }
    public void seferBilgileriniGetir()
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataTable dt = f.GetDataTable("SELECT * FROM Seferler where Id=" + Request.QueryString["id"]);
            if (dt != null && dt.Rows.Count > 0)
            {

                txtSeferSayisi.Text = dt.Rows[0]["Sefer_Kodu"].ToString();
                txtSeferTarihi.Text = dt.Rows[0]["Sefer_Tarih"].ToString().Split(' ')[0];
                txtSeferFatura.Text = dt.Rows[0]["Sefer_Fatura"].ToString();
                drpSeferPersoneli.SelectedValue = dt.Rows[0]["Sefer_Personel"].ToString();
                drpMusteri.SelectedValue = dt.Rows[0]["Sefer_Cari"].ToString();
                drpSeferArac.SelectedValue = dt.Rows[0]["Sefer_Arac"].ToString();
                drpSeferLokasyon.SelectedValue = dt.Rows[0]["Sefer_Lokasyon"].ToString();
                txtSeferMiktarKg.Text = dt.Rows[0]["Sefer_MiktarKG"].ToString();
                txtSeferMiktarLt.Text = dt.Rows[0]["Sefer_MiktarLT"].ToString();
                txtBasKm.Text = dt.Rows[0]["Sefer_BasKm"].ToString();
                txtBitKm.Text = dt.Rows[0]["Sefer_BitKm"].ToString();
                txtIrsaliyeNo.Text = dt.Rows[0]["Sefer_IrsaliyeNo"].ToString();
                if (dt.Rows[0]["Sefer_AktifPasif"].ToString().ToLower() == "true")
                {
                    chcAktifPasif.Checked = true;
                }
                else
                {
                    chcAktifPasif.Checked = false;
                }
                string seferFatura = dt.Rows[0]["sefer_fatura"].ToString();
                if (seferFatura.Trim().Length > 0 && seferFatura.Trim() != "0")
                {
                    btnKaydet.Visible = false;
                    Helper.mesaj(0, "Bu sefer faturalandırıldığı için güncelleme yapılamaz");
                }
            }

        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }
    }
    public void seferSayisiGetir()
    {
        DataTable dt = f.GetDataTable("SELECT ISNULL(Max(Sefer_Kodu),0) from Seferler");
        if (dt != null && dt.Rows.Count > 0)
        {
            int sayi = Convert.ToInt32(dt.Rows[0][0]);
            sayi++;
            txtSeferSayisi.Text = sayi.ToString();
        }
    }
    public void araclariGetir()
    {
        DataTable dt = f.GetDataTable("SELECT Arac_Plaka from Araclar");
        if (dt != null)
        {
            drpSeferArac.Items.Add(new ListItem("Seçiniz", "-1"));
            drpSeferArac.SelectedValue = "-1";
            foreach (DataRow item in dt.Rows)
            {
                drpSeferArac.Items.Add(new ListItem(item["Arac_Plaka"].ToString(), item[0].ToString()));
            }

        }

    }
    public void personelleriGetir()
    {
        DataTable dt = f.GetDataTable("SELECT Personel_Kodu,Personel_AdiSoyadi from Personeller");
        if (dt != null)
        {
            drpSeferPersoneli.Items.Add(new ListItem("Seçiniz", "-1"));
            drpSeferPersoneli.SelectedValue = "-1";
            foreach (DataRow item in dt.Rows)
            {
                drpSeferPersoneli.Items.Add(new ListItem(item["Personel_AdiSoyadi"].ToString(), item[0].ToString()));
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
    public void SeferleriGetir()
    {
        DataTable dt = f.GetDataTable("select l.lokasyon_aciklama,s.sefer_aktifPasif,s.sefer_IrsaliyeNo,s.sefer_fatura,s.Id,s.Sefer_Kodu,s.Sefer_Tarih,a.Arac_Plaka,c.Cari_Unvan,p.Personel_AdiSoyadi from Seferler s,araclar a,cariler c,personeller p,lokasyon l where s.sefer_personel=p.personel_kodu and s.sefer_arac=a.arac_plaka and s.sefer_cari=c.cari_kodu and l.lokasyon_kodu=s.sefer_lokasyon");
        if (dt != null && dt.Rows.Count > 0)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
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
            string tarih = Convert.ToDateTime(txtSeferTarihi.Text).ToString("yyyy-MM-dd");
            if (Request.QueryString["id"] == null)
            {
                string sorgu = "INSERT INTO [dbo].[Seferler]VALUES('" + f.Temizle(txtSeferSayisi.Text.ToUpper()) + "','" + tarih + "','0','" + drpSeferPersoneli.SelectedValue + "','" + drpMusteri.SelectedValue + "','" + drpSeferArac.SelectedValue + "','" + drpSeferLokasyon.SelectedValue + "','" + f.Temizle(txtSeferMiktarKg.Text) + "'," + f.Temizle(txtSeferMiktarLt.Text).tirnakla() + ",'" + txtBasKm.Text + "','" + txtBitKm.Text + "'," + chcAktifPasif.Checked.ToString().tirnakla() + "," + txtIrsaliyeNo.Text.tirnakla() + ")";
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
                string sorgu = "update seferler set Sefer_Kodu=" + f.Temizle(txtSeferSayisi.Text).tirnakla() + ",Sefer_Tarih=" + tarih.tirnakla() + ",Sefer_Personel=" + drpSeferPersoneli.SelectedValue.tirnakla() + ",Sefer_Cari=" + drpMusteri.SelectedValue.tirnakla() + ",Sefer_Arac=" + drpSeferArac.SelectedValue.tirnakla() + ",Sefer_lokasyon=" + drpSeferLokasyon.SelectedValue.tirnakla() + ",Sefer_MiktarKg=" + txtSeferMiktarKg.Text.tirnakla() + ",Sefer_MiktarLT=" + txtSeferMiktarLt.Text.tirnakla() + ",Sefer_BasKm=" + f.Temizle(txtBasKm.Text).tirnakla() + ",Sefer_BitKm=" + f.Temizle(txtBitKm.Text).tirnakla() + ",Sefer_AktifPasif=" + chcAktifPasif.Checked.ToString().tirnakla() + " where Id=" + f.Temizle(Request.QueryString["id"]);
                int sonuc = f.cmd(sorgu);
                if (sonuc > 0)
                {
                    Helper.mesaj(1, "Güncelleme Başarılı");
                    Response.Redirect(Request.RawUrl.Split('&')[0]);
                }
                else
                {
                    Helper.mesaj(0, "Güncelleme Başarısız");
                }
            }
        }
    }
    public void LokasyonlariGetir()
    {
        DataTable dt = f.GetDataTable("SELECT lokasyon_kodu,lokasyon_aciklama FROM Lokasyon");
        if (dt != null)
        {
            drpSeferLokasyon.Items.Add(new ListItem("Seçiniz", "-1"));
            drpSeferLokasyon.SelectedValue = "-1";
            foreach (DataRow item in dt.Rows)
            {
                drpSeferLokasyon.Items.Add(new ListItem(item["Lokasyon_Aciklama"].ToString(), item["Lokasyon_Kodu"].ToString()));
            }
        }
    }

}