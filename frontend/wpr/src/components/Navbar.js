import React, { useState } from 'react';
import './componentstyling/navbar.css';
import logo from './media/Logo Icon/icon_accessibility.png';

const Navbar = () => {
    // Stel de gebruikersstatus in (bijvoorbeeld ingelogd of niet-ingelogd)
    const [isLoggedIn, setLoggedIn] = useState(false);

    return (
        <nav>
            <div className="navbar-container">
                <div className="navbar-left">
                    <img src={logo} className="navbar-logo" alt="logo" style={{ height: '50px' }} />
                    <a href="Home" className="navbar-logo">Stichting Accessibility</a>
                </div>

                <ul className="navbar-links">
                    <li><a href="#" className="navbar-link">Sectoren▼</a></li>
                    <li><a href="casussen" className="navbar-link">Casussen▼</a></li>
                    <li><a href="#" className="navbar-link">Toegankelijkheid▼</a></li>
                    <li><a href="#" className="navbar-link">Actueel▼</a></li>

                    {/* Voorwaardelijke weergave van de login-knop op basis van de gebruikersstatus */}
                    {isLoggedIn ? (
                        // Gebruiker is ingelogd
                        <li><a href="account" className="login-button">Account▼</a></li>
                    ) : (
                        // Gebruiker is niet ingelogd
                        <li><a href="login" className="login-button">Login▼</a></li>
                    )}
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
