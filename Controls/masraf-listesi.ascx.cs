using System;
using System.Data;
using System.Web.UI;

public partial class Controls_masraf_listesi : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            kartlarilistele();
        }

    }
    public void kartlarilistele()
    {
        DataTable dt = f.GetDataTable("SELECT Masraf_Kodu,masraf_aciklama,ID FROM Masraflar");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
}