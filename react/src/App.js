import React from 'react';
import logo from './logo.svg';
import './App.css';
import './Clients'
import { Clients } from './Clients';
import { Contacts } from './Contacts';
import { FormContact } from './FormContact';
function App() {
  return (
    <div className="App">
      
      {/* <Clients></Clients> */}
      <FormContact></FormContact>
      <Contacts></Contacts>
    </div>
  );
}

export default App;
