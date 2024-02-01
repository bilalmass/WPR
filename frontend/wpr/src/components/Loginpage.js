import React, { useState } from 'react';
import './componentstyling/loginpage.css';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import userDummyData from './dummydata/userdummy';

const Login = () => {
    let navigate = useNavigate();
    const [showKeuze, setShowKeuze] = useState(false);
    const [loginError, setLoginError] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [refreshKey, setRefreshKey] = useState(0); 

    const handleRegisterClick = () => {
        setShowKeuze(true);
    };

    const handleCloseModal = () => {
        setShowKeuze(false);
    };

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
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

            if (!response.ok) {
                throw new Error('Er is een fout opgetreden bij het inloggen');
            }

            const data = await response.json();

            if ('success' in data && data.success) {
                const response = await fetch(`https://localhost:7211/Gebruiker/discriminator/${username}`, {
                    method: 'GET',
                    headers: {
                        'Accept': 'application/json',
                    },
                });
                const discriminatorData = await response.json();
                console.log('Discriminator:', discriminatorData);
                console.log('Ingelogd als:', username);
                setLoginError('');
                localStorage.setItem('access_token', username);
                localStorage.setItem('access_rol', discriminatorData);
                setRefreshKey(oldKey => oldKey + 1); // Verhoog de waarde van refreshKey
                console.log(localStorage);
                navigate('/home');
            } else {
                setLoginError('Ongeldige gebruikersnaam of wachtwoord');
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
                    <label htmlFor="username">Username:</label>
                    <br />
                    <input type="text" id="username" name="username" value={username} onChange={e => setUsername(e.target.value)} />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Wachtwoord:</label>
                    <br />
                    <input type="password" id="password" name="password" value={password} onChange={e => setPassword(e.target.value)} />
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
