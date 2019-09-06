using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CinematicEffects;
using UnityEngine.PostProcessing;

public class PlayerStats : MonoBehaviour {

	//Variables for the player
	//These are for the controller
	public FirstPersonController _FirstPersonController;
	public CharacterController _CharacterController;
	//This is to grab level difficulty and set things managed by it accordingly
	public LevelManager _LevelManager;
	public bool _calledDeath;
	public float _RechargeRate;
	//These are the basic ongoing (during level) stats of the player
	public float _PHealth;
	public float _PStamina;
	public float _PShield;
	public float _PCurrentHeDelay;
	public float _PCurrentStDelay;
	public float _PCurrentShDelay;
	//Player exhausted - sprint delay
	public bool _isWaiting;
	//These maxes are grabbed from the store manager
		public float _PMaxHealth;
		public float _PMaxStamina;
		public float _PMaxShield;
		public float _PPistolDamage;
		public float _PRifleDamage;
		public int _PPistolAmmo;
		public int _PRifleAmmo;
		public float _PHealthDelay;
		public float _PStaminaDelay;
		public float _PShieldDelay;
		public StoreManager _StoreManager;
	//This determines what levels are unlocked to the player (SAVED)
	public int _unlockLevel;
	//These are for the HUD stats
	public Text _HealthText;
	public Text _StaminaText;
    public Text _ShieldText;
    //These are for status notifications
    public Image _ElecOn;
    public Image _ElecOff;
    public Image _StamOn;
    public Image _StamOff;
    public Image _FireOn;
    public Image _FireOff;
	//These are for GFX settings
	public GameObject _objRen;
	public GameObject _gunRen;
    public GameObject _hudRen;
	public SettingsManager _SettingsManager;

	// Use this for initialization

	void Awake () {
		//Some things that are called upon in the script
		_FirstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    	_CharacterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
		_LevelManager = GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>();
    	_StoreManager = GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>();
		_SettingsManager = GameObject.FindGameObjectWithTag("SettingManagerTag").GetComponent<SettingsManager>();
		//Grab stuff from StoreManager
		_PPistolDamage = _StoreManager._UpgDamagePistol;
		_PRifleDamage = _StoreManager._UpgDamageRifle;
		_PPistolAmmo = _StoreManager._UpgAmmoPistol;
		_PRifleAmmo = _StoreManager._UpgAmmoRifle;
		_PMaxHealth = _StoreManager._UpgMaxHealth;
		_PHealth = _PMaxHealth;
		_PMaxShield = _StoreManager._UpgMaxShield;
		_PShield = _PMaxShield;
		_PMaxStamina = _StoreManager._UpgMaxStamina;
		_PStamina = _PMaxStamina;
		_PHealthDelay = _StoreManager._UpgDelayHealth;
		_PShieldDelay = _StoreManager._UpgDelayShield;
		_PStaminaDelay = _StoreManager._UpgDelayStamina;
		_calledDeath = false;
	}

	void Start ()
  {
		//Determine RechargeRate (is essentially the reverse of the entity _multiplier)
		if (_LevelManager._difficultyScore <= 3) {
			_RechargeRate = 1.5f;
		}
		if (_LevelManager._difficultyScore > 3 && _LevelManager._difficultyScore <= 6) {
			_RechargeRate = 1.2f;
		}
		if (_LevelManager._difficultyScore > 6 && _LevelManager._difficultyScore <= 10) {
			_RechargeRate = 1.0f;
		}
		if (_LevelManager._difficultyScore > 10 && _LevelManager._difficultyScore <= 14) {
			_RechargeRate = 0.8f;
		}
		if (_LevelManager._difficultyScore == 15) {
			_RechargeRate = 0.6f;
		}
		_objRen.GetComponent<SunShafts>().enabled = _SettingsManager._gr;
		_objRen.GetComponent<DepthOfField>().enabled = _SettingsManager._dof;
		_objRen.GetComponent<AmbientOcclusion>().enabled = _SettingsManager._ao;
		_gunRen.GetComponent<PostProcessingBehaviour>().enabled = _SettingsManager._pp;
        _hudRen.GetComponent<PostProcessingBehaviour>().enabled = _SettingsManager._pp;
		_ElecOn.enabled = false;
        _ElecOff.enabled = true;
		_FireOn.enabled = false;
        _FireOff.enabled = true;
		_StamOn.enabled = false;
		_StamOff.enabled = true;
	}

	// Update is called once per frame
	void Update ()
	{
		////Constantly updated variables////

		//These convert the stats to strings
		_HealthText.text = _PHealth.ToString("F0");
		_StaminaText.text = _PStamina.ToString("F0");
		_ShieldText.text = _PShield.ToString("F0");
		//These are represented by time
		_PCurrentStDelay += Time.deltaTime;
		_PCurrentHeDelay += Time.deltaTime;
		_PCurrentShDelay += Time.deltaTime;

		////Death/////

		//Activate death (handled by LevelManager) when health is 0
		if (_PHealth <= 0.0f)
		{
			_FirstPersonController.enabled = false;
			_CharacterController.enabled = false;
			if (_calledDeath == false) {
				_LevelManager.OnDeath();
				_calledDeath = true;
			}
		}

		////This is to handle recharging of different stats////
		//Starts recharging if the current timer for the delays of the stats
		//is greater than the current delay upgrade, and if the stat is
		//below the maximum stat

		//This is for the player's health
		if (_PHealth < _PMaxHealth && _PCurrentHeDelay >= _PHealthDelay)
		{
			_PHealth += Time.deltaTime * 1.0f * _RechargeRate;
		}
		//This is for the player's shield
		if (_PShield < _PMaxShield && _PCurrentShDelay >= _PShieldDelay)
		{
			_PShield += Time.deltaTime * 5.0f * _RechargeRate;
		}
		//This is for the player's stamina
		if (_PStamina < _PMaxStamina && _PCurrentStDelay >= _PStaminaDelay)
		{
			_PStamina += Time.deltaTime * 4.0f * _RechargeRate;
		}

		////This is to handle stamina decharging/exhaustion////

		//This is for if the player exhausts their stamina
		if (_PStamina <= 0.0f)
		{
			StartCoroutine("WaitForStamina");
		}
		//Reactivate the player's ability to run when exhaustion is gone
		if (_PStamina >= 0.0f && _isWaiting == false)
		{
			_FirstPersonController._canRun = true;
		}
		//Exhaust player stamina over time when sprinting
		if (Input.GetButton("Sprint") && _FirstPersonController._canRun == true && Input.GetAxisRaw("Vertical") != 0 && !Input.GetButton("Fire2"))
		{
			_PCurrentStDelay = 0.0f;
			_PStamina -= Time.deltaTime * 25.0f;
		}


	}
	//Player is exhausted (may have future UI element showing this)
	IEnumerator WaitForStamina()
    {
		_StamOn.enabled = true;
		_StamOff.enabled = false;
		_PStamina = 0.00001f;
		_isWaiting = true;
		_FirstPersonController._canRun = false;
		yield return new WaitForSeconds(5 + _PStaminaDelay);
        _isWaiting = false;
		_StamOn.enabled = false;
        _StamOff.enabled = true;
		yield break;
	}
	public IEnumerator TakeDamage(float _entdmg)
	{
		//If the shield is gone, take health damage
		if (_PShield <= 0.0f)
		{
			_PCurrentHeDelay = 0.0f;
			_PHealth -= _entdmg;
		}
		//If the shield is present but isn't high enough, exhaust the shield
		if (_PShield > 0.0f && _PShield <= _entdmg)
		{
			_PCurrentShDelay = 0.0f;
			_PShield = 0.0f;
		}
		//If the shield is present and high enough, take shield damage
		if (_PShield > 0.0f && _PShield > _entdmg)
		{
			_PCurrentShDelay = 0.0f;
			_PShield -= _entdmg;
		}
		yield break;
	}
	public void ElecDamageStatusOn() {
		_ElecOn.enabled = true;
        _ElecOff.enabled = false;
		this.ElecDamageStatusOff() ;
	}
	public void ElecDamageStatusOff() {
		_ElecOn.enabled = false;
		_ElecOff.enabled = true;
	}
	public void FireDamageStatusOn() {
        _FireOn.enabled = true;
		_FireOff.enabled = false;
		this.FireDamageStatusOff();
	}
	public void FireDamageStatusOff() {
		_FireOn.enabled = false;
		_FireOff.enabled = true;
    }
}
