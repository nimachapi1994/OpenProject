var locations = [
	['Shobe Markazi', 38.075980,46.278968],
	['Namayandegi', 38.074138,46.296241]
];

var Center=new google.maps.LatLng(38.075980,46.278968);

function initialize() {
    var venturamap = {
        center:Center,
        zoom:14,
        mapTypeId:google.maps.MapTypeId.ROADMAP
    };

    var map=new google.maps.Map(document.getElementById("googleMap"),venturamap);

    var infowindow = new google.maps.InfoWindow();

    var marker, i;

    for (i = 0; i < locations.length; i++){  
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
            icon:'assets/images/map-marker-2.png',
            animation:google.maps.Animation.BOUNCE,
            map: map
        });

        google.maps.event.addListener(marker, 'click', (function(marker, i) {
        return function() {
        infowindow.setContent(locations[i][0]);
        infowindow.open(map, marker);
        }
        })(marker, i));
    }

	var styles = [
        {"elementType":"geometry","stylers":[{"color":"#f5f5f5"}]},
        {"elementType":"labels.icon","stylers":[{"visibility":"off"}]},
        {"elementType":"labels.text.fill","stylers":[{"color":"#616161"}]},
        {"elementType":"labels.text.stroke","stylers":[{"color":"#f5f5f5"}]},
        {"featureType":"administrative.land_parcel","elementType":"labels.text.fill","stylers":[{"color":"#bdbdbd"}]},
        {"featureType":"poi","elementType":"geometry","stylers":[{"color":"#eeeeee"}]},
        {"featureType":"poi","elementType":"labels.text.fill","stylers":[{"color": "#757575"}]},
        {"featureType":"poi.park","elementType":"geometry","stylers":[{"color":"#e5e5e5"}]},
        {"featureType":"poi.park","elementType":"labels.text.fill","stylers":[{"color":"#9e9e9e"}]},
        {"featureType": "road","elementType": "geometry","stylers":[{"color": "#ffffff"}]},
        {"featureType":"road.arterial","elementType":"labels.text.fill","stylers":[{"color":"#757575"}]},
        {"featureType":"road.highway","elementType":"geometry","stylers":[{"color": "#dadada"}]},
        {"featureType":"road.highway","elementType":"labels.text.fill","stylers":[{"color":"#616161"}]},
        {"featureType":"road.local","elementType":"labels.text.fill","stylers":[{"color":"#9e9e9e"}]},
        {"featureType":"transit.line","elementType":"geometry","stylers":[{"color":"#e5e5e5"}]},
        {"featureType": "transit.station","elementType":"geometry","stylers":[{"color":"#eeeeee"}]},
        {"featureType":"water","elementType":"geometry","stylers":[{"color":"#c9c9c9"}]},
        {"featureType": "water","elementType":"labels.text.fill","stylers":[{"color":"#9e9e9e"}]}
    ];

    marker.setMap(map);

    map.setOptions({styles: styles});				
}

google.maps.event.addDomListener(window, 'load', initialize); 