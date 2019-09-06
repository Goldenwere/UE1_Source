using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//These handle game difficulty
	//DifficultyEscalation is determined by which level is used
	public float _difficultyescalation;
	//Player difficulty is determined by Settings, and must be grabbed from such
	public float _playerdifficulty;
	//The above difficulties are added
	public float _difficultyScore;
	//These gameobjects host all the objects that change depending on what part
	//of the level is used. Each base has 3 parts, and the part is determined
	//from loadmanager; the objects include entities, repair spots, and environmental changes
	public GameObject _obj1;
	public GameObject _obj2;
	public GameObject _obj3;
	//To grab the _basePart from LoadManager
	public LoadManager _lm;
	//To determine if paused or not
	public bool _isPaused;
	public bool _isLoading;
	public bool _isCutscene;
	//To enable/disable sounds (fixes a bug)
	public GameObject _ui1;
	public GameObject _ui2;
	public GameObject _ui3;
	public float _timer;
	//To determine if complete or not
	public bool _isComplete;
	public bool _completebool;
	public bool _isDead;
	public bool _isCompleting; //this one is to prevent the end cutscene send message from repeatedly sending
	//Canvases
	public Canvas _pause;
	public Canvas _completion;
	public GameObject _HUD;
	public Canvas _death;
	public Text _entText;
    public Text _repText;
    public Canvas _canvasObjectives;
    public Canvas _canvasMiniMap;
	public GameObject _canvasMiniMapObjects;
    public bool _COToggle;
    public bool _CMMToggle;
    public Light _flashlight;
    public bool _FLToggle;
    public int _minimapStatus;
    public Camera _mmFullCam;
    public Camera _mmZoomCam;
    //Player object is needed to prevent from swinging around while paused
    public MonoBehaviour _fpc;
    public HoverPlayerManager _HPM;
	//To disable the animation components
	public Animation _fpcanim;
	public Animation _pistolanim;
	public Animation _rifleanim;
	//To load the menu when Pause button is pressed and is viewing the intro/credits scene
	public AsyncOperation _asyncop;
	//Variables for completion
	public int _entities;
    public int _repair;
	//To tell music manager what level this is
	public int _musicLevel;

	void Awake() {
		Debug.Log("LevelManager: Finding LoadManager...");
		_lm = GameObject.FindWithTag("LoadManagerTag").GetComponent<LoadManager>();
		Debug.Log("LevelManager: LoadManager found. Setting difficulty escalation based on loadmanager level selected");
		//Determine the difficulty escalation
		//This first if is mainly to have a text-collapse in Mono
		if (_lm._levelSelected <= 32) {
			if (_lm._levelSelected == 1 || _lm._levelSelected == 2 || _lm._levelSelected == 3) {
				_difficultyescalation = 1;
			}
			if (_lm._levelSelected == 4 || _lm._levelSelected == 5 || _lm._levelSelected == 6) {
				_difficultyescalation = 2;
			}
			if (_lm._levelSelected == 7 || _lm._levelSelected == 8 || _lm._levelSelected == 9 || _lm._levelSelected == 10) {
				_difficultyescalation = 3;
			}
			if (_lm._levelSelected == 11 || _lm._levelSelected == 12 || _lm._levelSelected == 13) {
				_difficultyescalation = 4;
			}
			if (_lm._levelSelected == 14 || _lm._levelSelected == 15 || _lm._levelSelected == 16) {
				_difficultyescalation = 5;
			}
			if (_lm._levelSelected == 17 || _lm._levelSelected == 18 || _lm._levelSelected == 19 || _lm._levelSelected == 20) {
				_difficultyescalation = 6;
			}
			if (_lm._levelSelected == 21 || _lm._levelSelected == 22 || _lm._levelSelected == 23) {
				_difficultyescalation = 7;
			}
			if (_lm._levelSelected == 24 || _lm._levelSelected == 25 || _lm._levelSelected == 26) {
				_difficultyescalation = 8;
			}
			if (_lm._levelSelected == 27 || _lm._levelSelected == 28 || _lm._levelSelected == 29) {
				_difficultyescalation = 9;
			}
			if (_lm._levelSelected == 30 || _lm._levelSelected == 31 || _lm._levelSelected == 32) {
				_difficultyescalation = 10;
			}
		}
		Debug.Log("LevelManager: Escalation determined. Grabbing player difficulty from SettingsManager...");
		_playerdifficulty = GameObject.FindGameObjectWithTag("SettingManagerTag").GetComponent<SettingsManager>()._playerDiff;
		Debug.Log("LevelManager: Player difficulty found. Determining full difficulty score based on escalation plus player...");
		_difficultyScore = _difficultyescalation + _playerdifficulty;
		Debug.Log("LevelManager: Difficulty determined. End of Awake(). Executing Start()...");
	}

	void Start() {
		Debug.Log("LevelManager: Start of Start(). Setting paused/loading/completion variables to false and HUD toggles to true...");
		//To make certain that the game isn't paused at the start
		_isPaused = false;
		_isLoading = false;
		//To make certain that the menus are not active at start and the HUD is
		_completion.enabled = false;
		_pause.enabled = false;
		_death.enabled = false;
    _HUD.SetActive(true);
    _CMMToggle = true;
    _COToggle = true;
		_FLToggle = true;
		_flashlight.enabled = true;
		UpdateHUD();
    //Determines which of the three parts of the base to load
		Debug.Log("LevelManager: Variables set. Determining which part of the base to load based on loadmanager's basepart variable determinant...");
		if (_lm._basePart == 1) {
			_obj1.SetActive(true);
			_obj2.SetActive(false);
			_obj3.SetActive(false);
		}
		if (_lm._basePart == 2) {
			_obj1.SetActive(false);
			_obj2.SetActive(true);
			_obj3.SetActive(false);
		}
		if (_lm._basePart == 3) {
			_obj1.SetActive(false);
			_obj2.SetActive(false);
			_obj3.SetActive(true);
		}
		Debug.Log("LevelManager: Appropriate base objects activated/deactivated. Determining stats needed for level completion...");
		//Set up the stats needed for level completion
		//This first if is mainly to have a text-collapse in Mono
		if (_lm._levelSelected <= 32) {
			if (_lm._levelSelected == 1) {
				_entities = 10;
				_repair = 1;
			}
			if (_lm._levelSelected == 2) {
				_entities = 15;
				_repair = 3;
			}
			if (_lm._levelSelected == 3) {
				_entities = 25;
				_repair = 3;
			}
			if (_lm._levelSelected == 4) {
				_entities = 25;
				_repair = 3;
			}
			if (_lm._levelSelected == 5) {
				_entities = 25;
				_repair = 6;
			}
			if (_lm._levelSelected == 6) {
				_entities = 30;
				_repair = 4;
			}
			if (_lm._levelSelected == 7) {
				_entities = 20;
				_repair = 3;
			}
			if (_lm._levelSelected == 8) {
				_entities = 50;
				_repair = 5;
			}
			if (_lm._levelSelected == 9) {
				_entities = 50;
				_repair = 1;
			}
			if (_lm._levelSelected == 10) {
				_entities = 30;
				_repair = 8;
			}
			if (_lm._levelSelected == 11) {
				_entities = 50;
				_repair = 8;
			}
			if (_lm._levelSelected == 12) {
				_entities = 45;
				_repair = 7;
			}
			if (_lm._levelSelected == 13) {
				_entities = 50;
				_repair = 7;
			}
			if (_lm._levelSelected == 14) {
				_entities = 40;
				_repair = 7;
			}
			if (_lm._levelSelected == 15) {
				_entities = 100;
				_repair = 8;
			}
			if (_lm._levelSelected == 16) {
				_entities = 50;
				_repair = 6;
			}
			if (_lm._levelSelected == 17) {
				_entities = 35;
				_repair = 5;
			}
			if (_lm._levelSelected == 18) {
				_entities = 100;
				_repair = 5;
			}
			if (_lm._levelSelected == 19) {
				_entities = 100;
				_repair = 10;
			}
			if (_lm._levelSelected == 20) {
				_entities = 75;
				_repair = 8;
			}
			if (_lm._levelSelected == 22) {
				_entities = 50;
				_repair = 5;
			}
			if (_lm._levelSelected == 23) {
				_entities = 75;
				_repair = 8;
			}
			if (_lm._levelSelected == 24) {
				_entities = 50;
				_repair = 7;
			}
			if (_lm._levelSelected == 25) {
				_entities = 110;
				_repair = 12;
			}
			if (_lm._levelSelected == 26) {
				_entities = 100;
				_repair = 12;
			}
			if (_lm._levelSelected == 27) {
				_entities = 75;
				_repair = 8;
			}
			if (_lm._levelSelected == 29) {
				_entities = 100;
				_repair = 15;
			}
			if (_lm._levelSelected == 30) {
				_entities = 100;
				_repair = 10;
			}
		}
		Debug.Log("LevelManager: Stats determined. Telling MusicManager to start...");
        //Tell musicmanager to start
        _musicLevel = _lm._levelSelected;
		Debug.Log("LevelManager: ...music level = load manager's level selected...");
		//Avoid WaitForSeconds conflicts if coroutines still going
    GameObject.FindWithTag("MusicManagerTag").GetComponent<MusicManager>().StopCoroutine("GetCurrTrack");
    GameObject.FindWithTag("MusicManagerTag").GetComponent<MusicManager>().StopCoroutine("PlayTrack");
		GameObject.FindWithTag("MusicManagerTag").GetComponent<MusicManager>().StopCoroutine("StartLevelTrack");
		Debug.Log("LevelManager: ...stopped running coroutines...");
		GameObject.FindWithTag("MusicManagerTag").GetComponent<MusicManager>()._isStopped = false;
        //Get start track
        GameObject.FindWithTag("MusicManagerTag").GetComponent<MusicManager>().StartLevelTrack(_musicLevel);
		Debug.Log("LevelManager: ...and executed StartLevelTrack coroutine. MusicManager tasks executed.");
		//Update HUD
		UpdateDisplay();
        //Set MiniMap Toggle
        _minimapStatus = 2;
        _mmFullCam = GameObject.Find("MiniMapCam").GetComponent<Camera>();
		_mmZoomCam = GameObject.Find("MiniMapCamDynamic").GetComponent<Camera>();
		Debug.Log("LevelManager: Updated HUD and set mini-map cams and toggle. End of Start().");
		//Make sure when the menu is selected that the cursor shows
		if (_lm._levelSelected >= 97) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		if (_lm._levelSelected < 97) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	void Update() {

    ////Constantly updated variables////
      //Determines whether a cutscene is playing or not
      if (_lm._levelSelected != 99) {
          _isCutscene = GameObject.Find("CUTSCENEMANAGER").GetComponent<CutsceneManager>()._isCutscene;
      }

		////Handle the Pause button////
			//If the level isn't credits/intro, then pause the game (only if game isn't completed,
			//if not playing a cutscene, or if not dead
			if (Input.GetButtonDown("Pause") && _lm._levelSelected < 97 && _isComplete == false && _isCutscene == false && _isDead == false) {
				if (_isPaused == false) {
					StartCoroutine("Pause");
				}
				if (_isPaused == true) {
					StartCoroutine("Unpause");
				}
			}
			//If it is, load the menu
			if (Input.GetButtonDown("Pause") && _lm._levelSelected >= 97) {
	            _asyncop = SceneManager.LoadSceneAsync("Menu");
				_lm._levelSelected = 99;
				_asyncop.allowSceneActivation = true;
			}

		////For toggling the different HUD elements////
			if (Input.GetButtonDown("MinimapToggle")) {
				StartCoroutine("MMToggle");
			}
			if (Input.GetButtonDown("ObjectivesToggle")) {
				StartCoroutine("COToggle");
			}
			if (Input.GetButtonDown("Flashlight")) {
				StartCoroutine("FLToggle");
			}
		////Completion////
			//An if statement for false is not needed because _completion.enabled will already
			//be false, and _isComplete will never go from true to false
			if (_entities <= 0 && _repair == 0 && _isCompleting == false && _isComplete == false) {
				_isCompleting = true;
				GameObject.Find("CUTSCENEMANAGER").GetComponent<CutsceneManager>().StartEndCutscene();
			}
			if (_isComplete == true && _isCutscene == false && _completebool == false) {
				Complete();
			}
	}

	////Extra functions called by other scripts////

	//This is called on by the Back button on the Pause screen
	public IEnumerator Unpause() {
		Time.timeScale = 1.0f;
		_pause.enabled = false;
		_HUD.SetActive(true);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		_fpc.enabled = true;
		yield return new WaitForEndOfFrame();
		_isPaused = false;
		yield break;
	}
	public IEnumerator Pause() {
		//The pause function: changes time scale, disables/enables canvases
		//(_pause and _HUD), changes the visibility/lockstate of the cursor,
		//and enables/disables the FPC on the Player Controller
		//It depends on current level & if isLoading & isComplete & isDead is false to prevent conflict
		Time.timeScale = 0.0f;
		_pause.enabled = true;
		_HUD.SetActive(false);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		_fpc.enabled = false;
		yield return new WaitForEndOfFrame();
		_isPaused = true;
		yield break;
	}
	public IEnumerator MMToggle() {
		if (_minimapStatus == 2) {
			_CMMToggle = false;
			_minimapStatus = 0;
			UpdateHUD();
			yield break;
		}
		if (_minimapStatus == 1) {
			_CMMToggle = true;
			_minimapStatus = 2;
			UpdateHUD();
			yield break;
		}
		if (_minimapStatus == 0) {
			_CMMToggle = true;
			_minimapStatus = 1;
			UpdateHUD();
			yield break;
		}
	}
	public IEnumerator COToggle() {
		_COToggle =! _COToggle;
		UpdateHUD();
		yield break;
	}
	public IEnumerator FLToggle() {
		_FLToggle =! _FLToggle;
		//Setting light equal to toggle
		if (_FLToggle == true) {
			_flashlight.enabled = true;
			yield break;
		}
		if (_FLToggle == false) {
			_flashlight.enabled = false;
			yield break;
		}
	}
	public void UpdateHUD() {
		if (_isLoading == false && _isComplete == false && _isDead == false) {
			//Setting canvases equal to toggles
			if (_COToggle == true) {
				_canvasObjectives.enabled = true;
			}
			if (_CMMToggle == true) {
				_canvasMiniMap.enabled = true;
				_canvasMiniMapObjects.SetActive(true);
					}
			if (_COToggle == false) {
				_canvasObjectives.enabled = false;
			}
			if (_CMMToggle == false) {
				_canvasMiniMap.enabled = false;
				_canvasMiniMapObjects.SetActive(false);
			}
			if (_minimapStatus == 0) {
				_mmZoomCam.enabled = false;
				_mmFullCam.enabled = false;
			}
			if (_minimapStatus == 1) {
				_mmZoomCam.enabled = true;
				_mmFullCam.enabled = false;
			}
			if (_minimapStatus == 2) {
				_mmZoomCam.enabled = false;
				_mmFullCam.enabled = true;
			}
		}
		//Toggles the audio elements when menus are open or closed
		if (_isPaused == false && _isLoading == false && _isComplete == false && _isDead == false) {
			_timer += Time.deltaTime;
			if (_timer >= 1.0f) {
				_ui1.SetActive(false);
				_ui2.SetActive(false);
				_ui3.SetActive(false);
			}
		}
		if (_isPaused == true || _isComplete == true || _isLoading == true || _isComplete == true || _isDead == true) {
			_ui1.SetActive(true);
			_ui2.SetActive(true);
			_ui3.SetActive(true);
			_timer = 0;
		}
	}
	public void Complete() {
		_completebool = true;
		//The complete function: changes time, disables/enables canvases,
		//changes lockstate/visibility of cursor, and enables/disables FPC on
		//Player controller
		_isPaused = false;
		Time.timeScale = 0.0f;
		_pause.enabled = false;
		_HUD.SetActive(false);
		_completion.enabled = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		_fpc.enabled = false;
	}
	public void Loading() {
		//The loading function for the menu: changes time to be 1 so that the animation plays
		//This is for if isLoading is called on by the pause menu
		if (_isPaused == true) {
			Time.timeScale = 1.0f;
			_pause.enabled = true;
			_HUD.SetActive(false);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			_fpc.enabled = false;
			_fpcanim.Stop();
		}
		//This is for if isLoading is called on by the completion menu
		if (_isComplete == true) {
			Time.timeScale = 1.0f;
			_completion.enabled = true;
			_HUD.SetActive(false);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			_fpc.enabled = false;
			_fpcanim.Stop();
		}
		//This is for if isLoading is called on by the death menu
		if (_isDead == true) {
			Time.timeScale = 1.0f;
			_death.enabled = true;
			_HUD.SetActive(false);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			_fpc.enabled = false;
			_fpcanim.Stop();
		}
	}
	//This is called on by the Menu button on the Pause screen and the Completion screen
	public void SendMessageToLM() {
		_lm._levelSelected = 99;
		//This script calls "load" instead of "OnLevelSelected" because the
		//menu does not have an _obj1/2/3 like every other scene
		//Thus, it skips the OnLevelSelected step of determining _obj scenery
		//And goes right to the scene loading process
		_lm.StartCoroutine("load");
		_isLoading = true;
		Loading();
		if (GameObject.Find("GunManager").GetComponent<GunManager>()._GunSelection == 0) {
			GameObject.Find("GunManager").GetComponent<GunManager>()._animStop = true;
			_pistolanim.CrossFade("PUnequip");
		}
		if (GameObject.Find("GunManager").GetComponent<GunManager>()._GunSelection == 1) {
			GameObject.Find("GunManager").GetComponent<GunManager>()._animStop = true;
			_rifleanim.CrossFade("RUnequip");
		}
	}
	//This is called upon by PlayerStats when the current health is 0
	public void OnDeath() {
		_isDead = true;
		Time.timeScale = 0.2f;
		_isPaused = false;
		_isComplete = false;
		_pause.enabled = false;
		_HUD.SetActive(false);
		_completion.enabled = false;
		_death.enabled = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		_fpc.enabled = false;
		if (_lm._currentscene == 5 || _lm._currentscene == 8) {
			if (_HPM._isInside == true) {
				_HPM.StartCoroutine("ToggleBuggy");
			}
		}
  }
  //This is to update the objective display
  public void UpdateDisplay() {
		//Update the objectives HUD
			_entText.text = _entities.ToString("F0");
			_repText.text = _repair.ToString("F0");
	}
}
