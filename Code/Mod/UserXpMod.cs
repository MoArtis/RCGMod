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
        public bool AreEnemiesNoAi { get; private set; }
        public bool ArePlayersInvincible { get; private set; }

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

            bool hasInput = false;

            if (Input.GetKeyDown(KeyCode.F1))
            {
                AreEnemiesInvicible = !AreEnemiesInvicible;
                DisplayCustomTextAbovePlayer(0, string.Format("Invicible enemies: {0}", AreEnemiesInvicible), false, AreEnemiesInvicible ? Color.green : Color.red, 120);
                hasInput = true;
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                AreEnemiesNightmare = !AreEnemiesNightmare;
                DisplayCustomTextAbovePlayer(0, string.Format("Nightmare enemies: {0}", AreEnemiesNightmare), false, AreEnemiesNightmare ? Color.green : Color.red, 120);
                hasInput = true;
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                AreEnemiesPacifist = !AreEnemiesPacifist;
                DisplayCustomTextAbovePlayer(0, string.Format("Pacifist enemies: {0}", AreEnemiesPacifist), false, AreEnemiesPacifist ? Color.green : Color.red, 120);
                hasInput = true;
            }

            if (Input.GetKeyDown(KeyCode.F4))
            {
                AreEnemiesNoAi = !AreEnemiesNoAi;
                DisplayCustomTextAbovePlayer(0, string.Format("No AI enemies: {0}", AreEnemiesNoAi), false, AreEnemiesNoAi ? Color.green : Color.red, 120);
                hasInput = true;
            }

            if (Input.GetKeyDown(KeyCode.F5))
            {
                ArePlayersInvincible = !ArePlayersInvincible;
                DisplayCustomTextAbovePlayer(0, string.Format("Invincible players: {0}", ArePlayersInvincible), false, ArePlayersInvincible ? Color.green : Color.red, 120);
            }

            if (hasInput)
            {
                EnemyEnitity[] enemies = FindObjectsOfType<EnemyEnitity>();
                for (int i = 0; i < enemies.Length; i++)
                {
                    UpdateAiSetting(enemies[i]);
                }
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
                float scaleRatio = Mathf.Clamp(data.enemiesScalingRatio, 0.1f, 20f);
                Vector3 scale = enemy.transform.localScale;
                scale.x *= scaleRatio;
                scale.y *= scaleRatio;
                enemy.transform.localScale = scale;
            }
            if (data.activateTrainingMode && enemy._AISetting != null)
            {
                if (aiSettings.ContainsKey(enemy.ClassType) == false)
                {
                    aiSettings.Add(enemy.ClassType, enemy._AISetting);
                }
                enemy._AISetting = Instantiate(enemy._AISetting);

                EnemyEnitity[] enemies = FindObjectsOfType<EnemyEnitity>();
                for (int i = 0; i < enemies.Length; i++)
                {
                    UpdateAiSetting(enemies[i]);
                }
            }
        }

        public Dictionary<CombatEnitityMainManager.EnemyClassType, AISetting> aiSettings = new Dictionary<CombatEnitityMainManager.EnemyClassType, AISetting>();

        public void UpdateAiSetting(EnemyEnitity enemy)
        {
            if (data.activateTrainingMode == false || enemy._AISetting == null || enemy is NPCEntity)
                return;

            enemy.AI_ChangeState<AI_Idle>();
            enemy.SetAIChangeState(!AreEnemiesNoAi);
            enemy.SetAIChangeState_CombatEntityMainManager(!AreEnemiesNoAi);

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
                ApplyMonkMode();
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

            if (data.swapPhoneNavigationButtons)
            {
                blockUiInput = "Recruit";
                recruitUiInput = "Block";
            }

            ReplacePlayerMaps(0);
            ReplacePlayerMaps(1);
        }

        private void ApplyMonkMode()
        {
            if (data.gameplayModifications.monkMode)
                Singleton<GameplayTweaks>.instance.UnlockAllMoves = true;
        }

        public static string blockUiInput = "Block";
        public static string recruitUiInput = "Recruit";

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
            string labelYes = Singleton<Localizer>.instance.GetTranslatedKey("LBL_YES", null);
            string labelNo = Singleton<Localizer>.instance.GetTranslatedKey("LBL_NO", null);
            string label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_COMPLETED_QUEST", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetQuestCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_DEFEATED_BOSSES", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetBossCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_VISITED_AREAS", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetMapCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_SEEN_ITEMS", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetUsableCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_UNLOCKED_MOVES", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetAttackMoveCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_UNLOCKED_EQUIPS", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetEquipCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_BUSTED_STATUES", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetStatueCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_RECRUITS_FOUND", null);
            sb.AppendLine(string.Format("{0}{1} {2}/{3}", label, data_FileSelect.GetRecruitCompletion(out num, out num2).ToString("0%"), num, num2));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_GAME_BEATEN", null);
            sb.AppendLine(string.Format("{0}{1}", label, EventManager.instance.GetHasBeatenGameTimes() > 0 ? labelYes : labelNo));
            label = Singleton<Localizer>.instance.GetTranslatedKey("LBL_NGP_STARTED", null);
            sb.AppendLine(string.Format("{0}{1}", label, PersistentData.Instance.IsNewGamePlus ? labelYes : labelNo));
            return sb.ToString();
        }

        public bool IsUsingQuickSkip()
        {
            if (data.allowQuickSkip == false)
                return false;

            HasUsedQuickSkip = true;

            return Input.GetKeyDown(KeyCode.Escape) || Singleton<GlobalInput>.instance.ButtonDown(GlobalInput.Buttons.Start, GlobalInput.ControllerId.One);
        }

        public void DisplayHitDamage(CombatEntity victim, CombatEntity attacker, DamageInfo damageInfo, float dmg, bool hasBombBraEffect)
        {
            if (!data.displayDamageOnHit || victim.CharacterSprite == null || dmg <= 0f)
                return;

            float ratio = 0.5f;
            if (attacker != null)
            {
                RCG.Player player = attacker as RCG.Player;
                if (player != null)
                {
                    PlayerCharacters pc = PlayerManager.Instance.Players[player.PlayerID].ClassNameToPlayerCharacter;
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

        public void DisplayDojoMovesItem(Data_MovesItem move, Transform moveDisplayTransform)
        {
            if (data.displayMoveInputsInDojo == false)
                return;

            if (dojoMoveDisplay != null)
                Destroy(dojoMoveDisplay.gameObject);

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

        public static void AddQuickOverrideToMovesList(System.Collections.Generic.List<MoveDescription> movesList)
        {
            foreach (MoveDescription move in movesList)
            {
                ComboMove lightAttack = null;
                foreach (ComboMove combo in move.ComboList)
                {
                    if (combo.Priority == 0)
                    {
                        foreach (ComboCondition condition in combo.Conditions)
                        {
                            if (condition is InputCondition)
                            {
                                InputCondition inputCondition = condition as InputCondition;
                                if (inputCondition.DirectionModifier == InputDirectionModifier.None && inputCondition.ComboInputs == ComboInputs.Quick)
                                {
                                    lightAttack = new ComboMove();
                                    lightAttack.MoveName = combo.MoveName;
                                    lightAttack.ToMove = combo.ToMove;
                                    lightAttack.Priority = 3;
                                    lightAttack.AI_Followup = combo.AI_Followup;
                                    lightAttack.Conditions = new System.Collections.Generic.List<ComboCondition>();
                                    foreach (ComboCondition comboCondition in combo.Conditions)
                                    {
                                        if (comboCondition is InputCondition)
                                        {
                                            InputCondition newInputCondition = ScriptableObject.CreateInstance<InputCondition>();
                                            newInputCondition.ComboInputs = ComboInputs.Quick;
                                            newInputCondition.DirectionModifier = InputDirectionModifier.Up;
                                            lightAttack.Conditions.Add(newInputCondition);
                                        }
                                        else
                                        {
                                            lightAttack.Conditions.Add(comboCondition);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (lightAttack != null)
                    move.ComboList.Add(lightAttack);
            }
        }

        public static void AddBackAttackComboToMovesList(System.Collections.Generic.List<MoveDescription> movesList)
        {
            MoveDescription backAttack = null;
            foreach (MoveDescription move in movesList)
            {
                if (move.MoveName.ToLower().Contains("block") && move.ComboList.Count > 0)
                {
                    backAttack = move.ComboList[0].ToMove;
                }
            }

            if (backAttack != null)
            {
                foreach (MoveDescription move in movesList)
                {
                    ComboMove backCombo = null;
                    foreach (ComboMove combo in move.ComboList)
                    {
                        foreach (ComboCondition condition in combo.Conditions)
                        {
                            if (condition is InputCondition)
                            {
                                InputCondition inputCondition = condition as InputCondition;
                                if (inputCondition.DirectionModifier == InputDirectionModifier.None && inputCondition.ComboInputs == ComboInputs.Heavy)
                                {
                                    backCombo = new ComboMove();
                                    backCombo.MoveName = backAttack.MoveName;
                                    backCombo.ToMove = backAttack;
                                    backCombo.Priority = combo.Priority + 1;
                                    backCombo.AI_Followup = combo.AI_Followup;
                                    backCombo.Conditions = new System.Collections.Generic.List<ComboCondition>();
                                    foreach (ComboCondition comboCondition in combo.Conditions)
                                    {
                                        if (comboCondition is InputCondition)
                                        {
                                            InputCondition newInputCondition = ScriptableObject.CreateInstance<InputCondition>();
                                            newInputCondition.ComboInputs = ComboInputs.Heavy;
                                            newInputCondition.DirectionModifier = InputDirectionModifier.Back;
                                            backCombo.Conditions.Add(newInputCondition);
                                        }
                                        else
                                        {
                                            backCombo.Conditions.Add(comboCondition);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (backCombo != null)
                        move.ComboList.Add(backCombo);
                }
            }
        }

        public static bool TryBackAttackAutoParry(RCG.Player player, CombatEntity combatEntity)
        {
            if (player != null)
            {
                string playerMoveName = player.CurrentMove.MoveName;
                if (playerMoveName == "MisakoBruceBackhand" ||
                    playerMoveName == "KyokoDonkeyKick" ||
                    playerMoveName == "RikiCombingHair" ||
                    playerMoveName == "KunioBackElbow")
                {
                    if ((combatEntity.transform.position.x > player.transform.position.x) != (player.Facing.FacingSign > 0))
                    {
                        combatEntity.Fsm.ChangeState<EnemyBlockPushedByPlayer>(100);
                        player.Facing.SetFacingFromSign(player.Facing.FacingSign * -1);
                        player.PlayVFX_Parry();
                        player.ChangeState<PlayerIdle>(100);
                    }
                    return true;
                }
            }
            return false;
        }

        public static void TryHeavyAttackGuardBreak(RCG.Player player, CombatEntity combatEntity)
        {
            if (player != null && !(combatEntity is BossBaseEntity))
            {
                string playerMoveName = player.CurrentMove.MoveName;
                if (playerMoveName == "MisakoHaymaker" ||
                    playerMoveName == "KyokoDab" ||
                    playerMoveName == "RikiOneInchPunch" ||
                    playerMoveName == "KunioEat")
                {
                    combatEntity.Fsm.ChangeState<EnemyBlockPushedByPlayer>(100);
                    player.ChangeState<PlayerIdle>(100);
                }
            }
        }

        public void AddModLocDataToLocDatabase(Data_LocalizationDatabase locDatabase)
        {
            List<LocalizationKey> locDataKeys = locDatabase.Keys;
            for (int i = 0; i < data.localizationKeys.Length; i++)
            {
                bool alreadyExist = false;
                for (int j = 0; j < locDataKeys.Count; j++)
                {
                    if(data.localizationKeys[i].Key == locDataKeys[j].Key)
                    {
                        alreadyExist = true;
                        locDataKeys[j] = data.localizationKeys[i];
                        break;
                    }
                }

                if(alreadyExist == false)
                    locDatabase.Keys.Add(data.localizationKeys[i]);
            }
        }
    }
}