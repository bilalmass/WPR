import React from 'react';
import { Link } from 'react-router-dom';
import Navbar from './Navbar';
import './componentstyling/bedrijfportal.css';

const Bedrijfportal = () => {
    return (
        <>
            <div className="beheerder-portal">
                <h1>Bedrijfsportaal</h1>

                <Link to="/bedrijfportaal/onderzoeken">
                    <button className="portal-button">Onderzoek aanmaken</button>
                </Link>
                
            </div>
        </>
    );
};

export default Bedrijfportal;