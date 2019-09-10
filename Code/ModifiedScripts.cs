// ** PlayerInput.cs **
protected override void Start()
{
	interactActionId = Mod.UserXpMod.interactActionId;
	switch(interactActionId)
	{
		case "QuickAttack":
			prevInteractCombatInputSet = x => { Quick = x; };
			break;
		case "HeavyAttack":
			prevInteractCombatInputSet = x => { Heavy = x; };
			break;
		case "SpecialAttack":
			prevInteractCombatInputSet = x => { Special = x; };
			break;
		case "Block":
			prevInteractCombatInputSet = null;
			break;
		case "Recruit":
			prevInteractCombatInputSet = x => { Recruit = x; };
			break;
		case "Jump":
			prevInteractCombatInputSet = x => { Jump = x; };
			break;
	}
	
	//Truncated code
}


private void Update()
{
	//Added local function
	void HandleInteractAction(System.Action<bool> combatInputSet)
	{
		if(!InInteractRange)
		{
			base.InteractQuick = false;
		}
		else
		{
			combatInputSet(false);
		}
	}
	
	//Lines 193 to 202
	//if (!InInteractRange)
	//{
	base.Quick = _rewiredPlayer.GetButtonDown("QuickAttack");
	//base.InteractQuick = false;
	//}
	//else
	//{
	//base.Quick = false;
	base.InteractQuick = _rewiredPlayer.GetButtonDown(interactActionId);
	//}
	
	//Line 278
	HandleInteractAction(prevInteractCombatInputSet);
}

// ** UI_ScreenIntro.cs **
protected void Awake()
{
    // Add this at the end of the Awake method
    SkipAllMovies = Mod.UserXpMod.startFromMainMenu;

    bool allowSkipSplashScreens = Mod.UserXpMod.allowSkipSplashScreens;
    _SkipCanvas.SetActive(value: allowSkipSplashScreens);
    _AllowOnePressStartSkip = allowSkipSplashScreens;
}

protected void Update()
{
    if ((Input.GetKeyDown(KeyCode.Escape) || Singleton<GlobalInput>.instance.ButtonDown(GlobalInput.Buttons.Start)) && (!AreAllVideosPlayed || !AreAllLegalScreensPlayed) && _AllowOnePressStartSkip)
    {
        SkipAllMovies = true;
        OnPressSkip();
    }
}

//New coroutine to avoid some UI bugs when all the intro are skipped on start
public IEnumerator SkipAllMoviesCoroutine()
{
    this._StartScreenFadeTime = 0.5f;
    yield return new WaitForSeconds(1f);
    this.OnItemChange(false);
}

public void OnItemChange(bool _skipResetMusic = false)
{
    if (SkipAllMovies)
    {
        m_CurrentLegalScreenIndex = _allLegalScreenRoots.Length;
        m_CurrentVideoIndex = _allVideoClips.Length; //This line is modified
        SkipAllMovies = false;
        StartCoroutine(SkipAllMoviesCoroutine()); //This line is added
    }
    //Truncated code
}

// ** PlayerManager.cs - Start Method - At the end of the method
private void Start()
{
    Mod.UserXpMod.LoadCustomInputConfig();
}