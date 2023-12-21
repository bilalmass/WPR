import React from 'react';
import logo from './media/Logo Icon/icon_accessibility.png';
import expertise1 from './media/expertisefoto.jpg';
import './componentstyling/mainpage.css';

const Homepage = () => {
    return (
        <div className="mainpage">
            <div className="main-content">
                Welkom bij Stichting Accessibility
            </div>

            <section className="about-us-section">
                <h2>Ontdek samen met onze experts hoe we jou en onze gewaardeerde klanten kunnen bijstaan in het streven naar een betere samenleving.</h2>
                <p>Door middel van gezamenlijke inspanningen en innovatieve oplossingen willen we duurzame vooruitgang bevorderen. Onze experts kunnen daarbij jou assisteren.</p>
            </section>

            <section className="expertise-section">
                <div className="expertise-block">
                    <p>Ontdek samen met onze experts hoe
                        we jou en onze gewaardeerde klanten
                        kunnen bijstaan in het streven naar
                        een betere samenleving. Door middel
                        van gezamenlijke inspanningen en
                        innovatieve oplossingen willen we
                        duurzame vooruitgang bevorderen.
                        Onze expert kunnen daar bij jou
                        assisteren.</p>
                    <img src={expertise1} alt="Expertise 1" />
                </div>

                <div className="expertise-block">
                    <p>Ontdek samen met onze experts hoe
                        we jou en onze gewaardeerde klanten
                        kunnen bijstaan in het streven naar
                        een betere samenleving. Door middel
                        van gezamenlijke inspanningen en
                        innovatieve oplossingen willen we
                        duurzame vooruitgang bevorderen.
                        Onze expert kunnen daar bij jou
                        assisteren.</p>
                    <img src={expertise1} alt="Expertise 2" />
                </div>

                <div className="expertise-block">
                    <p>Ontdek samen met onze experts hoe
                        we jou en onze gewaardeerde klanten
                        kunnen bijstaan in het streven naar
                        een betere samenleving. Door middel
                        van gezamenlijke inspanningen en
                        innovatieve oplossingen willen we
                        duurzame vooruitgang bevorderen.
                        Onze expert kunnen daar bij jou
                        assisteren.</p>
                    <img src={expertise1} alt="Expertise 3" />
                </div>
            </section>

            {/* tweede sectie */}
            {/* tweede sectie */}
            {/* tweede sectie */}
            
            <section className="about-us-section">
                <h2>Wij werken onder anderen samen met:</h2>
            </section>

            <section className="expertise-section">
                <div className="expertise-block">
                        <p>Ontdek samen met onze experts hoe
                            we jou en onze gewaardeerde klanten
                            kunnen bijstaan in het streven naar
                            een betere samenleving. Door middel
                            van gezamenlijke inspanningen en
                            innovatieve oplossingen willen we
                            duurzame vooruitgang bevorderen.
                            Onze expert kunnen daar bij jou
                            assisteren.</p>
                    <img src={expertise1} alt="Expertise 1" />
                </div>

                <div className="expertise-block">
                    <p>Ontdek samen met onze experts hoe
                        we jou en onze gewaardeerde klanten
                        kunnen bijstaan in het streven naar
                        een betere samenleving. Door middel
                        van gezamenlijke inspanningen en
                        innovatieve oplossingen willen we
                        duurzame vooruitgang bevorderen.
                        Onze expert kunnen daar bij jou
                        assisteren.</p>
                    <img src={expertise1} alt="Expertise 2" />
                </div>

                <div className="expertise-block">
                    <p>Ontdek samen met onze experts hoe
                        we jou en onze gewaardeerde klanten
                        kunnen bijstaan in het streven naar
                        een betere samenleving. Door middel
                        van gezamenlijke inspanningen en
                        innovatieve oplossingen willen we
                        duurzame vooruitgang bevorderen.
                        Onze expert kunnen daar bij jou
                        assisteren.</p>
                    <img src={expertise1} alt="Expertise 3" />
                </div>
            </section>
            
        </div>
    );
};

export default Homepage;
