import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I go to the product page', () => {
  cy.visit("/products");
});

When('I set the category to {string}', (category) => {
  cy.get("#categories").select(category);
});

Then('I should see price {string} for product {string}', (price, product) => {
  cy.get('.product')
    .contains('div.product', product)
    .find('.price')
    .contains('Pris: ' + price + ' kr')
});