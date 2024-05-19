Feature: As user I want to be able to see the correct products listed when I have chosen a category so that I can easily filter the product list by category.

  Scenario Outline: Check that the category <category> shows the product <product>.
    Given that I land on the products page
    When I choose the category "<category>"
    Then I should see the product "<product>"

    Examples:
      | category         | product                      |
      | MIDI Keyboards   | Komplex Audio M81            |
      | MIDI Keyboards   | L-Audio MidiKeys 99 Stealth  |
      | MIDI Keyboards   | BasicFrequency Wireless SG32 |
      | Audio Interfaces | ScarLight Dragon X12         |
      | Audio Interfaces | FocusWrong Artist1-1         |
      | Audio Interfaces | NoSound IO Zero              |
      | Music Software   | QueueBase 20                 |
      | Music Software   | Illogical 9                  |
      | Music Software   | Disableton 7                 |
      | Music Software   | AudaTown X                   |
      | VST Plugins      | KompressMe                   |
      | VST Plugins      | Ekvalizer Pro                |
      | VST Plugins      | Revbero 12                   |
      | Sample Packs     | Sick Vocals                  |
      | Sample Packs     | MegaDrum EDM Pack            |
      | Sample Packs     | Polished Strings             |
