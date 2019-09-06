using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour {

	public int _levelSelected;
		//Note: 96 = Outro, 97 = Intro, 98 = Credits, 99 = Menu, 1-32 = all the other (9 = Player
		//Ship Exterior, 31 = Entity Ship, See BaseNotes.txt for other levels)
		//-1 = Quit, 0 = Start
	public int _basePart;
		//LevelManager calls on _basePart
	public int _currentscene;
    public AsyncOperation _asyncop;
    public bool _isLoadingScene;
    public bool _isStandardScene;
	public string _loadedScene;
	public int _randomNo;
	public Text _tips;
		//to generate a random number to select tips

	void Awake() {
		DontDestroyOnLoad(this.transform);
	}

	public void OnLevelSelected() {
		//Determines which part of the base to load
		if (_levelSelected == 1 || _levelSelected == 2 || _levelSelected == 3 ||
		_levelSelected == 5 || _levelSelected == 6 || _levelSelected == 10 ||
		_levelSelected == 16 || _levelSelected == 17 || _levelSelected == 21 ||
		_levelSelected == 22 || _levelSelected == 9 || _levelSelected == 31) {
			_basePart = 1;
		}
		if (_levelSelected == 4 || _levelSelected == 7 || _levelSelected == 8 ||
		_levelSelected == 11 || _levelSelected == 14 || _levelSelected == 19 ||
		_levelSelected == 20 || _levelSelected == 24 || _levelSelected == 27 ||
		_levelSelected == 28 || _levelSelected == 97) {
			_basePart = 2;
		}
		if (_levelSelected == 12 || _levelSelected == 13 || _levelSelected == 15 ||
		_levelSelected == 18 || _levelSelected == 23 || _levelSelected == 25 ||
		_levelSelected == 26 || _levelSelected == 29 || _levelSelected == 30 ||
		_levelSelected == 32 || _levelSelected == 98) {
			_basePart = 3;
		}
        //Tells the string for the Load Screen tips
        _randomNo = Random.Range(1, 380);
		_tips = GameObject.Find("Tip").GetComponent<Text>();
		if (_randomNo > 0 && _randomNo <= 20) {
			_tips.text = "Not all features are final or implemented"; }
		if (_randomNo > 20 && _randomNo <= 40) {
			_tips.text = "Complete the objectives according to your HUD"; }
		if (_randomNo > 40 && _randomNo <= 60) {
			_tips.text = "You can replay levels to get more experience"; }
		if (_randomNo > 60 && _randomNo <= 80) {
			_tips.text = "Your health replenishes very slowly over time"; }
		if (_randomNo > 80 && _randomNo <= 100) {
			_tips.text = "Your stamina recharges over time - Be careful, it runs out quickly"; }
		if (_randomNo > 100 && _randomNo <= 120) {
			_tips.text = "Your shield regenerates very quickly, but takes a long time to start regenerating"; }
		if (_randomNo > 120 && _randomNo <= 140) {
			_tips.text = "This is the area to get some tips on playing the game"; }
		if (_randomNo > 140 && _randomNo <= 160) {
			_tips.text = "Try turning up the difficulty to get more experience"; }
		if (_randomNo > 160 && _randomNo <= 180) {
			_tips.text = "Try turning down the difficulty if you keep dying or cannot kill all the entities"; }
		if (_randomNo > 180 && _randomNo <= 200) {
			_tips.text = "Use the store if you do not have enough stats or they take too long for you to survive"; }
		if (_randomNo > 200 && _randomNo <= 220) {
			_tips.text = "Use the store if your weapons seem too weak for later or harder levels"; }
		if (_randomNo > 220 && _randomNo <= 240) {
			_tips.text = "Your stamina (current upgrade) takes " + GameObject.FindWithTag("StoreManagerTag").GetComponent<StoreManager>()._UpgDelayStamina + " seconds to start recharging"; }
		if (_randomNo > 240 && _randomNo <= 260) {
			_tips.text = "Your health (current upgrade) takes " + GameObject.FindWithTag("StoreManagerTag").GetComponent<StoreManager>()._UpgDelayHealth + " seconds to start recharging"; }
		if (_randomNo > 260 && _randomNo <= 280) {
			_tips.text = "Your shield (current upgrade) takes " + GameObject.FindWithTag("StoreManagerTag").GetComponent<StoreManager>()._UpgDelayShield + " seconds to start recharging"; }
		if (_randomNo > 280 && _randomNo <= 300) {
			_tips.text = "The entities are a very simple enemy - Do not let that fool you"; }
		if (_randomNo > 300 && _randomNo <= 320) {
			_tips.text = "Be prepared to run"; }
		if (_randomNo > 320 && _randomNo <= 340) {
			_tips.text = "Entities tend to start in clusters. Try taking them out from further away"; }
		if (_randomNo > 340 && _randomNo <= 360) {
			_tips.text = "Avoid taking on groups of entities, especially non-turret entities. They can easily overwhelm you"; }
		if (_randomNo > 360 && _randomNo <= 380) {
			_tips.text = "Entities do not seek cover - you shouldn't either"; }
        StartCoroutine("load");
        _isLoadingScene = true;
	}
	void Update() {
		_currentscene = SceneManager.GetActiveScene().buildIndex;
	}
	public IEnumerator load() {
		//Determines which base scene to load
		if (_levelSelected == 1 || _levelSelected == 4 || _levelSelected == 12) {
			_asyncop = SceneManager.LoadSceneAsync("Base1");
			_asyncop.allowSceneActivation = false;
			_loadedScene = "Base1";
			_isStandardScene = true;
		}
		if (_levelSelected == 2 || _levelSelected == 7 || _levelSelected == 13) {
			_asyncop = SceneManager.LoadSceneAsync("Base2");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "Base2";
			_isStandardScene = true;
		}
		if (_levelSelected == 3 || _levelSelected == 8 || _levelSelected == 15) {
			_asyncop = SceneManager.LoadSceneAsync("Base3");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "Base3";
			_isStandardScene = true;
		}
		if (_levelSelected == 5 || _levelSelected == 11 || _levelSelected == 18) {
			_asyncop = SceneManager.LoadSceneAsync("Base4");
			_asyncop.allowSceneActivation = false;
			_loadedScene = "Base4";
			_isStandardScene = true;
		}
		if (_levelSelected == 6 || _levelSelected == 14 || _levelSelected == 23) {
			_asyncop = SceneManager.LoadSceneAsync("Base5");
			_asyncop.allowSceneActivation = false;
			_loadedScene = "Base5";
            _isStandardScene = true;
		}
		if (_levelSelected == 10 || _levelSelected == 19 || _levelSelected == 25) {
			_asyncop = SceneManager.LoadSceneAsync("Base6");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "Base6";
            _isStandardScene = true;
		}
		if (_levelSelected == 16 || _levelSelected == 20 || _levelSelected == 26) {
			_asyncop = SceneManager.LoadSceneAsync("Base7");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "Base7";
			_isStandardScene = true;
		}
		if (_levelSelected == 17 || _levelSelected == 24 || _levelSelected == 29) {
			_asyncop = SceneManager.LoadSceneAsync("Base8");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "Base8";
			_isStandardScene = true;
		}
		if (_levelSelected == 22 || _levelSelected == 27 || _levelSelected == 30) {
			_asyncop = SceneManager.LoadSceneAsync("Base9");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "Base9";
			_isStandardScene = true;
		}
		if (_levelSelected == 21 || _levelSelected == 28 || _levelSelected == 32) {
			_asyncop = SceneManager.LoadSceneAsync("RC");
			_asyncop.allowSceneActivation = false;
        	_loadedScene = "RC";
			_isStandardScene = false;
		}
		if (_levelSelected == 9) {
			_asyncop = SceneManager.LoadSceneAsync("PSE");
			_asyncop.allowSceneActivation = false;
        	_loadedScene = "PSE";
			_isStandardScene = false;
		}
		if (_levelSelected == 31) {
			_asyncop = SceneManager.LoadSceneAsync("ES");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "ES";
			_isStandardScene = false;
		}
		if (_levelSelected == 99) {
			Debug.Log("Going to menu...");
			_asyncop = SceneManager.LoadSceneAsync("Menu");
			_asyncop.allowSceneActivation = true;
            _loadedScene = "Menu";
			_isStandardScene = false;
		}
		if (_levelSelected == 97 || _levelSelected == 98) {
			_asyncop = SceneManager.LoadSceneAsync("IntroAndCredits");
			_asyncop.allowSceneActivation = false;
            _loadedScene = "IntroAndCredits";
			_isStandardScene = false;
		}
		if (_levelSelected == -1) {
			Application.Quit();
			Debug.Log("Quitting...");
			yield break;
        }
		yield return StartCoroutine("wait");
		yield return _asyncop;
	}
	IEnumerator wait() {
		while(_asyncop.progress < 0.9f) {
			Debug.Log(_asyncop.progress);
			_asyncop.allowSceneActivation = false;
			yield return new WaitForSeconds(0.1f);
		}
		if (_asyncop.progress >= 0.9f) {
			_asyncop.allowSceneActivation = false;
			yield return new WaitForSeconds(3.0f);
            _asyncop.allowSceneActivation = true;
			_isLoadingScene = false;
		}
	}
}
