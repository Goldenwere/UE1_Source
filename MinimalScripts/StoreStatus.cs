using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreStatus : MonoBehaviour {

	public int _statusId;		//Set in inspector 1-11
	public Text _text;		//Is found
	public StoreManager _sm;	//Grab _level(x)

	void Start() {
		_text = this.gameObject.GetComponent<Text>();
		_sm = GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>();
	}
	void Update() {
		if (_statusId == 1) {
			if (_sm._levelAP == 1) {
				_text.text = "100";
			}
			if (_sm._levelAP == 2) {
				_text.text = "250";
			}
			if (_sm._levelAP == 3) {
				_text.text = "500";
			}
			if (_sm._levelAP == 4) {
				_text.text = "1000";
			}
			if (_sm._levelAP == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 2) {
			if (_sm._levelAR == 1) {
				_text.text = "100";
			}
			if (_sm._levelAR == 2) {
				_text.text = "250";
			}
			if (_sm._levelAR == 3) {
				_text.text = "500";
			}
			if (_sm._levelAR == 4) {
				_text.text = "1000";
			}
			if (_sm._levelAR == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 3) {
			if (_sm._levelDP == 1) {
				_text.text = "100";
			}
			if (_sm._levelDP == 2) {
				_text.text = "250";
			}
			if (_sm._levelDP == 3) {
				_text.text = "500";
			}
			if (_sm._levelDP == 4) {
				_text.text = "1000";
			}
			if (_sm._levelDP == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 4) {
			if (_sm._levelDR == 1) {
				_text.text = "100";
			}
			if (_sm._levelDR == 2) {
				_text.text = "250";
			}
			if (_sm._levelDR == 3) {
				_text.text = "500";
			}
			if (_sm._levelDR == 4) {
				_text.text = "1000";
			}
			if (_sm._levelDR == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 5) {
			if (_sm._levelMHe == 1) {
				_text.text = "200";
			}
			if (_sm._levelMHe == 2) {
				_text.text = "500";
			}
			if (_sm._levelMHe == 3) {
				_text.text = "800";
			}
			if (_sm._levelMHe == 4) {
				_text.text = "1250";
			}
			if (_sm._levelMHe == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 6) {
			if (_sm._levelMSh == 1) {
				_text.text = "200";
			}
			if (_sm._levelMSh == 2) {
				_text.text = "500";
			}
			if (_sm._levelMSh == 3) {
				_text.text = "800";
			}
			if (_sm._levelMSh == 4) {
				_text.text = "1250";
			}
			if (_sm._levelMSh == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 7) {
			if (_sm._levelMSt == 1) {
				_text.text = "200";
			}
			if (_sm._levelMSt == 2) {
				_text.text = "500";
			}
			if (_sm._levelMSt == 3) {
				_text.text = "800";
			}
			if (_sm._levelMSt == 4) {
				_text.text = "1250";
			}
			if (_sm._levelMSt == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 8) {
			if (_sm._levelDHe == 1) {
				_text.text = "300";
			}
			if (_sm._levelDHe == 2) {
				_text.text = "600";
			}
			if (_sm._levelDHe == 3) {
				_text.text = "900";
			}
			if (_sm._levelDHe == 4) {
				_text.text = "1200";
			}
			if (_sm._levelDHe == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 9) {
			if (_sm._levelDSh == 1) {
				_text.text = "300";
			}
			if (_sm._levelDSh == 2) {
				_text.text = "600";
			}
			if (_sm._levelDSh == 3) {
				_text.text = "900";
			}
			if (_sm._levelDSh == 4) {
				_text.text = "1200";
			}
			if (_sm._levelDSh == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 10) {
			if (_sm._levelDSt == 1) {
				_text.text = "300";
			}
			if (_sm._levelDSt == 2) {
				_text.text = "600";
			}
			if (_sm._levelDSt == 3) {
				_text.text = "900";
			}
			if (_sm._levelDSt == 4) {
				_text.text = "1200";
			}
			if (_sm._levelDSt == 5) {
				_text.text = "Max";
			}
		}
		if (_statusId == 11) {
			_text.text = _sm._Exp.ToString("F0");
		}
	}
}
