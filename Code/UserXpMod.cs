using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using Rewired;
using System.Linq;

namespace Mod
{
    [System.Serializable]
    public struct ModData
    {
        public bool allowQuickSkip;
        public bool startFromMainMenu;

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

        public bool noTutorialInNewGamePlus;

        public bool unlockSecretCharactersOnceForAllSave;

        public bool fixBooksBug;
        public bool fixMaxStaminaBug;

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

    [System.Serializable]
    public struct InputConfig
    {
        public string up;
        public string down;
        public string left;
        public string right;
        public string jump;
        public string quickAttack;
        public string heavyAttack;
        public string specialAttack;
        public string block;
        public string recruit;
        public string start;

        public int[] ToKeycodeArray()
        {
            return new int[] {
                ParseKeycode(up),
                ParseKeycode(down),
                ParseKeycode(left),
                ParseKeycode(right),
                ParseKeycode(start),
                ParseKeycode(quickAttack),
                ParseKeycode(heavyAttack),
                ParseKeycode(jump),
                ParseKeycode(specialAttack),
                ParseKeycode(block),
                ParseKeycode(recruit),
                ParseKeycode(jump),
                ParseKeycode(specialAttack)
            };
        }

        private int ParseKeycode(string keycodeStr)
        {
            KeyboardKeyCode keyboardKeyCode;
            try
            {
                keyboardKeyCode = (KeyboardKeyCode)Enum.Parse(typeof(KeyboardKeyCode), keycodeStr);
            }
            catch (Exception e)
            {
                File.WriteAllText(string.Format(".\\{0}.txt", keycodeStr), e.Message);
                keyboardKeyCode = KeyboardKeyCode.None;
            }
            return (int)keyboardKeyCode;
        }
    }

    public class UserXpMod
    {
        private static int[] playerOneElementIdentifierIds = new int[] { 23, 19, 1, 4, 54, 7, 25, 8, 21, 9, 20, 8, 21 };
        private static int[] playerTwoElementIdentifierIds = new int[] { 89, 90, 92, 91, 116, 38, 39, 37, 40, 52, 51, 37, 40 };

        private static string kbMapXmlTemplate = "<?xml version =\"1.0\" encoding=\"utf-16\"?><KeyboardMap dataVersion=\"2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://guavaman.com/rewired http://guavaman.com/schemas/rewired/1.1/KeyboardMap.xsd\" xmlns=\"http://guavaman.com/rewired\"><sourceMapId>{26}</sourceMapId><categoryId>{27}</categoryId><layoutId>0</layoutId><name></name><hardwareGuid>00000000-0000-0000-0000-000000000000</hardwareGuid><enabled>true</enabled><buttonMaps><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>1</actionId><elementType>1</elementType><elementIdentifierId>{0}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{13}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>1</actionId><elementType>1</elementType><elementIdentifierId>{1}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>1</axisContribution><keyboardKeyCode>{14}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>0</actionId><elementType>1</elementType><elementIdentifierId>{2}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>1</axisContribution><keyboardKeyCode>{15}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>0</actionId><elementType>1</elementType><elementIdentifierId>{3}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{16}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>9</actionId><elementType>1</elementType><elementIdentifierId>{4}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{17}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>3</actionId><elementType>1</elementType><elementIdentifierId>{5}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{18}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>4</actionId><elementType>1</elementType><elementIdentifierId>{6}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{19}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>2</actionId><elementType>1</elementType><elementIdentifierId>{7}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{20}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>5</actionId><elementType>1</elementType><elementIdentifierId>{8}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{21}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>6</actionId><elementType>1</elementType><elementIdentifierId>{9}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{22}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>7</actionId><elementType>1</elementType><elementIdentifierId>{10}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{23}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>11</actionId><elementType>1</elementType><elementIdentifierId>{11}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{24}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>12</actionId><elementType>1</elementType><elementIdentifierId>{12}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{25}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap></buttonMaps></KeyboardMap>";

        public static ModData data { get { LoadModData(); return _data; } set { _data = value; } }
        private static ModData _data;

        public static bool hasData = false;

        private static void LoadModData()
        {
            if (hasData == false)
            {
                string modDataJson = File.ReadAllText(".\\ModData.json");
                data = JsonUtility.FromJson<ModData>(modDataJson);

                if (data.interactActionId == "")
                    _data.interactActionId = "QuickAttack";

                hasData = true;
            }
        }

        public static void ApplyFramerateConfig()
        {
            LoadModData();

            if (hasData == false)
                return;

            if (data.useCustomFramelimiter)
            {
                Application.targetFrameRate = -1;
                QualitySettings.vSyncCount = 0;
            }
            else
            {
                Application.targetFrameRate = data.targetFramerate;
                QualitySettings.vSyncCount = data.vSyncCount;
            }
        }

        public static void LoadCustomInputConfig()
        {
            LoadModData();

            if (hasData == false)
                return;

            if (data.forceXInput)
            {
                ReInput.configuration.windowsStandalonePrimaryInputSource = Rewired.Platforms.WindowsStandalonePrimaryInputSource.XInput;
            }

            ReplacePlayerMaps(0);
            ReplacePlayerMaps(1);
        }

        private static void ReplacePlayerMaps(int playerId)
        {
            InputConfig inputConfig = data.GetInputConfig(playerId);

            Player.ControllerHelper.MapHelper mapHelper = ReInput.players.GetPlayer(playerId).controllers.maps;

            //Clear previous maps
            mapHelper.ClearMaps(ControllerType.Keyboard, false);

            try
            {
                List<int> args = new List<int>();

                //Keyboard map
                if (playerId == 0)
                {
                    args.AddRange(playerOneElementIdentifierIds);
                }
                else
                {
                    args.AddRange(playerTwoElementIdentifierIds);
                }

                args.AddRange(inputConfig.ToKeycodeArray());

                args.Add(playerId + 1);
                args.Add(playerId + 1);

                string kbMapXml = "";
                kbMapXml = string.Format(kbMapXmlTemplate, args.Select(x => x.ToString()).ToArray());
                mapHelper.AddMapFromXml(ControllerType.Keyboard, 0, kbMapXml);
            }
            catch (Exception e)
            {
                File.WriteAllText(string.Format(".\\Player{0}-Remap-ERROR.txt", playerId), string.Concat(e.Message, "\n", e.StackTrace));
            }
        }

        private static Dictionary<string, PromptType> actionIdToPromptTypes = new Dictionary<string, PromptType>()
        {
            { "Jump", PromptType.A },
            { "QuickAttack", PromptType.X },
            { "HeavyAttack", PromptType.Y },
            { "SpecialAttack", PromptType.B },
            { "Block", PromptType.RTrigger },
            { "Recruit", PromptType.LTrigger },
            { "Start", PromptType.Start },
        };

        public static PromptType ActionIdToPromptType(string actionId)
        {
            if (actionIdToPromptTypes.ContainsKey(actionId))
                return actionIdToPromptTypes[actionId];
            else
                return PromptType.X;
        }

        private static long lastTime = HighResolutionTime.Time;

        public static void FrameLimiterUpdate()
        {
            if (hasData == false || data.useCustomFramelimiter == false || data.targetFramerate <= 0.0) return;

            lastTime += TimeSpan.FromSeconds(1.0 / data.targetFramerate).Ticks;

            var now = HighResolutionTime.Time;

            if (now >= lastTime)
            {
                lastTime = now;
                return;
            }
            else
            {
                //System.Threading.SpinWait.SpinUntil(() => { return (HighResolutionTime.Time >= lastTime); });
                while (HighResolutionTime.Time < lastTime) { }
            }
        }

        public static bool IsKunioAndRikkiUnlockedOnAnySaveSlot()
        {
            for (int i = 0; i < 4; i++)
            {
                List<PersistentData.EventSystemDataValue> eventValues = SaveManager_Main.LoadOrGetDefaultObject($"Slot_{i}_saveKeySlotFinishedEvents", new List<PersistentData.EventSystemDataValue>(), "savefile");
                for (int j = 0; j < eventValues.Count; j++)
                {
                    if (eventValues[j].EventName == "Kill Final")
                    {
                        if (eventValues[j].TimesFired >= 1)
                            return true;
                    }
                }
            }
            return false;
        }
    }

}