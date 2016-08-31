<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Fatura-goruntule.ascx.cs" Inherits="Controls_Fatura_goruntule" %>

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
    <div class="row" id="yazdir">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form id="frm" runat="server" class="form-horizontal" role="form">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Evrak No</label>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblEvrakNo" runat="server" Text="abc"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Tarih</label>
                                    <div class="col-md-4">
                                        <div class="input-group">
                                            <asp:Label ID="lblTarih" runat="server" Text="abc"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Cari Ünvan</label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblCariUnvan" runat="server" Text="abc"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table class="table table-striped m-b-0">
                                        <thead>
                                            <tr>
                                                <th>Hizmet</th>
                                                <th>Miktar</th>
                                                <th>Fiyat</th>
                                                <th>Tutar</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptgoruntule">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>Nakliye Bedeli</td>
                                                        <td><%#Eval("Sefer_Miktar") %></td>
                                                        <td><%#Eval("Cari_Tutar") %></td>
                                                        <td><%#fiyatmiktarcarp(Eval("Sefer_miktar"),Eval("Cari_Tutar")) %></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-4 pull-right">
                                <table class="table m-b-0">
                                    <tr>
                                        <td><b>Ara Toplam</b></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblAraToplam" Style="text-align: right"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><b>KDV</b></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblKdv" Style="text-align: right"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><b>Genel Toplam</b></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblGenToplam" Style="text-align: right"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                        <hr />

                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 pull-right">
            <div class="form-group">
                <label class="col-md-6 control-label"></label>
                <div class="col-md-6">
                    <button type="button" class="btn btn-success waves-effect waves-light" onclick="PrintElem('#yazdir');return false">
                        <span class="btn-label"><i class="ion-printer"></i>
                        </span>Yazdır</button>
                   
                </div>
            </div>
        </div>
    </div>
</div>

