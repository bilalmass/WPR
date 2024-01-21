describe('UserPortal Component', () => {
  beforeEach(() => {
    cy.visit('http://localhost:3000/userportal'); // Verander deze URL naar de juiste route voor uw UserPortal-component
  });

  it('loads the user portal', () => {
    cy.contains('User Portal').should('be.visible');
  });

  it('fetches and displays users', () => {
    cy.get('.users-list ul li').its('length').should('be.gt', 0);
  });

  it('applies filters correctly', () => {
    cy.get('select[name="genderFilter"]').select('Man');
    cy.get('.users-list ul li').each(($el) => {
      expect($el).to.contain('Man');
    });
  });
});
