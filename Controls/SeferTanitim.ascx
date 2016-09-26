<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SeferTanitim.ascx.cs" Inherits="Controls_SeferTanitim" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Sefer Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Sefer Tanıtım Kartı
                </li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form id="frm" runat="server" class="form-horizontal" role="form">
                        <div class="col-md-6">
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <label class="col-md-4 control-label">Sefer Sayısı</label>
                                        <div class="col-md-8">
                                            <asp:TextBox Enabled="false" ID="txtSeferSayisi" runat="server" CssClass="form-control" required data-parsley-maxlength="5"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Tarih</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSeferTarihi" runat="server" CssClass="form-control tarih" required data-parsley-maxlength="11" placeholder data-mask="99/99/9999"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">İrsaliye No</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtIrsaliyeNo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Fatura</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtSeferFatura" CssClass="form-control" MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Personel</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpSeferPersoneli" CssClass="form-control select2 "></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Müşteri</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpMusteri" CssClass="form-control select2 zorunlu"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Arac</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpSeferArac" CssClass="form-control select2 zorunlu"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Lokasyon</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpSeferLokasyon" CssClass="form-control select2 zorunlu"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Miktar KG - LT</label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txtSeferMiktarKg" CssClass="form-control" MaxLength="7" placeholder="Miktar KG Yazınız..." data-parsley-type="number"></asp:TextBox>
                                </div>
                                 <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txtSeferMiktarLt" CssClass="form-control" MaxLength="7" placeholder="Miktar LT Yazınız..." data-parsley-type="number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Km</label>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txtBasKm" CssClass="form-control" MaxLength="7" placeholder="Başlangıç Km. Yazınız..."></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txtBitKm" CssClass="form-control" MaxLength="7" placeholder="Bitiş Km. Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Aktif/Pasif</label>
                                <div class="col-md-5">
                                    <asp:CheckBox ID="chcAktifPasif" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" type="submit" CssClass="btn btn-info waves-light " OnClick="Kaydet" Text="Kaydet" />
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
                <table id="datatable" class="table datatable table-striped table-bordered myTable">
                    <thead>
                        <tr>
                            <th>Kodu</th>
                            <th>Tarihi</th>
                            <th>İrsaliye No</th>
                            <th>Fatura No</th>
                            <th>Müşteri</th>
                            <th>Arac</th>
                            <th>Personel</th>
                            <th>Lokasyon</th>
                            <th>Durum</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Sefer_Kodu") %></td>
                                    <td><%#Eval("Sefer_Tarih").ToString().Split(' ')[0]%></td>
                                    <td><%#Eval("Sefer_IrsaliyeNo")%></td>
                                    <td><%#Eval("Sefer_Fatura")%></td>
                                    <td><%#Eval("Cari_Unvan")%></td>
                                    <td><%#Eval("Arac_Plaka") %></td>
                                    <td><%#Eval("Personel_AdiSoyadi")%></td>
                                    <td><%#Eval("Lokasyon_Aciklama")%></td>
                                    <td><%#Eval("Sefer_AktifPasif").ToString().ToLower().Replace("false","Pasif").Replace("true","Aktif")%></td>

                                    <td>
                                        <a href="Default.aspx?sayfa=SeferTanitim&id=<%#Eval("Id")%>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                        <a href="javascript:;" class="btn btn-icon waves-effect waves-light btn-danger" onclick="confirmSil(this,'<%#Eval("Id")%>','Seferler','Id')"><i class="fa fa-remove"></i></a>
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
