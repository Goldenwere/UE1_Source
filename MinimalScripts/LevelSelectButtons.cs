using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour {

    public StoreManager _sm;
    public int _thisLevel;
    public Button _thisButton;
    public int _devStage;

	void Start() {
		//Change this when more levels are added
		_devStage = 1;
		if (_thisLevel <= _sm._unlockedLevel && _thisLevel <= _devStage) {
			_thisButton.interactable = true;
		}
		if (_thisLevel > _sm._unlockedLevel || _thisLevel > _devStage) {
			_thisButton.interactable = false;
		}
	}

}
