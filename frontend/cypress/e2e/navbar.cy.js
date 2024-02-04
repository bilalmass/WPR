describe('Navbar', () => {
  beforeEach(() => {
    localStorage.clear();
  });

  it('laat juist navbar zien voor ervaringsdeskundige', () => {
    localStorage.setItem('access_rol', 'Ervaringsdeskundige');

    cy.visit('http://localhost:3000/home');

    cy.get('.navbar-link').contains('Mijn Casussen▼').should('be.visible');
    cy.get('.login-button').contains('Account▼').should('be.visible');
  });

  it('laat juist navbar zien voor bedrijf', () => {
    localStorage.setItem('access_rol', 'Bedrijf');

    cy.visit('http://localhost:3000/home');

    cy.get('.navbar-link').contains('Bedrijfsportaal▼').should('be.visible');
    cy.get('.login-button').contains('Uitloggen▼').should('be.visible');
  });

  it('laat juist navbar zien voor beheerder', () => {
    localStorage.setItem('access_rol', 'Beheerder');

    cy.visit('http://localhost:3000/home');

    cy.get('.navbar-link').contains('Beheerdersportaal▼').should('be.visible');
    cy.get('.login-button').contains('Uitloggen▼').should('be.visible');
  });
  
});