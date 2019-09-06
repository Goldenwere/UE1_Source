using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	//This int is changed in Inspector view on each menu button to determine what level
	//to load
	public int _thisLevel;
    //This is to grab the _levelSelected and set it equal to the _level in this script
    public LoadManager _lm;
    //To grab unlocked levels
    public StoreManager _sm;
    //This button in the scene
    public Button _thisButton;
	//Stage of game design
	public int _devStage;

	void Start() {
        _lm = GameObject.FindWithTag("LoadManagerTag").GetComponent<LoadManager>();
        _sm = GameObject.FindWithTag("StoreManagerTag").GetComponent <StoreManager>();
		_thisButton = this.GetComponent<Button>();
        //Change this when more levels are added
        _devStage = 20;
		if (_thisLevel <= 32) {
			if (_thisLevel <= _sm._unlockedLevel && _thisLevel <= _devStage) {
				_thisButton.interactable = true;
			}
			if (_thisLevel > _sm._unlockedLevel || _thisLevel > _devStage) {
				_thisButton.interactable = false;
			}
		}
	}

	public void LevelSelected() {
		_lm._levelSelected = _thisLevel;
		_lm.OnLevelSelected();
	}
}
