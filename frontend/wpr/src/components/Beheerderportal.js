import React from 'react';
import { Link } from 'react-router-dom';
import Navbar from './Navbar';
import './componentstyling/beheerderpage.css';

const Beheerderportal = () => {
    const rol = localStorage.getItem("access_rol");
    if (rol !== "Beheerder") {
        return <div>Deze pagina is niet toegankelijk.</div>;
    }
    return (
        <>
            <div className="beheerder-portal">
                <h1>Beheerderportal</h1>

                <Link to="/beheerderportal/gebruikers">
                    <button className="portal-button">Gebruikers</button>
                </Link>

                <Link to="/beheerderportal/onderzoeken">
                    <button className="portal-button">Onderzoeken</button>
                </Link>
            </div>
        </>
    );
};

export default Beheerderportal;

