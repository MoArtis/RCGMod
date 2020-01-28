# River City Girls UserXpMod

## ** DOWNLOAD **

### https://github.com/MoArtis/RCGMod/releases

## ** What is it **

UserXpMod is a "quality of life" mod for the beat 'em-up game **River City Girls** by **Wayforward**.
It allows to tweak multiple small things to fix some issues and improve the user experience on PC.

## ** What is new **

- Compatible with the official patch 1.1
- Keep the currently held weapon when entering a boss room. (Off by default)
- Make the interaction with doors and bus stops instantaneous. (Off by default)
- Add the two missing moves' input display in the dojo.
- Add two new features to the training mode (No AI on enemies and players invincibility).
- Use the JSON localization file to write your own translation.
- Translated progression details (Only in Spanish and French for now - You can add you own in the mod's data file).
- Various bug fixes on existing features.


## ** What is it used for **

[Menus]
- Skip any splash screen, video, dialog with just pressing Start or Escape once.
- Start the game from the main menu. (Off by default)
- Display progression details in the save selection menu. (Off by default)
- Skip the tutorial in New Game Plus.
- Skip the "Press Start" menu.
- "Loiter" option highlighted by default after selecting a file.
- "Next" option highlighted by default in the file settings menu.
- Preselect a favorite character in the character selection screen. (Off by default)
- Useables' consumption status displayed for each character.
- Useables' stat gain displayed in shops.
- Display moves' inputs in Dojos.
- [NEW] Use the JSON localization file to write your own translation.

[Settings]
- Remap the "interact" action used to pick object on the floor or use doors.
- Remapping the “interact” action will change the button prompt accordingly.
- [NEW] Make the interaction with doors and bus stops instantaneous. (Off by default)  
- Remap the keyboard from the mod’s config file.
- Force the game to use XInput to potentially fix the controller related bugs. (Off by default)
- Display the PS4 controller’s button prompts instead of the Xbox ones. (Off by default)
- Configure the vSync settings.
- Use Unity’s frame limiter ("TargetFramerate") or a custom one. (Off by default)
- Swap the phone navigation buttons / keys. (Off by default)

[Game mechanics/Feedbacks]
- Unlock the secret characters on every save once they are unlocked on at least one save.
- Display the amount of damage on hit like other River City games.
- Customize the color and the size of the Damage and XP gain feedbacks.
- Make Recruits stay and fight for you when summoned. (Off by default) - Code by Muken
- Share rewards between players. (Off by default) - Code by Muken
- Customize the Attack and Combo system. (Off by default) - Code by Muken
- [NEW] Keep the currently held weapon when entering a boss room. (Off by default)

[Bug fixes]
- [DEPRECATED]Fix a bug that prevented the Book items to work properly when using a character other than Misako.
- Fix a bug that prevented the phone interface to display a maxed-out Stamina stat.

[Combo Training Mode]
- Press F1 to make enemies invincible.
- Press F2 to force common enemies to spawn as their Nightmare variations.
- Press F3 to prevent common enemies from attacking the players.
- [NEW] Press F4 to deactivate enemies' AI.
- [NEW] Press F5 to make the players invincible.

[FUN]
- Change the size of the enemies. (Off by default)

![vlcsnap-2019-09-16-13h12m18s096](https://user-images.githubusercontent.com/3904610/64936528-0b1bc800-d889-11e9-8c78-314270f8122d.png)
![1049320_20190922161231_1](https://user-images.githubusercontent.com/3904610/65384687-cb0c8780-dd57-11e9-8c10-23d4860a3fc3.png)
![1049320_20190922161454_1](https://user-images.githubusercontent.com/3904610/65384688-cba51e00-dd57-11e9-904c-8a458beda79e.png)
![1049320_20190922163910_1](https://user-images.githubusercontent.com/3904610/65384689-cc3db480-dd57-11e9-998c-53b75cdf594c.png)


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

- "skipStartMenu": Can be set to true or false. If true, always skip the "Press Start" menu (A.K.A. Title screen).

- "interactActionId": Can be set to any "action id" like "block" or "recruit" (full list just below). It will replace the button use for interacting with doors or grab objects on the floor. The game is using the "QuickAttack" by default which can be annoying when fighting next to a door or a weapon.

- "instantInteraction": Can be set to true or false. If true, it will make interaction with doors and bus stop instantaneous. Like in the version 1.0 of the game.

- "playerOneInputConfigs" & "playerTwoInputConfigs": Each line can be set to a keyboard keycode (full list just below). Remap each action to a new keyboard key.

- "forceXInput": Can be set to true or false. If true, it might fix some controller related bugs like controlling the two players with only one controller or the controller's inputs being not detected at all.

- "usePS4buttonPrompts": Can be set to true or false. If true, it will replace the Xbox controller’s input prompts by the PS4 controller’s ones.

- "displayProgressionInfo": Can be set to true or false. If true, it will display a detailed breakdown of the currently selected save in the save selection menu.

- "swapPhoneNavigationButtons": Can be set to true or false. If true, it will swap the "Recruit" and "Block" buttons (Left and right on the phones) for the UI / menus. 

- "vSyncCount": Can be set to 0, 1, 2, 3 or 4. 0 will deactivate the vertical sync and decouple the game’s framerate to the monitor refresh rate. Doing so will usually cause “screen tearing” but will allow to use frame limiters (see below). 1, the game default, will sync the framerate with the monitor’s refresh rate. Using 144hz monitor will make the game target a framerate of 144. As the number is the ratio between the monitor refresh rate and the framerate, 2 will make the game target a framerate of 72 (for the same 144hz monitor). Most user needs to keep that value to 1.

- "targetFramerate": Can be set to -1 or any positive integer. This setting is ignored if the vSync is activated (vSync sets 1,2,3 or 4). If set to -1, the game will run as fast as possible (This will kill your battery very fast). Anything above 0 will use Unity’s built-in frame limiter to limit the framerate to the indicated value. Expect screen tearing when the camera is moving around in game.

- "useCustomFramelimiter": Can be set to true or false. If true, the game will use a custom Frame limiter to do the same thing as described just before in the "targetFramerate" section. It might give better results than the built-in one. Don’t forget to set the targetFramerate before using this.

- "displayDamageOnHit": Can be set to true or false. If true, the amount of damage will be displayed when the enemies or the player characters are hit. An exclamation mark will be added to the damage indicator when the “Bomb Bra” effect (One hit KO) is being applied.

- "xpGetTextColor": Can be set to any real number between 0 and 1 for the Red, blue, green and alpha channels of the desired color. It corresponds to the desired color of the xp gain feedback displayed when an enemy is defeated. The alpha value (“a”) is ignored but setting it to 0 will pick the game’s default feedback text color.

- "xpGetTextFontSize": Can be set to any positive integer. It defines the font size of the xp gain feedback. The game’s default is 80. Setting it to 0 or less will pick the default value.

- "hitDmgTextColor": Can be set to any real number between 0 and 1 for the Red, blue, green and alpha channels of the desired color. The same usage as "xpGetTextColor" but for the Hit damage feedback.

- "hitDmgTextFontSizeMin": Can be set to any positive integer. As the size of the Hit damage feedback is actually dynamic, a minimum and a maximum size can be set. For the players, the size depends on the amount of base damage compared to all the other move of the player’s character. For the enemies, the size is determined from the portion of health lost from their attacks.

- "hitDmgTextFontSizeMax": Can be set to any positive integer. See "hitDmgTextFontSizeMin".

- "moreInfosInUseableShops": Can be set to true or false. If true, the shop selling foods or other useable will make it clear if a character already used an item. It will also display the items' stat gains. 

- "loiterSelectedByDefault": Can be set to true or false. If true, the "loiter" option will be selected by default after selecting a file. Making it unlikely to start a new game plus by mistake and reset the story progress.

- "startSelectedByDefault": Can be set to true or false. If true, the "Next" option in the selected by default in the file settings menu.

- "noTutorialInNewGamePlus": Can be set to true or false. If true, remove the tutorial in New Game Plus.

- "characterByDefault": Can be set to Misako, Kyoko, Kunio, Riki or left empty (""). If set to a character name, the character selection screen will try to select that character by default for the two players. If value is set to locked character, left empty or invalid, the default behavior will be used. 

- "unlockSecretCharactersOnceForAllSave": Can be set to true or false. If true, unlocking the secret playable characters only need to be done once in order to make them available for any save.

- "fixBooksBug": Can be set to true or false. If true, fix a bug that prevented the Book items to work properly when using a character other than Misako.

- "fixMaxStaminaBug": Can be set to true or false. If true, fix a bug that prevented the phone interface to display a maxed-out Stamina stat.

- "activateTrainingMode": Can be set to true or false. If true, allows to use the F1 to F5 keys to switch on and off different features related to "combo training".

- "enemiesScalingRatio": Can be set to any real number between 0.1 and 20. Will change the size of the enemies. :D

- "gameplayModifications": This section contains flags that change aspects of gameplay

	- "activeRecruits": Can be set to true or false. If true, change the recruit system entirely. Recruits will now actively participate to the fight until they are taken down by the enemies or until the player left the current room.  Summoning a recruit costs a heart, as well as letting a recruit get KO'ed.  Press the recruit button again to dismiss before they are KOed.

	- "quickComboOverride":  Can be set to true or false.  If true, after purchasing extensions to the quick combo, you can still do the finisher early by holding up while pressing quick attack.

	- "backAttackCombo":  Can be set to true or false.  If true, in all combos where you can combo into a heavy attack, you can also combo into a back attack by holding back while pressing heavy attack.

	- "backAttackAutoParry":  Can be set to true or false.  If true, all back attacks have an auto-parry property against all non-boss attacks coming from the back.

	- "heavyAttackGuardBreak":  Can be set to true or false.  If true, forward + heavy attacks will break the guard of non-boss enemies.
	
	- "sharedRewards":  Can be set to true or false.  If true, all XP and money from fighting enemies will be shared between players in coop mode.
	
	- "monkMode": Can be set to true or false.  This is a challenge mode where you play in poverty.  No money will be earned (though you will start with all techniques unlocked, and burgers are free during the Godai burger quest).  Enemies will have a 20% health bonus, act 1 and 2 enemies will be slightly tougher, all bosses will have double health, and Sabuko will have a nice end-boss surprise for you.  In return, all characters will start with both Kyoko's and Misako's starting equipment.  You may want to put on those gym shorts, since you don't have a lot of other ways to get health back :)

	- "alwaysKeepWeapons": Can be set to true or false.  If true, the player characters will keep their currently held weapon when entering a boss room.

- "useJsonLocalizationData": Can be set to true or false.  If true, the game will use the localization file located in "RiverCityGirls_Data\StreamingAssets\LocalizationData" instead of its internal data.

- "localizationKeys": A list of localization keys only used by the mod. Can also be used to replace any existing key used by the game.


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
