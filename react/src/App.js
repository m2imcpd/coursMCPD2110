import React from 'react';
import logo from './logo.svg';
import './App.css';
import './Clients'
import { Clients } from './Clients';
import { Contacts } from './Contacts';
function App() {
  return (
    <div className="App">
      
      {/* <Clients></Clients> */}
      <Contacts></Contacts>
    </div>
  );
}

export default App;
