﻿/* BedrijfRegister.js */
import React, { useState } from 'react';
import './componentstyling/registerpage.css';
import axios from 'axios';

const BedrijfRegister = () => {
    const [formData, setFormData] = useState({
        bedrijfsnaam: '',
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
        if (e.target.name === 'password' || e.target.name === 'confirmPassword') {
            setPasswordError('');
        }

    };

    const handleRegisterClick = () => {
        const passwordRegex = /^(?=.*[A-Z])(?=.*[0-9!@#\$%\^&\*])(?=.{8,})/;
        if (!passwordRegex.test(formData.password)) {
            setPasswordError('Wachtwoord voldoet niet aan de beveiligingseisen.');
            return;
        }
        if (formData.password !== formData.confirmPassword) {
            setPasswordError('Wachtwoorden komen niet overeen.');
            return;
        }

        console.log('Registratiegegevens:', formData);
    };

    return (
        <div className="registration-container">
            <div className="registration-form">
                <div className="form-row">
                    <div className="input-group">
                        <label>Bedrijfsnaam:</label>
                        <input type="text" name="bedrijfsnaam" value={formData.bedrijfsnaam} onChange={handleInputChange} />
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
                    </div>
                </div>
                {passwordError && <p className="error">{passwordError}</p>}

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

export default BedrijfRegister;