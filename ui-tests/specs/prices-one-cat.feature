Feature: As a user, I should see the right prices for products in the chosen category
    Scenario Outline: Check that all products in MIDI Keyboards show the right price
        Given that I go to the product page
        When I set the category to "MIDI Keyboards"
        Then I should see price "<price>" for product "<product>"

        Examples:
            | price | product                      |
            | 120   | Komplex Audio M81            |
            | 240   | L-Audio MidiKeys 99 Stealth  |
            | 122   | BasicFrequency Wireless SG32 |