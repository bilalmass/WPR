import React, {useEffect, useState} from 'react';
import { Link } from 'react-router-dom';
import './componentstyling/navbar.css';
import logo from './media/Logo Icon/icon_accessibility.png';

const Navbar = ({ refreshKey }) => {
    const [userDiscriminator, setUserDiscriminator] = useState(localStorage.getItem("access_rol"));

    useEffect(() => {
        const handleStorageChange = () => {
            setUserDiscriminator(localStorage.getItem("access_rol"));
        };

        window.addEventListener('storage', handleStorageChange);

        return () => {
            window.removeEventListener('storage', handleStorageChange);
        };
    }, [refreshKey]);

    return (
        <nav>
            <div className="navbar-container">
                <div className="navbar-left">
                    <img src={logo} className="navbar-logo" alt="logo" style={{ height: '50px' }} />
                    <Link to="/home" className="navbar-logo">Stichting Accessibility</Link>
                </div>

                <ul className="navbar-links">
                    <li><Link to="/casussen" className="navbar-link">Casussen▼</Link></li>

                    {userDiscriminator === 'Ervaringsdeskundige' && (
                        <>
                            <li><Link to="/mijncasussen" className="navbar-link">Mijn Casussen▼</Link></li>
                            <li><Link to="/usersettings" className="login-button">Account▼</Link></li>
                        </>
                    )}

                    {userDiscriminator === 'bedrijf' && (
                        <>
                            <li><Link to="/bedrijfportaal" className="navbar-link">Bedrijfsportaal▼</Link></li>
                            <li><Link to="/" className="login-button">Uitloggen▼</Link></li>
                        </>
                    )}

                    {userDiscriminator === 'beheerder' && (
                        <>
                            <li><Link to="/beheerderportal" className="navbar-link">Beheerdersportaal▼</Link></li>
                            <li><Link to="/logout" className="login-button">Uitloggen▼</Link></li>
                        </>
                    )}

                    {userDiscriminator == null && (
                        <li><Link to="/login" className="login-button">Login▼</Link></li>
                    )}
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
