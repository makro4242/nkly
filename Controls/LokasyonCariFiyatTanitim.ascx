<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LokasyonCariFiyatTanitim.ascx.cs" Inherits="Controls_LokasyonCariFiyatTanitim" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Lokasyon-Cari-Fiyat Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Lokasyon-Cari-Fiyat Tanıtım Kartı
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
                                <label class="col-md-2 control-label">Lokasyon</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpLokasyon" CssClass="form-control zorunlu select2" required data-parsley-maxlength="10" placeholder="Lokasyon Seçiniz..."></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label ">Cari</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpMusteri" CssClass="form-control zorunlu select2" required data-parsley-maxlength="10" placeholder="Cari Seçiniz..."></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Fiyat</label>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="txtLokFiyat" CssClass="form-control zorunlu select2" required data-parsley-maxlength="10" placeholder="Fiyat Yazınız..."></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <div class="radio radio-info radio-inline">
                                        <asp:RadioButton runat="server" ID="rdbKG" GroupName="rdbFiyat" />
                                        <label for="<%=rdbKG.ClientID %>">
                                            KG
                                        </label>
                                    </div>

                                    <div class="radio radio-info radio-inline">
                                        <asp:RadioButton runat="server" ID="rdbLT" GroupName="rdbFiyat" />
                                        <label for="<%=rdbLT.ClientID %>">
                                            LT
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label"></label>
                                <div class="checkbox col-md-10 checkbox-primary">
                                    <asp:CheckBox runat="server" ID="chxPaketFiyati" />
                                    <label for="<%=chxPaketFiyati.ClientID %>">
                                        Paket Fiyatı
                                    </label>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-info waves-light" OnClick="Kaydet" Text="Kaydet" />
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
                            <th>Lokasyon</th>
                            <th>Cari</th>
                            <th>Fiyat</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Lokasyon_Aciklama") %></td>
                                    <td><%#Eval("Cari_Unvan")%></td>
                                    <td><%#Eval("Lok_Fiyat")%></td>
                                    <td>
                                        <a href="Default.aspx?sayfa=LokasyonCariFiyatTanitim&id=<%#Eval("Id") %>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id") %>','LokasyonCariFiyat','Id')"><i class="fa fa-remove"></i></a>
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

