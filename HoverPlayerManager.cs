using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class HoverPlayerManager : MonoBehaviour {

    public float _BuggyHealth;
	public float _BuggyMaxHealth;						//These are 5x the player's health/shield current upgrade
	public float _BuggyShield;
    public float _BuggyMaxShield;
    public LevelManager _levelMgr;						//To call death
	public FirstPersonController _FPController;			//Player things to enable/disable - these are for disabling controls
    public CharacterController _CharController;			//...
	public GameObject _playerObj;						//... and this to simply disable all scripts/cameras/etc.
    public StoreManager _StoreMgr;						//To set the max stats
    public SettingsManager _SettingsMgr;				//To enable/disable PostProcessing
    public GameObject _BuggyCam;						//This is the buggy's camera object
    public GameObject _BuggyActive;						//This is the object enabled when the player is inside - gives controls, etc.
	public GameObject _BuggyInactive;                   //This is the object enabled when the player is not inside
    public bool _isInside;								//Self-explanatory
    public float _actualDistance;						//Determine distance from player
    public float _minDistance;							//5 meters
    public GameObject _enterCanvas;						//Like the "InteractableObject" script's pop-up
	public Text _textHealth;							//Set the HUD equal to these
    public Text _textShield;							//^
    public Text _textHealthExterior;                    //An exterior text to deter player from entering if the buggy is low on health
    public Text _objEnt;								//For the objectives HUD element
	public Text _objRep;								//^
	public GameObject _playerSpawnPoint;                //Moves player to top of buggy on exit
    public int _lightsStatus;							//Determines light stage (off, partial on, full on)
    public GameObject _StartupLights;					//Red exterior / blue interior lighting
    public GameObject _RoofLight;						//partial on stage
	public GameObject _FrontLights;						//full on stage
	public Canvas _HUD;                                 //The full HUD
    public AudioSource _audio;
    public GameObject _stage1dmg;                       //These are objects that display the damage of the buggy ...
    public GameObject _stage2dmg;                       //...
    public GameObject _stage3dmg;                       //...
    public GameObject _stage4dmg;                       //... ^
    public GameObject _damageStages;                    //This is the parent of the damage states

	void Start () {
        _playerObj = GameObject.Find("FPSController");
        _FPController = _playerObj.GetComponent<FirstPersonController>();
        _CharController = _playerObj.GetComponent<CharacterController>();
        _levelMgr = GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>();
		_StoreMgr = GameObject.FindWithTag("StoreManagerTag").GetComponent<StoreManager>();
		_SettingsMgr = GameObject.FindWithTag("SettingManagerTag").GetComponent<SettingsManager>();
		_isInside = false;
        _BuggyMaxHealth = _StoreMgr._UpgMaxHealth * 5f;
		_BuggyMaxShield = _StoreMgr._UpgMaxShield * 5f;
        _BuggyHealth = _BuggyMaxHealth;
        _BuggyShield = _BuggyMaxShield;
        _BuggyCam.GetComponent<PostProcessingBehaviour>().enabled = _SettingsMgr._pp;
        _minDistance = 5f;
        _lightsStatus = 3;
        _stage1dmg.SetActive(false);
        _stage2dmg.SetActive(false);
        _stage3dmg.SetActive(false);
        _stage4dmg.SetActive(false);
        _damageStages.transform.SetParent(_BuggyInactive.transform);
        StartCoroutine("SceneStart");
    }

	void Update () {
		_textHealth.text = _BuggyHealth.ToString("F0");
		_textHealthExterior.text = _BuggyHealth.ToString("F0");
        _textShield.text = _BuggyShield.ToString("F0");
        _objEnt.text = _levelMgr._entities.ToString("F0");
		_objRep.text = _levelMgr._repair.ToString("F0");
		//Don't constantly update this when "inside"
		if (_isInside == false) {
			_actualDistance = Vector3.Distance(_playerObj.transform.position, _enterCanvas.transform.position);
		}
		//Toggle the text when in range
		if (_actualDistance < _minDistance && _isInside == false) {
			_enterCanvas.SetActive(true);
		}
		if (_actualDistance > _minDistance && _isInside == false || _isInside == true) {
			_enterCanvas.SetActive(false);
        }
        //Make the text a face-me
        _enterCanvas.transform.LookAt(_playerObj.transform);
		//Two situations - player is inside - don't need to look for distance; player is outside - need distance
		if (Input.GetButtonDown("Interact") && _isInside == true || Input.GetButtonDown("Interact") && _actualDistance < _minDistance && _isInside == false) {
			StartCoroutine("ToggleBuggy");
		}
		//Call death when dead
		if (_BuggyHealth <= 0.0f && _isInside == true)
		{
			_FPController.enabled = false;
			_CharController.enabled = false;
			_levelMgr.OnDeath();
        }
		if (Input.GetButtonDown("Flashlight")) {
			StartCoroutine("Lights");
		}
	}

	public IEnumerator ToggleBuggy () {
		if (_isInside == false) {
            _StartupLights.SetActive(true);
			_RoofLight.SetActive(true);
			_FrontLights.SetActive(true);
			_FPController.enabled = false;
			_CharController.enabled = false;
            _playerObj.SetActive(false);
			_BuggyInactive.SetActive(false);
			_BuggyActive.SetActive(true);
			_BuggyCam.SetActive(true);
            _HUD.enabled = true;
            _audio.enabled = true;
			_audio.Play();
            _isInside = true;
            _damageStages.transform.SetParent(_BuggyActive.transform);
			yield break;
        }
		if (_isInside == true) {
			_BuggyInactive.transform.position = _BuggyActive.transform.position;
			_BuggyInactive.transform.rotation = _BuggyActive.transform.rotation;
			_StartupLights.SetActive(false);
            _FPController.enabled = true;
            _CharController.enabled = true;
			_playerObj.SetActive(true);
			_playerObj.transform.position = _playerSpawnPoint.transform.position;
			_BuggyInactive.SetActive(true);
			_BuggyActive.SetActive(false);
			_BuggyCam.SetActive(false);
			_HUD.enabled = false;
            _audio.enabled = false;
            _isInside = false;
            _damageStages.transform.SetParent(_BuggyInactive.transform);
			yield break;
		}
	}

	public IEnumerator TakeDamage(float _entdmg)
	{
		//If the shield is gone, take health damage
		if (_BuggyShield <= 0.0f)
		{
			_BuggyHealth -= _entdmg;
		}
		//If the shield is present but isn't high enough, exhaust the shield
		if (_BuggyShield > 0.0f && _BuggyShield <= _entdmg)
		{
			_BuggyShield = 0.0f;
		}
		//If the shield is present and high enough, take shield damage
		if (_BuggyShield > 0.0f && _BuggyShield > _entdmg)
		{
			_BuggyShield -= _entdmg;
        }

        ////Manage the destruction stage////

        //100-75% is healthy
        if (_BuggyHealth / _BuggyMaxHealth >= 0.75f) {
            //Do nothing
        }
        //50%-74% is stage 1
        if (_BuggyHealth / _BuggyMaxHealth < 0.75f && _BuggyHealth / _BuggyMaxHealth >= 0.50f && _stage1dmg.activeInHierarchy == false) {
            _stage1dmg.SetActive(true);
        }
        //25%-49% is stage 2
        if (_BuggyHealth / _BuggyMaxHealth < 0.50f && _BuggyHealth / _BuggyMaxHealth >= 0.25f && _stage2dmg.activeInHierarchy == false) {
            _stage2dmg.SetActive(true);
        }
        //1%-24% is stage 3
        if (_BuggyHealth / _BuggyMaxHealth < 0.25f && _BuggyHealth / _BuggyMaxHealth > 0.00f && _stage3dmg.activeInHierarchy == false) {
            _stage3dmg.SetActive(true);
        }
        //1%-24% is stage 4
        if (_BuggyHealth / _BuggyMaxHealth <= 0.00f && _stage4dmg.activeInHierarchy == false) {
            _stage4dmg.SetActive(true);
        }

		yield break;
    }

	public IEnumerator Lights() {
		if (_lightsStatus == 1) {
            _RoofLight.SetActive(false);
            _FrontLights.SetActive(false);
			_lightsStatus = 2;
			yield break;
        }
		if (_lightsStatus == 2) {
			_RoofLight.SetActive(true);
            _FrontLights.SetActive(false);
			_lightsStatus = 3;
			yield break;
		}
		if (_lightsStatus == 3) {
			_RoofLight.SetActive(true);
			_FrontLights.SetActive(true);
			_lightsStatus = 1;
			yield break;
		}
    }
    public IEnumerator SceneStart() {
        yield return new WaitForFixedUpdate();
        _BuggyCam.SetActive(false);
        _StartupLights.SetActive(false);
        _RoofLight.SetActive(false);
        _FrontLights.SetActive(false);
        _HUD.enabled = false;
        _audio.enabled = false;
        _BuggyActive.SetActive(false);
        _BuggyInactive.SetActive(true);
        yield break;
    }

}
