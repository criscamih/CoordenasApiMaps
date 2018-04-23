
function initMap() {
    var circle;
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 4.626993, lng: -74.080450 },
        zoom: 8
    });

    var drawingManager = new google.maps.drawing.DrawingManager({
        drawingMode: google.maps.drawing.OverlayType.MARKER,
        drawingControl: true,
        drawingControlOptions: {
            position: google.maps.ControlPosition.TOP_CENTER,
            drawingModes: ['marker', 'circle']
        },
        markerOptions: { icon: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png' },
        circleOptions: {
            fillColor: '#FF0000',
            fillOpacity: 0.35,
            strokeWeight: 5,
            clickable: false,
            editable: true,
            zIndex: 1
        }
    });
    drawingManager.setMap(map);
    google.maps.event.addListener(drawingManager, 'circlecomplete', onCircleComplete);

    function onCircleComplete(shape) {

        if (shape == null || (!(shape instanceof google.maps.Circle))) return;

        if (circle != null) {
            circle.setMap(null);
            circle = null;
        }

        circle = shape;
        console.log('radius', circle.getRadius());
        console.log('lat', circle.getCenter().lat());
        console.log('lng', circle.getCenter().lng());

        var latitud = document.getElementById('Latitud');
        latitud.setAttribute('value', circle.getCenter().lat());

        var longitud = document.getElementById('Longitud');
        longitud.setAttribute('value', circle.getCenter().lng());

        var radio = document.getElementById('Radio');
        radio.setAttribute('value', circle.getRadius());

    }
   
    

}

