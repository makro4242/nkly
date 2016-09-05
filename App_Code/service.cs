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
    public service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
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
