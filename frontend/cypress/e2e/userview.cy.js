describe('UserPortal', () => {
  beforeEach(() => {
    cy.intercept('GET', 'https://localhost:7211/Gebruiker/lijst', []).as('fetchData'); 


    cy.visit('http://localhost:3000/beheerderportal/gebruikers'); 
  });

  it('filters users correctly', () => {
    cy.get('select[name="discriminator"]', { timeout: 10000 }).select('Beheerder');

    cy.wait('@fetchData');

    cy.get('.users-list li').should($li => {
      $li.each((index, li) => {
        expect(li).to.contain('Beheerder');
      });
    });
  });

});
