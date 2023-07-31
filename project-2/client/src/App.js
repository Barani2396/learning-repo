import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Navbar from './components/layout/Navbar';
import Alerts from './components/layout/Alerts';
import Register from './components/auth/Register';
import Login from './components/auth/Login';
import Home from './components/pages/Home';
import About from './components/pages/About';

import PrivateRoute from './components/routing/PrivateRoute';
import ProtectedRoute from './components/routing/ProtectedRoute';

import AuthState from './context/auth/AuthState';
import ContactState from './context/contact/ContactState';
import AlertState from './context/alert/AlertState';

import setAuthToken from './utils/setAuthToken';

import './App.css';

if (localStorage.token) {
  setAuthToken(localStorage.token);
}

const App = () => {
  return (
    <AuthState>
      <ContactState>
        <AlertState>
          <BrowserRouter>
            <>
              <Navbar />
              <div className='container'>
                <Alerts />
                <Routes>
                  <Route element={<PrivateRoute />}>
                    <Route exact path='/' element={<Home />} />
                  </Route>
                  <Route exact path='/about' element={<About />} />
                  <Route element={<ProtectedRoute />}>
                    <Route exact path='/register' element={<Register />} />
                    <Route exact path='/login' element={<Login />} />
                  </Route>
                </Routes>
              </div>
            </>
          </BrowserRouter>
        </AlertState>
      </ContactState>
    </AuthState>
  );
};

export default App;
