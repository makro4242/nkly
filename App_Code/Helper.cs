using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
    MyFonksiyon f = new MyFonksiyon();
    public Helper()
    {
        //HAYDAR
        // TODO: Add constructor logic here
        //
    }
    public static bool boskontrol(Control ctrl)
    {
        bool kontrol = true;
        foreach (Control item in ctrl.Controls)
        {
            if (item is TextBox && (item as TextBox).CssClass.Contains("zorunlu") && (item as TextBox).Text.Trim().Length == 0)
            {
                kontrol = false;
            }
            else if (item is DropDownList && (item as DropDownList).SelectedValue == "-1" && (item as DropDownList).CssClass.Contains("zorunlu"))
            {
                kontrol = false;
            }
        }
        return kontrol;
    }

    public static string yaziyaCevir(decimal tutar)
    {
        string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
        string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
        string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
        string yazi = "";

        string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
        string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
        string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

        int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
        //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

        lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

        string grupDegeri;

        for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
        {
            grupDegeri = "";

            if (lira.Substring(i, 1) != "0")
                grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

            if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                grupDegeri = "YÜZ";

            grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

            grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

            if (grupDegeri != "") //binler
                grupDegeri += binler[i / 3];

            if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                grupDegeri = "BİN";

            yazi += grupDegeri;
        }

        if (yazi != "")
            yazi += " TL ";

        int yaziUzunlugu = yazi.Length;

        if (kurus.Substring(0, 1) != "0") //kuruş onlar
            yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

        if (kurus.Substring(1, 1) != "0") //kuruş birler
            yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

        if (yazi.Length > yaziUzunlugu)
            yazi += " Kr.";
        else
            yazi += "SIFIR Kr.";

        return yazi.ToLower();
    }
    public void alanlaritemizle(Control ctrl)
    {
        foreach (Control item in ctrl.Controls)
        {
            if (item is TextBox)
            {
                (item as TextBox).Text = "";
            }
            else if (item is DropDownList)
            {
                (item as DropDownList).SelectedValue = "-1";
            }
        }

    }
    public static void mesaj(int tip, string uyari)
    {
        string strtip = tip == 1 ? "success" : "error";
        HttpContext.Current.Session["mesaj"] = strtip + "-" + uyari;

    }
    public bool kayitvarmi(string kolon, string table, string value, string id)
    {
        bool durum = true;
        string where = "";
        if (id != null && id.Length > 0)
        {
            where = " and Id !=" + id;
        }
        DataTable dt = f.GetDataTable("select " + kolon + " from " + table + " where " + kolon + "='" + f.Temizle(value) + "'" + where);
        if (dt.Rows.Count > 0)
        {
            durum = false;
            Helper.mesaj(0, "Aynı Koda Sahip Başka Bir Kart Mevcuttur");
        }
        return durum;
    }
    public void kayitsil(string table, string kolon, string value)
    {
        f.cmd("delete from " + table + " where " + kolon + "=" + value.tirnakla());
    }
    public string kayitsilService(string table, string kolon, string value)
    {
        return f.cmd2("delete from " + table + " where " + kolon + "=" + value.tirnakla());
    }
}