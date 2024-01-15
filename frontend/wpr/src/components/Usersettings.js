import React, { useState } from 'react';
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
    const { logOut } = useAuth();
    const [selectedRestrictions, setSelectedRestrictions] = useState([]);

    
    
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
        logOut();
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
                        Type onderzoeken:
                        <input type="text" value={onderzoeken} onChange={(e) => setOnderzoeken(e.target.value)} />
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
