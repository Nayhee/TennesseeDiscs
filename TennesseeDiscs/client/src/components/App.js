import React from "react"
import {NavBar} from "./nav/NavBar"
import { ApplicationViews } from "./ApplicationViews"
import "./App.css"

function App() {
  return (
    <div className="App">
          <NavBar/>
          <ApplicationViews/>
    </div>
  );
}

export default App;
