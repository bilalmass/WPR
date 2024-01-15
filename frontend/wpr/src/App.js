// App.jsx
import React, { useState } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Casussen from './pages/Casussen';
import Login from './pages/Login';
import Register from './pages/Register';
import Usersettings from './pages/Usersettings';
import { AuthProvider } from './components/AuthContext';
import BedrijfsRegister from './pages/BedrijfRegister'
import Beheerderportal from './pages/Beheerderportal'
import BeheerderportalUser from './pages/BeheerderUserView'
import BeheerderportalOnderzoeken from './pages/BeheerderOnderzoekView'
import Bedrijfportal from './pages/Bedrijfportal'
import Bedrijfportalonderzoek from './pages/Bedrijfportalonderzoek'


export default function App() {
    const [loggedIn, setLoggedIn] = useState(true);

    const handleLogout = () => {
        setLoggedIn(false);
    };

    return (
        <div>
            <AuthProvider>
            <BrowserRouter>
                <Routes>
                    <Route
                        index
                        element={<Home loggedIn={loggedIn} />}
                    />
                    <Route
                        path="/home"
                        element={<Home loggedIn={loggedIn} />}
                    />
                    <Route path="/casussen" element={<Casussen />} />
                    <Route
                        path="/login"
                        element={<Login setLoggedIn={setLoggedIn} />}
                    />
                    <Route path="/register" element={<Register />} />
                    <Route
                        path="/usersettings"
                        element={<Usersettings handleLogout={handleLogout} />}
                    />
                    <Route path="/bedrijfsregister" element={<BedrijfsRegister />} />
                    <Route path="/beheerderportal" element={<Beheerderportal />} />
                    <Route path="/beheerderportal/onderzoeken" element={<BeheerderportalOnderzoeken />} />
                    <Route path="/beheerderportal/gebruikers" element={<BeheerderportalUser />} />
                    <Route path="/bedrijfportaal" element={<Bedrijfportal />} />
                    <Route path="/bedrijfportaal/onderzoeken" element={<Bedrijfportalonderzoek />} />

                </Routes>
            </BrowserRouter>
            </AuthProvider>
        </div>
    );
}
