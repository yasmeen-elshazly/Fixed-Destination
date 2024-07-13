import React from 'react';
import MapComponent from './MapComponent';
import Navbar from './Navbar';
import '../Styles/HomePage.css';

const HomePage = () => {
  return (
    <div className="homepage">
      <Navbar />
      <div className="map-fullscreen">
        <MapComponent />
      </div>
    </div>
  );
};

export default HomePage;
