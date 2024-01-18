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
                // Voer hier de Swagger-fetching logica in
                // Vervang de onderstaande URL door de werkelijke Swagger API-endpoint
                const response = await fetch('https://api.example.com/users');
                const data = await response.json();

                setUsers(data);
            } catch (error) {
                console.error('Fout bij het ophalen van gegevens:', error);
            }
        };

        fetchData();
    }, []); 

    const filterUsers = () => {
        let filteredUsers = users;

        if (genderFilter) {
            filteredUsers = filteredUsers.filter(user => user.gender === genderFilter);
        }

        if (minAgeFilter && maxAgeFilter) {
            const currentYear = new Date().getFullYear();
            filteredUsers = filteredUsers.filter(
                user => {
                    const age = currentYear - new Date(user.birthDate).getFullYear();
                    return age >= parseInt(minAgeFilter) && age <= parseInt(maxAgeFilter);
                }
            );
        }

        return filteredUsers;
    };

    const UsersList = ({ users }) => {
        return (
            <div className="users-list">
                <h2>Lijst van Gebruikers</h2>
                <ul>
                    {users.map((user) => (
                        <li key={user.id}>
                            <strong>{user.firstName} {user.lastName}</strong>
                            <p>Email: {user.email}</p>
                            <p>Telefoonnummer: {user.phoneNumber}</p>
                            <p>Geslacht: {user.gender}</p>
                            <p>Geboortedatum: {user.birthDate}</p>
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
                            <option value="man">Man</option>
                            <option value="vrouw">Vrouw</option>
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
                <UsersList users={filterUsers()} />
            </div>
        </>
    );
};

export default UserPortal;
