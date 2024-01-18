import React, { useState, useEffect } from 'react';
import './componentstyling/casuspage.css';
import { useAuth } from './AuthContext';

const Casussen = () => {
    const [selectedCasus, setSelectedCasus] = useState(null);
    const { isLoggedIn, logOut } = useAuth(false);
    const [userRole, setUserRole] = useState('gast');
    const [casussenData, setCasussenData] = useState([]);
    const [onderzoekenData, setOnderzoekenData] = useState([]);

    useEffect(() => {
// Functie voor het ophalen van onderzoeken met Swagger
        const fetchOnderzoekenData = async () => {
            try {
                // Voer hier de Swagger-fetching logica in voor onderzoeken
                // Vervang de onderstaande URL door de werkelijke Swagger API-endpoint
                const onderzoekenResponse = await fetch('https://api.example.com/onderzoeken');
                const onderzoekenData = await onderzoekenResponse.json();

                setOnderzoekenData(onderzoekenData);
            } catch (error) {
                console.error('Fout bij het ophalen van onderzoeken:', error);
            }
        };

        fetchOnderzoekenData();
    }, []); 

    const handleInschrijvenClick = (item) => {
        if (isLoggedIn) {
            setSelectedCasus(item);
        } else {
            console.log("Please log in to subscribe.");
        }
    };

    const sluitVenster = () => {
        setSelectedCasus(null);
    };

    return (
        <div>
            <div className="casussen-container">
                {casussenData.map((casus) => (
                    <div key={casus.id} className="casus-card">
                        <h1>{casus.type}</h1>
                        <h2>{casus.titel}</h2>
                        <p>{casus.beschrijving}</p>
                        <button className={"button"} onClick={() => handleInschrijvenClick(casus)}>Inschrijven</button>
                    </div>
                ))}

                {onderzoekenData.map((onderzoek) => (
                    <div key={onderzoek.id} className="casus-card">
                        <h1>{onderzoek.type}</h1>
                        <h2>{onderzoek.titel}</h2>
                        <p>{onderzoek.beschrijving}</p>
                        <button className={"button"} onClick={() => handleInschrijvenClick(onderzoek)}>Inschrijven</button>
                    </div>
                ))}
            </div>

            {selectedCasus && (
                <div className="venster">
                    <div className="venster-inhoud">
                        <span className="sluit" onClick={sluitVenster}>
                            &times;
                        </span>
                        <h1>{selectedCasus.type}</h1>
                        <h2>{selectedCasus.titel}</h2>
                        <p>{selectedCasus.beschrijving}</p>
                        <button>Inschrijven</button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default Casussen;
