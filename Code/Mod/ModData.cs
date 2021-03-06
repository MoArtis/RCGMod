using UnityEngine;

namespace Mod
{
    public enum DefaultCharacters
    {
        Misako,
        Kyoko,
        Kunio,
        Riki,
        None
    }

    [System.Serializable]
    public struct GameplayModifications
    {
        public bool activeRecruits;
        public bool quickComboOverride;
        public bool backAttackCombo;
        public bool backAttackAutoParry;
        public bool heavyAttackGuardBreak;
        public bool sharedRewards;
        public bool monkMode;
        public bool alwaysKeepWeapons;
    }

    [System.Serializable]
    public struct ModData
    {
        public bool allowQuickSkip;
        public bool startFromStartMenu;
        public bool skipStartMenu;

        public string interactActionId;
        public bool instantInteraction;
        public InputConfig[] playerOneInputConfigs;
        public InputConfig[] playerTwoInputConfigs;
        public bool forceXInput;
        public bool usePS4buttonPrompts;
        public bool displayProgressionInfo;
        public bool swapPhoneNavigationButtons;

        public int vSyncCount;
        public int targetFramerate;
        public bool useCustomFramelimiter;

        public bool displayDamageOnHit;
        public Color xpGetTextColor;
        public int xpGetTextFontSize;
        public Color hitDmgTextColor;
        public int hitDmgTextFontSizeMin;
        public int hitDmgTextFontSizeMax;

        public bool moreInfosInUseableShops;
        public bool loiterSelectedByDefault;
        public bool startSelectedByDefault;
        public bool noTutorialInNewGamePlus;
        public string characterByDefault;
        public bool displayMoveInputsInDojo;

        public bool unlockSecretCharactersOnceForAllSave;

        public bool fixMaxStaminaBug;

        public bool activateTrainingMode;
        public float enemiesScalingRatio;

        public bool useJsonLocalizationData;

        public GameplayModifications gameplayModifications;

        public LocalizationKey[] localizationKeys;

        public InputConfig GetInputConfig(int playerId)
        {
            if (playerId == 0)
            {
                return playerOneInputConfigs[0];
            }
            else
            {
                return playerTwoInputConfigs[0];
            }
        }

        public void SetInteractActionId(string actionId)
        {
            interactActionId = actionId;
        }
    }

}
