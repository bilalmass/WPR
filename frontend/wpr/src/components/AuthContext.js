import React, { createContext, useContext, useState } from 'react';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [isLoggedIn, setLoggedIn] = useState(false);
    const [userRole, setUserRole] = useState(null);
//keuze uit 'bedrijf', 'gebruiker', 'beheerder, 'gast'
    const logIn = (role, token) => {
        setLoggedIn(true);
        setUserRole(role);
        localStorage.setItem('token', token);
    };

    const logOut = () => {
        setLoggedIn(false);
        setUserRole(null);
    };

    return (
        <AuthContext.Provider value={{ isLoggedIn, userRole, logIn, logOut }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => {
    return useContext(AuthContext);
};
