using myLibrary;
using System;

public partial class Controls_fatura_numaralandir : System.Web.UI.UserControl
{
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Kaydet(object sender, EventArgs e)
    {

        if (txtEvrakNo.Text.Trim().Length > 0)
        {
            try
            {
                string islem = rdbArtir.Checked ? "+" : "-";
                string birim = txtBirim.Text;
                int sonuc = db.nonQuery(System.Data.CommandType.Text, "update cari_hesap_hareketleri set chh_evrakno_sira=(chh_evrakno_sira)" + islem + birim + " where chh_evrakno_sira>=@evrakNo and chh_seriNo=@serino", "evrakNo=" + txtEvrakNo.Text + ",serino=" + txtSeriNo.Text);
                Helper.mesaj(1, "İşlem yapıldı");
                txtEvrakNo.Text = "";
                txtSeriNo.Text = "";
            }
            catch (Exception)
            {
                
                 Helper.mesaj(0, "İşlem Yapılamıyor");
            }
        }

    }
}