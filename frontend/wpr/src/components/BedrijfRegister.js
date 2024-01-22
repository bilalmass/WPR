import React, { useState } from 'react';
import './componentstyling/registerpage.css';
import { Navigate, useNavigate } from 'react-router-dom';

const BedrijfRegister = () => {
    const navigate = useNavigate();
    const [apiError, setApiError] = useState('');
    const [formData, setFormData] = useState({
        gebruikersNaam: '',
        Naam: '',
        email: '',
        informatie: '',
        password: '',
        confirmPassword: '',
        locatie: '',
        link: '',
    });
    const [passwordError, setPasswordError] = useState('');
    const [loading, setLoading] = useState(false);
    const [serverResponse, setServerResponse] = useState('');

    const handleInputChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        if (e.target.name === 'password' || e.target.name === 'confirmPassword') {
            setPasswordError('');
        }
    };

    const handleRegisterClick = async () => {
        setLoading(true);

        const passwordRegex = /^(?=.*[A-Z])(?=.*[0-9!@#\$%\^&\*])(?=.{8,})/;
        if (!passwordRegex.test(formData.password)) {
            setPasswordError('Wachtwoord voldoet niet aan de beveiligingseisen.');
            setLoading(false);
            return;
        }
        if (formData.password !== formData.confirmPassword) {
            setPasswordError('Wachtwoorden komen niet overeen.');
            setLoading(false);
            return;
        }

        try {
            const response = await fetch('https://localhost:7211/RegistreerBedrijf/BedrijfRegistreer', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    GebruikersNaam: formData.gebruikersNaam,
                    Email: formData.email,
                    Wachtwoord: formData.password,
                    Naam: formData.Naam,
                    Informatie: formData.informatie,
                    Locatie: formData.locatie,
                    Link: formData.link,
                }),
            });

            if (response.ok) {
                const data = await response.json();
                console.log('Success:', data);
                setServerResponse('Registratie succesvol!');
                navigate('/Login');
            } else {
                const errorData = await response.json();
                console.error('Error:', errorData);
                setApiError('Er is iets misgegaan bij het registreren. Probeer het opnieuw.');
            }
        } catch (error) {
            console.error('Error:', error);
            setApiError('Er is iets misgegaan bij het registreren. Probeer het opnieuw.');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="registration-container">
            <div className="registration-form">
                <div className="form-row">
                    <div className="input-group">
                        <label>Gebruikersnaam:</label>
                        <input type="text" name="gebruikersNaam" value={formData.gebruikersNaam} onChange={handleInputChange} />
                    </div>

                    <div className="input-group">
                        <label>Bedrijfsnaam:</label>
                        <input type="text" name="Naam" value={formData.Naam} onChange={handleInputChange} />
                    </div>
                </div>

                <div className="form-row">
                    <div className="input-group">
                        <label>Email:</label>
                        <input type="email" name="email" value={formData.email} onChange={handleInputChange} />
                    </div>

                    <div className="input-group">
                        <label>Informatie:</label>
                        <input type="text" name="informatie" value={formData.informatie} onChange={handleInputChange} />
                    </div>
                </div>

                <div className="form-row">
                    <div className="input-group">
                        <label>Wachtwoord:</label>
                        <input type="password" name="password" value={formData.password} onChange={handleInputChange} />
                    </div>

                    <div className="input-group">
                        <label>Bevestig wachtwoord:</label>
                        <input type="password" name="confirmPassword" value={formData.confirmPassword} onChange={handleInputChange} />
                    </div>
                </div>
                {passwordError && <p className="error">{passwordError}</p>}

                <div className="form-row">
                    <div className="input-group">
                        <label>Link:</label>
                        <input type="link" name="link" value={formData.link} onChange={handleInputChange} />
                    </div>

                    <div className="input-group">
                        <label>Locatie:</label>
                        <input type="text" name="locatie" value={formData.locatie} onChange={handleInputChange} />
                    </div>
                </div>

                <button onClick={handleRegisterClick} disabled={loading}>
                    {loading ? 'Registreren...' : 'Registreren'}
                </button>

                {apiError && <p className="error">{apiError}</p>}
                {serverResponse && <p>{serverResponse}</p>}
            </div>
        </div>
    );
};

export default BedrijfRegister;
