import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I pay a visit to the product page', () => {
  cy.visit("/products");
});

When('I put the category to {string}', (category) => {
  cy.get("#categories").select(category);
});

Then('I should see the description {string} for the product {string}', (description, productName) => {
  cy.get('.product').contains('div.product', productName).find('.description').contains(description)
});

Given('that I visits the product page', () => {
  cy.visit("/products");
});

When('I set category to {string}', (category) => {
  cy.get("#categories").select(category);
});

Then('I should see description {string} for {string}', (description, product) => {
  cy.get('.product').contains('div.product', product).find('.description').contains(description)
});