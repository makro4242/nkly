<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CariTanitim.ascx.cs" Inherits="Controls_CariTanitim" %>
<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Cari Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Cari Tanıtım Kartı
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
                                <label class="col-md-2 control-label">Kodu</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtCariKodu" runat="server" CssClass="form-control zorunlu cariTamamla"  required data-parsley-maxlength="25" placeholder="Carinin Kodunu Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Ünvanı</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariUnvan" CssClass="form-control zorunlu" data-parsley-maxlength="150" placeholder="Ünvanı Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Tipi</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpTipi" CssClass="form-control zorunlu" required>
                                        <asp:ListItem Value="-1" Text="Seçiniz"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Müşteri"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Satıcı"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">V.Dairesi</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtVergiDairesi" class="form-control" data-parsley-maxlength="50" placeholder="Vergi Dairesini Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Vergi No</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtVergiNo" class="form-control" data-mask="99999999999" data-parsley-maxlength="50" placeholder="Vergi Noyu Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Yetkili</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariYetkili" class="form-control" data-parsley-maxlength="50" placeholder="Yetkiliyi Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Yetkili Gsm</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariYetkiliGsm" class="form-control"  data-parsley-maxlength="14" placeholder="Yetkili Gsm Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">

                            <div class="form-group">
                                <label class="col-md-2 control-label">Tel-1</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariTel1" class="form-control" data-parsley-maxlength="14" placeholder="Telefon Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Tel-2</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariTel2" class="form-control"  data-parsley-maxlength="14" placeholder="Telefon Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Tel-3</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariTel3" class="form-control"  data-parsley-maxlength="14" placeholder="Telefon Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Adres</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariAdres" class="form-control " data-parsley-maxlength="250" placeholder="Adres Yazınız..." TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 p0">
                                    <label class="col-md-4 control-label">İl</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtIl" class="form-control " data-parsley-maxlength="50" placeholder="İl Yazınız..."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 p0">
                                    <label class="col-md-4 control-label">İlçe</label>
                                    <div class="col-md-8">
                                        <asp:TextBox runat="server" ID="txtIlce" class="form-control " data-parsley-maxlength="50" placeholder="İlçe Yazınız..."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Not</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtCariNot" class="form-control " data-parsley-maxlength="250" placeholder="Not Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">E-Mail</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="E-mail adresi yazınız."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" type="submit" class="btn btn-info waves-light " OnClick="Kaydet" Text="Kaydet" />
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
                            <th>Kodu</th>
                            <th>Ünvanı</th>
                            <th>Tipi</th>
                            <th>Bakiyesi</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Cari_Kodu") %></td>
                                    <td><%#Eval("Cari_Unvan")%></td>
                                    <td><%#tipyaz(Eval("Cari_Tipi").ToString())%></td>
                                    <td><%#Eval("Cari_Tipi") %></td>
                                    <td>
                                        <a href="Default.aspx?sayfa=CariTanitim&id=<%#Eval("Id") %>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id") %>','Cariler','Id')"><i class="fa fa-remove"></i></a>
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

<!-- container -->
