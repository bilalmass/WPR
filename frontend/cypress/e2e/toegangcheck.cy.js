describe('Beheerderportal Access Test', () => {
  beforeEach(() => {
    cy.clearLocalStorage();
  });

  it('Zou wel toegang geven als rol beheerder is', () => {
    cy.window().then((win) => {
      win.localStorage.setItem('access_rol', 'Beheerder');
    });
    cy.visit('http://localhost:3000/beheerderportal');
    cy.contains('Beheerderportal').should('be.visible');
  });

  it('Zou geen toegang geven als rol niet beheerder is', () => {
    cy.window().then((win) => {
      win.localStorage.setItem('access_rol', 'Ervaringsdeskundige');
    });
    cy.visit('http://localhost:3000/beheerderportal');
    cy.contains('Deze pagina is niet toegankelijk.').should('be.visible');
  });
});
