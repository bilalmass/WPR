import React, { useState, useEffect } from 'react';
import './componentstyling/casuspage.css';
import { useAuth } from './AuthContext';

const Casussen = () => {
    const [selectedCasus, setSelectedCasus] = useState(null);
    const { isLoggedIn, logOut } = useAuth(false);
    const [userRole, setUserRole] = useState('gast');
    const [casussenData, setCasussenData] = useState([]);
    const [onderzoekenData, setOnderzoekenData] = useState([]);
    const [filteredCasussenData, setFilteredCasussenData] = useState([]);

    useEffect(() => {
        const fetchOnderzoekenData = async () => {
            try {
                const onderzoekenResponse = await fetch('https://localhost:7211/Onderzoek/getall');
                let onderzoekenData = await onderzoekenResponse.json();

                onderzoekenData = onderzoekenData.filter(item => item.status === 'Open');

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
                {filteredCasussenData.map((casus) => (
                    <div key={casus.id} className="casus-card">
                        <h1>{casus.categorie}</h1>
                        <h2>{casus.titel}</h2>
                        <p>{casus.beschrijving}</p>
                        <button className={"button"} onClick={() => handleInschrijvenClick(casus)}>Inschrijven</button>
                    </div>
                ))}
                {onderzoekenData.map((onderzoek) => (
                    <div key={onderzoek.id} className="casus-card">
                        <h1>{onderzoek.categorie}</h1>
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
                        <p>{selectedCasus.beloning}</p>
                        <p>{selectedCasus.start}</p>
                        <button>Inschrijven</button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default Casussen;
