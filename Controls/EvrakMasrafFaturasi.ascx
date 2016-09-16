KDV Hariç Tutar<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EvrakMasrafFaturasi.ascx.cs" Inherits="Controls_EvrakMasrafFaturasi" %>
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
                    <form class="frmMasraf">
                        <div class="row form-horizontal">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Evrak No</label>
                                    <div class="col-md-4">
                                        <input type="text" id="txtEvrakno" name="evrakNo" class="form-control kitle" required data-parsley-maxlength="25" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Tarih</label>
                                    <div class="col-md-4">
                                        <div class="input-group">
                                            <input type="text" id="txtFaturaTarihi" name="faturaTarihi" class="form-control tarih kitle" required data-parsley-maxlength="25" />
                                            <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Cari Ünvan</label>
                                    <div class="col-md-8">
                                        <select name="cariKodu" id="drpCariKodu" class="form-control select2 kitle" required>
                                            <%=drpCariler %>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">Masraf</label>
                                    <div class="col-md-12">
                                        <select name="masrafKodu" id="drpMasraf" required class="form-control select2 temizle">
                                            <%=drpMasraflar %>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">

                                <div class="form-group">
                                    <label class="control-label col-md-12">Araç</label>
                                    <div class="col-md-12">
                                        <select name="aracPlaka" id="drpArac" required class="form-control select2 temizle">
                                            <%=drpAraclar %>
                                        </select>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">Masraf Ay</label>
                                    <div class="col-md-12">
                                        <select name="taksitSayisi" id="drpTaksit" required class="form-control select2 temizle">
                                            <option value="">Seçiniz</option>
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            <option value="6">6</option>
                                            <option value="7">7</option>
                                            <option value="8">8</option>
                                            <option value="9">9</option>
                                            <option value="10">10</option>
                                            <option value="11">11</option>
                                            <option value="12">12</option>
                                        </select>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label class="control-label col-md-12">KM</label>
                                    <div class="col-md-12">
                                        <input type="text" data-parsley-type="number" required id="txtKm" name="km" class="form-control text-right temizle" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">KDV %</label>
                                    <div class="col-md-12">
                                        <select name="kdv" id="drpKDV" required class="form-control select2 temizle">
                                            <option value="">Seçiniz </option>
                                            <option value="0">0</option>
                                            <option value="1">1</option>
                                            <option value="8">8</option>
                                            <option value="18">18 </option>

                                        </select>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">KDV Hariç Tutar</label>
                                    <div class="col-md-12">
                                        <input type="text" data-parsley-type="number" required id="txtTutar" name="tutar" class="form-control text-right temizle" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <label class="control-label col-md-12">&nbsp;</label>
                                <button class="btn btn-info waves-light pull-right msrfEkle">EKLE</button>
                            </div>

                        </div>
                        <hr />
                        
                    </form>
                    <div class="col-md-12 masrafListele"></div>
                    <hr />
                    <form id="frm" runat="server" role="form">
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
                                        <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-info waves-light pull-right" OnClick="Kaydet" Text="Yeni Fatura" />
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
                            <th>Cari</th>
                            <th>KM</th>
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
                                    <td><%#Eval("km")%></td>
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
