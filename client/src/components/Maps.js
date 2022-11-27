import React from 'react'
import { GoogleMap, useJsApiLoader } from '@react-google-maps/api';

const GOOGLE_MAPS_API_KEY = process.env.REACT_APP_GOOGLE_MAPS_API_KEY

const containerStyle = {
    width: '400px',
    height: '400px'
};

const center = {
    lat: -3.745,
    lng: -38.523
};

function Maps({ alerts }) {
    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: GOOGLE_MAPS_API_KEY
    })

    const [map, setMap] = React.useState(null)

    const onLoad = React.useCallback(function callback(map) {
        var marker;
        for (var i = 0; i < alerts.length; i++) {
            // Create info window
            var infowindow = new window.google.maps.InfoWindow({
                maxWidth: 350,
                pixelOffset: new window.google.maps.Size(-10, -25)
            });

            var infoFn = function (i) {
                return function (e) {
                    var content = '<div>' +
                        '<span>Title: ' + alerts[i].title + '</span>' +
                        '<span>, Lat: ' + alerts[i].latitude + '</span>' +
                        '<span>, Long: ' + alerts[i].longitude + '</span>' +
                        '</div>';

                    infowindow.setContent(content);
                    infowindow.open(map);
                    infowindow.setPosition(new window.google.maps.LatLng(alerts[i].latitude, alerts[i].longitude));
                }
            };
            var position = new window.google.maps.LatLng(alerts[i].latitude, alerts[i].longitude);

            marker = new window.google.maps.Marker({
                position: position,
                map: map,
                title: alerts[i].title
            });


            let fn = infoFn(i);
            window.google.maps.event.addListener(marker, 'click', fn);
        }

        setMap(map)
    }, [])

    const onUnmount = React.useCallback(function callback(map) {
        setMap(null)
    }, [])



    return isLoaded ? (
        <GoogleMap
            mapContainerStyle={containerStyle}
            center={center}
            zoom={10}
            onLoad={onLoad}
            onUnmount={onUnmount}
        />
    ) : <></>
}

export default React.memo(Maps)