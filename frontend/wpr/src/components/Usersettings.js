import React, { useState, useEffect } from 'react';
import './componentstyling/usersettings.css';
import { useAuth } from './AuthContext';
import Navbar from './Navbar';
import { Link, useNavigate } from 'react-router-dom';

const UserSettings = () => {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [phone, setPhone] = useState('');
    const [voorkeur, setVoorkeur] = useState('');
    const [postcode, setPostcode] = useState('');
    const [onderzoeken, setOnderzoeken] = useState('');
    const [beperkingen, setBeperkingen] = useState('');
    const [isEditing, setIsEditing] = useState(false);
    const [blindness, setBlindness] = useState(false);
    const [lowVision, setLowVision] = useState(false);
    const [colorBlindness, setColorBlindness] = useState(false);
    const [selectedRestrictions, setSelectedRestrictions] = useState([]);
    let token = localStorage.getItem('access_token')
    const [userData, setUserData] = useState(null);

    useEffect(() => {
        const fetchUserData = async () => {
            const response = await fetch(`https://localhost:7211/Gebruiker/gebruikerinfo/${token}`, {
                method: 'GET',
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('access_token'),
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                throw new Error('Er is een fout opgetreden bij het ophalen van de gebruikersgegevens');
            }

            const data = await response.json();
            setName(data.userName);
            setEmail(data.email);
            setPhone(data.telefoonnummer);
            setPostcode(data.postCode);
            setVoorkeur(data.voorkeur);
            setBeperkingen(data.beperkingen);
            setUserData(data);
        };

        fetchUserData();
    }, []);



    const handleEditClick = () => { 
        setIsEditing(true);
    };
    const navigate = useNavigate();

    const handleCloseEdit = () => {
        setIsEditing(false);
    };

    const handleSave = () => {
        setSelectedRestrictions([
            blindness && 'Blindheid',
            lowVision && 'Slechtziendheid',
            colorBlindness && 'Kleurenblindheid',
        ].filter(Boolean));

        setIsEditing(false);
    };

    const handleLogout = () => {
        localStorage.removeItem('access_token');
        localStorage.removeItem('access_rol')
        navigate('/home');

    };

    return (
        <>
            <div className="user-settings-container">
                <h2>Gebruikersinstellingen</h2>
                <form>
                    <label>
                        Naam:
                        <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
                    </label>
                    <br />
                    <label>
                        Email:
                        <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
                    </label>
                    <br />
                    <label>
                        Telefoonnummer:
                        <input type="tel" value={phone} onChange={(e) => setPhone(e.target.value)} />
                    </label>
                    <br />
                    <label>
                        Postcode:
                        <input type="text" value={postcode} onChange={(e) => setPostcode(e.target.value)} />
                    </label>
                    <br />
                    <label>
                        Benaderingsvoorkeur:
                        <select type="text" value={voorkeur} onChange={(e) => setVoorkeur(e.target.value)}>
                            <option value="telefoon">Telefonisch contact</option>
                            <option value="e-mail">Mail berichten</option>
                        </select>
                    </label>
                    <br />
                    <label>
                        Beperkingen: <span>{selectedRestrictions.join(', ')}</span>
                    </label>
                    <button type="button" onClick={handleEditClick}>
                        Wijzig
                    </button>
                    <br/>
                    <button type="submit" onClick={handleSave}>
                        Opslaan
                    </button>
                    <button type="button" onClick={handleLogout}>
                        Uitloggen
                    </button>
                </form>
            </div>

            {isEditing && (
                <div className="venster">
                    <div className="venster-inhoud">
            <span className="sluit" onClick={handleCloseEdit}>
              &times;
            </span>
                        <h1>Editing Beperkingen</h1>
                        <span>Blindheid</span>
                        <input
                            type="checkbox"
                            checked={blindness}
                            onChange={() => setBlindness(!blindness)}
                        />

                        <br />
                        
                        <span>Slechtziendheid</span>
                        <input
                            type="checkbox"
                            checked={lowVision}
                            onChange={() => setLowVision(!lowVision)}
                        />

                        <br />

                        <span>Kleurenblindheid</span>
                        <input
                            type="checkbox"
                            checked={colorBlindness}
                            onChange={() => setColorBlindness(!colorBlindness)}
                        />
                        <br />
                        <button className="btnopslaan" onClick={handleSave}>
                            Opslaan
                        </button>
                        
                    </div>
                </div>
            )}
        </>
    );
};

export default UserSettings;
