// ** PlayerInput.cs - Update Method - Lines 193 to 202 **
private void Update()
{
	//if (!InInteractRange)
	//{
	base.Quick = _rewiredPlayer.GetButtonDown("QuickAttack");
	//base.InteractQuick = false;
	//}
	//else
	//{
	//base.Quick = false;
	base.InteractQuick = _rewiredPlayer.GetButtonDown(Mod.UserXpMod.interactActionId);
	//}
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