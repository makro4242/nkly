using System;
using System.Data;

public partial class Controls_arac_listesi : System.Web.UI.UserControl
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
        DataTable dt = f.GetDataTable("SELECT Id,Arac_Plaka,Arac_Plaka,Arac_Marka,Arac_Model FROM Araclar");
        if (dt != null)
        {
            rptKayitlar.DataSource = dt;
            rptKayitlar.DataBind();
        }

    }
}