import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Navbar from './Navbar';
import './componentstyling/bedrijfportalonderzoek.css';

const Bedrijfportalonderzoek = () => {
    const [formData, setFormData] = useState({
        title: '',
        shortDescription: '',
        fullDescription: '',
        date: '',
        researchType: 'online',
        reward: '',
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
    };

    return (
        <>
            <div className="beheerder-portal">
                <h1>Onderzoek aanmaken</h1>

                <Link to="/bedrijfportaal">
                    <button className="portal-button">Terug naar Overzicht</button>
                </Link>

                <div className="onderzoek-form">
                    <h2>Onderzoek Details</h2>
                    <form onSubmit={handleSubmit}>
                        <label>
                            Titel:
                            <input
                                type="text"
                                name="title"
                                value={formData.title}
                                onChange={handleChange}
                                required
                            />
                        </label>
                        <br />

                        <label>
                            Korte beschrijving:
                            <textarea
                                name="shortDescription"
                                value={formData.shortDescription}
                                onChange={handleChange}
                                required
                            ></textarea>
                        </label>
                        <br />

                        <label>
                            Volledige beschrijving:
                            <textarea
                                name="fullDescription"
                                value={formData.fullDescription}
                                onChange={handleChange}
                                required
                            ></textarea>
                        </label>
                        <br />

                        <label>
                            Datum:
                            <input
                                type="date"
                                name="date"
                                value={formData.date}
                                onChange={handleChange}
                                required
                            />
                        </label>
                        <br />

                        <label>
                            Soort onderzoek:
                            <select
                                name="researchType"
                                value={formData.researchType}
                                onChange={handleChange}
                            >
                                <option value="online">Online onderzoek</option>
                                <option value="engels">Engelstalig onderzoek</option>
                                <option value="interview">Interview</option>
                                <option value="groepsgesprek">Groepsgesprek</option>
                            </select>
                        </label>
                        <br />

                        <label>
                            Beloning:
                            <input
                                type="text"
                                name="reward"
                                value={formData.reward}
                                onChange={handleChange}
                            />
                        </label>
                        <br />

                        <button type="submit">Onderzoek Aanmaken</button>
                    </form>
                </div>
            </div>
        </>
    );
};

export default Bedrijfportalonderzoek;
