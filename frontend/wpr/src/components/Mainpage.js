import React, { useState, useEffect } from 'react';
import logo from './media/Logo Icon/icon_accessibility.png';
import expertise1 from './media/expertisefoto.jpg';
import './componentstyling/mainpage.css';

const Homepage = () => {
    const [newsArticles, setNewsArticles] = useState([]);

    useEffect(() => {
        const fetchNewsArticles = async () => {
            const apiKey = '08f8c3963a7241ce9d30b665ad8d39dd';
            const apiUrl = `https://newsapi.org/v2/everything?q=accessibility&apiKey=${apiKey}`;

            try {
                const response = await fetch(apiUrl);
                const data = await response.json();

                if (data.articles) {
                    setNewsArticles(data.articles.slice(2, 6));
                }
            } catch (error) {
                console.error('Fout bij het ophalen van nieuws:', error);
            }
        };

        fetchNewsArticles();
    }, []);

    return (
        <div className="mainpage">
            <div className="main-content">
                <h1>Welkom bij Stichting Accessibility</h1>
            </div>

            <section className="about-us-section">
                <h2>Ontdek samen met onze experts hoe we jou en onze gewaardeerde klanten kunnen bijstaan in het streven naar een betere samenleving.</h2>
                <p>Door middel van gezamenlijke inspanningen en innovatieve oplossingen willen we duurzame vooruitgang bevorderen. Onze experts kunnen daarbij jou assisteren.</p>
            </section>

            <section className="expertise-section">
                <div className="expertise-block">
                    <p>Ontdek samen met onze experts hoe we jou en onze gewaardeerde klanten kunnen bijstaan in het streven naar een betere samenleving. Door middel van gezamenlijke inspanningen en innovatieve oplossingen willen we duurzame vooruitgang bevorderen. Onze expert kunnen daar bij jou assisteren.</p>
                    <img src={expertise1} alt="Expertise 1 - Beschrijving van de expertise of inhoud" />
                </div>

            </section>

            <section className="nieuws-section">
                <h2>Recente Nieuwsartikelen over Toegankelijkheid</h2>
                <ul>
                    {newsArticles.map((article, index) => (
                        <li key={index}>
                            <a href={article.url} target="_blank" rel="noopener noreferrer">
                                <img src={article.urlToImage} alt={`News ${index + 1} - ${article.title}`} />
                                <h3>{article.title}</h3>
                                <p>{article.description}</p>
                            </a>
                        </li>
                    ))}
                </ul>
            </section>
        </div>
    );
};

export default Homepage;
