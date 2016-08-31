using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_AracTanitim : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            kartlarilistele();
            personelKartlariniDrpDownaGetir();
            if (Request.QueryString["id"] != null)
            {
                kartbilgilerinigetir();
            }
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
            if (hp.kayitvarmi("Arac_Plaka", "Araclar", txtAracPlaka.Text, Request.QueryString["id"]))
            {
                if (Request.QueryString["id"] == null)
                {
                    string sorgu = "INSERT INTO [dbo].[Araclar]([Arac_Plaka],[Arac_Marka],[Arac_Model],[Arac_Zimmet],[Arac_Not])VALUES('" + f.Temizle(txtAracPlaka.Text.ToUpper()) + "','" + f.Temizle(txtAracMarka.Text.ToUpper()) + "','" + f.Temizle(txtAracModel.Text.ToUpper()) + "','" + drpZimmetPersoneli.SelectedValue + "','" + f.Temizle(txtAracNot.Text.ToUpper()) + "')";
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
                    string sorgu = "UPDATE [dbo].[Araclar] SET [Arac_Plaka]=" + f.Temizle(txtAracPlaka.Text.ToUpper()).tirnakla() + ",[Arac_Marka]=" + f.Temizle(txtAracMarka.Text.ToUpper()).tirnakla() + ",[Arac_Model]=" + f.Temizle(txtAracModel.Text).tirnakla() + ",[Arac_Zimmet]=" + f.Temizle(drpZimmetPersoneli.SelectedValue).tirnakla() + ",[Arac_Not]=" + f.Temizle(txtAracNot.Text.ToUpper()).tirnakla() + " where Id=" + Request.QueryString["id"];
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
        DataTable dt = f.GetDataTable("SELECT Id,Arac_Plaka,Arac_Plaka,Arac_Marka,Arac_Model FROM Araclar");
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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataTable dt = f.GetDataTable("SELECT * FROM Araclar where Id=" + Request.QueryString["id"]);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtAracPlaka.Text = dt.Rows[0]["Arac_Plaka"].ToString();
                txtAracMarka.Text = dt.Rows[0]["Arac_Marka"].ToString();
                txtAracModel.Text = dt.Rows[0]["Arac_Model"].ToString();
                drpZimmetPersoneli.SelectedValue = dt.Rows[0]["Arac_Zimmet"].ToString();
                txtAracNot.Text = dt.Rows[0]["Arac_Not"].ToString();
            }

        }
        catch (Exception)
        {
            Response.Redirect("Default.aspx");
        }


    }
    public void personelKartlariniDrpDownaGetir()
    {
        DataTable dt = f.GetDataTable("SELECT Id,Personel_Kodu,Personel_AdiSoyadi from Personeller");
        if (dt != null)
        {
            drpZimmetPersoneli.Items.Add(new ListItem("Seçiniz", "-1"));
            drpZimmetPersoneli.SelectedValue = "-1";
            foreach (DataRow item in dt.Rows)
            {
                drpZimmetPersoneli.Items.Add(new ListItem(item["Personel_AdiSoyadi"].ToString(), item[0].ToString()));
            }

        }
    }
}