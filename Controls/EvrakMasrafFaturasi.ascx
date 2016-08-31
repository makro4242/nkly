<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EvrakMasrafFaturasi.ascx.cs" Inherits="Controls_EvrakMasrafFaturasi" %>
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
                    <form id="frm" runat="server" role="form">
                        <div class="row form-horizontal">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Evrak No</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtEvrakNo" runat="server" CssClass="form-control zorunlu" required data-parsley-maxlength="25"></asp:TextBox>
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
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Cari Ünvan</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList runat="server" required ID="drpCariUnvan" CssClass="form-control select2 drpCari zorunlu"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <hr />
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">Masraf</label>
                                    <div class="col-md-12">
                                        <asp:DropDownList runat="server" ID="drpMasraf" required CssClass="form-control select2 zorunlu">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">

                                <div class="form-group">
                                    <label class="control-label col-md-12">Araç</label>
                                    <div class="col-md-12">
                                        <asp:DropDownList runat="server" ID="drpArac" required CssClass="form-control select2 zorunlu">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-12">Masraf Ay</label>
                                        <div class="col-md-12">
                                            <asp:DropDownList runat="server" ID="drpTaksit" required CssClass="form-control select2 zorunlu">
                                                <asp:ListItem Text="Seçiniz" Value=""></asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label col-md-12">KM</label>
                                        <div class="col-md-12">
                                            <asp:TextBox runat="server" data-parsley-type="number" required ID="txtKM" CssClass="form-control text-right"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">KDV %</label>
                                    <div class="col-md-12">
                                        <asp:DropDownList runat="server" ID="drpKDV" required CssClass="form-control drpKdv zorunlu">
                                            <asp:ListItem Text="Seçiniz" Value=""></asp:ListItem>
                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label class="control-label col-md-12">KDV Hariç Tutar</label>
                                    <div class="col-md-12">
                                        <asp:TextBox runat="server" ID="txtTutar" required Style="text-align: right" CssClass="form-control txtMasraf zorunlu" data-parsley-type="number">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr />
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
                                        <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-info waves-effect waves-light pull-right" OnClick="Kaydet" Text="Kaydet" />
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
