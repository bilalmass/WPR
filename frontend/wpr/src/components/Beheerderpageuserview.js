import React, { useState, useEffect } from 'react';
import Navbar from './Navbar';
import { Link } from 'react-router-dom';
import './componentstyling/userview.css';

const UserPortal = () => {
    const [users, setUsers] = useState([]);
    const [genderFilter, setGenderFilter] = useState('');
    const [minAgeFilter, setMinAgeFilter] = useState('');
    const [maxAgeFilter, setMaxAgeFilter] = useState('');
    const [discriminatorFilter, setDiscriminatorFilter] = useState('');

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

                data = data.map(user => {
                    if (user.geboortedatum) {
                        const parts = user.geboortedatum.split('-');
                        const datum = new Date(parts[2], parts[1] - 1, parts[0]);
                        const today = new Date();
                        let age = today.getFullYear() - datum.getFullYear();
                        const monthDiff = today.getMonth() - datum.getMonth();
                        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < datum.getDate())) {
                            age--;
                        }
                        return { ...user, age };
                    } else {
                        return user;
                    }
                });


                if (genderFilter !== '' || minAgeFilter !== '' || maxAgeFilter !== '' || discriminatorFilter !== '') {
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
                        if (discriminatorFilter !== '' && user.discriminator !== discriminatorFilter) {
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
    }, [genderFilter, minAgeFilter, maxAgeFilter, discriminatorFilter]);

    const UsersList = ({ users }) => {
        return (
            <div className="users-list">
                <h2>Lijst van Gebruikers</h2>
                <ul>
                    {users.map((user) => (
                        <li key={user.id}>
                            <strong>{user.firstName} {user.lastName}</strong>
                            <p>Email: {user.email}</p>
                            <p>Gebruikersnaam: {user.userName}</p>
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
                    <label>
                        Type:
                        <select value={discriminatorFilter} onChange={(e) => setDiscriminatorFilter(e.target.value)}>
                            <option value="">All</option>
                            <option value="Ervaringsdeskundige">Ervaringsdeskundige</option>
                            <option value="Bedrijf">Bedrijf</option>
                            <option value="Beheerder">Beheerder</option>
                        </select>
                    </label>
                </div>
                <UsersList users={users} />
            </div>
        </>
    );
};

export default UserPortal;
