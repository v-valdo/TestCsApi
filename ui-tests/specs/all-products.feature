Feature: As a user I want to be presented with all available products when I specify category to All

    Scenario Outline: Check that the category choice "Alla" shows <product>.
        Given that I am on the product page
        When I specify category to "Alla"
        Then I should see the product "<product>"

        Examples:
            | product                      |
            | Komplex Audio M81            |
            | L-Audio MidiKeys 99 Stealth  |
            | BasicFrequency Wireless SG32 |
            | ScarLight Dragon X12         |
            | FocusWrong Artist1-1         |
            | NoSound IO Zero              |
            | QueueBase 20                 |
            | Illogical 9                  |
            | Disableton 7                 |
            | AudaTown X                   |
            | KompressMe                   |
            | Ekvalizer Pro                |
            | Revbero 12                   |
            | Sick Vocals                  |
            | MegaDrum EDM Pack            |
            | Polished Strings             |