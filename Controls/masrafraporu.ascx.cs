﻿using myLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_masrafraporu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            drpKriterlistesiicin();
        }
    }
    protected void Raporla(object sender, EventArgs e)
    {
        panelleriKapat();
        myDbHelper db = new myDbHelper(new sqlDbHelper());
        string kolon = "aratoplam";
        if (rdbKdvli.Checked)
        {
            kolon = "geneltoplam";
        }

        if (drpKriterListesi.SelectedValue == "0")
        {
            pnlAraclar.Visible = true;
            string sorgu = "select sum(msr_" + kolon + ") as fark,msr_arac_plaka from masraf_hareketleri where msr_arac_plaka!='' and msr_tarihi between @tarih1 and @tarih2 group by msr_arac_plaka";
            DataTable dt = db.exReaderDT(CommandType.Text, sorgu, "tarih1=" + txtilkTarih.Text + ",tarih2=" + txtSonTarih.Text);
            if (dt != null)
            {
                rptAracKayitlari.DataSource = dt;
                rptAracKayitlari.DataBind();
            }
        }
        else if (drpKriterListesi.SelectedValue == "1")
        {
            pnlPersonel.Visible = true;
            string sorgu = "select sum(m.msr_" + kolon + ") as fark,m.msr_personel_kodu as personel_kodu,p.personel_adisoyadi from masraf_hareketleri m,personeller p where p.personel_kodu=m.msr_personel_kodu and msr_personel_kodu!=0 and msr_tarihi between @tarih1 and @tarih2 group by m.msr_personel_kodu,p.personel_adisoyadi";
            DataTable dt = db.exReaderDT(CommandType.Text, sorgu, "tarih1=" + txtilkTarih.Text + ",tarih2=" + txtSonTarih.Text);
            if (dt != null)
            {
                rptPersonel.DataSource = dt;
                rptPersonel.DataBind();
            }
        }
    }
    public void drpKriterlistesiicin()
    {
        drpKriterListesi.Items.Add(new ListItem("Seçiniz", "-1"));
        drpKriterListesi.Items.Add(new ListItem("Araç Bazında", "0"));
        drpKriterListesi.Items.Add(new ListItem("Şoför Bazında", "1"));
    }
    public void panelleriKapat()
    {
        foreach (Control item in pnlContainer.Controls)
        {
            if (item is Panel)
            {
                item.Visible = false;
            }
        }
    }
}