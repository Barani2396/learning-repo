import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import Navbar from './components/layout/Navbar';
import Alert from './components//layout/Alert';
import Home from './components/pages/Home';
import About from './components/pages/About';
import User from './components/users/User';
import Notfound from './components/pages/Notfound';

import GithubState from './context/github/GithubState';
import AlertState from './context/alert/AlertState';

import './App.css';

const App = () => {
  return (
    <GithubState>
      <AlertState>
        <BrowserRouter>
          <div className='App'>
            <Navbar />
            <div className='container'>
              <Alert />
              <Routes>
                <Route exact path='/' element={<Home />} />
                <Route exact path='/About-us' element={<About />} />
                <Route exact path='user/:loginName' element={<User />} />
                <Route path='*' element={<Notfound />} />
              </Routes>
            </div>
          </div>
        </BrowserRouter>
      </AlertState>
    </GithubState>
  );
};

export default App;
