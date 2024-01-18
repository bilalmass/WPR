import React, { useState, useEffect } from 'react';
import Navbar from './Navbar';
import './componentstyling/beheerderpage.css';
import { Link } from 'react-router-dom';

const BeheerderOnderzoekview = () => {
    const [onderzoeken, setOnderzoeken] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                // Voer hier de Swagger-fetching logica in
                // Vervang de onderstaande URL door de werkelijke Swagger API-endpoint
                const response = await fetch('https://api.example.com/onderzoeken');
                const data = await response.json();

                setOnderzoeken(data);
            } catch (error) {
                console.error('Fout bij het ophalen van gegevens:', error);
            }
        };

        fetchData();
    }, []);

    const OnderzoekenList = ({ onderzoeken }) => {
        return (
            <div className="onderzoeken-lijst">
                <h2>Lijst van Lopende Onderzoeken</h2>
                <ul>
                    {onderzoeken.map((onderzoek) => (
                        <li key={onderzoek.id}>
                            <strong>{onderzoek.titel}</strong>
                            <p>{onderzoek.beschrijving}</p>
                            <p>Uitvoerder: {onderzoek.uitvoerder}</p>
                            <p>Datum: {onderzoek.datum}</p>
                            <p>Locatie: {onderzoek.locatie}</p>
                            <p>Beloning: {onderzoek.beloning}</p>
                            <p>Type: {onderzoek.type}</p>
                            <p>Status: {onderzoek.status}</p>
                        </li>
                    ))}
                </ul>
            </div>
        );
    };

    return (
        <>
            <div className="beheerder-portal">
                <Link to="/beheerderportal">Terug naar Beheerder Portal</Link>
                <h1>Beheerderportal</h1>
                <OnderzoekenList onderzoeken={onderzoeken} />
            </div>
        </>
    );
};

export default BeheerderOnderzoekview;
