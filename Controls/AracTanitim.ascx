<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AracTanitim.ascx.cs" Inherits="Controls_AracTanitim" %>

<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Araç Tanıtım Kartı</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Kartlar</a>
                </li>
                <li class="active">Araç Tanıtım Kartı
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
                                <label class="col-md-2 control-label">Plaka</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtAracPlaka" runat="server" CssClass="form-control zorunlu" required data-parsley-maxlength="10" placeholder="Aracın Plakasını Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label ">Marka</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtAracMarka" CssClass="form-control zorunlu" required data-parsley-maxlength="20" placeholder="Aracın Markasını Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Model</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtAracModel" CssClass="form-control zorunlu" required data-parsley-maxlength="20" placeholder="Aracın Modelini Yazınız..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Zimmet</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpZimmetPersoneli" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Not</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="txtAracNot" CssClass="form-control" data-parsley-maxlength="250" placeholder="Araç ile ilgili Not Yazınız..."></asp:TextBox>
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
