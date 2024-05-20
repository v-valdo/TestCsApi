Feature: As a user I want the description to match the products

    Scenario Outline: Check that the descriptions for each product are correctr
        Given that I pay a visit to the product page
        When I change the category to "Alla"
        Then I should see the description "<description>" for the product "<product>"

        Examples:
            | product                      | description                                                                                                                      |
            | Komplex Audio M81            | 81 velocity sensitive keys and immersive RGB lights reacting to your every move                                                  |
            | L-Audio MidiKeys 99 Stealth  | Lightweight midi keyboard for travelling with 12 knobs and 16 pads for translating your stories into music! No pedal compability |
            | BasicFrequency Wireless SG32 | 32 motion enabled keys with Bluetooth connection and extreme delay!                                                              |
            | ScarLight Dragon X12         | Professional audio interface delivering high fidelity sound and freedom of choice for every serious music producer               |
            | FocusWrong Artist1-1         | Minimalistic interface for the bedroom producer. 1 output for headphones, 1 input for microphone. Be the next Avicii.            |
            | NoSound IO Zero              | Audio interface with zero functionality! Live the artist dream without putting in the effort!                                    |
            | QueueBase 20                 | Dominate the hipster's in your area by using this vintage DAW for your outdated synth music!                                     |
            | Illogical 9                  | Tease your brain in this nonsensical audio workstation with your flashy MacBook                                                  |
            | Disableton 7                 | Increase your CPU load to never before seen levels with this high weight DAW for rich producers                                  |
            | AudaTown X                   | Record your microphone and add a reverb - now with Microsoft XP compatibility!                                                   |
            | KompressMe                   | Compress your mixes beyond recognition! Now with AI-controlled treshold!                                                         |
            | Ekvalizer Pro                | Fab-Q can go to hell!                                                                                                            |
            | Revbero 12                   | The only reverb you'll ever need!                                                                                                |
            | Sick Vocals                  | Vocals recorder by sick people, to get that unique unrecognizable modern vocal sound! 200 mp3 files!                             |
            | MegaDrum EDM Pack            | One million bass drums that sound exactly the same! Be the next Martin Garrix                                                    |
            | Polished Strings             | String loops for all your rap intros! You no longer need to write ur own music!                                                  |

    Scenario Outline: Check that the descriptions for each product match for a specific category
        Given that I visit the product page
        When I set category to "<category>"
        Then I should see description "<description>" for "<product>"

        Examples:
            | category         | product                      | description                                                                                                                      |
            | MIDI Keyboards   | Komplex Audio M81            | 81 velocity sensitive keys and immersive RGB lights reacting to your every move                                                  |
            | MIDI Keyboards   | L-Audio MidiKeys 99 Stealth  | Lightweight midi keyboard for travelling with 12 knobs and 16 pads for translating your stories into music! No pedal compability |
            | MIDI Keyboards   | BasicFrequency Wireless SG32 | 32 motion enabled keys with Bluetooth connection and extreme delay!                                                              |
            | Audio Interfaces | ScarLight Dragon X12         | Professional audio interface delivering high fidelity sound and freedom of choice for every serious music producer               |
            | Audio Interfaces | FocusWrong Artist1-1         | Minimalistic interface for the bedroom producer. 1 output for headphones, 1 input for microphone. Be the next Avicii.            |
            | Audio Interfaces | NoSound IO Zero              | Audio interface with zero functionality! Live the artist dream without putting in the effort!                                    |
            | Music Software   | QueueBase 20                 | Dominate the hipster's in your area by using this vintage DAW for your outdated synth music!                                     |
            | Music Software   | Illogical 9                  | Tease your brain in this nonsensical audio workstation with your flashy MacBook                                                  |
            | Music Software   | Disableton 7                 | Increase your CPU load to never before seen levels with this high weight DAW for rich producers                                  |
            | Music Software   | AudaTown X                   | Record your microphone and add a reverb - now with Microsoft XP compatibility!                                                   |
            | VST Plugins      | KompressMe                   | Compress your mixes beyond recognition! Now with AI-controlled treshold!                                                         |
            | VST Plugins      | Ekvalizer Pro                | Fab-Q can go to hell!                                                                                                            |
            | VST Plugins      | Revbero 12                   | The only reverb you'll ever need!                                                                                                |
            | Sample Packs     | Sick Vocals                  | Vocals recorder by sick people, to get that unique unrecognizable modern vocal sound! 200 mp3 files!                             |
            | Sample Packs     | MegaDrum EDM Pack            | One million bass drums that sound exactly the same! Be the next Martin Garrix                                                    |
            | Sample Packs     | Polished Strings             | String loops for all your rap intros! You no longer need to write ur own music!                                                  |