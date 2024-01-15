import React from 'react';
import { Link } from 'react-router-dom';
import './componentstyling/navbar.css';
import logo from './media/Logo Icon/icon_accessibility.png';
import { useAuth } from './AuthContext';

const Navbar = () => {
    const { isLoggedIn, userRole, logOut } = useAuth(false);

    const handleLogout = () => {
        logOut();
    };

    return (
        <nav>
            <div className="navbar-container">
                <div className="navbar-left">
                    <img src={logo} className="navbar-logo" alt="logo" style={{ height: '50px' }} />
                    <Link to="/home" className="navbar-logo">Stichting Accessibility</Link>
                </div>

                <ul className="navbar-links">
                    <li><Link to="/casussen" className="navbar-link">Casussen▼</Link></li>

                    {isLoggedIn && userRole === 'gebruiker' && (
                        <>  
                            <li><Link to="/mijncasussen" className="navbar-link">Mijn Casussen▼</Link></li>
                            <li><Link to="/usersettings" className="login-button">Account▼</Link></li>
                        </>
                    )}

                    {isLoggedIn && userRole === 'bedrijf' && (
                        <>
                            <li><Link to="/bedrijfportaal" className="navbar-link">Bedrijfsportaal▼</Link></li>
                            <li><Link to="/" onClick={handleLogout} className="login-button">Uitloggen▼</Link></li>
                        </>
                    )}

                    {isLoggedIn && userRole === 'beheerder' && (
                        <>
                            <li><Link to="/beheerderportal" className="navbar-link">Beheerdersportaal▼</Link></li>
                            <li><Link to="/logout" onClick={handleLogout} className="login-button">Uitloggen▼</Link></li>
                        </>
                    )}

                    {!isLoggedIn && (
                        <li><Link to="/login" className="login-button">Login▼</Link></li>
                    )}
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
