<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fatura-sec.ascx.cs" Inherits="Controls_fatura_sec" %>
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
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Evrak No</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtEvrakNo" runat="server" CssClass="form-control" required data-parsley-maxlength="25"></asp:TextBox>
                                    </div>
                                    <label class="col-md-2 control-label">Evrak No 2</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtEvrakNo2" runat="server" CssClass="form-control" data-parsley-maxlength="25"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-md-12">* Birden Fazla Fatura Çıktısı Almak İçin Evrak No Aralığı Giriniz</label>
                                    <label class="col-md-12">* Tek Fatura Çıktısı Almak İçin Evrak No'yu Giriniz</label>
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
                                        <asp:Button ID="btnKaydet" runat="server" OnClick="btnKaydet_Click" CssClass="btn btn-info waves-light pull-right" Text="Fatura(ları) Getir" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>

</div>
