<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Fatura.ascx.cs" Inherits="Controls_Fatura" %>
<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Fatura</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Fatura
                </li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form id="frm" runat="server" class="form-horizontal" role="form">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Evrak No</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtEvrakNo" runat="server" CssClass="form-control" required data-parsley-maxlength="25"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Tarih</label>
                                    <div class="col-md-4">
                                        <div class="input-group">
                                            <asp:TextBox ID="txtFaturaTarihi" runat="server" CssClass="form-control tarih zorunlu" required data-parsley-maxlength="11" placeholder data-mask="99/99/9999"></asp:TextBox>
                                            <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                        </div>
                                    </div>
                                </div>



                            </div>

                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                                <table id="dtSeferler" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>
                                            <th style="display: none"></th>
                                            <th>Hizmet</th>
                                            <th>Tarih</th>
                                            <th>Cari</th>
                                            <th>Miktar KG</th>
                                            <th>Miktar LT</th>
                                            <th>Fiyat</th>
                                            <th style="display: none">FiyatSayi</th>
                                            <th>Tutar</th>
                                            <th style="display: none">TutarSayi</th>
                                            <th>İrsaliye No</th>
                                            <th>Araç</th>
                                            <th>Personel</th>
                                            <th>Km</th>
                                            <th>Lokasyon</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater runat="server" ID="rptSeferler">
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="display: none"><%#Eval("sefer_kodu") %></td>
                                                    <td>Nakliye Bedeli</td>
                                                    <td><%#Eval("sefer_tarih").ToString().Split(' ')[0] %></td>
                                                    <td><%#Eval("Cari_Unvan") %></td>
                                                    <td><%#Eval("Sefer_miktarKG") %></td>
                                                    <td><%#Eval("Sefer_miktarLT") %></td>
                                                    <td><%#Eval("Fiyat") %></td>
                                                    <td style="display: none;"><%#Eval("Fiyat") %></td>
                                                    <td><%#tutarBelirle(Eval("sefer_miktarKg"),Eval("sefer_miktarLT"),Eval("Lok_fiyat_tip"),Eval("Fiyat"),Eval("lok_Paket")) %></td>
                                                    <td style="display: none;"><%#Eval("Fiyat") %></td>
                                                    <td><%#Eval("Sefer_IrsaliyeNo") %></td>
                                                    <td><%#Eval("arac_plaka") %></td>
                                                    <td><%#Eval("personel_adiSoyadi") %></td>
                                                    <td><%#Eval("Sefer_bitkm") %></td>
                                                    <td><%#Eval("lokasyon_aciklama") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 pull-right">
                                <div class="form-group">
                                    <label class="col-md-6 control-label">Ara Toplam</label>
                                    <div class="col-md-6">
                                        <span class="spnAraToplam form-control" style="text-align: right"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-6 control-label">Kdv</label>
                                    <div class="col-md-6">
                                        <span class="spnKdv form-control" style="text-align: right"></span>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-6 control-label">Genel Toplam</label>
                                    <div class="col-md-6">
                                        <span class="spnGenToplam form-control" style="text-align: right"></span>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 pull-right">
                                <div class="form-group">
                                    <label class="col-md-6 control-label"></label>
                                    <div class="col-md-6">
                                        <asp:HiddenField runat="server" ID="hdnSeferler" />
                                        <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-info waves-light pull-right" OnClick="Kaydet" OnClientClick="return seferKontrol()" Text="Kaydet" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <table id="datatable" class="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th>Evrak No</th>
                            <th>Tarih</th>
                            <th>Cari
                            </th>
                            <th>Ara Toplam</th>
                            <th>KDV</th>
                            <th>Genel Toplam</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("chh_evrakno_sira") %></td>
                                    <td><%#Eval("chh_tarihi")%></td>
                                    <td><%#Eval("cari_unvan")%></td>
                                    <td><%#Eval("chh_aratoplam")%></td>
                                    <td><%#Eval("chh_ft_kdv")%></td>
                                    <td><%#Eval("chh_geneltoplam")%></td>

                                    <td>
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("chh_kayno") %>','cari_hesap_hareketleri','chh_kayno')"><i class="fa fa-remove"></i></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function seferKontrol() {
        var k = '<%=hdnSeferler.ClientID%>';
        return fnFaturaKontrol(k);
    }



</script>
