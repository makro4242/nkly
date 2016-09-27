using iTextSharp.text;
using iTextSharp.text.pdf;
using myLibrary;
using System;
using System.Data;
using System.IO;

public partial class pdf : System.Web.UI.Page
{
    public class myList
    {
        public PdfWriter writer { get; set; }
        public iTextSharp.text.Document pdf { get; set; }
        public myList(PdfWriter writer, iTextSharp.text.Document pdf)
        {
            this.writer = writer;
            this.pdf = pdf;
        }
    }
    myDbHelper db = new myDbHelper(new sqlDbHelper());
    BaseFont trArial;
    iTextSharp.text.Font fontArial;
    iTextSharp.text.Font fontArialKucuk;
    iTextSharp.text.Font fontArialHeader;
    string dosya = "fatura.pdf";

    protected void Page_Load(object sender, EventArgs e)
    {
        trArial = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        fontArial = new iTextSharp.text.Font(trArial, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        fontArialKucuk = new iTextSharp.text.Font(trArial, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        fontArialHeader = new iTextSharp.text.Font(trArial, 13, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
        if (Request.QueryString["evrakno1"] != null && Request.QueryString["evrakno2"] != null)
        {
            iTextSharp.text.Document pdf = faturalariGetir();
            FileInfo file = new FileInfo(Server.MapPath("~/images/" + dosya));

            if (file.Exists)
            {

                Response.ContentType = "application/pdf";



                Response.Clear();


                Response.TransmitFile(file.FullName);

                Response.End();

            }
        }
    }
    public iTextSharp.text.Document faturalariGetir()
    {
        iTextSharp.text.Document pdf = null;
        DataTable dt = db.exReaderDT(CommandType.Text, "select ca.cari_unvan,ca.cari_adres, ch.chh_tarihi,sum(ch.chh_aratoplam) as aratoplam,sum(ch.chh_ft_kdv) as kdv,sum(ch.chh_geneltoplam) as geneltoplam,ch.chh_evrakno_sira from cari_hesap_hareketleri ch,cariler ca where ca.cari_kodu=ch.chh_cari_kodu and ch.chh_evrakno_sira in(select distinct(chh_evrakno_sira) from cari_hesap_hareketleri where chh_evrakno_sira>=@evrakno1 and chh_evrakno_sira<=@evrakno2) group by chh_evrakno_sira,chh_cari_kodu,chh_tarihi,cari_unvan,cari_adres", "evrakno1=" + Request.QueryString["evrakno1"].ToString() + ",evrakno2=" + Request.QueryString["evrakno2"]);
        if (dt != null && dt.Rows.Count > 0)
        {
            myList lst = pdfOlustur();
            pdf = lst.pdf;
            PdfWriter writer = lst.writer;
            int sayac = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (sayac > 0)
                {
                    pdf.NewPage();
                }
                PdfPTable tblUst = ustTableGetir(item["cari_unvan"].ToString(), item["cari_adres"].ToString(), item["chh_tarihi"].ToString().Split(' ')[0], item["chh_evrakno_sira"].ToString());
                pdf.Open();
                pdf.Add(tblUst);
                PdfPTable tblSatirlar = fatura_bagla(item["chh_evrakno_sira"].ToString());
                if (tblSatirlar != null)
                {
                    pdf.Add(tblSatirlar);
                }
                PdfPTable tblAltSatir = footerTableGEtir((float)Convert.ToDouble(item["aratoplam"]), (float)Convert.ToDouble(item["kdv"]), (float)Convert.ToDouble(item["geneltoplam"]));
                tblAltSatir.WriteSelectedRows(0, -1, (int)((pdf.PageSize.Width - tblAltSatir.TotalWidth) / 2), (pdf.Bottom + 65), writer.DirectContent);
                sayac++;
            }
            pdf.Close();

        }
        return pdf;
    }
    protected PdfPTable fatura_bagla(string evrakno)
    {
        PdfPTable table = null;

        DataTable dt = db.exReaderDT(CommandType.Text, "select ch.chh_tarihi,c.Cari_Unvan,c.cari_adres,ch.chh_evrakno_sira,sf.Sefer_MiktarKG as sefer_miktar,ch.chh_geneltoplam,ch.chh_aratoplam,ch.chh_ft_kdv from Cari_Hesap_Hareketleri ch, Cariler c, Seferler sf where ch.chh_SeferNo=sf.Sefer_Kodu and ch.chh_cari_kodu=c.Cari_Kodu and ch.chh_evrakno_sira=" + evrakno);
        if (dt != null && dt.Rows.Count > 0)
        {
            table = hizmetSatirGetir(dt);
        }
        return table;
    }
    public myList pdfOlustur()
    {

        if (File.Exists(Server.MapPath("~/images/" + dosya)))
        {
            File.Delete(Server.MapPath("~/images/" + dosya));
        }
        Rectangle mySize = new Rectangle(PageSize.A4.Width, 297.5f);
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document(mySize, 0, 0, 28, 0);
        PdfWriter writer = PdfWriter.GetInstance(pdfDosya, new FileStream(Server.MapPath("~/images/" + dosya), FileMode.CreateNew));
        myList lst = new myList(writer, pdfDosya);
        return lst;
    }
    public PdfPTable ustTableGetir(string cari, string cariAdres, string tarih, string belgeNo)
    {
        PdfPTable table = new PdfPTable(3);
        table.HorizontalAlignment = 0;
        table.DefaultCell.Border = 0;
        table.SetWidths(new float[] { 310, 190, 95 });

        table.TotalWidth = 595;
        table.LockedWidth = true;


        PdfPCell cell = new PdfPCell(new Phrase(cari, fontArial));
        cell.Border = 0;
        cell.PaddingLeft = 55;
        cell.Colspan = 1;
        cell.HorizontalAlignment = 0;
        table.AddCell(cell);
        table.AddCell(new Phrase(""));
        table.AddCell(new Phrase(""));


        cell = new PdfPCell(new Phrase(cariAdres, fontArial));
        cell.PaddingLeft = 55;
        cell.Colspan = 1;
        cell.Border = 0;
        cell.HorizontalAlignment = 0;
        table.AddCell(cell);
        table.AddCell(new Phrase(""));

        cell = new PdfPCell(new Phrase(tarih + Environment.NewLine + belgeNo, fontArialKucuk));
        cell.Border = 0;
        cell.HorizontalAlignment = 0;
        cell.PaddingTop = 15;
        table.AddCell(cell);

        return table;
    }

    public PdfPTable footerTableGEtir(float araToplam, float kdv, float genelToplam)
    {
        PdfPTable tabFot = new PdfPTable(new float[] { 235, 65, 90, 80 });
        tabFot.DefaultCell.Border = 0;
        tabFot.TotalWidth = 560;
        tabFot.LockedWidth = true;
        PdfPCell cell = new PdfPCell(new Phrase("Yalnız Bin Beşyüzelli. TL Elliiki Kr.", fontArial));
        cell.Border = 0;
        cell.PaddingLeft = 40;
        cell.HorizontalAlignment = 0;
        tabFot.AddCell(cell);


        tabFot.AddCell(new Phrase(""));


        cell = new PdfPCell(new Phrase("ARA TOPLAM", fontArialKucuk));
        cell.Border = 0;
        cell.HorizontalAlignment = 0;
        tabFot.AddCell(cell);

        cell = new PdfPCell(new Phrase(String.Format("{0:N}", araToplam), fontArialKucuk));
        cell.Border = 0;
        cell.PaddingRight = 30;
        cell.HorizontalAlignment = 2;
        tabFot.AddCell(cell);



        cell = new PdfPCell(new Phrase("Banka İban Bilgilerimiz Süleyman POÇAN", fontArial));
        cell.Border = 0;
        cell.PaddingLeft = 40;
        cell.HorizontalAlignment = 0;
        tabFot.AddCell(cell);



        cell = new PdfPCell(new Phrase("", fontArial));
        cell.Colspan = 1;
        cell.Border = 0;
        cell.HorizontalAlignment = 0;
        tabFot.AddCell(cell);

        cell = new PdfPCell(new Phrase("K.D.V.% 18..", fontArialKucuk));
        cell.Border = 0;
        cell.HorizontalAlignment = 0;
        tabFot.AddCell(cell);

        cell = new PdfPCell(new Phrase(String.Format("{0:N}", kdv), fontArialKucuk));
        cell.Border = 0;
        cell.HorizontalAlignment = 2;
        cell.PaddingRight = 30;
        tabFot.AddCell(cell);



        cell = new PdfPCell(new Phrase("TEB KONYA Şubesi TR02 0003 2000 0000 0032 7094 49", fontArial));

        cell.Border = 0;
        cell.PaddingLeft = 40;
        cell.HorizontalAlignment = 0;
        tabFot.AddCell(cell);

        tabFot.AddCell(new Phrase(""));

        cell = new PdfPCell(new Phrase("GENEL TOPLAM", fontArialKucuk));
        cell.Border = 0;
        cell.HorizontalAlignment = 0;

        tabFot.AddCell(cell);
        cell = new PdfPCell(new Phrase(String.Format("{0:N}", genelToplam), fontArialKucuk));
        cell.Border = 0;
        cell.PaddingRight = 30;
        cell.HorizontalAlignment = 2;
        tabFot.AddCell(cell);


        return tabFot;
    }

    public PdfPTable hizmetSatirGetir(DataTable dt)
    {
        PdfPTable table = new PdfPTable(4);
        table.SpacingBefore = 40;
        table.DefaultCell.Border = 0;
        table.SetWidths(new float[] { 235, 65, 90, 80 });
        table.TotalWidth = 560;
        table.LockedWidth = true;

        foreach (DataRow item in dt.Rows)
        {
            PdfPCell cell = new PdfPCell(new Phrase("AKARYAKIT NAKLİYE BEDELİ", fontArial));
            cell.Border = 0;
            cell.PaddingLeft = 40;
            cell.HorizontalAlignment = 0;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(item["sefer_miktar"].ToString(), fontArial));
            cell.Colspan = 1;
            cell.Border = 0;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);

            float kdv = (float)Convert.ToDouble(item["chh_ft_kdv"]);
            cell = new PdfPCell(new Phrase(String.Format("{0:N}", kdv), fontArialKucuk));
            cell.Border = 0;
            cell.HorizontalAlignment = 0;
            table.AddCell(cell);

            float araToplam = (float)Convert.ToDouble(item["chh_aratoplam"]);
            cell = new PdfPCell(new Phrase(String.Format("{0:N}", araToplam), fontArialKucuk));
            cell.Border = 0;
            cell.PaddingRight = 30;
            cell.HorizontalAlignment = 2;
            table.AddCell(cell);
        }
        return table;
    }

}