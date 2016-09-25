using System;
using System.Data;
using System.Web.UI;

public partial class Controls_personel_listesi : System.Web.UI.UserControl
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
        DataTable dt = f.GetDataTable("SELECT ID,personel_kodu,personel_adisoyadi FROM Personeller");
        rptKayitlar.DataSource = dt;
        rptKayitlar.DataBind();
    }
}