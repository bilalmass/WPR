import React, {useEffect, useState} from 'react';
import { Link } from 'react-router-dom';
import './componentstyling/navbar.css';
import logo from './media/Logo Icon/icon_accessibility.png';
import { useNavigate } from 'react-router-dom';

const Navbar = ({ refreshKey }) => {
    const navigate = useNavigate(); 
    const [userDiscriminator, setUserDiscriminator] = useState(localStorage.getItem("access_rol"));
    const handleLogout = () => {
        localStorage.removeItem('access_token');
        localStorage.removeItem('access_rol')
        navigate('/home');
        window.location.reload();
    };
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

                    {userDiscriminator === 'Bedrijf' && (
                        <>
                            <li><Link to="/bedrijfportaal" className="navbar-link">Bedrijfsportaal▼</Link></li>
                            <li><button onClick={handleLogout} className="login-button">Uitloggen▼</button></li>
                        </>
                    )}

                    {userDiscriminator === 'Beheerder' && (
                        <>
                            <li><Link to="/beheerderportal" className="navbar-link">Beheerdersportaal▼</Link></li>
                            <li><button onClick={handleLogout} className="login-button">Uitloggen▼</button></li>
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
