import React, { useState, useEffect } from 'react';
import './componentstyling/casuspage.css';
import { useAuth } from './AuthContext';

const Casussen = () => {
    const [selectedCasus, setSelectedCasus] = useState(null);
    const { isLoggedIn, logOut } = useAuth(false);
    const [userRole, setUserRole] = useState('gast');
    const [casussenData, setCasussenData] = useState([]);
    const [onderzoekenData, setOnderzoekenData] = useState([]);
    const [resultaten, setResultaten] = useState([]);

    useEffect(() => {
        const fetchOnderzoekenData = async () => {
            try {
                const onderzoekenResponse = await fetch('https://localhost:7211/Onderzoek');
                let responseJson = await onderzoekenResponse.json();

                let onderzoekenData = responseJson.$values;

                onderzoekenData = onderzoekenData.filter(item => item.status === 'Open');

                setOnderzoekenData(onderzoekenData);

                // Maak een lege array om de resultaten in op te slaan
                let resultatenArray = [];

                // Loop door de onderzoekenData
                for (let i = 0; i < onderzoekenData.length; i++) {
                    const onderzoek = onderzoekenData[i];
                    // Voeg het onderzoek toe aan de resultatenArray
                    resultatenArray.push(onderzoek);
                }

                // Update de resultaten staat variabele
                setResultaten(resultatenArray);
            } catch (error) {
                console.error('Fout bij het ophalen van onderzoeken:', error);
            }
        };

        fetchOnderzoekenData();
    }, []);

    const handleInschrijvenClick = async (item) => {
        if (isLoggedIn) {
            try {
                const response = await fetch(`https://localhost:7211/Onderzoek/register/${item.id}`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                console.log(data);
            } catch (error) {
                console.error('Fout bij het inschrijven:', error);
            }
        } else {
            alert("Je bent niet ingelogd");
        }
    };

    const sluitVenster = () => {
        setSelectedCasus(null);
    };

    return (
        <div className="casussen-container">
            {/* Render de resultaten */}
            {resultaten.map((onderzoek) => (
                <div key={onderzoek.id} className='casus-card'>
                    <h1>{onderzoek.categorie}</h1>
                    <h2>{onderzoek.titel}</h2>
                    <p>{onderzoek.beschrijving}</p>
                    <button className={"button"} onClick={() => handleInschrijvenClick(onderzoek)}>Inschrijven</button>
                </div>
            ))}
        </div>
    );
};


export default Casussen;
