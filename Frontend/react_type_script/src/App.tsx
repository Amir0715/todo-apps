import React from 'react';
import './App.css';
import MainPage from './pages/main/MainPage';

import { configure } from "mobx"
configure({
  enforceActions: "always",
})

function App() {
  return (
    <div className="App">
      <MainPage />
    </div>
  );
}

export default App;
