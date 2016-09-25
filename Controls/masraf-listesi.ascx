<%@ Control Language="C#" AutoEventWireup="true" CodeFile="masraf-listesi.ascx.cs" Inherits="Controls_masraf_listesi" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Masraf Listesi</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Raporlar</a>
                </li>
                <li class="active">Masraf Listesi
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
                            <th>Açıklaması</th>
                            <th>Bakiye</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Masraf_Kodu") %></td>
                                    <td><%#Eval("Masraf_Aciklama")%></td>
                                    <td></td>
                                    <td>
                                        <a href="Default.aspx?sayfa=MasrafTanitim&id=<%#Eval("Id") %>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id")%>','Masraflar','Masraf_Kodu')"><i class="fa fa-remove"></i></a>

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
