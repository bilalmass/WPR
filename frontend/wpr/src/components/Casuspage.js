import React, { useState } from 'react';
import './componentstyling/casuspage.css';
import dummydata from './dummydata/onderzoekendummy'

const Casussen = () => {
    const [selectedCasus, setSelectedCasus] = useState(null);

    const handleInschrijvenClick = (casus) => {
        setSelectedCasus(casus);
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
                        <button onClick={() => handleInschrijvenClick(casus)}>Inschrijven</button>
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
