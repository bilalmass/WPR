// App.jsx
import React from 'react';
import logo from './components/media/Logo Icon/icon_accessibility.png';
import './App.css';
import Navbar from './components/Navbar';
import Footer from './components/Footer';
import './components/componentstyling/mainpage.css';  // Aangepaste import-paden

function App() {

    return (
        <div className="App">
            <Navbar />
            <div className="main-page">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <div className="main-title">
                        Welkom bij Stichting Accessibility
                    </div>
                    <div className="sub-title">
                        Een inclusieve samenleving waarin iedereen gelijkwaardig participeert.
                    </div>
                    <a className="btn" href="#lees-meer">
                        Lees meer
                    </a>
                </header>
            </div>
            <Footer />
        </div>
    );
}

export default App;
