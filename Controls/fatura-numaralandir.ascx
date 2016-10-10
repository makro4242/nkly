<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fatura-numaralandir.ascx.cs" Inherits="Controls_fatura_numaralandir" %>
<div class="container">

    <!-- Page-Title -->
    <div class="row">
        <div class="col-sm-12">
            <h4 class="page-title">Fatura Numaralandır</h4>
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Seri</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtSeriNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Evrak No</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtEvrakNo" runat="server" CssClass="form-control" required data-parsley-maxlength="25"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">İşlem</label>
                                    <div class="col-md-4">
                                        <div class="radio radio-info radio-inline">
                                            <asp:RadioButton runat="server" ID="rdbArtir" Checked="true" GroupName="rdbIslem" />
                                            <label for="<%=rdbArtir.ClientID %>">
                                                Artır
                                            </label>
                                        </div>

                                        <div class="radio radio-info radio-inline">
                                            <asp:RadioButton runat="server" ID="rdbAzalt" GroupName="rdbIslem" />
                                            <label for="<%=rdbAzalt.ClientID %>">
                                                Azalt
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Birim</label>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtBirim" runat="server" CssClass="vertical-spin form-control" required data-parsley-maxlength="25" Text="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group m-b-0">
                                    <div class="pull-right col-md-8">
                                        <asp:Button ID="btnKaydet" runat="server" type="submit" class="btn btn-info waves-light " OnClick="Kaydet" Text="Kaydet" />
                                    </div>
                                </div>



                            </div>

                        </div>
                        <hr />


                    </form>
                </div>
            </div>
        </div>
    </div>
</div>
