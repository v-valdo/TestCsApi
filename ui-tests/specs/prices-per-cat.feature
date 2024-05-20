Feature: As a user, I should see the right prices for products in the chosen category
    Scenario Outline: Check that all products in MIDI Keyboards show the right price
        Given that I go to the product page
        When I set the category to "<category>"
        Then I should see price "<price>" for product "<product>"

        Examples:
            | price | product                      | category         |
            | 120   | Komplex Audio M81            | MIDI Keyboards   |
            | 240   | L-Audio MidiKeys 99 Stealth  | MIDI Keyboards   |
            | 122   | BasicFrequency Wireless SG32 | MIDI Keyboards   |
            | 899   | ScarLight Dragon X12         | Audio Interfaces |
            | 99    | FocusWrong Artist1-1         | Audio Interfaces |
            | 155   | NoSound IO Zero              | Audio Interfaces |
            | 129   | QueueBase 20                 | Music Software   |
            | 200   | Illogical 9                  | Music Software   |
            | 544   | Disableton 7                 | Music Software   |
            | 199   | AudaTown X                   | Music Software   |
            | 200   | KompressMe                   | VST Plugins      |
            | 299   | Ekvalizer Pro                | VST Plugins      |
            | 500   | Revbero 12                   | VST Plugins      |
            | 99    | Sick Vocals                  | Sample Packs     |
            | 155   | MegaDrum EDM Pack            | Sample Packs     |
            | 315   | Polished Strings             | Sample Packs     |