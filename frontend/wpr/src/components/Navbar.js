// Navbar.jsx
import React from 'react';
import './componentstyling/navbar.css';  // Aangepaste import-paden
import logo from './media/Logo Icon/icon_accessibility.png';

const Navbar = () => {
    return (
        <nav>
            <div className="navbar-container">
                <a href="#" className="navbar-logo">Stichting Accessibility</a>
                <img src={logo} className="App-logo" alt="logo" />

                <ul className="navbar-links">
                    <li><a href="#" className="navbar-link">Sectoren▼</a></li>
                    <li><a href="#" className="navbar-link">Casussen▼</a></li>
                    <li><a href="#" className="navbar-link">Toegankelijkheid▼</a></li>
                    <li><a href="#" className="navbar-link">Actueel▼</a></li>
                    <li><a href="#" className="navbar-link">Login▼</a></li>
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
