

<link rel="stylesheet" href="https://unpkg.com/leaflet@1.5.1/dist/leaflet.css"
          integrity="sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
          crossorigin="" />
    <style>
        #mapid {
            height: 500px;
        }
    </style>

    <div id="mapid"></div>



        <script src="https://unpkg.com/leaflet@1.5.1/dist/leaflet.js"
                integrity="sha512-GffPMF3RvMeYyc1LWMHtK8EbPv0iNZ8/oTtHPx9/cc2ILxQ+u905qIwdpULaqDkyBKgOaB57QTMg7ztg8Jm2Og=="
                crossorigin=""></script>
        <script>


            var mbAttr = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
                mbUrl = 'https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibGthbmtvIiwiYSI6ImNqcXMxa3ZwZzAyaHg0M3FjcnlodWdyN2gifQ.kZWy1_TOotLAnGCVb2qHXA';

            var grayscale = L.tileLayer(mbUrl, { id: 'mapbox.light', attribution: mbAttr }),
                streets = L.tileLayer(mbUrl, { id: 'mapbox.streets', attribution: mbAttr });

            var baseLayers = {
                "Grayscale": grayscale,
                "Streets": streets
            };

            //var mymap = L.map('mapid').setView([51.505, -0.09], 13);



            //L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
            //    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            //    maxZoom: 18,
            //    id: 'mapbox.streets',
            //    accessToken: 'pk.eyJ1IjoibGthbmtvIiwiYSI6ImNqcXMxa3ZwZzAyaHg0M3FjcnlodWdyN2gifQ.kZWy1_TOotLAnGCVb2qHXA'
            //}).addTo(mymap);
        </script>

