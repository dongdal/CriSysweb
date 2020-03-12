@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.ModuleSahana
    Layout = "~/Views/Shared/_LayoutSahanaChart.vbhtml"
End Code

<div class="container-fluid">
    <!-- Breadcrumb-->
    <div class="page-header">
        @*<h1 class="page-title">@Resource.Menu_Home</h1>*@
        <ol class="breadcrumb">
            @*<li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>*@
            @*<li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.ManageRegion</a></li>
                <li class="breadcrumb-item active">@Resource.ListRegion</li>*@
        </ol>
    </div>

    <!-- End Breadcrumb-->
    <h6 class="text-uppercase">@Resource.ModuleSahana</h6>
    <hr>
    <div class="row">
        <div class="col-lg-6">
            <div class="card">
                <div class="card-header text-uppercase">Moyens de réponse</div>
                <div class="card-body">
                    <div id="c3-pie-chart"></div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="card">
                <div class="card-header text-uppercase">Moyens de réponse</div>
                <div class="card-body">
                    <div id="c3-bar-chart"></div>
                </div>
            </div>
        </div>
    </div><!--End Row-->
</div>

@Section Scripts

    <script>

    $(function () {
        'use strict';
        var c3PieChart = c3.generate({
            bindto: '#c3-pie-chart',
            data: {
                // iris data from R
                columns: [
                    ['data1', 30],
                    ['data2', 120],
                ],
                type: 'pie',
                onclick: function (d, i) {
                    console.log("onclick", d, i);
                },
                onmouseover: function (d, i) {
                    console.log("onmouseover", d, i);
                },
                onmouseout: function (d, i) {
                    console.log("onmouseout", d, i);
                }
            },
            //color: {
            //    pattern: ['#0dceec', '#15ca20', '#fd3550', '#8ae48f', "#ff9700", "#fd3550", "#223035", "#b81cff", "#765b0c", "#3fd5a0", "#1a262b", "#000c33", "#ffff00", "#ffcc99", "#993366", "#993333"]
            //},
            padding: {
                top: 0,
                right: 0,
                bottom: 30,
                left: 0,
            }
        });

        setTimeout(function () {
            c3PieChart.load({
                columns: [
                    ["Hopitaux", @ViewBag.MoyenReponse.Hopitaux],
                    ["Bureaux", @ViewBag.MoyenReponse.Bureaux],
                    ["Heliports", @ViewBag.MoyenReponse.Heliports],
                    ["Port_de_Mer", @ViewBag.MoyenReponse.PortDeMer],
                    ["Aeroport", @ViewBag.MoyenReponse.Aeroports],
                    ["Abris", @ViewBag.MoyenReponse.Abris],
                    ["Entrepots", @ViewBag.MoyenReponse.Entrepots],
                ],
                colors: {
                    Hopitaux: '#0dceec',
                    Bureaux: '#15ca20',
                    Heliports: '#fd3550',
                    Port_de_Mer: '#3fd5a0',
                    Aeroport: '#765b0c',
                    Abris: '#223035',
                    Entrepots: '#b81cff',
                },
                color: function (color, d) {
                    // d will be 'id' when called for legends
                    return d.id && d.id === 'data3' ? d3.rgb(color).darker(d.value / 150) : color;
                }
            });
        }, 1500);

        setTimeout(function () {
            c3PieChart.unload({
                ids: 'data1'
            });
            c3PieChart.unload({
                ids: 'data2'
            });
        }, 2500);


        var c3BarChart = c3.generate({
            bindto: '#c3-bar-chart',
            data: {
                columns: [
                    ["Hopitaux", @ViewBag.MoyenReponse.Hopitaux],
                    ["Heliports", @ViewBag.MoyenReponse.Heliports],
                    ["Bureaux", @ViewBag.MoyenReponse.Bureaux],
                    ["Port_de_Mer", @ViewBag.MoyenReponse.PortDeMer],
                    ["Aeroport", @ViewBag.MoyenReponse.Aeroports],
                    ["Abris", @ViewBag.MoyenReponse.Abris]
                ],
                type: 'bar',
                colors: {
                    Hopitaux: '#0dceec',
                    Bureaux: '#15ca20',
                    Heliports: '#fd3550',
                    Port_de_Mer: '#3fd5a0',
                    Aeroport: '#765b0c',
                    Abris: '#223035',
                    Entrepots: '#b81cff',
                },
                color: function (color, d) {
                    // d will be 'id' when called for legends
                    return d.id && d.id === 'data3' ? d3.rgb(color).darker(d.value / 150) : color;
                }
            },
            //color: {
            //    pattern: ['#0dceec', '#15ca20', '#fd3550', '#8ae48f', "#ff9700", "#fd3550", "#223035", "#b81cff", "#765b0c", "#3fd5a0", "#1a262b", "#000c33", "#ffff00", "#ffcc99", "#993366", "#993333"]
            //},
            padding: {
                top: 0,
                right: 0,
                bottom: 30,
                left: 0,
            },
            bar: {
                width: {
                    ratio: 0.7 // this makes bar width 50% of length between ticks
                }
            }
        });

        setTimeout(function () {
            c3BarChart.load({
                columns: [
                    ["Entrepots", @ViewBag.MoyenReponse.Entrepots]
                ]
            });
        }, 1000);


    })(jQuery);


    </script>
End Section
