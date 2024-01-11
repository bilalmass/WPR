import React, { useState } from 'react';
import './componentstyling/registerpage.css';
//import axios from 'axios';

const Register = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        phoneNumber: '',
        password: '',
        confirmPassword: '',
        gender: 'male',
        birthDate: '',
    });

    const [passwordError, setPasswordError] = useState('');

    const handleInputChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleRegisterClick = () => {
        const passwordRegex = /^(?=.*[A-Z])(?=.*[0-9!@#\$%\^&\*])(?=.{8,})/;
        if (!passwordRegex.test(formData.password)) {
            setPasswordError('Wachtwoord voldoet niet aan de beveiligingseisen.');
            return;
        }
        RegistreerErvaringsdeskundige();
        console.log('Registratiegegevens:', formData);
    };

    function RegistreerErvaringsdeskundige()
    {
        fetch("https://localhost:7211/Registreer/ervaringsdeskundige", {
            method: "POST",
            mode: "cors",
            headers: {
                'Acces-Control-Allow-Origin': '*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "firstName": formData.firstName,
                "lastName": formData.lastName,
                "email": formData.email,
                "phoneNumber": formData.phoneNumber,
                "password": formData.password,
                "gender": formData.gender,
                "birthDate": formData.birthDate
            })
        })
        .then(response => response.json())
        .then(data => console.log(data));
    }

    return (
        <div className="registration-container">
            <div className="registration-form">
                <div className="form-row">
                    <div className="input-group">
                        <label>Voornaam:</label>
                        <input type="text" name="firstName" value={formData.firstName} onChange={handleInputChange} />
                    </div>

                    <div className="input-group">
                        <label>Achternaam:</label>
                        <input type="text" name="lastName" value={formData.lastName} onChange={handleInputChange} />
                    </div>
                </div>

                <div className="form-row">
                    <div className="input-group">
                        <label>Email:</label>
                        <input type="email" name="email" value={formData.email} onChange={handleInputChange} />
                    </div>

                    <div className="input-group">
                        <label>Telefoonnummer:</label>
                        <input type="tel" name="phoneNumber" value={formData.phoneNumber} onChange={handleInputChange} />
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
                        {passwordError && <p className="error">{passwordError}</p>}
                    </div>
                </div>

                    <div className="form-row">
                        <div className="input-group">
                            <label>Geboortedatum:</label>
                            <input type="date" name="birthDate" value={formData.birthDate} onChange={handleInputChange} />
                        </div>
    
                        <div className="input-group">
                            <label>Geslacht:</label>
                            <select name="gender" value={formData.gender} onChange={handleInputChange}>
                                <option value="male">Man</option>
                                <option value="female">Vrouw</option>
                                <option value="other">Zeg ik liever niet</option>
                            </select>
                        </div>
                    </div>


                <button onClick={handleRegisterClick}>Registreren</button>
            </div>
        </div>
    );
};

export default Register;
