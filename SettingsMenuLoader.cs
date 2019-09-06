using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuLoader : MonoBehaviour {

	//This int is controlled in Inspector view
	public int setting;
	//This is to grab the SettingsManager
	public SettingsManager _sm;
    //This is the object the script is applied to
    public GameObject settingobj;

	void Start () {
		settingobj = this.gameObject;
		_sm = GameObject.FindWithTag("SettingManagerTag").GetComponent<SettingsManager>();
		//The value of "setting" determines what the script does by identifying
		//the setting. The object's UI value/toggle is set equal to the
		//setting on SettingsManager on Start
		_sm.UIResetter();
    }


	public void OnUIChange () {
		//The objects UI value/toggle when changed changes what SettingsManager
		//has saved. The UI change sends a message to this void to do this
		_sm = GameObject.FindWithTag("SettingManagerTag").GetComponent<SettingsManager>();
		if (setting == 1) {
			_sm._pp = settingobj.GetComponent<Toggle>().isOn;
		}
		if (setting == 2) {
			_sm._gr = settingobj.GetComponent<Toggle>().isOn;
		}
		if (setting == 3) {
			_sm._dof = settingobj.GetComponent<Toggle>().isOn;
		}
		if (setting == 4) {
			_sm._ao = settingobj.GetComponent<Toggle>().isOn;
		}
		if (setting == 5) {
            _sm._Music = settingobj.GetComponent<Slider>().value;
			_sm.SetAudioFloats(setting);
        }
		if (setting == 6) {
            _sm._Enviro = settingobj.GetComponent<Slider>().value;
			_sm.SetAudioFloats(setting);
		}
		if (setting == 7) {
            _sm._Effects = settingobj.GetComponent<Slider>().value;
			_sm.SetAudioFloats(setting);
		}
        if (setting == 8) {
			_sm._camsnap = settingobj.GetComponent<Slider>().value;
		}
		if (setting == 9) {
			_sm._playerDiff = settingobj.GetComponent<Slider>().value;
        }
		if (setting == 14) {
            GameObject.FindWithTag("SaveManagerTag").GetComponent<SaveManager>().Delete();
			_sm.UIResetter();
		}
		if (setting == 15) {
			GameObject.FindWithTag("SaveManagerTag").GetComponent<SaveManager>().Save();
		}
		//These are for the preset buttons, which don't require loading from
		//SettingsManager and don't affect SettingsManager
		if (setting == 10) {
			QualitySettings.SetQualityLevel(0);
		}
		if (setting == 11) {
			QualitySettings.SetQualityLevel(1);
		}
		if (setting == 12) {
			QualitySettings.SetQualityLevel(2);
		}
		if (setting == 13) {
			QualitySettings.SetQualityLevel(3);
		}
    }
	public void OnUIReset() {
	        if (setting == 1) {
	            settingobj.GetComponent<Toggle>().isOn = _sm._pp;
			}
			if (setting == 2) {
	            settingobj.GetComponent<Toggle>().isOn = _sm._gr;
			}
			if (setting == 3) {
	            settingobj.GetComponent<Toggle>().isOn = _sm._dof;
			}
			if (setting == 4) {
	            settingobj.GetComponent<Toggle>().isOn = _sm._ao;
			}
			if (setting == 5) {
	            settingobj.GetComponent<Slider>().value = _sm._Music;
			}
			if (setting == 6) {
	            settingobj.GetComponent<Slider>().value = _sm._Enviro;
			}
			if (setting == 7) {
	            settingobj.GetComponent<Slider>().value = _sm._Effects;
			}
			if (setting == 8) {
	            settingobj.GetComponent<Slider>().value = _sm._camsnap;
			}
			if (setting == 9) {
	            settingobj.GetComponent<Slider>().value = _sm._playerDiff;
	        }
	}
}
