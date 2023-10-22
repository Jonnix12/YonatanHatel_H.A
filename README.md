# YonatanHatel_H.A
I divided my code into 4 segments:
1. Player- The two players (the human and the AI). this section contains the player's data (score, color, etc.) and the player controller.
2. Table- Contains the goals logic and the PAC.
3. Managers- Responsible for game sequence and logic. It contains the Game Manager class that provides the main communication between all relevant systems.
4. UI- Responsible for turning on/off UI elements.

While developing the player input, I ran into a slight difficulty synchronizing the player movement to the mouse movement using physics, I had a problem with incorrect separation between FixedUpdate and Update, but after rearranging and separating the logic into the correct functions I was able to solve the problem.
