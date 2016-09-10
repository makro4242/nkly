using myLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class service : System.Web.Services.WebService
{
    MyFonksiyon f = new MyFonksiyon();
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    class evrak
    {
        public string masraf { get; set; }
        public string arac { get; set; }
        public string taksit { get; set; }
        public string Km { get; set; }
        public string KDV { get; set; }
        public string tutar { get; set; }
        public string toplamTutar { get; set; }
        public string toplamKDV { get; set; }

    }
    public service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string evrakMasraf(string evrakNo, string faturaTarihi, string cariKodu, string masrafKodu, string aracPlaka, string taksitSayisi, string km, string kdv, string tutar)
    {
        /*
        DateTime dtTarih = Convert.ToDateTime(faturaTarihi);
        string evrakNoSeri = "";
        string tarih = dtTarih.ToString("yyyy-MM-dd");
        string cins = "1";
        int taksitAy = Convert.ToInt32(taksitSayisi);
        int kdvSayi = Convert.ToInt32(kdv);
        decimal tutarSayi = Convert.ToDecimal(tutar);
        decimal tutarKdv = Math.Round((tutarSayi * kdvSayi / 100), 2);
        decimal tutarToplam = tutarSayi + tutarKdv;

        string insert = "INSERT INTO [Cari_Hesap_Hareketleri] vallues(@tarih,@cins,@evrakNo,@evrakSira,@cariCins,@cariKodu,@araToplam,@kdv,@genelToplam,@seferNo,@arac,@km)";

        string prm = "tarih=" + tarih + ",cins=" + cins + ",evrakNo=" + evrakNoSeri.stringKaldir() + ",evrakSira=" + evrakNo.stringKaldir() + ",cariCins=0,cariKodu=" + cariKodu.stringKaldir() + ",araToplam=" + tutar.stringKaldir() + ",kdv=" + kdv.stringKaldir() + ",geneltoplam=" + tutarToplam.ToString().stringKaldir() + ",seferNo=0,arac=" + aracPlaka.stringKaldir() + ",km=" + km.stringKaldir();
        int sonuc = db.nonQuery(CommandType.Text, insert, prm);
        if (sonuc == 1)
        {
            decimal taksitTutar = Math.Round((tutarSayi / Convert.ToInt32(taksitSayisi)), 2);
            decimal taksitKdv = Math.Round(taksitTutar * kdvSayi / 100, 2);
            decimal taksitToplam = Math.Round((taksitTutar + taksitKdv), 2);
            for (int i = 0; i < taksitAy; i++)
            {

                prm = "tarih=" + tarih + ",cins=" + cins + ",evrakNo=" + evrakNoSeri.stringKaldir() + ",evrakSira=" + evrakNo.stringKaldir() + ",cariCins=1,cariKodu=" + cariKodu.stringKaldir() + ",araToplam=" + taksitTutar.ToString().stringKaldir() + ",kdv=" + taksitKdv.ToString().stringKaldir() + ",geneltoplam=" + taksitToplam.ToString().stringKaldir() + ",seferNo=0,arac=" + aracPlaka.stringKaldir() + ",km=" + km.stringKaldir();
                if (sonuc == 1)
                {
                    Helper.mesaj(1, "Kayıt Başarılı");
                }
                else
                {
                    Helper.mesaj(0, "Kayıt Yapılamadı");

                }
            }
            evrak em = new evrak();
            em.masraf = masrafKodu;
            em.arac = aracPlaka;
            em.taksit = taksitSayisi;
            em.Km = km;
            em.KDV = kdv;
            em.tutar = tutar;
        }
         * */
        return "deneme";
    }

    [WebMethod]
    public string cariKodu(string kod)
    {
        DataTable dt = f.GetDataTable("select top 1 cari_kodu from cariler where cari_Kodu like '" + kod + "%' order by cari_kodu desc");
        string strReturn = "";
        if (dt != null && dt.Rows.Count > 0)
        {
            strReturn = dt.Rows[0][0].ToString().Replace(kod, "");
            try
            {
                strReturn = (Convert.ToInt32(strReturn) + 1).ToString();
                while (strReturn.Length < 3)
                {
                    strReturn = "0" + strReturn;
                }
            }
            catch (Exception)
            {
            }
        }
        return kod + strReturn;
    }

    [WebMethod]
    public string kayitSil(string id, string tablo, string kolon)
    {
        string mesaj = "";
        Helper h = new Helper();
        mesaj = h.kayitsilService(tablo, kolon, id);
        return mesaj;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getSeferler()
    {
        string json = "";
        DataTable dt = f.GetDataTable("select * from seferler");
        if (dt != null)
        {
            List<sefer> lstSeferler = new List<sefer>();

            int say = 0;
            foreach (DataRow item in dt.Rows)
            {

                say++;
                lstSeferler.Add(new sefer() { arac = "Kamyon", miktar = 1000, fiyat = 5000, tutar = 2500, hizmet = "nakliye", personel = "Murat", km = 3500 });


            }
            json = new JavaScriptSerializer().Serialize(lstSeferler);
            json = "{\n \"data\":\n" + json + "\n\n}";
            return json;
        }
        else
        {
            return "";
        }


    }
    class sefer
    {
        public int miktar { get; set; }
        public int fiyat { get; set; }
        public int tutar { get; set; }
        public string hizmet { get; set; }
        public string arac { get; set; }
        public string personel { get; set; }

        public int km { get; set; }
    }

}
