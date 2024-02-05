import React, { useState } from 'react';
import { useAuth } from './AuthContext';
import style from './componentstyling/onderzoekform.css';
import {Link} from "react-router-dom";

function OnderzoekForm() {
    const { authToken } = useAuth();

    
    const [onderzoekData, setOnderzoekData] = useState({
        titel: '',
        beschrijving: '',
        start: '',
        categorie: '',
        beloning: ''
    });

    
    const rol = localStorage.getItem("access_rol");
    if (rol !== "Beheerder") {
        return <div>Ga terug naar de <Link to="/home">homepage</Link>.</div>;
    }

 const handleInputChange = (e) => {
    const { name, value } = e.target;
    setOnderzoekData(prevState => ({
      ...prevState,
      [name]: value
    }));
 };

 const handleSubmit = async (e) => {
    e.preventDefault();

    try {
        const response = await fetch('https://localhost:7211/Onderzoek/create', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${authToken}`,
          },
          body: JSON.stringify(onderzoekData)
        });
    
        if (response.ok) {
          const result = await response.json();
          console.log('Onderzoek succesvol aangemaakt:', result);
        } else {
          console.error(`Error: ${response.status}`);
        }
      } catch (error) {
        console.error('Network error:', error);
      }

    console.log(onderzoekData);

    setOnderzoekData({
      titel: '',
      beschrijving: '',
      start: '',
      categorie: '',
      beloning: ''
    });
 };

  return (
    <div className="onderzoek-form">
      <h2>Maak een nieuw onderzoek aan</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Titel:</label>
          <input
            type="text"
            name="titel"
            value={onderzoekData.titel}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Beschrijving:</label>
          <textarea
            name="beschrijving"
            value={onderzoekData.beschrijving}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Startdatum:</label>
          <input
            type="date"
            name="start"
            value={onderzoekData.start}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Categorie:</label>
          <input
            type="text"
            name="categorie"
            value={onderzoekData.categorie}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Beloning:</label>
          <input
            type="number"
            name="beloning"
            value={onderzoekData.beloning}
            onChange={handleInputChange}
          />
        </div>
        <button type="submit">Onderzoek aanmaken</button>
      </form>
    </div>
  );
}

export default OnderzoekForm;
