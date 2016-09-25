<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Controls_Menu" %>
<div class="left side-menu">
    <div class="sidebar-inner slimscrollleft">
        <!--- Divider -->
        <div id="sidebar-menu">
            <ul>
                <li class="text-muted menu-title">Menu</li>
                <li class="has_sub">
                    <a href="#" class="waves-effect"><i class="ti-home"></i><span>Kartlar </span></a>
                    <ul class="list-unstyled">
                        <li><a href="Default.aspx?sayfa=CariTanitim">Cari Tanıtım Kartı</a></li>
                        <li><a href="Default.aspx?sayfa=SeferTanitim">Sefer Tanıtım Kartı</a></li>
                        <li><a href="Default.aspx?sayfa=AracTanitim">Araç Tanıtım Kartı</a></li>
                        <li><a href="Default.aspx?sayfa=PersonelTanitim">Personel Tanıtım Kartı</a></li>
                        <li><a href="Default.aspx?sayfa=MasrafTanitim">Masraf Tanıtım Kartı</a></li>
                        <li><a href="Default.aspx?sayfa=LokasyonTanitim">Lokasyon Tanıtım Kartı</a></li>
                        <li><a href="Default.aspx?sayfa=LokasyonCariFiyatTanitim">Lokasyon-Cari-Fiyat Tanıtım Kartı</a></li>
                    </ul>
                </li>
                <li class="has_sub">
                    <a href="#" class="waves-effect"><i class="ti-home"></i><span>Evraklar </span></a>
                    <ul class="list-unstyled">
                        <li><a href="Default.aspx?sayfa=Fatura">Fatura</a></li>
                        <li><a href="Default.aspx?sayfa=EvrakMasrafFaturasi">Masraf</a></li>
                    </ul>
                </li>
                <li class="has_sub">
                    <a href="#" class="waves-effect"><i class="ti-home"></i><span>Raporlar </span></a>
                    <ul class="list-unstyled">
                        <li><a href="Default.aspx?sayfa=arac-listesi">Araç listesi</a></li>
                        <li><a href="Default.aspx?sayfa=personel-listesi">Personel listesi</a></li>
                        <li><a href="Default.aspx?sayfa=cari-listesi">Cari listesi</a></li>
                        <li><a href="Default.aspx?sayfa=masraf-listesi">Masraf listesi</a></li>
                        <li><a href="Default.aspx">Sefer listesi(Tarih Bazlı)</a></li>
                        <li><a href="Default.aspx?sayfa=karlilikraporu">Karlılık Raporu<br />Tarih Bazlı<br />(Müşteri,Şoför,Araç,Sefer)</a></li>
                        <li><a href="Default.aspx">Masraf Raporu<br />Tarih Bazlı<br />(Müşteri,Şoför,Araç,Sefer)</a></li>
                    </ul>
                </li>
                <li>
                    <a href="default.aspx?sayfa=fatura-sec" class="waves-effect"><i class="ti-printer"></i><span>Fatura Yazdır </span></a>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
        <div class="clearfix"></div>
    </div>
</div>
