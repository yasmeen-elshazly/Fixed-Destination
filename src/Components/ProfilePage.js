import React, { useEffect, useState } from 'react';

const ProfilePage = () => {
  const [userInfo, setUserInfo] = useState(null);
  const [visitCount, setVisitCount] = useState(0);

  useEffect(() => {
    // Fetch user profile data
    fetchUserProfile();

    // Simulate fetching visit count based on user's current location
    fetchVisitCount();
  }, []);

  const fetchUserProfile = async () => {
    try {
    
      const response = await fetch('/api/user/profile', {
        method: 'GET',
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('accessToken')}`
        }
      });

      if (!response.ok) {
        throw new Error('Failed to fetch user profile');
      }

      const userData = await response.json();
      setUserInfo(userData);
    } catch (error) {
      console.error('Error fetching user profile:', error.message);
    }
  };

  const fetchVisitCount = async () => {
    try {
      
      const response = await fetch('/api/user/visit-count', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('accessToken')}`
        },
        body: JSON.stringify({
          latitude: 30.029694, 
          longitude: 31.457111 
        })
      });

      if (!response.ok) {
        throw new Error('Failed to fetch visit count');
      }

      const visitData = await response.json();
      setVisitCount(visitData.count); 
    } catch (error) {
      console.error('Error fetching visit count:', error.message);
    }
  };

  if (!userInfo) {
    return <div>Loading...</div>;
  }

  return (
    <div className="profile-page">
      <h2>Profile Page</h2>
      <div>
        <h3>User Information</h3>
        <p>Name: {userInfo.name}</p>
        <p>Email: {userInfo.email}</p>
      </div>
      <div>
        <h3>Visit Count to Destination</h3>
        <p>Number of Visits: {visitCount}</p>
      </div>
    </div>
  );
};

export default ProfilePage;
