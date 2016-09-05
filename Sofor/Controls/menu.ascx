<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="Sofor_Controls_menu" %>

           
                    <ul>
                        <li class="text-muted menu-title">Menu</li>
                        <asp:Repeater runat="server" ID="rptSeferler">
                            <ItemTemplate>
                                <li><a href="Default.aspx?sayfa=SeferTanitim">Sefer Tanıtım Kartı</a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
            