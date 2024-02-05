import React, { useState, useEffect } from 'react';
import Navbar from './Navbar';
import './componentstyling/beheerderpage.css';
import { Link } from 'react-router-dom';

const BeheerderOnderzoekview = () => {
    const [onderzoeken, setOnderzoeken] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch('https://localhost:7211/Onderzoek');
                const data = await response.json();
                console.log(data);
                setOnderzoeken(data.$values || []); 
            } catch (error) {
                console.error('Fout bij het ophalen van gegevens:', error);
            }
        };
    
        fetchData();
    }, []);

    const verwijderOnderzoek = async (onderzoekId) => {
        try {
            const response = await fetch(`https://localhost:7211/Onderzoek/${onderzoekId}`, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json'
                }
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const data = await response.json();
            console.log(data);
            setOnderzoeken(onderzoeken.filter(onderzoek => onderzoek.id !== onderzoekId));
        } catch (error) {
            console.error('Error during DELETE request:', error);
        }
    };



    const OnderzoekenList = ({ onderzoeken }) => {
        return (
            <div className="onderzoeken-lijst">
                <h2>Lijst van Lopende Onderzoeken</h2>
                <ul>
                    {onderzoeken.map((onderzoek) => (
                        <li key={onderzoek.id}>
                            <strong>{onderzoek.titel}</strong>
                            {onderzoek.beschrijving && <p>{onderzoek.beschrijving}</p>}
                            {onderzoek.uitvoerder && <p>Uitvoerder: {onderzoek.uitvoerder}</p>}
                            {onderzoek.datum && <p>Datum: {onderzoek.datum}</p>}
                            {onderzoek.locatie && <p>Locatie: {onderzoek.locatie}</p>}
                            {onderzoek.beloning && <p>Beloning: {onderzoek.beloning}</p>}
                            {onderzoek.categorie && <p>Type: {onderzoek.categorie}</p>}
                            {onderzoek.status && <p>Status: {onderzoek.status}</p>}
                            <button
                                onClick={() => verwijderOnderzoek(onderzoek.onderzoekId)}
                            >
                                Verwijder
                            </button>

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
