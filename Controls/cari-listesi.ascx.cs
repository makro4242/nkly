using System;
using System.Data;
using System.Web.UI;

public partial class Controls_cari_listesi : System.Web.UI.UserControl
{
    MyFonksiyon f = new MyFonksiyon();
    Helper hp = new Helper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            kartlarilistele();
        }
    }
    public void kartlarilistele()
    {
        DataTable dt = f.GetDataTable("SELECT Id,Cari_Kodu,Cari_Unvan,Cari_Tipi from Cariler");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }
    }
    public string tipyaz(string tip)
    {
        return tip == "0" ? "Müşteri" : "Satıcı";
    }
}