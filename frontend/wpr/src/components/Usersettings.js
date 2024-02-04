        import React, { useState, useEffect } from 'react';
        import './componentstyling/usersettings.css';
        import Navbar from './Navbar';
        import { useNavigate } from 'react-router-dom';
        
        const UserSettings = () => {
            const [name, setName] = useState('');
            const [email, setEmail] = useState('');
            const [nieuwemail, setNieuwemail] = useState('');
            const [phone, setPhone] = useState('');
            const [nieuweTel, setNieuwetel] = useState('');
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
                    setPhone(data.phoneNumber);
                    setPostcode(data.postCode);
                    setUserData(data);
                };

                fetchUserData();
            }, []);

    
    
    
            const handleEditClick = () => {
                setIsEditing(true);
            };
            const handleVerwijderaccount = () => {
                fetch(`https://localhost:7211/Gebruiker/verwijderen/${token}`, {
                    method: 'DELETE',
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem('access_token'),
                        'Content-Type': 'application/json',
                    },
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Er is een fout opgetreden bij het verwijderen van het account');
                        }
                        alert('Account succesvol verwijderd');
                        localStorage.removeItem("access_rol")
                        localStorage.removeItem("access_token")
                        navigate('/home');
    
                    })
                    .catch(error => console.error('Error:', error));
            };
    
            const navigate = useNavigate();
        
            const handleCloseEdit = () => {
                setIsEditing(false);
            };

            const handleOpslaan = async () => {
                let body = {};
                if (nieuwemail !== '') {
                    body.nieuweEmail = nieuwemail;
                }
                else {body.nieuweEmail = email;}
                if (nieuweTel !== '') {
                    body.nieuweTelefoon = nieuweTel;
                }
                else {body.nieuweTelefoon = phone;}

                await fetch('https://localhost:7211/Gebruiker/bijwerken/User1', {
                    method: 'PUT',
                    headers: {
                        'Accept': '*/*',
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(body)
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Network response was not ok');
                        }
                        return response.status;
                    })
                    .then(() => {
                        window.location.reload();
                    });
            }


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
                                <input type="text" value={name} disabled={!isEditing} onChange={(e) => setName(e.target.value)} />
                            </label>
                            <br />
                            <label>
                                Email:
                                <input type="email" value={email} disabled={!isEditing} onChange={(e) => setEmail(e.target.value)}/>
                            </label>
                            <br />
                            <label>
                                Telefoonnummer:
                                <input type="tel" value={phone} disabled={!isEditing} onChange={(e) => setPhone(e.target.value)} />
                            </label>
                            <br />
                            <label>
                                Benaderingsvoorkeur:
                                <select type="text" value={voorkeur} disabled={!isEditing} onChange={(e) => setVoorkeur(e.target.value)}>
                                    <option value="telefoon">Telefonisch contact</option>
                                    <option value="e-mail">Mail berichten</option>
                                </select>
                            </label>
                            <br />
                            <label>
                                Beperkingen: <span>{selectedRestrictions.join(', ')}</span>
                            </label>
                            <button type="button" onClick={handleEditClick}>
                                Wijzig informatie
                            </button>
                            <br/>
                            <button type="button" onClick={handleLogout}>
                                Uitloggen ↩
                            </button>
                            <button type="button" onClick={handleVerwijderaccount}>
                                Verwijder Account
                            </button>
                        </form>
                    </div>
        
                    {isEditing && (
                        <div className="venster">
                            <div className="venster-inhoud">
                    <span className="sluit" onClick={handleCloseEdit}>
                      &times;
                    </span>
                                <h1>Wijzig email</h1>
                                <input
                                    type="text"
                                    onChange={(event) => setNieuwemail(event.target.value)}
                                />
                                <h1>Wijzig telefoonnummer</h1>

                                <input
                                    type="text"
                                    onChange={(event) => setNieuwetel(event.target.value)}
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
        
        export default UserSettings;
