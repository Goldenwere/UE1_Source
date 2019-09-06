using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour {


	public int _buttonId;		//Id is 1-10, assigned in inspector
	public StoreManager _sm;	//Call functions here

	void Start() {
        //Get the StoreManager
        _sm = GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>();
		//Lock the buttons if save data had max
		if (_buttonId == 1 && _sm._levelAP == 5 || _buttonId == 2 && _sm._levelAR == 5 ||
		_buttonId == 3 && _sm._levelDP == 5 || _buttonId == 4 && _sm._levelDR == 5 ||
		_buttonId == 5 && _sm._levelMHe == 5 || _buttonId == 6 && _sm._levelMSh == 5 ||
		_buttonId == 7 && _sm._levelMSt == 5 || _buttonId == 8 && _sm._levelDHe == 5 ||
		_buttonId == 9 && _sm._levelDSh == 5 || _buttonId == 10 && _sm._levelDSt == 5) {
			this.gameObject.GetComponent<Button>().interactable = false;
		}
	}

	public void OnUIClick() {
		//If the _level(x) is 4 or less, upgrade it
		if (_buttonId == 1 && _sm._levelAP <= 4) {
			_sm.UpdateAmmoPistol();
		}
		if (_buttonId == 2 && _sm._levelAR <= 4) {
			_sm.UpdateAmmoRifle();
		}
		if (_buttonId == 3 && _sm._levelDP <= 4) {
			_sm.UpdateDamagePistol();
		}
		if (_buttonId == 4 && _sm._levelDR <= 4) {
			_sm.UpdateDamageRifle();
		}
		if (_buttonId == 5 && _sm._levelMHe <= 4) {
			_sm.UpdateMaxHealth();
		}
		if (_buttonId == 6 && _sm._levelMSh <= 4) {
			_sm.UpdateMaxShield();
		}
		if (_buttonId == 7 && _sm._levelMSt <= 4) {
			_sm.UpdateMaxStamina();
		}
		if (_buttonId == 8 && _sm._levelDHe <= 4) {
			_sm.UpdateDelayHealth();
		}
		if (_buttonId == 9 && _sm._levelDSh <= 4) {
			_sm.UpdateDelayShield();
		}
		if (_buttonId == 10 && _sm._levelDSt <= 4) {
			_sm.UpdateDelayStamina();
		}
		this.CheckForMax();
	}

	public void CheckForMax () {
		if (_buttonId == 1 && _sm._levelAP == 5 || _buttonId == 2 && _sm._levelAR == 5 ||
		_buttonId == 3 && _sm._levelDP == 5 || _buttonId == 4 && _sm._levelDR == 5 ||
		_buttonId == 5 && _sm._levelMHe == 5 || _buttonId == 6 && _sm._levelMSh == 5 ||
		_buttonId == 7 && _sm._levelMSt == 5 || _buttonId == 8 && _sm._levelDHe == 5 ||
		_buttonId == 9 && _sm._levelDSh == 5 || _buttonId == 10 && _sm._levelDSt == 5) {
			this.gameObject.GetComponent<Button>().interactable = false;
		}
	}
}
