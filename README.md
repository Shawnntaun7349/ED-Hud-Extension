Elite: Dangerous Hud Extension
A second-monitor program for Frontier Development's Elite: Dangerous.

Developed by Sean Roe 

Current Version : 0.1.8

--- Planned Features ---
Expansion on Combat Panel to show more player data, such as Power Distributor levels, current shield status, etc.
Expansion on Exploration Panel to give the player a list of bodies in the current system, with an option to select a particular body &
see a more detailed breakdown of that body. [Body Type, notable Signals, est. scan value, etc.] - to include integration w/ EDSM [] via EDDN [https://github.com/EDCD/EDDN].
Implementation of Stationing Panel to display data on the current Station/Settlement, Market data, Mission data, etc.
Implementation of Mining Panel to display a list of Hotspots, notable stations for selling various Materials, etc.
[Tentatively] A Color changing mechanism of some kind to allow the user to customize the appearance of their UI [in EDHE, not in-game. EDHM-UI exists and is fantastic.] [https://bluemystical.github.io/edhm-api/]

--- Update Notes ---
Version 0.1.8
Implemented a Status Reader class for retrieving and handling data from the Status.json file, 
Continued fleshing out the Exploration Panel w/ newly-acquired Status data,
Corrected some issues with the initial loading screen with the program launched w/ Elite idling in the Main Menu,
Corrected some issues with the Combat Panel where some data points would fail to populate while scanning another ship.

Version 0.1.7
Iterated on Combat Panel & underlying mechanisms,
Streamlined dependent library integration,
Corrected an issue w/ some of the data being retrieved by the JournalReader library.

Version 0.1.6a
Integrated Ship Scanning event from JournalReader library,
Made some minor adjustments to the UI for readability,
Corrected an issue w/ the Auto Shutdown setting incorrectly activating when Elite is launched.

Version 0.1.6
Further JournalReader library implementation,
Updated Home Panel UI,
Began initial stages of Combat Panel development,
Minor misc. bug fixes.

Version 0.1.5b
Corrected an issue with the initial loading screen that would occasionally cause a lock-up when Elite was launched,
More minor UI tweaks.

Version 0.1.5a
Updated UI elements to account for Player Journal data,
Continued integration of JournalReader library,
Minor code streamlining.

Versions <--- 0.1.5
Expanded on Settings options, corrected an issue with a User's settings not being saved properly,
Began integration of Marits Elbers & Barry Wimlett's EliteJournalReader library [links included in the Dependencies section of Credits]
Added User Settings functionality,
Initial setup, Initial Commit, etc.

--- Credits ---
The majority of this project, unless otherwise noted, was written by Shawnntaun. [GitHub.com/Shawnntaun7349]
Shout-out to my brother for letting me pick his brain & offering sage wisdom (such as: "oh gross, C#")

EliteJournalReader library - Written by Marits Elbers & Barry Wimlett. [GitHub.com/MagicMau/EliteJournalReader]

The primary Font, Oxanium - created by Severin Meyer, used under the SIL Open Font License. [See (...licenses/Oxanium (Font)) for documentation] [sev.dev/fonts/oxanium/]

This project sources data from several external sources, including (but probably not limited to) Elite Dangerous Star Map [EDSM, https://www.edsm.net/] & Elite: Dangerous Data Network [https://github.com/EDCD/EDDN]
