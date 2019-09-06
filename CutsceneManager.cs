using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour {

  public Vector3 _playerSpawn;
	//This grabs what level is being loaded
	public LoadManager _lm;
  //This grabs if it is the start of the level or the end (with public bool _isComplete)
  public LevelManager _lem;
  //This grabs the unlocked level int
  public StoreManager _sm;
	//This saves the game
	public SaveManager _save;
	//Cutscene cams - each scene has up to two cameras
	public GameObject _cam1;
	public GameObject _cam2;
	//Async op
	public AsyncOperation _asyncop;
    //Tells LevelManager that a cutscene is playing
    public bool _isCutscene;
    //The text/transition script
    public CutsceneTransition _ct;
    //Stuff set at the beginning of each level
    GameObject _player;
    Image _crosshair;
    AudioListener _AudioListener;
    Camera _p1;
    Camera _p2;
    Camera _p3;
    CharacterController _pCC;
    FirstPersonController _pFPC;
    GunManager _gm;
    GameObject _playerObject;
    Vector3 _0;

	void Start () {
		_sm = GameObject.FindWithTag("StoreManagerTag").GetComponent<StoreManager>();
		_save = GameObject.FindWithTag("SaveManagerTag").GetComponent<SaveManager>();
		_cam1 = GameObject.Find("CutsceneCam1");
		_cam2 = GameObject.Find("CutsceneCam2");
        _lm = GameObject.FindWithTag("LoadManagerTag").GetComponent<LoadManager>();
        _ct = GameObject.Find("CUTSCENETRANSITIONS").GetComponent<CutsceneTransition>();
		if (_lm._levelSelected == 97) {
			StartCoroutine("IntroCutscene");
		}
		if (_lm._levelSelected == 1) {
			StartCoroutine("Intro1");
        }
		if (_lm._levelSelected == 2) {
			StartCoroutine("Intro2");
        }
		if (_lm._levelSelected == 3) {
			StartCoroutine("Intro3");
    }
    if (_lm._levelSelected == 4) {
        StartCoroutine("Intro4");
    }
    if (_lm._levelSelected == 5) {
        StartCoroutine("Intro5");
    }
    if (_lm._levelSelected == 6) {
        StartCoroutine("Intro6");
    }
    if (_lm._levelSelected == 7) {
        StartCoroutine("Intro7");
    }
    if (_lm._levelSelected == 8) {
        StartCoroutine("Intro8");
    }
    if (_lm._levelSelected == 9) {
        StartCoroutine("Intro9");
    }
    if (_lm._levelSelected == 10) {
        StartCoroutine("Intro10");
    }
    if (_lm._levelSelected == 11) {
        StartCoroutine("Intro11");
    }
    if (_lm._levelSelected == 12) {
        StartCoroutine("Intro12");
    }
    if (_lm._levelSelected == 13) {
        StartCoroutine("Intro13");
    }
    if (_lm._levelSelected == 14) {
        StartCoroutine("Intro14");
    }
    if (_lm._levelSelected == 15) {
        StartCoroutine("Intro15");
    }
    if (_lm._levelSelected == 16) {
        StartCoroutine("Intro16");
    }
    if (_lm._levelSelected == 17) {
        StartCoroutine("Intro17");
    }
    if (_lm._levelSelected == 18) {
        StartCoroutine("Intro18");
    }
    if (_lm._levelSelected == 19) {
        StartCoroutine("Intro19");
    }
    if (_lm._levelSelected == 20) {
        StartCoroutine("Intro20");
    }
    if (_lm._levelSelected == 21) {
        StartCoroutine("Intro21");
    }
    if (_lm._levelSelected == 22) {
        StartCoroutine("Intro22");
    }
    if (_lm._levelSelected == 23) {
        StartCoroutine("Intro23");
    }
    if (_lm._levelSelected == 24) {
        StartCoroutine("Intro24");
    }
    if (_lm._levelSelected == 25) {
        StartCoroutine("Intro25");
    }
    if (_lm._levelSelected == 26) {
        StartCoroutine("Intro26");
    }
    if (_lm._levelSelected == 27) {
        StartCoroutine("Intro27");
    }
    if (_lm._levelSelected == 28) {
        StartCoroutine("Intro28");
    }
    if (_lm._levelSelected == 29) {
        StartCoroutine("Intro29");
    }
    if (_lm._levelSelected == 30) {
        StartCoroutine("Intro30");
    }
    if (_lm._levelSelected == 31) {
        StartCoroutine("Intro31");
    }
	}
	IEnumerator IntroCutscene () {
  		//Start of cutscene for intro
  		_cam1.SetActive(true);
  		_cam2.SetActive(false);
  		_cam1.GetComponent<Animation>().CrossFade("Intro-Cam-Beginning");
  		GameObject.Find("IntroCanvas").GetComponent<Animation>().CrossFade("Intro-Canvas-Beginning");
  		yield return new WaitForSeconds(74);
      _asyncop = SceneManager.LoadSceneAsync("Menu");
  		_lm._levelSelected = 99;
  		_asyncop.allowSceneActivation = true;
	}
	IEnumerator Intro1 () {
  		StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro1");
      yield return new WaitForSeconds(39.1f);
  		StartCoroutine("IntroStuffEnd");
  		yield break;
	}
	IEnumerator Outro1 () {
  		StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro1");
      yield return new WaitForSeconds(3);
  		StartCoroutine("OutroStuffEnd");
  		yield break;
    }
	IEnumerator Intro2 () {
  		StartCoroutine("IntroStuffStart");
  		_cam1.GetComponent<Animation>().CrossFade("Intro2");
  		yield return new WaitForSeconds(15.2f);
  		StartCoroutine("IntroStuffEnd");
  		yield break;
	}
	IEnumerator Outro2 () {
      StartCoroutine("OutroStuffStart");
  		_cam2.GetComponent<Animation>().CrossFade("Outro2");
  		yield return new WaitForSeconds(13);
  		StartCoroutine("OutroStuffEnd");
  		yield break;
  }
	IEnumerator Intro3 () {
  		StartCoroutine("IntroStuffStart");
  		_cam1.GetComponent<Animation>().CrossFade("Intro3");
  		yield return new WaitForSeconds(13.2f);
  		StartCoroutine("IntroStuffEnd");
  		yield break;
	}
	IEnumerator Outro3 () {
  		StartCoroutine("OutroStuffStart");
  		_cam2.GetComponent<Animation>().CrossFade("Outro3");
  		yield return new WaitForSeconds(5);
  		StartCoroutine("OutroStuffEnd");
  		yield break;
	}
  IEnumerator Intro4 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro4");
      yield return new WaitForSeconds(7.1f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro4 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro4");
      yield return new WaitForSeconds(3);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro5 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro5");
      yield return new WaitForSeconds(9.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro5 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro5");
      yield return new WaitForSeconds(2);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro6 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro6");
      yield return new WaitForSeconds(2.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro6 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro6");
      yield return new WaitForSeconds(0.1f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro7 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro7");
      yield return new WaitForSeconds(15.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro7 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro7");
      yield return new WaitForSeconds(2);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro8 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro8");
      yield return new WaitForSeconds(9.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro8 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro8");
      yield return new WaitForSeconds(4);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro9 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("IntroPSE");
      yield return new WaitForSeconds(12.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro9 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("OutroPSE");
      yield return new WaitForSeconds(20);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro10 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro10");
      yield return new WaitForSeconds(7.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro10 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro10");
      yield return new WaitForSeconds(7);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro11 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro11");
      yield return new WaitForSeconds(3.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro11 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro11");
      yield return new WaitForSeconds(2);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro12 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro12");
      yield return new WaitForSeconds(4.1f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro12 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro12");
      yield return new WaitForSeconds(19);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro13 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro13");
      yield return new WaitForSeconds(15.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro13 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro13");
      yield return new WaitForSeconds(6);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro14 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro14");
      yield return new WaitForSeconds(2.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro14 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro14");
      yield return new WaitForSeconds(0.1f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro15 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro15");
      yield return new WaitForSeconds(9.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro15 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro15");
      yield return new WaitForSeconds(32);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro16 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro16");
      yield return new WaitForSeconds(11.1f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro16 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro16");
      yield return new WaitForSeconds(2.2f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro17 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro17");
      yield return new WaitForSeconds(8.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro17 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro17");
      yield return new WaitForSeconds(1.2f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro18 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro18");
      yield return new WaitForSeconds(3.0f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro18 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro18");
      yield return new WaitForSeconds(2.0f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro19 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro19");
      yield return new WaitForSeconds(7.0f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro19 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro19");
      yield return new WaitForSeconds(2.0f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }
  IEnumerator Intro20 () {
      StartCoroutine("IntroStuffStart");
      _cam1.GetComponent<Animation>().CrossFade("Intro20");
      yield return new WaitForSeconds(6.2f);
      StartCoroutine("IntroStuffEnd");
      yield break;
  }
  IEnumerator Outro20 () {
      StartCoroutine("OutroStuffStart");
      _cam2.GetComponent<Animation>().CrossFade("Outro20");
      yield return new WaitForSeconds(3.1f);
      StartCoroutine("OutroStuffEnd");
      yield break;
  }

  IEnumerator IntroStuffStart() {
      //Start of cutscene for level one
      //Need to get these variables
      GameObject.Find("Quad1").SetActive(false);
  		_player = GameObject.FindWithTag("Player");
  		_crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
  		_AudioListener = _player.GetComponentInChildren<AudioListener>();
  		_p1 = GameObject.Find("ObjectRenderer").GetComponent<Camera>();
  		_p2 = GameObject.Find("GunRenderer").GetComponent<Camera>();
  		_p3 = GameObject.Find("HUDRenderer").GetComponent<Camera>();
  		_pCC = _player.GetComponent<CharacterController>();
  		_pFPC = _player.GetComponent<FirstPersonController>();
  		_gm = GameObject.Find("GunManager").GetComponent<GunManager>();
  		_playerObject = GameObject.FindWithTag("Player");
  		_playerSpawn = GameObject.FindWithTag("Player").transform.position;
  		_0 = new Vector3 (0,0,0);
      _ct.TransitionIntroBeginning();
  	   //Disables a bunch of stuff to prevent camera conflicts and such
      yield return new WaitForFixedUpdate();
  		_isCutscene = true;
  		_pCC.enabled = false;
  		_pFPC.enabled = false;
  		_p1.enabled = false;
  		_p2.enabled = false;
  		_p3.enabled = false;
  		_crosshair.enabled = false;
  		_AudioListener.enabled = false;
  		_gm.enabled = false;
  		_cam1.SetActive(true);
      _cam2.SetActive(false);
  		_playerObject.transform.position = _0;
  		yield break;
  }
  IEnumerator IntroStuffEnd() {
      _ct.TransitionIntroEnding();
      yield return new WaitForSeconds(3.0f);
  		//Need to get these variables
  		//GameObject.Find("Quad1").SetActive(false);
  		_isCutscene = false;
  		_pCC.enabled = true;
  		_pFPC.enabled = true;
  		_p1.enabled = true;
  		_p2.enabled = true;
  		_p3.enabled = true;
  		_crosshair.enabled = true;
  		_AudioListener.enabled = true;
  		_gm.enabled = true;
  		_playerObject.transform.position = _playerSpawn;
      //GameObject.Find("Quad1").SetActive(false);
  		yield break;
  }
  IEnumerator OutroStuffStart() {
  	_isCutscene = true;
  	_player.SetActive(false);
  	_cam1.SetActive(false);
    _cam2.SetActive(true);
    GameObject.Find("Quad2").SetActive(false);
  	if (_lm._levelSelected == _sm._unlockedLevel) {
  		_sm._unlockedLevel += 1;
  	}
    _save.Save();
    _ct.TransitionOutroBeginning();
  	yield break;
  }
  IEnumerator OutroStuffEnd() {
    _ct.TransitionOutroEnding();
    yield return new WaitForSeconds(3.0f);
    _isCutscene = false;
  	_player.SetActive(true);
  	_cam2.SetActive(false);
    _lem._isComplete = true;
  	yield break;
  }

	////Called on by LevelManager////

	public void StartEndCutscene() {
		if (_lm._levelSelected == 1) {
			StartCoroutine("Outro1");
        }
        if (_lm._levelSelected == 2) {
            StartCoroutine("Outro2");
        }
        if (_lm._levelSelected == 3) {
            StartCoroutine("Outro3");
        }
        if (_lm._levelSelected == 4) {
            StartCoroutine("Outro4");
        }
        if (_lm._levelSelected == 5) {
            StartCoroutine("Outro5");
        }
        if (_lm._levelSelected == 6) {
            StartCoroutine("Outro6");
        }
        if (_lm._levelSelected == 7) {
            StartCoroutine("Outro7");
        }
        if (_lm._levelSelected == 8) {
            StartCoroutine("Outro8");
        }
        if (_lm._levelSelected == 9) {
            StartCoroutine("Outro9");
        }
        if (_lm._levelSelected == 10) {
            StartCoroutine("Outro10");
        }
        if (_lm._levelSelected == 11) {
            StartCoroutine("Outro11");
        }
        if (_lm._levelSelected == 12) {
            StartCoroutine("Outro12");
        }
        if (_lm._levelSelected == 13) {
            StartCoroutine("Outro13");
        }
        if (_lm._levelSelected == 14) {
            StartCoroutine("Outro14");
        }
        if (_lm._levelSelected == 15) {
            StartCoroutine("Outro15");
        }
        if (_lm._levelSelected == 16) {
            StartCoroutine("Outro16");
        }
        if (_lm._levelSelected == 17) {
            StartCoroutine("Outro17");
        }
        if (_lm._levelSelected == 18) {
            StartCoroutine("Outro18");
        }
        if (_lm._levelSelected == 19) {
            StartCoroutine("Outro19");
        }
        if (_lm._levelSelected == 20) {
            StartCoroutine("Outro20");
        }
        if (_lm._levelSelected == 21) {
            StartCoroutine("Outro21");
        }
        if (_lm._levelSelected == 22) {
            StartCoroutine("Outro22");
        }
        if (_lm._levelSelected == 23) {
            StartCoroutine("Outro23");
        }
        if (_lm._levelSelected == 24) {
            StartCoroutine("Outro24");
        }
        if (_lm._levelSelected == 24) {
            StartCoroutine("Outro24");
        }
        if (_lm._levelSelected == 25) {
            StartCoroutine("Outro25");
        }
        if (_lm._levelSelected == 26) {
            StartCoroutine("Outro26");
        }
        if (_lm._levelSelected == 27) {
            StartCoroutine("Outro27");
        }
        if (_lm._levelSelected == 28) {
            StartCoroutine("Outro28");
        }
        if (_lm._levelSelected == 29) {
            StartCoroutine("Outro29");
        }
        if (_lm._levelSelected == 30) {
            StartCoroutine("Outro30");
        }
        if (_lm._levelSelected == 31) {
            StartCoroutine("Outro31");
        }
	}
}
