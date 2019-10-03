@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListTypeSuivi
    Layout = "~/Views/Shared/_LayoutSahana.vbhtml"
End Code

@*<link rel="stylesheet" href="https://unpkg.com/leaflet@1.5.1/dist/leaflet.css"
          integrity="sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
          crossorigin="" />
    <style>
        #mapid {
            height: 500px;
        }
    </style>*@


<div class="page-header">
    <h1 class="page-title">@Resource.ManageTypeSuivi</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "TypeSuivis")>@Resource.ManageTypeSuivi</a></li>
        <li class="breadcrumb-item active">@Resource.ListTypeSuivi</li>
    </ol>
</div>

@Html.Partial("_MyMapPartial")


@section Scripts
    @*<script src="https://unpkg.com/leaflet@1.5.1/dist/leaflet.js"
            integrity="sha512-GffPMF3RvMeYyc1LWMHtK8EbPv0iNZ8/oTtHPx9/cc2ILxQ+u905qIwdpULaqDkyBKgOaB57QTMg7ztg8Jm2Og=="
            crossorigin=""></script>
        <script>
            var mymap = L.map('mapid').setView([51.505, -0.09], 13);



            L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
                attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                maxZoom: 18,
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoibGthbmtvIiwiYSI6ImNqcXMxa3ZwZzAyaHg0M3FjcnlodWdyN2gifQ.kZWy1_TOotLAnGCVb2qHXA'
            }).addTo(mymap);*@

    <script>
        var src = '@Url.Content("~/assets/images/leafIcon/iconfinder.png")';

        var heliportIcon = L.icon({
            iconUrl: src,

            iconSize: [20, 50],
            iconAnchor: [22, 94],
            popupAnchor: [-3, -76]
        });

        var heliports = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Heliport',
            format: 'image/png',
            icon: heliportIcon,
            transparent: true,
        });

        var Hopitaux = L.tileLayer.wms("http://localhost:8080/geoserver/cite/wms", {
            layers: 'Hopitaux',
            format: 'image/png',
            transparent: true,
        });

        var overlayMaps = {
            "Hopitaux": Hopitaux,
            "Héliports": heliports
        };

        //center: [51.505, -0.09],
        var mymap = L.map('mapid', {
            center: [6.420116, 13.091309],
            zoom: 6,
            //leyers activer par defaut
            layers: [streets, heliports, Hopitaux]
        });

        L.marker([6.490116, 13.091809], { icon: heliportIcon }).addTo(mymap);
        L.control.layers(baseLayers, overlayMaps).addTo(mymap);

    </script>

end section