<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cari-listesi.ascx.cs" Inherits="Controls_cari_listesi" %>
<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Cari Listesi</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Cari Listesi
                </li>
            </ol>
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
