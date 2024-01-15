import React, { useState } from 'react';
import './componentstyling/casuspage.css';
import dummydata from './dummydata/onderzoekendummy'
import { useAuth } from './AuthContext';

const Casussen = () => {
    const [selectedCasus, setSelectedCasus] = useState(null);
    const { isLoggedIn, logOut } = useAuth(false);
    const [userRole, setUserRole] = useState('gast');

    const handleInschrijvenClick = (casus) => {
        if (isLoggedIn) {
            setSelectedCasus(casus);
        } else {
            console.log("Please log in to subscribe.");
        }
    };

    const sluitVenster = () => {
        setSelectedCasus(null);
    };

    const casussenData = dummydata;
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
