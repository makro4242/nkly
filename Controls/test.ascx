<%@ Control Language="C#" AutoEventWireup="true" CodeFile="test.ascx.cs" Inherits="Controls_test" %>
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
    <div id="yazdir" style="background-color: #fff; width: 812px; float: left;">
        <asp:Repeater runat="server" ID="rptFatura" OnItemDataBound="fatura_bagla">
            <ItemTemplate>

                <div style="height: 525.35433071px;float:left; width: 812px; padding-left: 85px; border-bottom: 1px solid #000">
                    <div style="height: 120px;float:left;width:100%;">&nbsp;</div>
                    <div style="height: 135px;float:left;width:100%;">
                        <div style="width: 50%; float: left; padding-top: 35px;">
                            <div style="padding-left: 30px;"><%#Eval("cari_unvan") %></div>
                            <div style="padding-left: 30px;"><%#Eval("cari_adres") %></div>

                        </div>
                        <div style="width: 50%; float: left; margin-top: 60px; text-align: right;">
                            <div style="margin-top: 35px; margin-right: 50px; margin-bottom: 5px;">
                                31.05.2016
                            </div>
                            <div style="margin-right: 80px;">
                                3327
                            </div>
                        </div>
                    </div>

                    <div style="height: 150px; float:left;width:100%;">

                        <asp:Repeater runat="server" ID="rptgoruntule">
                            <ItemTemplate>
                                <div style="height: 25px;">
                                    <div style="width: 400px; float: left;">&emsp;Nakliye Bedeli</div>
                                    <div style="width: 70px; float: left;"><%#String.Format("{0:N}",Eval("Sefer_Miktar")) %></div>
                                    <div style="width: 120px; float: left; text-align: right;"><%#String.Format("{0:N}",Eval("chh_aratoplam")) %></div>
                                    <div style="width: 120px; float: left; text-align: right;"><%#String.Format("{0:N}",Eval("chh_genelToplam")) %></div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>

                    </div>

                    <div style="height: 95px;float:left;width:100%;">
                        <div style="width: 400px; float: left;">
                            <br />
                            <div>&emsp;YALNIZ <%#Helper.yaziyaCevir(Convert.ToDecimal(Eval("genelToplam"))) %></div>
                            <div>&emsp;Banka İban Bilgilerimiz Süleyman POÇAN</div>
                            <div>
                                &emsp;TEB Konya Şubesi TR02 003 2000 0000 0032 7094 49
                            </div>

                        </div>
                        <div style="width: 70px; float: left; text-align: right;">&nbsp;</div>
                        <div style="width: 120px; float: left; text-align: right;">
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
                        <div style="width: 120px; float: left; text-align: right;">
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
