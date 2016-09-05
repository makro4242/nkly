using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Sofor_Controls_default : System.Web.UI.UserControl
{
    public string sofor = "", mesaj = "";
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater rpt = (Repeater)Parent.FindControl("rptSeferler");
        DataTable dt = (DataTable)rpt.DataSource;
        if (dt != null && dt.Rows.Count > 0)
        {
            mesaj = "Sizin için tanımlanmış toplam ( " + dt.Rows.Count + " ) sefer bulunmaktadır";
        }
        else
        {
            mesaj = "Sizin için tanımlanmış aktif sefer bulunmamaktadır";
        }
        soforBilgileri();
    }

    public void soforBilgileri()
    {
        if (Request.Cookies["sofor"] != null)
        {
            if (Request.Cookies["sofor"]["adiSoyadi"] != null)
            {
                sofor = Request.Cookies["sofor"]["adiSoyadi"].ToString();
            }
            else
            {
                sofor = f.GetDataCell("select personel_adisoyadi from personeller where personel_kodu=" + Request.Cookies["sofor"]["kullaniciadi"].ToString());
                Request.Cookies["sofor"]["adiSoyadi"] = sofor;
            }
        }
    }

}