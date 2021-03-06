﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sofor_Controls_SeferTanitim : System.Web.UI.UserControl
{

    MyFonksiyon f = new MyFonksiyon();
    myLibrary.myDbHelper db = new myLibrary.myDbHelper(new myLibrary.sqlDbHelper());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            seferBilgileriniGetir();
        }
    }
    public bool irsaliyeKontrol()
    {
        bool kontrol = false;
        string adet = db.exReaderTekSutun(CommandType.Text, "select count(*) from seferler where sefer_IrsaliyeNo=@irsaliye and sefer_kodu!=@sefer and sefer_IrsaliyeNo!=0", "irsaliye=" + txtIrsaliyeNo.Text + ",sefer=" + hdnseferkodu.Value);
        if (adet.Length > 0 && adet == "0")
        {
            kontrol = true;
        }
        return kontrol;
    }
    protected void Kaydet(object sender, EventArgs e)
    {
        if (irsaliyeKontrol())
        {
            string BitKm = "0";
            string BasKm = txtBasKm.Text;
            if (BasKm.Trim().Length == 0)
            {
                BasKm = "0";
            }
            else
            {
                BitKm = txtBitKm.Text;
                if (BitKm.Trim().Length == 0)
                {
                    BitKm = "0";
                }
                else
                {
                    f.cmd("Update Seferler Set Sefer_AktifPasif=0 where Sefer_Kodu=" + hdnseferkodu.Value);
                }
            }
            f.cmd("Update Seferler Set Sefer_MiktarKG=" + txtSeferMiktarKG.Text.tirnakla() + ",Sefer_MiktarLT=" + txtSeferMiktarLT.Text.tirnakla
                () + ",Sefer_IrsaliyeNo=" + txtIrsaliyeNo.Text.tirnakla() + ", Sefer_BasKm=" + BasKm + ", Sefer_BitKm=" + BitKm + " where Sefer_Kodu=" + hdnseferkodu.Value);
            Helper.mesaj(1, "Kayıt Güncelleme Başarılı");
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Helper.mesaj(0, "Bu irsaliye no daha önce kullanılmış");
        }
    }

    public void seferBilgileriniGetir()
    {
        DataTable dt = f.GetDataTable("select s.sefer_IrsaliyeNo,s.Sefer_BasKm,s.Sefer_BitKm,s.Sefer_MiktarKG,s.sefer_MiktarLT,s.Sefer_Kodu,s.Sefer_Tarih,s.Sefer_Arac,a.Arac_Plaka,s.Sefer_Cari,c.Cari_Unvan,s.Sefer_Personel,p.Personel_AdiSoyadi from Seferler s left join Cariler c on s.Sefer_Cari=c.Cari_Kodu  left join Personeller p on s.Sefer_Personel=p.Personel_Kodu left join Araclar a on s.Sefer_Arac=a.Arac_Plaka where Sefer_Personel=" + Request.Cookies["sofor"]["kullaniciadi"].ToString().tirnakla() + " and Sefer_AktifPasif=1 and sefer_kodu=" + Request.QueryString["seferkodu"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            hdnseferkodu.Value = dt.Rows[0]["Sefer_Kodu"].ToString();
            txtSeferSayisi.Text = dt.Rows[0]["Sefer_Kodu"].ToString();
            txtSeferTarihi.Text = dt.Rows[0]["Sefer_Tarih"].ToString().Split(' ')[0];
            txtSeferPersoneli.Text = dt.Rows[0]["Personel_AdiSoyadi"].ToString();
            txtMusteri.Text = dt.Rows[0]["Cari_Unvan"].ToString();
            txtSeferArac.Text = dt.Rows[0]["Arac_Plaka"].ToString();
            txtSeferMiktarKG.Text = dt.Rows[0]["Sefer_MiktarKG"].ToString();
            txtSeferMiktarLT.Text = dt.Rows[0]["Sefer_MiktarLT"].ToString();
            txtBasKm.Text = dt.Rows[0]["Sefer_BasKm"].ToString();
            txtBitKm.Text = dt.Rows[0]["Sefer_BitKm"].ToString();
            txtIrsaliyeNo.Text = dt.Rows[0]["Sefer_IrsaliyeNo"].ToString();
            txtBasKm.Text = txtBasKm.Text.Trim() == "0" ? "" : txtBasKm.Text;
            txtBitKm.Text = txtBitKm.Text.Trim() == "0" ? "" : txtBitKm.Text;
        }
        else
        {
            btnKaydet.Visible = false;
            Helper.mesaj(0, "Aktif Seferiniz Bulunmamaktadır.");
        }

    }
}