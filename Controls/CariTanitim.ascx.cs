using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_CariTanitim : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            kartlarilistele();
        }
        if (Request.QueryString["id"] != null)
        {
            kartbilgilerinigetir();
        }
    }
    protected void Kaydet(object sender, EventArgs e)
    {

        if (!Helper.boskontrol(frm))//sqlde boş bırakılmaması gereken kolonların kontrolü yapıldı...
        {
            Helper.mesaj(0, "Kayıt Başarısız");
        }
        else
        //yeni kayıtta query string null ise değiştirde query string null değilse 
        {
            if (hp.kayitvarmi("Cari_Kodu", "Cariler", txtCariKodu.Text, Request.QueryString["id"]) == true)
            {
                if (Request.QueryString["id"] == null)
                {
                    string sorgu = "INSERT INTO [dbo].[Cariler] ([Cari_Kodu],[Cari_Unvan],[Cari_Tipi],[Cari_VergiDairesi],[Cari_VergiNo],[Cari_Yetkili],[Cari_YetkiliGsm],[Cari_Tel1],[Cari_Tel2],[Cari_Tel3],[Cari_Adres],[Cari_Not],[Cari_EMail],[Cari_AktifPasif],Cari_Il,Cari_Ilce)";
                    sorgu += " VALUES ('" + f.Temizle(txtCariKodu.Text.ToUpper()) + "','" + f.Temizle(txtCariUnvan.Text.ToUpper()) + "'," + drpTipi.SelectedValue + ",'" + f.Temizle(txtVergiDairesi.Text.ToUpper()) + "','" + f.Temizle(txtVergiNo.Text.ToUpper()) + "','" + f.Temizle(txtCariYetkili.Text) + "','" + f.Temizle(txtCariYetkiliGsm.Text.ToUpper()) + "','" + f.Temizle(txtCariTel2.Text.ToUpper()) + "','" + f.Temizle(txtCariTel3.Text.ToUpper()) + "','" + f.Temizle(txtCariTel3.Text.ToUpper()) + "','" + f.Temizle(txtCariAdres.Text.ToUpper()) + "','" + f.Temizle(txtCariNot.Text.ToUpper()) + "','" + f.Temizle(txtEmail.Text.ToUpper()) + "',1," + txtIl.Text.tirnakla() + "," + txtIlce.Text.tirnakla() + ")";
                    int sonuc = f.cmd(sorgu);
                    if (sonuc > 0)
                    {
                        Helper.mesaj(1, "Kayıt Başarılı");  //sql e kayıt girildiği zaman yani işlem başarılı ise ...  
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Helper.mesaj(0, "Kayıt Başarısız"); //herhangi bir sebepden dolayı sql e kayıt girilememesi durumunda
                    }
                }
                else
                {
                    string sorgu = "UPDATE [dbo].[Cariler] SET [Cari_Kodu]=" + f.Temizle(txtCariKodu.Text.ToUpper()).tirnakla() + ",[Cari_Unvan]=" + f.Temizle(txtCariUnvan.Text.ToUpper()).tirnakla() + ",[Cari_Tipi]=" + drpTipi.SelectedValue + ",[Cari_VergiDairesi]=" + f.Temizle(txtVergiDairesi.Text.ToUpper()).tirnakla() + ",[Cari_VergiNo]=" + f.Temizle(txtVergiNo.Text.ToUpper()).tirnakla() + ",[Cari_Yetkili]=" + f.Temizle(txtCariYetkili.Text.ToUpper()).tirnakla() + ",[Cari_YetkiliGsm]=" + f.Temizle(txtCariYetkiliGsm.Text.ToUpper()).tirnakla() + ",[Cari_Tel1]=" + f.Temizle(txtCariTel1.Text).tirnakla() + ",[Cari_Tel2]=" + f.Temizle(txtCariTel2.Text).tirnakla() + ",[Cari_Tel3]=" + f.Temizle(txtCariTel3.Text).tirnakla() + ",[Cari_Adres]=" + f.Temizle(txtCariAdres.Text.ToUpper()).tirnakla() + ",[Cari_Not]=" + f.Temizle(txtCariNot.Text.ToUpper()).tirnakla() + ",[Cari_Email]=" + f.Temizle(txtEmail.Text.ToUpper()).tirnakla() + ",Cari_Il=" + txtIl.Text.tirnakla() + ",Cari_Ilce=" + txtIlce.Text.tirnakla() + " where Id=" + Request.QueryString["id"];
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
    }
    public void kartlarilistele()
    {
        DataTable dt = f.GetDataTable("SELECT Id,Cari_Kodu,Cari_Unvan,Cari_Tipi from Cariler");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
    public void kartbilgilerinigetir()
    {
        try
        {
            string id = Request.QueryString["id"];
            DataTable dt = f.GetDataTable("SELECT * from Cariler where Id=" + Request.QueryString["id"].tirnakla());
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCariKodu.Text = dt.Rows[0]["Cari_Kodu"].ToString();
                txtCariUnvan.Text = dt.Rows[0]["Cari_Unvan"].ToString();
                drpTipi.SelectedValue = dt.Rows[0]["Cari_Tipi"].ToString();
                txtVergiDairesi.Text = dt.Rows[0]["Cari_VergiDairesi"].ToString();
                txtVergiNo.Text = dt.Rows[0]["Cari_VergiNo"].ToString();
                txtCariYetkili.Text = dt.Rows[0]["Cari_Yetkili"].ToString();
                txtCariYetkiliGsm.Text = dt.Rows[0]["Cari_YetkiliGsm"].ToString();
                txtCariTel1.Text = dt.Rows[0]["Cari_Tel1"].ToString();
                txtCariTel2.Text = dt.Rows[0]["Cari_Tel2"].ToString();
                txtCariTel3.Text = dt.Rows[0]["Cari_Tel3"].ToString();
                txtCariAdres.Text = dt.Rows[0]["Cari_Adres"].ToString();
                txtCariNot.Text = dt.Rows[0]["Cari_Not"].ToString();
                txtEmail.Text = dt.Rows[0]["Cari_Email"].ToString();
                txtIl.Text = dt.Rows[0]["Cari_Il"].ToString();
                txtIlce.Text = dt.Rows[0]["Cari_Ilce"].ToString();
            }
        }
        catch (Exception)
        {
            //Response.Redirect("Default.aspx");
        }
    }
    public string tipyaz(string tip)
    {
        return tip == "0" ? "Müşteri" : "Satıcı";
    }
}