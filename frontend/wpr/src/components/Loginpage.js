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

    const handleLogin = (e) => {
        e.preventDefault();

        const username = e.target.username.value;
        const password = e.target.password.value;

        const user = userDummyData.find((user) => user.email === username && user.password === password);

        if (user) {

    //extra code als ieand inlogt
            console.log('Ingelogd als:', user);
            setLoginError('');
        } else {
            setLoginError('Ongeldige gebruikersnaam of wachtwoord');
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
