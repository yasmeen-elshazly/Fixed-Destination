import React, { useEffect, useRef, useState } from 'react';
import Map from '@arcgis/core/Map';
import MapView from '@arcgis/core/views/MapView';
import Graphic from '@arcgis/core/Graphic';
import GraphicsLayer from '@arcgis/core/layers/GraphicsLayer';
import L from 'leaflet';
import 'leaflet-routing-machine';
import '../Styles/MapComponent.css';
import destinationIcon from '../Assets/gps.png';

const MapComponent = () => {
  const mapRef = useRef();
  const [location, setLocation] = useState(null);
  const destination = { longitude: 31.457111, latitude: 30.029694 };

  useEffect(() => {
    const map = new Map({
      basemap: 'streets-navigation-vector'
    });

    const view = new MapView({
      container: mapRef.current,
      map: map,
      center: [0, 0], // Initial center of the map
      zoom: 2 // Initial zoom level
    });

    const graphicsLayer = new GraphicsLayer();
    map.add(graphicsLayer);

    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position) => {
        const { longitude, latitude } = position.coords;
        setLocation({ longitude, latitude });

        const userPoint = {
          type: 'point',
          longitude: longitude,
          latitude: latitude
        };

        const userMarkerSymbol = {
          type: 'simple-marker',
          color: 'blue',
          size: '15px'
        };

        const userPointGraphic = new Graphic({
          geometry: userPoint,
          symbol: userMarkerSymbol
        });

        graphicsLayer.add(userPointGraphic);
        view.center = [longitude, latitude];
        view.zoom = 15;

        // Add fixed destination point with custom icon
        const destinationPoint = new Graphic({
          geometry: {
            type: 'point',
            longitude: destination.longitude,
            latitude: destination.latitude
          },
          symbol: {
            type: 'picture-marker',
            url: destinationIcon,
            width: '28px',
            height: '28px'
          }
        });

        graphicsLayer.add(destinationPoint);

        // routing
        initializeLeafletMap(longitude, latitude, destination.longitude, destination.latitude);

      }, (error) => {
        console.error('Error getting location:', error);
      });
    } else {
      console.error('Geolocation is not supported by this browser.');
    }

    
    return () => {
      if (view) {
        view.destroy();
      }
    };
  }, []);

  const initializeLeafletMap = (startLon, startLat, endLon, endLat) => {
    const leafletMap = L.map(mapRef.current).setView([startLat, startLon], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors'
    }).addTo(leafletMap);

    const control = L.Routing.control({
      waypoints: [
        L.latLng(startLat, startLon),
        L.latLng(endLat, endLon)
      ],
      createMarker: function (i, waypoint, n) {
        if (i === n - 1) { 
          return L.marker(waypoint.latLng, {
            icon: L.icon({
              iconUrl: destinationIcon,
              iconSize: [28, 28]
            }),
            draggable: false 
          });
        } else {
          return L.marker(waypoint.latLng, {
            draggable: true 
          });
        }
      },
      routeWhileDragging: true
    }).addTo(leafletMap);
  };

  return (
    <div style={{ width: '100vw', height: '100vh', backgroundColor: '#f0f0f0' }}>
      <div className="map-container" ref={mapRef} style={{ width: '100%', height: 'calc(100% - 50px)' }}></div>
    </div>
  );
};

export default MapComponent;
