using myLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_fatura_sec : System.Web.UI.UserControl
{
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        string evrakNo1 = txtEvrakNo.Text;
        string evrakNo2 = txtEvrakNo2.Text;
        if (evrakNo2.Trim().Length == 0)
        {
            int adet = Convert.ToInt32(db.exReaderTekSutun(CommandType.Text, "select count(*) from cari_hesap_hareketleri where chh_evrakno_sira=@evrakNo", "evrakNo=" + evrakNo1.stringKaldir()));
            if (adet > 0)
            {
                Response.Redirect("pdf.aspx?evrakno1=" + evrakNo1 + "&evrakno2=" + evrakNo1);
            }
            else
            {
                Helper.mesaj(0, "Belirtilen evrak no bulunamadı");
            }
        }
        else
        {
            int adet = Convert.ToInt32(db.exReaderTekSutun(CommandType.Text, "select count(*) from cari_hesap_hareketleri where chh_evrakno_sira>=@evrakNo and chh_evrakno_sira<=@evrakNo2", "evrakNo=" + evrakNo1.stringKaldir() + ",evrakNo2=" + evrakNo2.stringKaldir()));
            if (adet > 0)
            {
                Response.Redirect("pdf.aspx?evrakno1=" + evrakNo1 + "&evrakno2=" + evrakNo2);
            }
            else
            {
                Helper.mesaj(0, "Belirtilen evrak no bulunamadı");
            }
        }
    }
}