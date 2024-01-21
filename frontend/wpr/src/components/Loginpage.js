import React, { useState } from 'react';
import './componentstyling/loginpage.css';
import { Link } from 'react-router-dom';
import userDummyData from './dummydata/userdummy';

const Login = () => {
    const [showKeuze, setShowKeuze] = useState(false);
    const [loginError, setLoginError] = useState('');

    const handleRegisterClick = () => {
        setShowKeuze(true);
    };

    const handleCloseModal = () => {
        setShowKeuze(false);
    };

    const handleLogin = async (e) => {
        e.preventDefault();

        const username = e.target.username.value;
        const password = e.target.password.value;

        try {
            // Maak een HTTP-verzoek naar de Swagger API
            const response = await fetch('https://localhost:7211/Login/Login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    gebruikersNaam: username,
                    wachtwoord: password,
                }),
            });

            // Controleer of het verzoek succesvol was
            if (response.ok) {
                const data = await response.json();

                // Controleer of de inloggegevens geldig zijn
                if (data.success) {
                    console.log('Ingelogd als:', data.user);
                    setLoginError('');
                } else {
                    setLoginError('Ongeldige gebruikersnaam of wachtwoord');
                }
            } else {
                setLoginError('Er is een fout opgetreden bij het inloggen');
            }
        } catch (error) {
            console.error('Er is een fout opgetreden bij het verwerken van het inlogverzoek:', error);
            setLoginError('Er is een fout opgetreden bij het inloggen');
        }
    };

    return (
        <div className="login-container">
            <h2>Login</h2>
            <form onSubmit={handleLogin}>
                <div className="form-group">
                    <label htmlFor="adres">E-mailadres:</label>
                    <br />
                    <input type="text" id="username" name="username" />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Wachtwoord:</label>
                    <br />
                    <input type="password" id="password" name="password" />
                </div>
                {loginError && <p className="error">{loginError}</p>}
                <div className="form-options">
                    <div className="forgot-password">
                        <a href="#">Wachtwoord vergeten?</a>
                    </div>
                    <div className="register-link">
                        Nog geen lid? <a href="#" onClick={handleRegisterClick}>Registreer je hier</a>
                    </div>
                </div>
                <button className="button" type="submit">Inloggen</button>
            </form>

            <div className={`modal ${showKeuze ? 'visible' : 'hidden'}`}>
                {showKeuze && (
                    <div className="modal-content">
                        <span className="close" onClick={handleCloseModal}>&times;</span>
                        <p>Waarvoor wil je je registreren?</p>
                        <div className="button-container">
                            <Link to="/Register" className="button">Ervaringsdeskundige</Link>
                            <Link to="/BedrijfsRegister" className="button">Bedrijf</Link>
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
};

export default Login;
