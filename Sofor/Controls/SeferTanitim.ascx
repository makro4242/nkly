<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SeferTanitim.ascx.cs" Inherits="Sofor_Controls_SeferTanitim" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Sefer Tanıtım Kartı</h4>
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

                                    <label class="col-md-3 control-label">Sefer Sayısı</label>
                                    <div class="col-md-4">
                                        <asp:TextBox Enabled="false" ID="txtSeferSayisi" runat="server" CssClass="form-control" required data-parsley-maxlength="5"></asp:TextBox>
                                    </div>

                                </div>

                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Tarih</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSeferTarihi" Enabled="false" runat="server" CssClass="form-control tarih"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">İrsaliye No</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtIrsaliyeNo" runat="server" CssClass="form-control" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Personel</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" Enabled="false" ID="txtSeferPersoneli" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">Müşteri</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" Enabled="false" ID="txtMusteri" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">

                                <label class="col-md-3 control-label">Arac</label>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" Enabled="false" ID="txtSeferArac" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <label class="col-md-6 control-label">Miktar KG</label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtSeferMiktarKG" CssClass="form-control" data-parsley-type="number"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label class="col-md-6 control-label">Miktar LT</label>
                                    <div class="col-md-6">
                                        <asp:TextBox runat="server" ID="txtSeferMiktarLT" CssClass="form-control" data-parsley-type="number"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">Km</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtBasKm" CssClass="form-control" MaxLength="7" placeholder="Başlangıç Km. Yazınız..." data-parsley-type="number"></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" ID="txtBitKm" CssClass="form-control" MaxLength="7" placeholder="Bitiş Km. Yazınız..." data-parsley-type="number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" type="submit" CssClass="btn btn-info waves-effect waves-light " OnClick="Kaydet" Text="Kaydet" />
                                </div>
                            </div>
                            <asp:HiddenField runat="server" ID="hdnseferkodu" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

