import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I visit the product page', () => {
  cy.visit("/products");
});

When('I set da category to {string}', (category) => {
  cy.get("#categories").select(category);
});

Then('I should see the price {string} for {string}', (price, productName) => {
  cy.get('.product')
    .contains('div.product', productName)
    .find('.price')
    .contains('Pris: ' + price + ' kr');
});