<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/Controls/Menu.ascx" TagPrefix="uc1" TagName="Menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Nakliye Programı">
    <meta name="author" content="Makrosoft">

    <link rel="shortcut icon" href="assets/images/favicon_1.ico">
    <link href="assets/plugins/datatables/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
    <title>Makrosoft Nakliye Programı</title>

    <!--Morris Chart CSS -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/mycss.css" rel="stylesheet" />
    <link href="assets/plugins/sweetalert/dist/sweetalert.css" rel="stylesheet" type="text/css">
    <link href="assets/plugins/select2/select2.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shiv and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

    <script src="assets/js/modernizr.min.js"></script>


</head>
<body class="fixed-left">

    <!-- Begin page -->
    <div id="wrapper">
        murat
        <!-- Top Bar Start -->
        <div class="topbar">

            <!-- LOGO -->
            <div class="topbar-left">
                <div class="text-center">
                    <a href="Default.aspx" class="logo">
                        <span>
                            <img src="/assets/images/logo.jpg" style="height: 55px;" /></span>
                    </a>
                </div>
            </div>

            <!-- Button mobile view to collapse sidebar menu -->
            <div class="navbar navbar-default" role="navigation">
                <div class="container">
                    <div class="">
                        <div class="pull-left">
                            <button class="button-menu-mobile open-left">
                                <i class="ion-navicon"></i>
                            </button>
                            <span class="clearfix"></span>
                        </div>

                        <form role="search" class="navbar-left app-search pull-left hidden-xs">
                            <input type="text" placeholder="Ara....." class="form-control">
                            <a href=""><i class="fa fa-search"></i></a>
                        </form>


                        <ul class="nav navbar-nav navbar-right pull-right">
                            <li class="dropdown hidden-xs">
                                <a href="#" data-target="#" class="dropdown-toggle waves-effect waves-light" data-toggle="dropdown" aria-expanded="true">
                                    <i class="icon-bell"></i><span class="badge badge-xs badge-danger">3</span>
                                </a>
                                <ul class="dropdown-menu dropdown-menu-lg">
                                    <li class="notifi-title"><span class="label label-default pull-right">New 3</span>Notification</li>
                                    <li class="list-group nicescroll notification-list">
                                        <!-- list item-->
                                        <a href="javascript:void(0);" class="list-group-item">
                                            <div class="media">
                                                <div class="pull-left p-r-10">
                                                    <em class="fa fa-diamond fa-2x text-primary"></em>
                                                </div>
                                                <div class="media-body">
                                                    <h5 class="media-heading">A new order has been placed A new order has been placed</h5>
                                                    <p class="m-0">
                                                        <small>There are new settings available</small>
                                                    </p>
                                                </div>
                                            </div>
                                        </a>

                                        <!-- list item-->
                                        <a href="javascript:void(0);" class="list-group-item">
                                            <div class="media">
                                                <div class="pull-left p-r-10">
                                                    <em class="fa fa-cog fa-2x text-custom"></em>
                                                </div>
                                                <div class="media-body">
                                                    <h5 class="media-heading">New settings</h5>
                                                    <p class="m-0">
                                                        <small>There are new settings available</small>
                                                    </p>
                                                </div>
                                            </div>
                                        </a>

                                        <!-- list item-->
                                        <a href="javascript:void(0);" class="list-group-item">
                                            <div class="media">
                                                <div class="pull-left p-r-10">
                                                    <em class="fa fa-bell-o fa-2x text-danger"></em>
                                                </div>
                                                <div class="media-body">
                                                    <h5 class="media-heading">Updates</h5>
                                                    <p class="m-0">
                                                        <small>There are <span class="text-primary font-600">2</span> new updates available</small>
                                                    </p>
                                                </div>
                                            </div>
                                        </a>

                                        <!-- list item-->
                                        <a href="javascript:void(0);" class="list-group-item">
                                            <div class="media">
                                                <div class="pull-left p-r-10">
                                                    <em class="fa fa-user-plus fa-2x text-info"></em>
                                                </div>
                                                <div class="media-body">
                                                    <h5 class="media-heading">New user registered</h5>
                                                    <p class="m-0">
                                                        <small>You have 10 unread messages</small>
                                                    </p>
                                                </div>
                                            </div>
                                        </a>

                                        <!-- list item-->
                                        <a href="javascript:void(0);" class="list-group-item">
                                            <div class="media">
                                                <div class="pull-left p-r-10">
                                                    <em class="fa fa-diamond fa-2x text-primary"></em>
                                                </div>
                                                <div class="media-body">
                                                    <h5 class="media-heading">A new order has been placed A new order has been placed</h5>
                                                    <p class="m-0">
                                                        <small>There are new settings available</small>
                                                    </p>
                                                </div>
                                            </div>
                                        </a>

                                        <!-- list item-->
                                        <a href="javascript:void(0);" class="list-group-item">
                                            <div class="media">
                                                <div class="pull-left p-r-10">
                                                    <em class="fa fa-cog fa-2x text-custom"></em>
                                                </div>
                                                <div class="media-body">
                                                    <h5 class="media-heading">New settings</h5>
                                                    <p class="m-0">
                                                        <small>There are new settings available</small>
                                                    </p>
                                                </div>
                                            </div>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:void(0);" class="list-group-item text-right">
                                            <small class="font-600">See all notifications</small>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class="hidden-xs">
                                <a href="#" id="btn-fullscreen" class="waves-effect waves-light"><i class="icon-size-fullscreen"></i></a>
                            </li>
                            <li class="dropdown">
                                <a href="" class="dropdown-toggle profile" data-toggle="dropdown" aria-expanded="true">
                                    <img src="assets/images/users/avatar-1.jpg" alt="user-img" class="img-circle">
                                </a>
                                <ul class="dropdown-menu">
                                    <li><a href="javascript:void(0)"><i class="ti-user m-r-5"></i>Profile</a></li>
                                    <li><a href="javascript:void(0)"><i class="ti-settings m-r-5"></i>Settings</a></li>
                                    <li><a href="javascript:void(0)"><i class="ti-lock m-r-5"></i>Lock screen</a></li>
                                    <li><a href="/cikis-yap.aspx"><i class="ti-power-off m-r-5"></i>Çıkış</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>
        </div>
        <!-- Top Bar End -->


        <!-- ========== Left Sidebar Start ========== -->

        <uc1:Menu runat="server" ID="Menu" />

        <!-- Left Sidebar End -->



        <!-- ============================================================== -->
        <!-- Start right Content here -->
        <!-- ============================================================== -->
        <div class="content-page">
            <!-- Start content -->
            <asp:Panel runat="server" ID="pnlContainer" class="content">
                <!-- container -->

            </asp:Panel>
            <!-- content -->

            <footer class="footer text-right">
                2016 © Makrosoft Nakliye
            </footer>

        </div>


        <!-- ============================================================== -->
        <!-- End Right content here -->
        <!-- ============================================================== -->




    </div>
    <!-- END wrapper -->



    <script>
        var resizefunc = [];
    </script>

    <!-- jQuery  -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/detect.js"></script>
    <script src="assets/js/fastclick.js"></script>
    <script src="assets/js/jquery.slimscroll.js"></script>
    <script src="assets/js/jquery.blockUI.js"></script>
    <script src="assets/js/waves.js"></script>
    <script src="assets/js/wow.min.js"></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>

    <script src="assets/plugins/peity/jquery.peity.min.js"></script>

    <!-- jQuery  -->
    <script src="assets/plugins/waypoints/lib/jquery.waypoints.js"></script>
    <script src="assets/plugins/counterup/jquery.counterup.min.js"></script>



    <script src="assets/plugins/raphael/raphael-min.js"></script>

    <script src="assets/plugins/jquery-knob/jquery.knob.js"></script>


    <script src="assets/js/jquery.core.js"></script>
    <script src="assets/js/jquery.app.js"></script>
    <script src="assets/plugins/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-datepicker/dist/js/datepicker.js"></script>
    <script>
        jQuery('.tarih').datepicker({
            autoclose: true,
            todayHighlight: true,
            dayNames: ["pazar", "pazartesi", "salı", "çarşamba", "perşembe", "cuma", "cumartesi"],
            dayNamesMin: ["pa", "pzt", "sa", "çar", "per", "cum", "cmt"],
            months: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            format: 'dd/mm/yyyy',
        });
    </script>
    <script type="text/javascript" src="assets/plugins/parsleyjs/dist/parsley.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('form').parsley();
        });
    </script>
    <script src="assets/js/upper.js" type="text/javascript"> </script>
    <script src="assets/plugins/bootstrap-inputmask/bootstrap-inputmask.min.js" type="text/javascript"></script>
    <script src="assets/plugins/autoNumeric/autoNumeric.js" type="text/javascript"></script>
    <script src="assets/plugins/notifyjs/dist/notify.min.js"></script>
    <script src="assets/plugins/notifications/notify-metro.js"></script>
    <script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="assets/plugins/datatables/dataTables.bootstrap.js"></script>
    <script src="assets/plugins/sweetalert/dist/sweetalert.min.js"></script>
    <script src="assets/plugins/select2/select2.min.js" type="text/javascript"></script>
    <script src="//cdn.datatables.net/plug-ins/1.10.12/api/fnReloadAjax.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.fn.serializeObject = function () {
                var o = {};
                var a = this.serializeArray();
                $.each(a, function () {
                    if (o[this.name] !== undefined) {
                        if (!o[this.name].push) {
                            o[this.name] = [o[this.name]];
                        }
                        o[this.name].push(this.value || '');
                    } else {
                        o[this.name] = this.value || '';
                    }
                });
                return o;
            };
            $(".txtEvrakNo").blur(function () {

            });
            $('.frmMasraf').submit(function () {
                $('.msrfEkle').attr("disabled", true);
                $('.kitle').attr("disabled", false);
                var msj = JSON.stringify($('.frmMasraf').serializeObject());
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/service.asmx/evrakMasraf",
                    data: msj,
                    success: function (msg) {
                        var msrf = (jQuery.parseJSON((msg.d)));
                        var element = $("<div class='row'></div>");
                        $(element).append("<div class='col-md-2'><label class='col-md-12 control-label'>" + msrf["masraf"] + "</label></div>");
                        $(element).append("<div class='col-md-2'><label class='col-md-12 control-label'>" + msrf["arac"] + "</label></div>");
                        $(element).append("<div class='col-md-2 text-center'><label class='col-md-12 control-label'>" + msrf["taksit"] + "</label></div>");
                        $(element).append("<div class='col-md-1 text-center'><label class='col-md-12 control-label'>" + msrf["Km"] + "</label></div>");
                        $(element).append("<div class='col-md-2 text-center'><label class='col-md-12 control-label'>%   " + msrf["KDV"] + "</label></div>");
                        $(element).append("<div class='col-md-2 text-right'><label class='col-md-12 control-label'>" + msrf["tutar"] + "</label></div>");
                        $(".spnAraToplam").html(msrf["toplamTutar"]);
                        $(".spnKdv").html(msrf["toplamKDV"]);
                        $(".spnGenToplam").html(msrf["genelToplamTutar"]);


                        $(".masrafListele").append(element);
                        $(".masrafListele").append("<hr/>");
                        $('.msrfEkle').attr("disabled", false);

                        $(".temizle").val("");
                        $(".temizle").select2("val", "");
                        $('.kitle').attr("disabled", true);
                        ShowMessageBox("success", "", "Kayıt Eklendi");

                    },
                    error: function () {
                        ShowMessageBox("error", "", "Kayıt yapılamıyor");
                    }
                });
                return false;
            });

            $('.bestupper').bestupper({
                ln: 'tr'
            });
        });
    </script>
    <script type="text/javascript">

        jQuery(function ($) {
            $('.autonumber').autoNumeric('init');
        });
    </script>



    <script>
        function ShowMessageBox(tip, baslik, icerik) {
            $.Notification.notify(tip, 'right middle', baslik, icerik);
            return false;
        }
        var uyari = '<%=Session["mesaj"].ToString()%>';
            <%=Session["mesaj"] = ""%>
        if (uyari.length > 0) {
            var arr = uyari.split('-');
            ShowMessageBox(arr[0], "Uyarı", arr[1]);
        }
        function confirmSil(element, id, tablo, kolon) {
            swal({
                title: "Eminmisiniz?",
                text: "Sildikten Sonra Bilgilere Ulaşamayacaksınız!",
                type: "warning",
                showCancelButton: true,
                cancelButtonText: "Kapat",
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Evet, Silinsin!",
                closeOnConfirm: false
            }, function () {
                $.ajax({
                    type: "POST",
                    url: "/service.asmx/kayitSil",
                    data: "{tablo:'" + tablo + "',id:'" + id + "',kolon:'" + kolon + "'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        if (msg.d == "1") {
                            $(element).parent().parent().hide();
                            swal("Silindi!", "Seçtiğiniz Kayıt Silindi.", "success");
                        }
                        else {
                            swal('', msg.d, 'error');
                        }
                    },
                    error: function () {
                        swal('Hata', 'Kayıt Silinemiyor', 'error');
                    }
                });
            });

        }
        var table;
        var araToplam = 0;
        var kdv = 0;
        var genToplam = 0;
        var idler = [];
        $(document).ready(function () {
            $(".select2").select2();
            $("#datatable").dataTable();
            table = $('#dtSeferler').dataTable();
            $('#dtSeferler tbody').on('click', 'tr', function () {

                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                    araToplam -= parseFloat($(this).find('td').eq(9).text());
                    var removeItem = $(this).find('td').eq(0).text();
                    idler = jQuery.grep(idler, function (value) {
                        return value != removeItem;
                    });

                }
                else {
                    $(this).addClass('selected');
                    idler.push($(this).find('td').eq(0).text());
                    araToplam += parseFloat($(this).find('td').eq(9).text());


                }
                kdv = araToplam * 8 / 100;
                kdv = yuvarla(kdv, 2);
                genToplam = araToplam + kdv;

                genToplam = yuvarla(genToplam, 2);

                $(".spnAraToplam").html(formatYap(araToplam));
                $(".spnKdv").html(formatYap(kdv));
                $(".spnGenToplam").html(formatYap(genToplam));
            });
            $(".drpCari").change(function () {
                seferleriGetir($(".drpCari").select2('val'));
            });
        });
        function seferleriGetir(id) {
            araToplam = 0; kdv = 0;
            genToplam = 0;
            idler = [];
            $(".spnAraToplam").html(formatYap(araToplam));
            $(".spnKdv").html(formatYap(kdv));
            $(".spnGenToplam").html(formatYap(genToplam));
            table.fnReloadAjax('/json.aspx?id=' + id);

        }
        function fnFaturaKontrol(id) {

            if (idler.length > 0) {
                $("#" + id).val(idler.toString());
                return true;
            }
            else {
                ShowMessageBox("error", "Hata", "Sefer Seçmelisiniz");
                return false;
            }
        }
        function formatYap(deger) {
            deger = deger.toString();
            var dizi = deger.split(".");
            deger = dizi[0];
            var islem = 0;
            var yeni = "";
            for (var i = deger.length - 1; i >= 0; i--) {
                islem++;
                yeni = deger[i] + yeni;
                if (islem % 3 == 0 && i > 0) {
                    yeni = "." + yeni;
                }


            }
            if (dizi.length > 1) {
                yeni += "," + dizi[1];
            }
            else {
                yeni += ",00";
            }

            return yeni;


        }
    </script>
    <script type="text/javascript">

        function PrintElem(elem) {
            Popup($(elem).html());
        }

        function Popup(data) {
            var mywindow = window.open('', 'mydiv', 'height=400,width=800');
            /*mywindow.document.write('<html><head><link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css"></head><body onload="window.print()">' + data + '</body></html>');*/
            mywindow.document.write('<html><head>');
            mywindow.document.write('<link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />');
            mywindow.document.write(' <link href="assets/css/core.css" rel="stylesheet" type="text/css" />');
            mywindow.document.write('<link href="assets/css/components.css" rel="stylesheet" type="text/css" />');

            mywindow.document.write('<link href="assets/css/icons.css" rel="stylesheet" type="text/css" />');
            mywindow.document.write('<link href="assets/css/pages.css" rel="stylesheet" type="text/css" />');
            mywindow.document.write('<link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />');
            mywindow.document.write('<link href="assets/css/mycss.css" rel="stylesheet" />');




            mywindow.document.write('</head><body onload="window.print()">');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');

            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10


            return true;
        }

        $(document).ready(function () {
            $(".cariTamamla").keyup(function () {
                if ($(this).val().length == 2) {
                    $.ajax({
                        type: "POST",
                        url: "/service.asmx/cariKodu",
                        data: "{kod:'" + $(this).val() + "'}",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            $(".cariTamamla").val(msg.d);
                        },
                        error: function () {
                        }
                    });
                }
            });
            $(".txtMasraf").keyup(function () {
                var toplam = parseFloat($(".txtMasraf").val());
                var kdvOran = parseInt($(".drpKdv").val());
                var kdv = toplam * kdvOran / 100;
                $(".spnAraToplam").html(toplam);
                $(".spnKdv").html(kdv);
                var k = toplam + kdv;
                $(".spnGenToplam").html(yuvarla(k, 2));
            });
        })
        function yuvarla(sayi, hane) {
            return Number(Math.round(sayi + 'e' + hane) + 'e-' + hane);
        }
    </script>

</body>
</html>
