var Center=new google.maps.LatLng(38.075980,46.278968);

function initialize() {
    var venturamap = {
        center:Center,
        zoom:16,
        mapTypeId:google.maps.MapTypeId.ROADMAP
    };

    var map=new google.maps.Map(document.getElementById("googleMap"),venturamap);

    var marker=new google.maps.Marker({
        position:Center,
        icon:'assets/images/map-y-mark.png',
        animation:google.maps.Animation.BOUNCE
    });
 
	var styles = [
	{"featureType":"all","elementType":"labels.text.fill","stylers":[{"saturation":36},{"color":"#000000"},{"lightness":40}]},
    {"featureType":"all","elementType":"labels.text.stroke","stylers":[{"visibility":"off"},{"color":"#000000"},{"lightness":16}]},
    {"featureType":"landscape","elementType":"geometry","stylers":[{"color":"#b3aea5"},{"lightness":20}]},
    {"featureType":"poi","elementType":"geometry","stylers":[{"color":"#b5bba7"},{"lightness":21}]},
    {"featureType":"road.highway","elementType":"geometry.fill","stylers":[{"color":"#e0d448"},{"lightness":17}]},
    {"featureType":"road.highway","elementType":"geometry.stroke","stylers":[{"color":"#e0d448"},{"lightness":29},{"weight":0.2}]},
    {"featureType":"road.arterial","elementType":"geometry","stylers":[{"color":"#e0d448"},{"lightness":18}]},
    {"featureType":"road.local","elementType":"geometry","stylers":[{"color":"#cecece"},{"lightness":16}]},
    {"featureType":"transit","elementType":"geometry","stylers":[{"color":"#d1cfcb"},{"lightness":19}]},
    {"featureType":"water","elementType":"geometry","stylers":[{"color":"#d1cfcb"},{"lightness":17}]}
	];

    marker.setMap(map);

    map.setOptions({styles: styles});				
}

google.maps.event.addDomListener(window, 'load', initialize); 