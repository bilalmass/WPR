﻿import React from 'react';
import Navbar from './Navbar';
import './componentstyling/beheerderpage.css';
import dummydata from './dummydata/onderzoekendummy'
import { Link } from 'react-router-dom';

const BeheerderOnderzoekview = () => {
    const onderzoeken = dummydata;
    const OnderzoekenList = ({ onderzoeken }) => {
        return (
            <div className="onderzoeken-lijst">
                <h2>Lijst van Lopende Onderzoeken</h2>
                <ul>
                    {onderzoeken.map((onderzoek) => (
                        <li key={onderzoek.id}>
                            <strong>{onderzoek.titel}</strong>
                            <p>{onderzoek.beschrijving}</p>
                            <p>Uitvoerder: {onderzoek.uitvoerder}</p>
                            <p>Datum: {onderzoek.datum}</p>
                            <p>Locatie: {onderzoek.locatie}</p>
                            <p>Beloning: {onderzoek.beloning}</p>
                            <p>Type: {onderzoek.type}</p>
                            <p>Status: {onderzoek.status}</p>
                        </li>
                    ))}
                </ul>
            </div>
        );
    };


    return (
        <>
            <div className="beheerder-portal">
                <Link to="/beheerderportal">Terug naar Beheerder Portal</Link>
                <h1>Beheerderportal</h1>
                <OnderzoekenList onderzoeken={onderzoeken} />
            </div>
        </>
    );
};

export default BeheerderOnderzoekview;
