<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KarlilikRaporu.ascx.cs" Inherits="Controls_KarlilikRaporu" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Karlılık Raporu</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Raporlar</a>
                </li>
                <li class="active">Karlılık Raporu
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
                            <div class="form-group">
                                <label class="col-md-2 control-label">İlk Tarih</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtilkTarih" runat="server" CssClass="form-control tarih" required data-parsley-maxlength="11" placeholder data-mask="99/99/9999"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                    </div>
                                </div>
                                <label class="col-md-2 control-label">Son Tarih</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSonTarih" runat="server" CssClass="form-control tarih" required data-parsley-maxlength="11" placeholder data-mask="99/99/9999"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Kriter</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpKriterListesi" CssClass="form-control select2" OnSelectedIndexChanged="drpfiltreicin" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Filtre</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpFiltreListesi" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnRaporla" runat="server" type="submit" CssClass="btn btn-info waves-light " OnClick="Raporla" Text="Raporla" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlAraclar" runat="server">
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <table id="dtAraclar" class="table table-striped table-bordered myTable">
                        <thead>
                            <tr>
                                <th>Plaka</th>
                                <th>Kar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptAracKayitlari">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("chh_AracPlaka") %></td>
                                        <td><%#Eval("Kar-Zarar") %></td>
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
    </asp:Panel>
    <asp:Panel ID="pnlPersonel" runat="server">
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <table id="dtPersonel" class="table table-striped table-bordered myTable">
                        <thead>
                            <tr>
                                <th>PersonelKodu</th>
                                <th>Kar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="Repeater1">
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
    </asp:Panel>
</div>
