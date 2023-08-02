import React, { useEffect } from 'react';

import { Provider } from 'react-redux';
import store from './store';

import SearchBar from './components/layout/SearchBar';
import Logs from './components/logs/Logs';
import AddBtn from './components/layout/AddBtn';
import AddLogModal from './components/logs/AddLogModal';
import EditLogModal from './components/logs/EditLogModal';
import AddTechModal from './components/techs/AddTechModal';
import TechListModal from './components/techs/TechListModal';

import 'materialize-css/dist/css/materialize.min.css';
import M from 'materialize-css/dist/js/materialize.min.js';
import './App.css';

function App() {
  useEffect(() => {
    M.AutoInit();
    // eslint-disable-next-line
  });
  return (
    <Provider store={store}>
      <>
        <SearchBar />
        <div className='container'>
          <Logs />
          <AddBtn />
          <AddLogModal />
          <EditLogModal />
          <AddTechModal />
          <TechListModal />
        </div>
      </>
    </Provider>
  );
}

export default App;
