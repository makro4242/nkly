<%@ Control Language="C#" AutoEventWireup="true" CodeFile="arac-listesi.ascx.cs" Inherits="Controls_arac_listesi" %>
<div class="container">
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Araç Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Raporlar</a>
                </li>
                <li class="active">Araç Listesi
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
                            <th>Plaka</th>
                            <th>Marka</th>
                            <th>Model</th>
                            <th>S.Sayısı</th>
                            <th>İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptKayitlar">
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Arac_Plaka") %></td>
                                    <td><%#Eval("Arac_Marka")%></td>
                                    <td><%#Eval("Arac_Model")%></td>
                                    <td></td>
                                    <td>
                                        <a href="Default.aspx?sayfa=AracTanitim&id=<%#Eval("Id") %>" class="btn btn-icon waves-effect waves-light btn-warning"><i class="fa fa-wrench"></i></a>
                                        <a href="javascript:;" class="btn btn-default waves-effect waves-light" onclick="confirmSil(this,'<%#Eval("Id") %>','Araclar','Id')"><i class="fa fa-remove"></i></a>
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
