import React, { useContext } from 'react';
import { Outlet, Navigate } from 'react-router-dom';

import AuthContext from '../../context/auth/authContext';

const PrivateRoute = () => {
  const authContext = useContext(AuthContext);

  const { isAuthenticated } = authContext;

  return isAuthenticated || localStorage.token ? (
    <Outlet />
  ) : (
    <Navigate to='/login' />
  );
};

export default PrivateRoute;
