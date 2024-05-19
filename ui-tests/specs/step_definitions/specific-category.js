import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I land on the products page', () => {
  cy.visit('/products');
});

When('I choose the category {string}', (category) => {
  cy.get('#categories').select(category);
});

Then('I should see the product from chosen category {string}', (productName) => {
  cy.get('.product .name').contains(productName);
});