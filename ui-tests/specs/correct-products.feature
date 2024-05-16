Feature: As user I want to be able to seee the correct products listed when I have chosen a category so that IC an easily filter the product list by category.

    Scenario: : Check that the "MIDI Keyboards" - category shows the right products.
        Given that I am on the startpage
        When I choose the category "Midi Keyboards"
        Then I should see the product ""
        And I should see the product ""