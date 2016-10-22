<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sabitler.ascx.cs" Inherits="Controls_sabitler" %>
<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Sabit Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="/anasayfa">Ana Sayfa</a>
                </li>
                <li>
                    <a href="/anasayfa">Kartlar</a>
                </li>
                <li class="active">Sabit Tanıtım Kartı
                </li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="card-box">
                <div class="row">
                    <form ID="frm" runat="server" class="form-horizontal" role="form">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-md-2 control-label">Lastik Ömrü</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtLastikOmru" runat="server" CssClass="form-control zorunlu" required placeholder="Lastik Ömrünü Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Lokasyona Göre Harcırah</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtLokasyonHarcirah" CssClass="form-control zorunlu" required  placeholder="Lokasyona göre harcırah..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Personel Hakediş</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtPersonelHakedis" CssClass="form-control zorunlu" required placeholder="Personel Hakedişi Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnKaydet" runat="server" CssClass="btn btn-info waves-light" onclick="Kaydet" Text="Kaydet" />
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
                            <th>Lastik Ömrü</th>
                            <th>Lokasyon Harcırah</th>
                            <th>Personel Hakediş</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("lastikOmru") %></td>
                                    <td><%#Eval("lokasyonHarcirah")%></td>
                                      <td><%#Eval("personelHakedis")%></td>
                                    <td>
                                        <a href="Default.aspx?sayfa=sabitler&id=<%#Eval("Id") %>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a> 
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id") %>','Sabitler','Id')"><i class="fa fa-remove"></i></a>
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