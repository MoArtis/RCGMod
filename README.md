# River City Girls UserXpMod

## ** What is it **

This mod allows multiple small things to improve the user experience for PC users of the game.

- Skip the legal splashscreen, logos, and the intro by just pressing the "Escape" key once.

- Start the game from the main menu. (Optional)

- Remap the "interaction" action used to pick object on the floor or use doors.

- Change the keyboard mapping from the config file.

- Force the game to use Xinput to potentially fix the controller related bugs. (Optional)


## ** How to install **

Extract the entire content of the archive where River City Girls is installed.
The install folder on Steam is usually "Steam\steamapps\common\River City Girls".

It should replace the "Assembly-CSharp.dll" file located in "River City Girls\RiverCityGirls_Data\Managed".


## ** How to use **

Next to the "RiverCityGirls.exe" file, you should have a "ModData.json" file.
Open it with any text editor. 

Following the order of the file, this is what you can modify:

- "allowSkipSplashScreens" : Can be set to true or false. if true, allows to skip all the intro screens and videos by pressing escape (all at once) or by holding the "Quick Attack" key (one by one).

- "startFromMainMenu" : Can be set to true or false. If true, always start the game from the main menu.

- "interactActionId" : Can be set to any "action id" like "block" or "recruit" (full list just below). It will replace the button use for interacting with doors or grab objects on the floor. The game is using the "QuickAttack" by default which can be annoying when fighting next to a door or a weapon.

- "playerOneInputConfigs" & "playerTwoInputConfigs" : Each line can be set to a keyboard keycode (full list just below). Remap each action to a new keyboard key.

- "forceXInput" : Can be set to true or false. If true, it might fix some controller related bugs like controlling the two players with only one controller or the controller's inputs being not detected at all.


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
MoveHorizontal
MoveVertical
Jump
QuickAttack
HeavyAttack
SpecialAttack
Block
Recruit
GripChange
Start
Taunt
FaceAccept
FaceBack
None
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
