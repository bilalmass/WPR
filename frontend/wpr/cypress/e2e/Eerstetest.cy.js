describe('Homepage Component', () => {
  it('loads and displays recent news articles', () => {
    cy.visit('http://localhost:3000');
    cy.get('.main-content h1').should('be.visible').and('contain', 'Welkom bij Stichting Accessibility');
    cy.get('.about-us-section h2').should('be.visible').and('contain', 'Ontdek samen met onze experts hoe we jou');
    cy.get('.expertise-section').should('be.visible');
    cy.get('.expertise-block p').should('be.visible');
    cy.get('.expertise-block img').should('be.visible');
    cy.get('.nieuws-section h2').should('be.visible').and('contain', 'Recente Nieuwsartikelen over Toegankelijkheid');});
});
