<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LokasyonTanitim.ascx.cs" Inherits="Controls_LokasyonTanitim" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Lokasyon Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Lokasyon Tanıtım Kartı
                </li>
            </ol>
        </div>
    </div>
    <form id="frm" runat="server" class="form-horizontal" role="form">
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-md-2 control-label">Kodu</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtLokasyonKodu" runat="server" CssClass="form-control"  required data-parsley-maxlength="10" placeholder="Lokasyon Kodunu Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Açıklaması</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtLokasyonAciklama" CssClass="form-control" required data-parsley-maxlength="100" placeholder="Lokasyon Açıklamasını Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-info waves-effect waves-light" OnClick="Kaydet" Text="Kaydet" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <table id="datatable" class="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th>Kodu</th>
                            <th>Açıklaması</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlarr">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Lokasyon_Kodu") %></td>
                                    <td><%#Eval("Lokasyon_Aciklama")%></td>
                                
                                    <td>
                                        <a href="Default.aspx?sayfa=LokasyonTanitim&id=<%#Eval("Id") %>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id")%>','Lokasyon','Id')"><i class="fa fa-remove"></i></a>
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

