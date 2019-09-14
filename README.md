# River City Girls UserXpMod

## ** What is it **

UserXpMod is a "quality of life" mod for the beat 'em-up game **River City Girls** by **Wayforward**.
It allows to tweak multiple small things to fix some issues and improve the user experience on PC.

[Menus]
- Skip any splash screen, video, dialog with just pressing Start or Escape once.
- Start the game from the main menu. (Off by default)
- [NEW] Display progression details in the save selection menu. (Off by default)
- [NEW] Skip the tutorial in New Game Plus.

[Settings]
- Remap the "interact" action used to pick object on the floor or use doors.
- [NEW] Remapping the “interact” action will change the button prompt accordingly.  
- Remap the keyboard from the mod’s config file.
- Force the game to use XInput to potentially fix the controller related bugs. (Off by default)
- [NEW] Display the PS4 controller’s button prompts instead of the Xbox ones. (Off by default)
- [NEW] Configure the vSync settings.
- [NEW] Use Unity’s frame limiter ("TargetFramerate") or a custom one. (Off by default)

[Gameplay/Feedbacks]
- [NEW] Unlock the secret characters on every save once they are unlocked on at least one save.
- [NEW] Display the amount of damage on hit like other River City games.
- [NEW] Customize the color and the size of the Damage and XP gain feedbacks.

[Bug fixes]
- Fix a bug that prevented the Book items to work properly when using a character other than Misako.
- Fix a bug that prevented the phone interface to display a maxed-out Stamina stat.


## ** How to install **

Extract the entire content of the archive where River City Girls is installed.
The install folder on Steam is usually "Steam\steamapps\common\River City Girls".

It should replace the "Assembly-CSharp.dll" file located in "River City Girls\RiverCityGirls_Data\Managed".


## ** How to use **

Next to the "RiverCityGirls.exe" file, you should have a "ModData.json" file.
Open it with any text editor. 

Following the order of the file, this is what you can modify:

- "allowQuickSkip": Can be set to true or false. if true, allows to skip any video, dialog and the whole intro by pressing Start or Escape once.

- "startFromMainMenu": Can be set to true or false. If true, always start the game from the main menu.

- "interactActionId": Can be set to any "action id" like "block" or "recruit" (full list just below). It will replace the button use for interacting with doors or grab objects on the floor. The game is using the "QuickAttack" by default which can be annoying when fighting next to a door or a weapon.

- "playerOneInputConfigs" & "playerTwoInputConfigs": Each line can be set to a keyboard keycode (full list just below). Remap each action to a new keyboard key.

- "forceXInput": Can be set to true or false. If true, it might fix some controller related bugs like controlling the two players with only one controller or the controller's inputs being not detected at all.

- "usePS4buttonPrompts": Can be set to true or false. If true, it will replace the Xbox controller’s input prompts by the PS4 controller’s ones.

- "displayProgressionInfo": Can be set to true or false. If true, it will display a detailed breakdown of the currently selected save in the save selection menu.

- "vSyncCount": Can be set to 0, 1, 2, 3 or 4. 0 will deactivate the vertical sync and decouple the game’s framerate to the monitor refresh rate. Doing so will usually cause “screen tearing” but will allow to use frame limiters (see below). 1, the game default, will sync the framerate with the monitor’s refresh rate. Using 144hz monitor will make the game target a framerate of 144. As the number is the ratio between the monitor refresh rate and the framerate, 2 will make the game target a framerate of 72 (for the same 144hz monitor). Most user needs to keep that value to 1.

- "targetFramerate": Can be set to -1 or any positive integer. This setting is ignored if the vSync is activated (vSync sets 1,2,3 or 4). If set to -1, the game will run as fast as possible (This will kill your battery very fast). Anything above 0 will use Unity’s built-in frame limiter to limit the framerate to the indicated value. Expect screen tearing when the camera is moving around in game.

- "useCustomFramelimiter": Can be set to true or false. If true, the game will use a custom Frame limiter to do the same thing as described just before in the "targetFramerate" section. It might give better results than the built-in one. Don’t forget to set the targetFramerate before using this.

- "displayDamageOnHit": Can be set to true or false. If true, the amount of damage will be displayed when the enemies or the player characters are hit. An exclamation mark will be added to the damage indicator when the “Bomb Bra” effect (One hit KO) is being applied.

- "xpGetTextColor": Can be set to any real number between 0 and 1 for the Red, blue, green and alpha channels of the desired color. It corresponds to the desired color of the xp gain feedback displayed when an enemy is defeated. The alpha value (“a”) is ignored but setting it to 0 will pick the game’s default feedback text color.

- "xpGetTextFontSize": Can be set to any positive integer. It defines the font size of the xp gain feedback. The game’s default is 80. Setting it to 0 or less will pick the default value.

- "hitDmgTextColor": Can be set to any real number between 0 and 1 for the Red, blue, green and alpha channels of the desired color. The same usage as "xpGetTextColor" but for the Hit damage feedback.

- "hitDmgTextFontSizeMin": Can be set to any positive integer. As the size of the Hit damage feedback is actually dynamic, a minimum and a maximum size can be set. For the players, the size depends on the amount of base damage compared to all the other move of the player’s character. For the enemies, the size is determined from the portion of health lost from their attacks.

- "hitDmgTextFontSizeMax": Can be set to any positive integer. See "hitDmgTextFontSizeMin".

- "noTutorialInNewGamePlus": Can be set to true or false. If true, remove the tutorial in New Game Plus.

- "unlockSecretCharactersOnceForAllSave": Can be set to true or false. If true, unlocking the secret playable characters only need to be done once in order to make them available for any save.

- "fixBooksBug": Can be set to true or false. If true, fix a bug that prevented the Book items to work properly when using a character other than Misako.

- "fixMaxStaminaBug": Can be set to true or false. If true, fix a bug that prevented the phone interface to display a maxed-out Stamina stat.


## ** How to uninstall **

If you want or need to restore the original files, you should be able to do that on Steam by using the "Verify integrity of the game files" option.

In your steam's library, Right click on the game name, properties, local files. The option should be here.


## ** Available Action Id **

```
Jump
QuickAttack
HeavyAttack
SpecialAttack
Block
Recruit
Start
```


## ** Available keyboard keycode **

```
Backspace
Tab
Clear
Return
Pause
Escape
Space
Exclaim
DoubleQuote
Hash
Dollar
Ampersand
Quote
LeftParen
RightParen
Asterisk
Plus
Comma
Minus
Period
Slash
Alpha0
Alpha1
Alpha2
Alpha3
Alpha4
Alpha5
Alpha6
Alpha7
Alpha8
Alpha9
Colon
Semicolon
Less
Equals
Greater
Question
At
LeftBracket
Backslash
RightBracket
Caret
Underscore
BackQuote
A
B
C
D
E
F
G
H
I
J
K
L
M
N
O
P
Q
R
S
T
U
V
W
X
Y
Z
Delete
Keypad0
Keypad1
Keypad2
Keypad3
Keypad4
Keypad5
Keypad6
Keypad7
Keypad8
Keypad9
KeypadPeriod
KeypadDivide
KeypadMultiply
KeypadMinus
KeypadPlus
KeypadEnter
KeypadEquals
UpArrow
DownArrow
RightArrow
LeftArrow
Insert
Home
End
PageUp
PageDown
F1
F2
F3
F4
F5
F6
F7
F8
F9
F10
F11
F12
F13
F14
F15
Numlock
CapsLock
ScrollLock
RightShift
LeftShift
RightControl
LeftControl
RightAlt
LeftAlt
RightCommand
LeftCommand
LeftWindows
RightWindows
AltGr
Help
Print
SysReq
Break
Menu
```
