using myLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_sabitler : System.Web.UI.UserControl
{
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            kartlariListele();
            if (Request.QueryString["id"] != null)
            {
                kartBilgileriniGetir();
            }
        }
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        if (Helper.boskontrol(frm))
        {
            if (Request.QueryString["id"] == null)
            {
                int sonuc = db.nonQuery(CommandType.Text, "insert into sabitler values(@lastikOmru,@harcirah,@hakedis)", "lastikOmru=" + txtLastikOmru.Text.stringKaldir() + ",harcirah=" + txtLokasyonHarcirah.Text.stringKaldir() + ",hakedis=" + txtPersonelHakedis.Text.stringKaldir());
                if (sonuc == 1)
                {
                    Helper.mesaj(1, "Kayıt Başarılı");

                }
                else
                {
                    Helper.mesaj(0, "Kayıt Yapılamadı");
                }
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                int sonuc = db.nonQuery(CommandType.Text, "update sabitler set lastikOmru=@lastikOmru,lokasyonHarcirah=@lokasyonHarcirah,personelHakedis=@personelHakedis where Id=@id", "lastikOmru=" + txtLastikOmru.Text.stringKaldir() + ",lokasyonHarcirah=" + txtLokasyonHarcirah.Text.stringKaldir() + ",personelHakedis=" + txtPersonelHakedis.Text + ",id=" + Request.QueryString["id"]);
                if (sonuc == 1)
                {
                    Helper.mesaj(1, "Güncelleme Başarılı");
                }
                else
                {
                    Helper.mesaj(0, "Güncelleme Yapılamadı");
                }
                Response.Redirect(Request.RawUrl.Split('&')[0]);
            }
        }
        else
        {
            Helper.mesaj(0, "Boş Alan Bırakmayın");
        }
    }
    public void kartBilgileriniGetir()
    {
        DataTable dt = db.exReaderDT(CommandType.Text, "select * from sabitler where ID=@id", "id=" + Request.QueryString["id"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            txtLastikOmru.Text = dt.Rows[0]["lastikOmru"].ToString();
            txtLokasyonHarcirah.Text = dt.Rows[0]["lokasyonHarcirah"].ToString();
            txtPersonelHakedis.Text = dt.Rows[0]["personelHakedis"].ToString();
        }
    }
    public void kartlariListele()
    {
        DataTable dt = db.exReaderDT(CommandType.Text, "select * from sabitler");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
}