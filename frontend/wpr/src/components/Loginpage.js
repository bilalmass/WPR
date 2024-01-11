import React from 'react';
import './componentstyling/loginpage.css';

const Login = () => {
    return (
        <div className="login-container">
            <h2>Login</h2>
            <form>
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
                <div className="form-options">
                    <div className="forgot-password">
                        <a href="#">Wachtwoord vergeten?</a>
                    </div>
                    <div className="register-link">
                        Nog geen lid? <a href="register">Registreer je hier</a>
                    </div>
                </div>
                <button className="button" type="submit">Inloggen</button>
            </form>
        </div>
    );
};

export default Login;
