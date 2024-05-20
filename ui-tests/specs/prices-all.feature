Feature: As I user I should see the right prices for all products
    Scenario Outline: Check that all products show correct prices
        Given that I visit the product page
        When I set da category to "Alla"
        Then I should see the price "<price>" for "<product>"

        Examples:
            | product                      | price |
            | Komplex Audio M81            | 120   |
            | L-Audio MidiKeys 99 Stealth  | 240   |
            | BasicFrequency Wireless SG32 | 122   |
            | ScarLight Dragon X12         | 899   |
            | FocusWrong Artist1-1         | 99    |
            | NoSound IO Zero              | 155   |
            | QueueBase 20                 | 129   |
            | Illogical 9                  | 200   |
            | Disableton 7                 | 544   |
            | AudaTown X                   | 199   |
            | KompressMe                   | 200   |
            | Ekvalizer Pro                | 299   |
            | Revbero 12                   | 500   |
            | Sick Vocals                  | 99    |
            | MegaDrum EDM Pack            | 155   |
            | Polished Strings             | 315   |