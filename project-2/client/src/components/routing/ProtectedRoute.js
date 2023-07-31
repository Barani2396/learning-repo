import React, { useContext } from 'react';
import { Outlet, Navigate } from 'react-router-dom';

import AuthContext from '../../context/auth/authContext';

const ProtectedRoute = () => {
  const authContext = useContext(AuthContext);

  const { isAuthenticated } = authContext;

  return isAuthenticated || localStorage.token ? (
    <Navigate to='/' />
  ) : (
    <Outlet />
  );
};

export default ProtectedRoute;
