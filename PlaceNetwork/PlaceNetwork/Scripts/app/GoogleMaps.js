var myOptions = {
    zoom: 16,
    minZoom: 11,
    maxZoom: 19,
    center: new google.maps.LatLng(49.839027, 24.027518),
    disableDoubleClickZoom: true,
    draggableCursor: "crosshair"
};

var markers = [];
var map = new google.maps.Map(document.getElementById("map-canvas"), myOptions);
var user_marker;

google.maps.event.addListener(map, 'click', function (event) {
    placeMarker(event.latLng);
});

function placeMarker(location) {
    if (user_marker) {
        user_marker.setPosition(location);
    } else {
        user_marker = new google.maps.Marker({
            position: location,
            icon: "/Content/Icons/marker.png",
            map: map
        });
    }
    $("#myModal").modal();
}

function addPlace() {
    var place =
    {
        Title: $("#placeTitle").val(),
        Description: $("#placeDescription").val(),
        Latitude: user_marker.position.k,
        Longitude: user_marker.position.D,
        CategoryId: null
    }
    $.ajax({
        type: 'POST',
        url: '/api/Place',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(place)
    }).done(function () {
        location.reload();
    }).fail(function (resp) {
        alert(resp.status + ": " + resp.statusText);
    });

}

function getAllPlaces() {
    $.ajax({
        type: 'Get',
        url: '/api/Place',
        contentType: 'application/json; charset=utf-8',
    }).done(function (data) {
        showPlaces(data);
    }).fail(function (resp) {
        alert(resp.status + ": " + resp.statusText);
    });
}

function getMyPlaces() {
    $.ajax({
        type: 'Get',
        url: '/api/Place/MyPlaces',
        contentType: 'application/json; charset=utf-8',
    }).done(function (data) {
        showPlaces(data);
    }).fail(function (resp) {
        alert(resp.status + ": " + resp.statusText);
    });
}

function showPlaces(places) {
    deleteMarkers();
    _.each(places, function (num) {
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(num.Latitude, num.Longitude),
        });
        markers.push(marker);
    });
    setPlaces(map);
}

function setPlaces(map) {
    _.each(markers, function (num) {
        num.setMap(map);
    });
}

function deleteMarkers() {
    setPlaces(null);
    markers = [];
}