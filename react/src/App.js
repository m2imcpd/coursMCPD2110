import React, { useState } from 'react';
import logo from './logo.svg';
import './App.css';
import './Clients'
import { Clients } from './Clients';
import { Contacts } from './Contacts';
import { FormContact } from './FormContact';
import {UploadImage} from "./UploadImage"
function App() {

  const [newData, setNewData] = useState(false)
  const updateNewData = (isNewData) => {
    setNewData(isNewData)
  }
  return (
    <div className="App">
      
      {/* <Clients></Clients> */}
      {/* <FormContact updateNewData={updateNewData}></FormContact>
      <Contacts newData={newData} updateNewData={updateNewData}></Contacts> */}
      <UploadImage></UploadImage>
    </div>
  );
}

export default App;
