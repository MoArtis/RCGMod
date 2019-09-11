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
    public class ModData
    {
        public bool allowSkipSplashScreens;
        public bool startFromMainMenu;
        public string interactActionId;
        public InputConfig[] playerOneInputConfigs;
        public InputConfig[] playerTwoInputConfigs;
        public bool forceXInput;
        public bool fixBooksBug;
        public bool fixMaxStaminaBug;
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

        private static ModData data = null;

        public static bool startFromMainMenu { get { LoadModData(); return data.startFromMainMenu; } }

        public static bool allowSkipSplashScreens { get { LoadModData(); return data.allowSkipSplashScreens; } }

        public static string interactActionId { get { LoadModData(); return data.interactActionId; } }

        public static bool fixBooksBug { get { LoadModData(); return data.fixBooksBug; } }

        public static bool fixMaxStaminaBug { get { LoadModData(); return data.fixMaxStaminaBug; } }

        private static void LoadModData()
        {
            if (data == null)
            {
                string modDataJson = File.ReadAllText(".\\ModData.json");
                data = JsonUtility.FromJson<ModData>(modDataJson);
            }
        }

        public static void LoadCustomInputConfig()
        {
            LoadModData();

            if (data.forceXInput)
            {
                ReInput.configuration.windowsStandalonePrimaryInputSource = Rewired.Platforms.WindowsStandalonePrimaryInputSource.XInput;
            }

            ReplacePlayerMaps(0, data);
            ReplacePlayerMaps(1, data);

            //File.WriteAllText(".\\config.txt", string.Concat(
            //    ReInput.configuration.windowsStandalonePrimaryInputSource, "\n",
            //    ReInput.configuration.disableNativeInput, "\n",
            //    ReInput.configuration.useXInput, "\n"
            //    ));
        }

        private static void ReplacePlayerMaps(int playerId, ModData inputData)
        {
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
                    args.AddRange(inputData.playerOneInputConfigs[0].ToKeycodeArray());
                }
                else
                {
                    args.AddRange(playerTwoElementIdentifierIds);
                    args.AddRange(inputData.playerTwoInputConfigs[0].ToKeycodeArray());
                }

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

            //Controller map
            //???
        }
    }

}
