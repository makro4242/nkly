<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonelTanitim.ascx.cs" Inherits="PersonelTanitim" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Personel Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Personel Tanıtım Kartı
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
                                    <asp:TextBox ID="txtPersonelKodu" runat="server" CssClass="form-control" required data-parsley-maxlength="20" placeholder="Personel Kodunu Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Adı Soyadı</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtPersonelAdiSoyadi" CssClass="form-control sadeceharf" required data-parsley-maxlength="50" placeholder="Adı Soyadı Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Telefonu</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtPersonelTelefonu" class="form-control"  data-parsley-maxlength="20" placeholder="Telefonu Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Adresi</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtPersonelAdresi" class="form-control" data-parsley-maxlength="400" placeholder="Adresi Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Şifre</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtPersonelSifre" class="form-control" data-parsley-maxlength="7" placeholder="Personel Şifresini Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" class="btn btn-info waves-effect waves-light" OnClick="Kaydet" Text="Kaydet" />
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
                                <th>Adı Soyadı</th>
                                <th>Bakiye</th>
                                <th>İşlemler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptKayitlar">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Personel_Kodu") %></td>
                                        <td><%#Eval("Personel_AdiSoyadi")%></td>
                                        <td></td>
                                        <td>
                                            <a href="Default.aspx?sayfa=PersonelTanitim&id=<%#Eval("Id")%>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                            <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id")%>','Personeller','Id')"><i class="fa fa-remove"></i></a>
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
