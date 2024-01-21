import casussenDataFixture from '../fixtures/example.json';
beforeEach(() => {
  cy.intercept('GET', '/Onderzoek/getall', { fixture: 'example.json' }).as('getOnderzoekenData');
  cy.visit('http://localhost:3000/casussen');
});


describe('Casussen Component', () => {
  beforeEach(() => {
    cy.visit('http://localhost:3000/casussen');
  });

  it('Casus containers correct laten zien', () => {
    cy.get('.casussen-container').should('be.visible');
    cy.get('.casus-card').should('be.visible');
    cy.get('.casus-card').should('have.length.greaterThan', 0);
    
  });
  it('Inschrijven knoppen zijn zichtbaar', () => {
    cy.get('.button').should('be.visible');
  });
  it('Inschrijven knop openr venstertje', () => {
    cy.get('.button').first().click();
    cy.get('.venster').should('be.visible');
  });
});
