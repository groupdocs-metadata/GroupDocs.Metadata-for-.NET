import { getGreeting } from '../support/app.po';

describe('metadata', () => {
  beforeEach(() => cy.visit('/'));

  it('should display welcome message', () => {
    getGreeting().contains('Welcome to metadata!');
  });
});
