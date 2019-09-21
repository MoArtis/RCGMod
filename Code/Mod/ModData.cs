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
    public struct ModData
    {
        public bool allowQuickSkip;
        public bool startFromStartMenu;
        public bool skipStartMenu;

        public string interactActionId;
        public InputConfig[] playerOneInputConfigs;
        public InputConfig[] playerTwoInputConfigs;
        public bool forceXInput;
        public bool usePS4buttonPrompts;
        public bool displayProgressionInfo;

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

        public bool fixBooksBug;
        public bool fixMaxStaminaBug;

        public bool activateTrainingMode;
        public float enemiesScalingRatio;

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
    }

}
