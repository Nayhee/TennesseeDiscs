import React from 'react';
import { StrictMode } from 'react';
import { createRoot } from "react-dom/client";
import { BrowserRouter as Router } from "react-router-dom";
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './components/App';

const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
    <StrictMode>
        <Router>
          <App/>
        </Router>
    </StrictMode>
);