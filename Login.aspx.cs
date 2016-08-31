using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            CookieBilgileriniGetir();
            txtSifre.Attributes["type"] = "password";
        }
    }
    protected void GirisYap(object sender, EventArgs e)
    {


        DataTable dt = f.GetDataTable("select * from Kullanicilar where Kullanici_User=" + f.Temizle(txtKullaniciAdi.Text).tirnakla() + " and Kullanici_Sifre=" + f.Temizle(txtSifre.Text).tirnakla());
        if (dt != null && dt.Rows.Count > 0)
        {
            if (chxBeniHatirla.Checked)
            {
                HttpCookie cookienesne = new HttpCookie("Login"); //Cookiekullaniciadi isminde bir Cookie oluşturduk.
                cookienesne["kullaniciadi"] = txtKullaniciAdi.Text;  //cookienesne'sinin kullaniciadi değerine kullaniciaditxt bilgisini atıyoruz.
                cookienesne["sifre"] = txtSifre.Text;   //cookienesne'sinin sifre değerine sifretxt bilgisini atıyoruz.   
                cookienesne.Expires = DateTime.Now.AddDays(30);  //Cookie'mizin ömrü 30 saniye olacak.
                Response.Cookies.Add(cookienesne);
            }
            if (dt.Rows[0][3].ToString().ToLower() == "false")
            {
                HttpCookie cookienesne2 = new HttpCookie("Sofor");
                cookienesne2["kullaniciadi"] = txtKullaniciAdi.Text;
                cookienesne2.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookienesne2);
                Response.Redirect("/Sofor");
            }
            else
            {
                HttpCookie cookienesne2 = new HttpCookie("admin");
                cookienesne2["kullaniciadi"] = txtKullaniciAdi.Text;
                cookienesne2.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookienesne2);
                Response.Redirect("/");
            }
        }

    }
    public void CookieBilgileriniGetir()
    {
        //Öncelikle hata almamak için Cookie değerlerimizin olup olmadığını kontrol ediyoruz.
        if (Request.Cookies["Login"] != null)
        {
            txtKullaniciAdi.Text = Request.Cookies["Login"]["kullaniciadi"].ToString(); //Login Cookie içerisindeki kullanici adi değerini kullaniciadilbl içine atıyoruz.
            txtSifre.Text = Request.Cookies["Login"]["sifre"].ToString(); //Login Cookie içerisindeki değeri sifrelbl içine atıyoruz. Böylece Cookie değerlerimizi almış oluyoruz.
            chxBeniHatirla.Checked = true;
        }
    }
}