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
        //
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
                kontrol=false;
            }
        }
        return kontrol;
    }

    public void alanlaritemizle(Control ctrl)
    {
        foreach (Control item in ctrl.Controls)
        {
            if (item is TextBox)
            {
                (item as TextBox).Text = "";
            }
            else if(item is DropDownList)
            {
                (item as DropDownList).SelectedValue = "-1";
            }
        }

    }
    public static void mesaj(int tip,string uyari)
    {
        string strtip = tip == 1 ? "success" : "error";
        HttpContext.Current.Session["mesaj"] = strtip + "-" + uyari;

    }
    public bool kayitvarmi(string kolon,string table,string value,string id)
    {
        bool durum = true;
        string where = "";
        if (id!=null&&id.Length>0)
        {
            where = " and Id !=" + id;  
        }
        DataTable dt = f.GetDataTable("select "+kolon+" from "+table+" where "+kolon+"='" +f.Temizle(value)+ "'"+where);
        if (dt.Rows.Count > 0)
        {
            durum = false;
            Helper.mesaj(0, "Aynı Koda Sahip Başka Bir Kart Mevcuttur");
        }
        return durum;
    }
    public void kayitsil(string table,string kolon,string value)
    {
        f.cmd("delete from " + table + " where " + kolon + "=" + value.tirnakla());
    }
    public string kayitsilService(string table, string kolon, string value)
    {
       return f.cmd2("delete from " + table + " where " + kolon + "=" + value.tirnakla());
    }
}