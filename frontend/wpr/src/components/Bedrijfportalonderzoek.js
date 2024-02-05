        import React, { useState } from 'react';
        import { Link } from 'react-router-dom';
        import Navbar from './Navbar';
        import './componentstyling/bedrijfportalonderzoek.css';

        const Bedrijfportalonderzoek = () => {
            const rol = localStorage.getItem("access_rol");
            const [titel, setTitel] = useState('');
            const [beschrijving, setBeschrijving] = useState('');
            const [start, setStart] = useState('');
            const [categorie, setCategorie] = useState('');
            const [beloning, setBeloning] = useState('');

            if (rol !== "Bedrijf") {
                return <div>Deze pagina is niet toegankelijk.</div>;
            }

            const handleSubmit = (e) => {
                e.preventDefault();
                fetch('https://localhost:7211/Onderzoek/create', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        Titel: titel,
                        Beschrijving: beschrijving,
                        Start: start,
                        Categorie: categorie,
                        Beloning: beloning,
                    }),        
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.json();
                    })
        
                    .then(data => {
                        console.log('Success:', data);
                    })
                    .catch(error => {
                        console.error('Error:', error);
                    });
            };
            return (
                <>
                    <div className="beheerder-portal">
                        <h1>Onderzoek aanmaken</h1>
        
                        <Link to="/bedrijfportaal"> 
                            <button className="portal-button">Terug naar Overzicht</button>
                        </Link>
        
                        <div className="onderzoek-form">
                            <h2>Onderzoek Details</h2>
                            <form onSubmit={handleSubmit}>
                                <label>
                                    Titel:
                                    <input
                                        type="text"
                                        name="titel"
                                        value={titel}
                                        onChange={e => setTitel(e.target.value)}
                                        required
                                    />
                                </label>
                                <br />
                                
                                <label>
                                     Beschrijving:
                                    <textarea
                                        type="text"
                                        name="beschrijving"
                                        value={beschrijving}
                                        onChange={e => setBeschrijving(e.target.value)}
                                        required
                                    ></textarea>
                                </label>
                                <br />
        
                                <label>
                                    Datum:
                                    <input
                                        type="date"
                                        name="start"
                                        value={start}
                                        onChange={e => setStart(e.target.value)}
                                        required
                                    />
    
                                </label>
                                <br />
        
                                <label>
                                    Soort onderzoek:
                                    <select
                                        name="researchType"
                                    >
                                        <option value="online">Online onderzoek</option>
                                        <option value="engels">Engelstalig onderzoek</option>
                                        <option value="interview">Interview</option>
                                        <option value="groepsgesprek">Groepsgesprek</option>
                                        value={categorie}
                                        onChange={e => setCategorie(e.target.value)}
                                    </select>
                                </label>
                                <br />
        
                                <label>
                                    Beloning:
                                    <input
                                        type="text"
                                        name="beloning"
                                        value={beloning}
                                        onChange={e => setBeloning(e.target.value)}
        
                                    />
                                </label>
                                <br />
        
                                <button type="submit">Onderzoek Aanmaken</button>
                            </form>
                        </div>
                    </div>
                </>
            );
        };
        
        export default Bedrijfportalonderzoek;
