<%@ Control Language="C#" AutoEventWireup="true" CodeFile="coklu-fatura-goruntule.ascx.cs" Inherits="Controls_coklu_fatura_goruntule" %>
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
    <div id="yazdir" style="background-color: #fff">
        <asp:Repeater runat="server" ID="rptFatura" OnItemDataBound="fatura_bagla">
            <ItemTemplate>
                <div class="row" style="height: 635px; padding-top: 125px; padding-left: 75px;">
                    <div class="col-sm-12">
                        <div class="card-box">
                            <div class="row">
                                <div class="row">
                                    <div style="width: 50%; float: left">
                                        <table class="table tblUnvan">
                                            <tbody>
                                                <tr style="padding-left: 30px;">
                                                    <td><%#Eval("cari_unvan") %></td>
                                                </tr>
                                                <tr>
                                                    <td><%#Eval("cari_adres") %></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div style="width: 50%; float: left">
                                        <table class="table tblTarih">
                                            <tbody>
                                                <tr>
                                                    <td>31.05.2016</td>
                                                </tr>
                                                <tr>
                                                    <td>3327</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-md-12" style="min-height: 130px;">

                                        <asp:Repeater runat="server" ID="rptgoruntule">
                                            <ItemTemplate>
                                                <div class="row">
                                                    <div style="width: 380px; float: left; padding-left: 20px;">&emsp;Nakliye Bedeli</div>
                                                    <div style="width: 70px; float: left;"><%#String.Format("{0:N}",Eval("Sefer_Miktar")) %></div>
                                                    <div style="width: 125px; float: left; text-align: right;"><%#String.Format("{0:N}",Eval("chh_aratoplam")) %></div>
                                                    <div style="width: 105px; float: left; text-align: right;"><%#String.Format("{0:N}",Eval("chh_genelToplam")) %></div>
                                                </div>

                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div style="width: 380px; float: left; padding-left: 20px;">
                                        <br />
                                        <div>&emsp;YALNIZ <%#Helper.yaziyaCevir(Convert.ToDecimal(Eval("genelToplam"))) %></div>
                                        <div>&emsp;Banka İban Bilgilerimiz Süleyman POÇAN</div>
                                        <div>
                                            &emsp;TEB Konya Şubesi TR02 003 2000 0000 0032 7094 49
                                        </div>
                                    </div>
                                    <div style="width: 85px; float: left;">&nbsp;</div>
                                    <div style="width: 125px; float: left;">
                                        <div>
                                            ARA TOPLAM
                                        </div>
                                        <div>
                                            K.D.V
                                        </div>
                                        <div>
                                            G.TOPLAM
                                        </div>
                                    </div>
                                    <div style="width: 105px; float: left; text-align: right;">
                                        <div>
                                            <%#String.Format("{0:N}",Eval("aratoplam")) %>
                                        </div>
                                        <div>
                                            <%#String.Format("{0:N}",Eval("kdv")) %>
                                        </div>
                                        <div>
                                            <%#String.Format("{0:N}",Eval("geneltoplam")) %>
                                        </div>
                                    </div>


                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

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
