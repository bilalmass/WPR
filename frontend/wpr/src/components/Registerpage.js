/* Register.js */
import React, { useState } from 'react';
import './componentstyling/registerpage.css';

const Register = () => {
    const [formData, setFormData] = useState({
        gebruikersnaam: '',
        voornaam: '',
        achternaam: '',
        email: '',
        telefoonnummer: '',
        wachtwoord: '',
        confirmPassword: '',
        geslacht: 'Man',
        geboortedatum: '',
        postCode: ''
    });

    const [passwordError, setPasswordError] = useState('');

    const handleInputChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        if (e.target.name === 'password' || e.target.name === 'confirmPassword') {
            setPasswordError('');
        }
    };


    const handleRegisterClick = () => {
        console.log(formData);
        const passwordRegex = /^(?=.*[A-Z])(?=.*[0-9!@#\$%\^&\*])(?=.{8,})/;
        if (!passwordRegex.test(formData.wachtwoord)) {
            setPasswordError('Wachtwoord voldoet niet aan de beveiligingseisen.');
            return;
        }
        if (formData.wachtwoord !== formData.confirmPassword) {
            setPasswordError('Wachtwoorden komen niet overeen.');
            return;
        }
        RegistreerErvaringsdeskundige();
        console.log('Registratiegegevens:', formData);
    };


    function RegistreerErvaringsdeskundige() {
        fetch('https://localhost:7211/RegistreerErvaringsdeskundige/ErvaringsdeskundigeRegistreer', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(formData)
        })
            .then(response => response.json())
            .then(data => console.log(data))
            .catch(error => console.error('Network error:', error));
    };



        return (
        <div className="register-container">
            <label className="form-label">Gebruikersnaam:
                <input
                    type="text"
                    name="gebruikersnaam"
                    value={formData.gebruikersnaam}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>


            <label className="form-label">Voornaam:
                <input
                    type="text"
                    name="voornaam"
                    value={formData.voornaam}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>

            <label className="form-label">Achternaam:
                <input
                    type="text"
                    name="achternaam"
                    value={formData.achternaam}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>

            <label className="form-label">Wachtwoord:
                <input
                    type="password"
                    name="wachtwoord"
                    value={formData.wachtwoord}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>

            <label className="form-label">Bevestig wachtwoord:
                <input
                    type="password"
                    name="confirmPassword"
                    value={formData.confirmPassword}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>


            <label className="form-label">Email:
                <input
                    type="text"
                    name="email"
                    value={formData.email}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>

            <label className="form-label">Telefoonnummer:
                <input
                    type="text"
                    name="telefoonnummer"
                    value={formData.telefoonnummer}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>

            <label className={"form-label"}>Geboortedatum:
            <input type="date" 
                   name="geboortedatum" 
                   value={formData.geboortedatum} 
                   onChange={handleInputChange}
                   className={"form-input"}
            />
            </label>


            <label className="form-label">Geslacht:
            <select name="gender" value={formData.gender} 
                    onChange={handleInputChange}>
                <option value="male">Man</option>
                <option value="female">Vrouw</option>
                <option value="other">Zeg ik liever niet</option>
            </select>
            </label>    
            <label className="form-label">Postcode:
                <input
                    type="text"
                    name="postCode"
                    value={formData.postCode}
                    onChange={handleInputChange}
                    className="form-input"
                />
            </label>

            <button onClick={handleRegisterClick} className="register-button">Registreren</button>
        </div>
    );
};

export default Register;
