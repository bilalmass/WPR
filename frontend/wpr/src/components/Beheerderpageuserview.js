import React, { useState, useEffect } from 'react';
import Navbar from './Navbar';
import { Link } from 'react-router-dom';
import './componentstyling/userview.css';

const UserPortal = () => {
    const [users, setUsers] = useState([]);
    const [genderFilter, setGenderFilter] = useState('');
    const [minAgeFilter, setMinAgeFilter] = useState('');
    const [maxAgeFilter, setMaxAgeFilter] = useState('');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch(`https://localhost:7211/Gebruiker/lijst`, {
                    method: 'GET',
                    headers: {
                        'Accept': 'application/json',
                    },
                });

                if (!response.ok) {
                    throw new Error(`Fout bij het ophalen van gegevens: ${response.statusText}`);
                }

                let data = await response.json();

                // Calculate age for each user
                data = data.map(user => {
                    const dob = new Date(user.geboortedatum);
                    const today = new Date();
                    const age = today.getFullYear() - dob.getFullYear();
                    return { ...user, age };
                });

                // Filter users based on gender and age
                if (genderFilter !== '' || minAgeFilter !== '' || maxAgeFilter !== '') {
                    data = data.filter(user => {
                        if (genderFilter !== '' && user.geslacht !== genderFilter) {
                            return false;
                        }
                        if (minAgeFilter !== '' && user.age < parseInt(minAgeFilter)) {
                            return false;
                        }
                        if (maxAgeFilter !== '' && user.age > parseInt(maxAgeFilter)) {
                            return false;
                        }
                        return true;
                    });
                }

                setUsers(data);
            } catch (error) {
                console.error('Fout bij het ophalen van gegevens:', error.message);
            }
        };


        fetchData();
    }, [genderFilter]);

    const UsersList = ({ users }) => {
        return (
            <div className="users-list">
                <h2>Lijst van Gebruikers</h2>
                <ul>
                    {users.map((user) => (
                        <li key={user.id}>
                            <strong>{user.firstName} {user.lastName}</strong>
                            <p>Email: {user.email}</p>
                            <p>Voornaam: {user.voornaam}</p>
                            <p>Achternaam: {user.achternaam}</p>
                            <p>Telefoonnummer: {user.phoneNumber}</p>
                            <p>Geslacht: {user.geslacht}</p>
                            <p>Soort: {user.discriminator}</p>
                            <p>Geboortedatum: {user.geboortedatum}</p>
                        </li>
                    ))}
                </ul>
            </div>
        );
    };

    return (
        <>
            <div className="user-portal">
                <Link to="/beheerderportal">Terug naar Beheerder Portal</Link>
                <h1>User Portal</h1>
                <div className="filters">
                    <label>
                        Geslacht:
                        <select value={genderFilter} onChange={(e) => setGenderFilter(e.target.value)}>
                            <option value="">Alle</option>
                            <option value="Man">Man</option>
                            <option value="Vrouw">Vrouw</option>
                            <option value="wil ik liever niet zeggen">N.v.t.</option>
                        </select>
                    </label>
                    <label>
                        Leeftijd vanaf:
                        <input
                            type="number"
                            placeholder="Min. leeftijd"
                            value={minAgeFilter}
                            onChange={(e) => setMinAgeFilter(e.target.value)}
                        />
                    </label>
                    <label>
                        Leeftijd tot:
                        <input
                            type="number"
                            placeholder="Max. leeftijd"
                            value={maxAgeFilter}
                            onChange={(e) => setMaxAgeFilter(e.target.value)}
                        />
                    </label>
                </div>
                <UsersList users={users} />
            </div>
        </>
    );
};

export default UserPortal;
