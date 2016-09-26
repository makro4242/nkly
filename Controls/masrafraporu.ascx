<%@ Control Language="C#" AutoEventWireup="true" CodeFile="masrafraporu.ascx.cs" Inherits="Controls_masrafraporu" %>
<asp:Panel runat="server" ID="pnlContainer" class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Masraf Raporu</h4>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Ana Sayfa</a>
                </li>
                <li>
                    <a href="Default.aspx">Raporlar</a>
                </li>
                <li class="active">Karlılık Raporu
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
                                <label class="col-md-2 control-label">İlk Tarih</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtilkTarih" runat="server" CssClass="form-control tarih" required data-parsley-maxlength="11" placeholder data-mask="99/99/9999"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                    </div>
                                </div>
                                <label class="col-md-2 control-label">Son Tarih</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtSonTarih" runat="server" CssClass="form-control tarih" required data-parsley-maxlength="11" placeholder data-mask="99/99/9999"></asp:TextBox>
                                        <span class="input-group-addon bg-custom b-0 text-white"><i class="icon-calender"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">Kriter</label>
                                <div class="col-md-10">
                                    <asp:DropDownList runat="server" ID="drpKriterListesi" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2 control-label">KDV</label>
                                <div class="col-md-10">
                                    <div class="radio radio-info radio-inline">
                                        <asp:RadioButton runat="server" ID="rdbKdvli" GroupName="rdbKdv" Checked="true" />
                                        <label for="<%=rdbKdvli.ClientID %>">
                                            Dahil
                                        </label>
                                    </div>

                                    <div class="radio radio-info radio-inline">
                                        <asp:RadioButton runat="server" ID="rdbKdvsiz" GroupName="rdbKdv" />
                                        <label for="<%=rdbKdvsiz.ClientID %>">
                                            Hariç
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group m-b-0">
                                <div class="pull-right">
                                    <asp:Button ID="btnRaporla" runat="server" type="submit" CssClass="btn btn-info waves-light " OnClick="Raporla" Text="Raporla" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlAraclar" runat="server" Visible="false">
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <table id="datatable" class="table table-striped table-bordered myTable">
                        <thead>
                            <tr>
                                <th>Plaka</th>
                                <th>Kar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptAracKayitlari">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("chh_AracPlaka") %></td>
                                        <td><%#String.Format("{0:N}",Eval("Fark"))%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </asp:Panel>


    <asp:Panel ID="pnlPersonel" runat="server" Visible="false">
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <table id="datatable" class="table table-striped table-bordered myTable">
                        <thead>
                            <tr>
                                <th>Personel Kodu</th>
                                <th>Adı Soyadı</th>
                                <th>Kar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptPersonel">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("personel_kodu") %></td>
                                        <td><%#Eval("personel_kodu") %></td>
                                        <td><%#Eval("Fark") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Panel>