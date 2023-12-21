import React, { useState } from 'react';
import './componentstyling/casuspage.css';

const Casussen = () => {
    const [selectedCasus, setSelectedCasus] = useState(null);

    const handleInschrijvenClick = (casus) => {
        setSelectedCasus(casus);
    };

    const sluitVenster = () => {
        setSelectedCasus(null);
    };

    // Dummy data omdat er nog geen database is
    const casussenData = [
        { id: 1, type: 'Interview', title: 'Casus 1', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 2, type: 'Groepsgesprek', title: 'Casus 2', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 3, type: 'Online Onderzoek', title: 'Casus 3', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 4, type: 'Engelstalig Onderzoek', title: 'Casus 4', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 5, type: 'Engelstalig Onderzoek', title: 'Casus 5', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 6, type: 'Engelstalig Onderzoek', title: 'Casus 6', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 7, type: 'Engelstalig Onderzoek', title: 'Casus 7', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 8, type: 'Engelstalig Onderzoek', title: 'Casus 8', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
        { id: 9, type: 'Groepsgesprek', title: 'Casus 2', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.' },
    ];

    return (
        <div>
            <div className="casussen-container">
                {casussenData.map((casus) => (
                    <div key={casus.id} className="casus-card">
                        <h1>{casus.type}</h1>
                        <h2>{casus.title}</h2>
                        <p>{casus.description}</p>
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
                        <h2>{selectedCasus.title}</h2>
                        <p>{selectedCasus.description}</p>
                        <button>Inschrijven</button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default Casussen;
