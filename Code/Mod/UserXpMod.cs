using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using Rewired;
using System.Linq;
using RCG;

namespace Mod
{
    public class UserXpMod : MonoBehaviour
    {
        private static UserXpMod s_instance;

        public static UserXpMod Instance
        {
            get
            {
                if (s_instance == null)
                {
                    GameObject go = new GameObject("UserXpMod");
                    s_instance = go.AddComponent<UserXpMod>();
                    s_instance.LoadModData();
                    DontDestroyOnLoad(go);
                }
                return s_instance;
            }
        }

        private int[] playerOneElementIdentifierIds = new int[] { 23, 19, 1, 4, 54, 7, 25, 8, 21, 9, 20, 8, 21 };
        private int[] playerTwoElementIdentifierIds = new int[] { 89, 90, 92, 91, 116, 38, 39, 37, 40, 52, 51, 37, 40 };

        private string kbMapXmlTemplate = "<?xml version =\"1.0\" encoding=\"utf-16\"?><KeyboardMap dataVersion=\"2\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://guavaman.com/rewired http://guavaman.com/schemas/rewired/1.1/KeyboardMap.xsd\" xmlns=\"http://guavaman.com/rewired\"><sourceMapId>{26}</sourceMapId><categoryId>{27}</categoryId><layoutId>0</layoutId><name></name><hardwareGuid>00000000-0000-0000-0000-000000000000</hardwareGuid><enabled>true</enabled><buttonMaps><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>1</actionId><elementType>1</elementType><elementIdentifierId>{0}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{13}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>1</actionId><elementType>1</elementType><elementIdentifierId>{1}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>1</axisContribution><keyboardKeyCode>{14}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>0</actionId><elementType>1</elementType><elementIdentifierId>{2}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>1</axisContribution><keyboardKeyCode>{15}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>0</actionId><elementType>1</elementType><elementIdentifierId>{3}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{16}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>9</actionId><elementType>1</elementType><elementIdentifierId>{4}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{17}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>3</actionId><elementType>1</elementType><elementIdentifierId>{5}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{18}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>4</actionId><elementType>1</elementType><elementIdentifierId>{6}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{19}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>2</actionId><elementType>1</elementType><elementIdentifierId>{7}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{20}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>5</actionId><elementType>1</elementType><elementIdentifierId>{8}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{21}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>6</actionId><elementType>1</elementType><elementIdentifierId>{9}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{22}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>7</actionId><elementType>1</elementType><elementIdentifierId>{10}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{23}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>11</actionId><elementType>1</elementType><elementIdentifierId>{11}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{24}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap><ActionElementMap><actionCategoryId>0</actionCategoryId><actionId>12</actionId><elementType>1</elementType><elementIdentifierId>{12}</elementIdentifierId><axisRange>0</axisRange><invert>false</invert><axisContribution>0</axisContribution><keyboardKeyCode>{25}</keyboardKeyCode><modifierKey1>0</modifierKey1><modifierKey2>0</modifierKey2><modifierKey3>0</modifierKey3><enabled>true</enabled></ActionElementMap></buttonMaps></KeyboardMap>";

        public ModData data { get { LoadModData(); return _data; } set { _data = value; } }

        public bool AreEnemiesInvicible { get; private set; }
        public bool AreEnemiesNightmare { get; private set; }
        public bool AreEnemiesPacifist { get; private set; }

        public bool HasUsedQuickSkip { get; private set; }
        public bool HasSeenIntros { get; set; }

        private ModData _data;

        public bool hasData = false;

        private void SwitchDebugMenu()
        {
            if (UI_DebugMenu_Manager.Instance.Open)
            {
                UI_DebugMenu_Manager.Instance.CloseMenu();
            }
            else
            {
                UI_DebugMenu_Manager.Instance.OpenMenu();
            }
        }

        private void InputUpdate()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F1))
            {
                SwitchDebugMenu();
                return;
            }

            TrainingInputUpdate();
        }

        private void TrainingInputUpdate()
        {
            if (data.activateTrainingMode == false || GameState.CurrentState != GameStates.Playing)
                return;

            if (Input.GetKeyDown(KeyCode.F1))
            {
                AreEnemiesInvicible = !AreEnemiesInvicible;
                DisplayCustomTextAbovePlayer(0, string.Format("Invicible enemies: {0}", AreEnemiesInvicible), false, AreEnemiesInvicible ? Color.green : Color.red, 120);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                AreEnemiesNightmare = !AreEnemiesNightmare;
                DisplayCustomTextAbovePlayer(0, string.Format("Nightmare enemies: {0}", AreEnemiesNightmare), false, AreEnemiesNightmare ? Color.green : Color.red, 120);
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                AreEnemiesPacifist = !AreEnemiesPacifist;
                DisplayCustomTextAbovePlayer(0, string.Format("Pacifist enemies: {0}", AreEnemiesPacifist), false, AreEnemiesPacifist ? Color.green : Color.red, 120);
            }
        }

        public void Update()
        {
            FrameLimiterUpdate();
            InputUpdate();
        }

        public void ApplyModifiersOnEnemy(EnemyEnitity enemy)
        {
            if (AreEnemiesNightmare)
            {
                enemy._DifficultyType = EnemyEnitity.enumDifficultyType.Nightmare;
            }
            if (enemy is NPCEntity == false && data.enemiesScalingRatio > 0f && data.enemiesScalingRatio != 1f)
            {
                float scale = Mathf.Clamp(data.enemiesScalingRatio, 0.1f, 20f);
                transform.localScale *= scale;
            }
            if (data.activateTrainingMode && enemy._AISetting != null)
            {
                if (aiSettings.ContainsKey(enemy.ClassType) == false)
                {
                    aiSettings.Add(enemy.ClassType, enemy._AISetting);
                }
                enemy._AISetting = Instantiate(enemy._AISetting);
            }
        }

        public Dictionary<CombatEnitityMainManager.EnemyClassType, AISetting> aiSettings = new Dictionary<CombatEnitityMainManager.EnemyClassType, AISetting>();

        public void UpdateAiSetting(EnemyEnitity enemy)
        {
            if (data.activateTrainingMode == false)
                return;

            enemy._AISetting.PercentageOfGetupAttack = AreEnemiesPacifist ? 0f : aiSettings[enemy.ClassType].PercentageOfGetupAttack;
            enemy._AISetting.AIAttackDetails_RunHeavyAttack.Weight = AreEnemiesPacifist ? 0f : aiSettings[enemy.ClassType].AIAttackDetails_RunHeavyAttack.Weight;
            enemy._AISetting.AIAttackDetails_RunSpecialAttack.Weight = AreEnemiesPacifist ? 0f : aiSettings[enemy.ClassType].AIAttackDetails_RunSpecialAttack.Weight;
            enemy._AISetting.AIAttackDetails_RunQuickAttack.Weight = AreEnemiesPacifist ? 0f : aiSettings[enemy.ClassType].AIAttackDetails_RunQuickAttack.Weight;
            enemy._AISetting.ChasingAttack_WhatToUse = AreEnemiesPacifist ? AI_MoveToAttackRange.AttackType.None : aiSettings[enemy.ClassType].ChasingAttack_WhatToUse;
            enemy._AISetting.AttackTime_Min = AreEnemiesPacifist ? float.PositiveInfinity : aiSettings[enemy.ClassType].AttackTime_Min;
            enemy._AISetting.AttackTime_Max = AreEnemiesPacifist ? float.PositiveInfinity : aiSettings[enemy.ClassType].AttackTime_Max;

            enemy._AISetting.Retaliate_AftersHPCount_ByBlocking = AreEnemiesPacifist ? false : aiSettings[enemy.ClassType].Retaliate_AftersHPCount_ByBlocking;
            enemy._AISetting.Blocking_HowManyBlockHitsBeforeRetaliation = AreEnemiesPacifist ? int.MaxValue : aiSettings[enemy.ClassType].Blocking_HowManyBlockHitsBeforeRetaliation;
            enemy._AISetting.Retaliate_AfterManyHitsWithoutIdle_HPCount = AreEnemiesPacifist ? int.MaxValue : aiSettings[enemy.ClassType].Retaliate_AfterManyHitsWithoutIdle_HPCount;
        }

        private void LoadModData()
        {
            if (hasData == false)
            {
                string modDataJson = File.ReadAllText(".\\ModData.json");
                data = JsonUtility.FromJson<ModData>(modDataJson);

                hasData = true;

                ApplyFramerateConfig();
                ApplyCustomInputConfig();
            }
        }

        private void ApplyFramerateConfig()
        {
            if (hasData == false)
                return;

            //Screen.SetResolution(1920, 640, false);

            if (data.useCustomFramelimiter && HighResolutionTime.IsAvailable)
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

        private void ApplyCustomInputConfig()
        {
            if (hasData == false)
                return;

            if (data.forceXInput)
            {
                ReInput.configuration.windowsStandalonePrimaryInputSource = Rewired.Platforms.WindowsStandalonePrimaryInputSource.XInput;
            }

            if (_data.interactActionId == "")
                _data.interactActionId = "QuickAttack";

            if (data.swapControllerBlockAndRecruitButtons)
            {
                //actionIdToPromptTypes["Block"] = PromptType.LTrigger;
                //actionIdToPromptTypes["Recruit"] = PromptType.RTrigger;

                blockInput = "Recruit";
                recruitInput = "Block";

                string block = data.playerOneInputConfigs[0].block;
                _data.playerOneInputConfigs[0].block = data.playerOneInputConfigs[0].recruit;
                _data.playerOneInputConfigs[0].recruit = block;
                block = data.playerTwoInputConfigs[0].block;
                _data.playerTwoInputConfigs[0].block = data.playerTwoInputConfigs[0].recruit;
                _data.playerTwoInputConfigs[0].recruit = block;

                if (data.interactActionId == "Block")
                    _data.SetInteractActionId("Recruit");
                else if (data.interactActionId == "Recruit")
                    _data.SetInteractActionId("Block");
            }

            ReplacePlayerMaps(0);
            ReplacePlayerMaps(1);
        }

        public static string blockInput = "Block";
        public static string recruitInput = "Recruit";

        private void ReplacePlayerMaps(int playerId)
        {
            InputConfig inputConfig = data.GetInputConfig(playerId);

            Rewired.Player.ControllerHelper.MapHelper mapHelper = ReInput.players.GetPlayer(playerId).controllers.maps;

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

        private Dictionary<string, PromptType> actionIdToPromptTypes = new Dictionary<string, PromptType>()
        {
            { "Jump", PromptType.A },
            { "QuickAttack", PromptType.X },
            { "HeavyAttack", PromptType.Y },
            { "SpecialAttack", PromptType.B },
            { "Block", PromptType.RTrigger },
            { "Recruit", PromptType.LTrigger },
            { "Start", PromptType.Start },
        };

        public PromptType ActionIdToPromptType(string actionId)
        {
            if (actionIdToPromptTypes.ContainsKey(actionId))
                return actionIdToPromptTypes[actionId];
            else
                return PromptType.X;
        }

        private long lastTime = HighResolutionTime.IsAvailable ? HighResolutionTime.Time : 0L;

        public void FrameLimiterUpdate()
        {
            if (HighResolutionTime.IsAvailable == false || hasData == false || data.useCustomFramelimiter == false || data.targetFramerate <= 0.0)
                return;

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

        public int GetHasBeatenGameTimesAnyChar(bool ignoreModData = false)
        {
            if (ignoreModData == false && data.unlockSecretCharactersOnceForAllSave == false)
                return EventManager.instance.GetHasBeatenGameTimes();

            string hasBeatenGameEventName = EventManager.instance.GetHasBeatenGameEvent().EventName;
            int hasBeatenGameCount = 0;
            for (int i = 0; i < 4; i++)
            {
                List<PersistentData.EventSystemDataValue> eventValues = SaveManager_Main.LoadOrGetDefaultObject(string.Format("Slot_{0}_saveKeySlotFinishedEvents", i), new List<PersistentData.EventSystemDataValue>(), "savefile");
                for (int j = 0; j < eventValues.Count; j++)
                {
                    if (eventValues[j].EventName == hasBeatenGameEventName)
                    {
                        hasBeatenGameCount += eventValues[j].TimesFired;
                    }
                }
            }
            return hasBeatenGameCount;
        }

        public string GetProgressionInfo(Data_FileSelect data_FileSelect)
        {
            if (data.displayProgressionInfo == false)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            //sb .AppendLine( string.Format("Completion rate: {0}", data_FileSelect.GetTotalCompletionRatio().ToString("p2")));
            int num;
            int num2;
            sb.AppendLine(string.Format("Completed Quests:\t  {0} {1}/{2}", data_FileSelect.GetQuestCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Defeated Bosses:\t  {0} {1}/{2}", data_FileSelect.GetBossCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("visited Areas:\t  {0} {1}/{2}", data_FileSelect.GetMapCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Seen Items:\t\t  {0} {1}/{2}", data_FileSelect.GetUsableCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Unlocked Moves:\t  {0} {1}/{2}", data_FileSelect.GetAttackMoveCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Unlocked Equips:\t  {0} {1}/{2}", data_FileSelect.GetEquipCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Busted Statues:\t  {0} {1}/{2}", data_FileSelect.GetStatueCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Recruits Found:\t  {0} {1}/{2}", data_FileSelect.GetRecruitCompletion(out num, out num2).ToString("0%"), num, num2));
            sb.AppendLine(string.Format("Game beaten:\t  {0}", EventManager.instance.GetHasBeatenGameTimes() > 0 ? "YES" : "NO"));
            sb.AppendLine(string.Format("NewGame+ started: {0}", PersistentData.Instance.IsNewGamePlus ? "YES" : "NO"));
            return sb.ToString();
        }

        public bool IsUsingQuickSkip()
        {
            if (data.allowQuickSkip == false)
                return false;

            HasUsedQuickSkip = true;

            return Input.GetKeyDown(KeyCode.Escape) || Singleton<GlobalInput>.instance.ButtonDown(GlobalInput.Buttons.Start, GlobalInput.ControllerId.One);
        }

        public void DisplayHitDamage(CombatEntity victim, CombatEntity attacker, DamageInfo damageInfo, float dmg)
        {
            if (!data.displayDamageOnHit || victim.CharacterSprite == null || dmg <= 0f)
                return;

            bool hasBombBraEffect = false;
            float ratio = 0.5f;
            if (attacker != null)
            {
                RCG.Player player = attacker as RCG.Player;
                if (player != null)
                {
                    PlayerCharacters pc = PlayerManager.Instance.Players[player.PlayerID].ClassNameToPlayerCharacter;
                    hasBombBraEffect = RCG.PlayerEquipEffectManager.Instance.BombBraEffect(pc, victim);
                    if (hasBombBraEffect)
                    {
                        ratio = 1f;
                    }

                    int current = damageInfo.DamageAmount;
                    int min = current;
                    int max = current;
                    for (int i = 0; i < player.CharacterDescription.MovesList.Count; i++)
                    {
                        int baseDmg = player.CharacterDescription.MovesList[i].DamageInfo.DamageAmount;

                        if (baseDmg <= 0)
                            continue;

                        if (min > baseDmg)
                        {
                            min = baseDmg;
                        }
                        if (max < baseDmg)
                        {
                            max = baseDmg;
                        }
                    }
                    ratio = Mathf.InverseLerp((float)min, (float)max, (float)current);
                }
                else
                {
                    ratio = Mathf.InverseLerp(0.05f, 0.4f, Mathf.CeilToInt(dmg) / (float)(victim.Stamina + Mathf.CeilToInt(dmg)));
                }
            }
            int scaledFontSize = Mathf.RoundToInt(Mathf.Lerp(data.hitDmgTextFontSizeMin, data.hitDmgTextFontSizeMax, ratio));
            DisplayCustomTextAbove(victim, string.Format("{0}{1}", Mathf.CeilToInt(dmg), hasBombBraEffect ? "!" : ""), true, data.hitDmgTextColor, scaledFontSize);
        }

        private GameObject _dmgTextPrefab;

        public void DisplayCustomTextAbove(CombatEntity entity, string text,
            bool bUseUnscaleTime = true, Color customColor = default(Color), int fontSize = -1)
        {
            if (_dmgTextPrefab == null)
            {
                _dmgTextPrefab = Resources.Load<GameObject>("Prefab/DamageText");
            }

            entity.FindCharacterSprite();
            if (entity.CharacterSprite != null)
            {
                Vector2 rendererPosition = entity.CharacterSprite.RendererPosition;
                rendererPosition.y += 1.8f;
                GameObject gameObject = UnityEngine.Object.Instantiate(_dmgTextPrefab, rendererPosition, Quaternion.identity);
                DamageText damageText = gameObject.GetComponent<DamageText>();
                damageText.SetText(text);
                if (customColor.a > 0f)
                {
                    damageText.SetColor(customColor);
                }
                if (fontSize >= 0)
                {
                    damageText.SetSize(fontSize);
                }
                if (!bUseUnscaleTime)
                {
                    gameObject.GetComponentInChildren<UI2DFloatyText>()._useUnscaleTime = false;
                    return;
                }
            }
            else
            {
                Debug.LogError("Missing CharacterSprite");
            }
        }

        public void DisplayCustomTextAbovePlayer(int playerId, string text,
            bool bUseUnscaleTime = true, Color customColor = default(Color), int fontSize = -1)
        {
            if (playerId < 0 || playerId >= 2)
                return;

            CombatEntity playerCmbEntity = PlayerManager.Instance.Players[playerId] as CombatEntity;
            if (playerCmbEntity == null)
                return;

            DisplayCustomTextAbove(playerCmbEntity, text, bUseUnscaleTime, customColor, fontSize);
        }

        public void ModifyNgpDefaultOption(UI_Confirm ngpConfirm)
        {
            if (data.loiterSelectedByDefault)
                ngpConfirm.StartOption = ngpConfirm._noOption;
        }

        public string AddStoreInfosToUsableItem(Data_Item item, UI_StoreItemDisplayV2 itemUi, bool isHidden)
        {
            if (!data.moreInfosInUseableShops || isHidden)
                return string.Empty;

            Data_InventoryItem invItem = item as Data_InventoryItem;

            if (invItem == null || invItem.ItemType != InventoryItemTypes.Useable)
                return string.Empty;

            int playerId = UI_StoreScreenV2.Instance.CurrentShopper;
            PlayerCharacters playerChar = PlayerManager.Instance.Players[playerId].PlayerCharacter;
            bool haveConsumed = PlayerGlobalInventory.instance.HaveYouConsumedThis(item, playerChar);

            itemUi.ToggleAlreadyPurchased(haveConsumed, true);

            if (invItem.ItemName == "ITEM_NAME_NOIZE_FIGURE")
                return " +1 ALL";

            return string.Format("{0}{1}{2}{3}{4}{5}",
                invItem.Stat_ST > 0 ? string.Format(" +{0} ST", invItem.Stat_ST) : string.Empty,
                invItem.Stat_SP > 0 ? string.Format(" +{0} SP", invItem.Stat_SP) : string.Empty,
                invItem.Stat_AG > 0 ? string.Format(" +{0} AG", invItem.Stat_AG) : string.Empty,
                invItem.Stat_WP > 0 ? string.Format(" +{0} WP", invItem.Stat_WP) : string.Empty,
                invItem.Stat_AT > 0 ? string.Format(" +{0} AT", invItem.Stat_AT) : string.Empty,
                invItem.Stat_LK > 0 ? string.Format(" +{0} LK", invItem.Stat_LK) : string.Empty
            );

        }

        public UI_InputSelectable GetStartingCharacterSelectable(UI_InputSelectable startSelectable, List<UI_InputSelectable> selectables, ref int[] hoveredStateByPlayers)
        {
            if (string.IsNullOrEmpty(data.characterByDefault))
                return startSelectable;

            //Enum.TryParse(); //No Enum.TryParse in C# 4 ???
            PlayerCharacters playerCharacter;
            try
            {
                playerCharacter = (PlayerCharacters)Enum.Parse(typeof(PlayerCharacters), data.characterByDefault, true);
                if ((playerCharacter == PlayerCharacters.Riki || playerCharacter == PlayerCharacters.Kunio) && GetHasBeatenGameTimesAnyChar() < 1)
                    return startSelectable;
            }
            catch
            {
                return startSelectable;
            }

            for (int i = 0; i < selectables.Count; i++)
            {
                UI_CharacterSelectOption option = selectables[i].transform.parent.GetComponent<UI_CharacterSelectOption>();
                if (option.Character == playerCharacter)
                {
                    for (int j = 0; j < hoveredStateByPlayers.Length; j++)
                    {
                        hoveredStateByPlayers[j] = i;
                    }
                    return selectables[i];
                }
            }

            return startSelectable;
        }

        public UI_MovesItemDisplay dojoMovesItemPrefab;

        private UI_MovesItemDisplay dojoMoveDisplay;

        public void DisplayDojoMovesItem(Data_Item[] moves, string moveName, Transform moveDisplayTransform)
        {
            if (data.displayMoveInputsInDojo == false)
                return;

            if (dojoMoveDisplay != null)
                Destroy(dojoMoveDisplay.gameObject);

            Data_MovesItem move = null;
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] != null && moves[i].ItemNameEnglish == moveName)
                    move = moves[i] as Data_MovesItem;
            }

            if (move == null)
                return;

            dojoMoveDisplay = Instantiate(dojoMovesItemPrefab, moveDisplayTransform, false);
            dojoMoveDisplay.GenerateInputDisplay(move.DisplayInfo.MoveIcons, move.Inputs);
            dojoMoveDisplay.Init(string.Empty, move.MoveType, move.GetBackgroundSprite(move.MoveType), move.DisplayInfo.MaterialSelected, move.DisplayInfo.MaterialUnselected, null);
            dojoMoveDisplay.SetDisplayMaterial(true);
            dojoMoveDisplay.ToggleUnlockGraphic(false);

            RectTransform dojoMoveRt = GetComponent<RectTransform>();
            RectTransform moveDisplayRt = dojoMoveDisplay.GetComponent<RectTransform>();

            moveDisplayRt.anchorMin = new Vector2(0.5f, 0.5f);
            moveDisplayRt.anchorMax = new Vector2(0.5f, 0.5f);
            moveDisplayRt.anchoredPosition = new Vector2(-112.8f, -404.5f);
        }
    }
}