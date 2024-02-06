import React, { useState, useEffect } from 'react';
import Navbar from './Navbar';
import './componentstyling/beheerderpage.css';
import { Link } from 'react-router-dom';

const BeheerderOnderzoekview = () => {
    const [onderzoeken, setOnderzoeken] = useState([]);
    const [isEditing, setIsEditing] = useState(false);
    const [selectedResearch, setSelectedResearch] = useState(null);
    const [nieuweTitel, setNieuweTitel] = useState('');
    const [nieuweBeschrijving, setNieuweBeschrijving] = useState('');
    const [nieuweBeloning, setNieuweBeloning] = useState('');
    const [nieuweCategorie, setNieuweCategorie] = useState('');
    const [nieuweStart, setNieuweStart] = useState('');

    // Moved fetchData outside of useEffect
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

    useEffect(() => {
        fetchData(); // Call fetchData within the useEffect
    }, []);
    const handleOpenEdit = (onderzoek) => {
        setIsEditing(true);
        setSelectedResearch(onderzoek);
        setNieuweTitel(onderzoek.titel);
        setNieuweBeschrijving(onderzoek.beschrijving);
        setNieuweBeloning(onderzoek.beloning);
        setNieuweCategorie(onderzoek.categorie)
    };
    const handleOpslaan = async () => {
        const updatedResearch = {
            titel: nieuweTitel,
            beschrijving: nieuweBeschrijving,
            start: nieuweStart, // Make sure this value is set correctly
            categorie: nieuweCategorie,
            beloning: nieuweBeloning,
        };

        try {
            const response = await fetch(`https://localhost:7211/Onderzoek/update/${selectedResearch.onderzoekId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': '*/*'
                },
                body: JSON.stringify(updatedResearch)
            });

            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            
            fetchData(); // Assuming fetchData is the function that loads the initial data

            setIsEditing(false);
        } catch (error) {
            console.error('Error during UPDATE request:', error);
        }
    };


    const handleCloseEdit = () => {
        setIsEditing(false);
    };

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
                        <li key={onderzoek.onderzoekId}>
                            <strong>{onderzoek.titel}</strong>
                            {onderzoek.beschrijving && <p>{onderzoek.beschrijving}</p>}
                            {onderzoek.onderzoekId && <p>ID: {onderzoek.onderzoekId}</p>}
                            {onderzoek.uitvoerder && <p>Uitvoerder: {onderzoek.uitvoerder}</p>}
                            {onderzoek.start && <p>Datum: {onderzoek.start}</p>}
                            {onderzoek.locatie && <p>Locatie: {onderzoek.locatie}</p>}
                            {onderzoek.beloning && <p>Beloning: {onderzoek.beloning}</p>}
                            {onderzoek.categorie && <p>Type: {onderzoek.categorie}</p>}
                            {onderzoek.status && <p>Status: {onderzoek.status}</p>}
                            <button onClick={() => handleOpenEdit(onderzoek)}>Wijzig</button>
<br/>
                            <button
                                onClick={() => verwijderOnderzoek(onderzoek.onderzoekId)}
                                style={{ backgroundColor: 'red', color: 'white' }}
                            >
                                Verwijder
                            </button>
                            <br/>

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
            {isEditing && (
                <div className="venster">
                    <div className="venster-inhoud">
                        <span className="sluit" onClick={handleCloseEdit}>&times;</span>
                        <h1>Wijzig titel</h1>
                        <input
                            type="text"
                            value={nieuweTitel}
                            onChange={(event) => setNieuweTitel(event.target.value)}
                        />
                        <h1>Wijzig beschrijving</h1>
                        <input
                            type="text"
                            value={nieuweBeschrijving}
                            onChange={(event) => setNieuweBeschrijving(event.target.value)}
                        />
                        <h1>Wijzig categorie</h1>
                        <input
                            type="text"
                            value={nieuweCategorie}
                            onChange={(event) => setNieuweCategorie(event.target.value)}
                        />
                        <h1>Wijzig datum</h1>
                        <input
                            type="date"
                            value={nieuweStart}
                            onChange={(event) => setNieuweStart(event.target.value)}
                        />
                        <h1>Wijzig beloning</h1>
                        <input
                            type="text"
                            value={nieuweBeloning}
                            onChange={(event) => setNieuweBeloning(event.target.value)}
                        />
                        <button className="btnopslaan" onClick={handleOpslaan}>
                            Opslaan
                        </button>
                    </div>
                </div>
            )}
        </>
    );
};

export default BeheerderOnderzoekview;
