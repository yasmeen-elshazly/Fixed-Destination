import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './Components/HomePage';
import LoginPage from './Components/LoginPage'; 
import SignUpPage from './Components/SignUpPage';
import ProfilePage from './Components/ProfilePage'

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/signup" element={<SignUpPage />} />
        <Route path="/Profile" element={<ProfilePage/>}/>
      </Routes>
    </Router>
  );
};

export default App;
