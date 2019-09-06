using System.Collections;
using UnityEngine;

public class StoreManager : MonoBehaviour {

	//The upgrades are all saved on PlayerStats - GunManager grabs gun stuff from PlayerStats

	////Upgrade values////

	//Gun upgrades
	public int _UpgAmmoPistol;
	public int _UpgAmmoRifle;
	public float _UpgDamagePistol;
	public float _UpgDamageRifle;
	//Stat upgrades
	public float _UpgMaxHealth;
	public float _UpgMaxShield;
	public float _UpgMaxStamina;
	public float _UpgDelayHealth;
	public float _UpgDelayShield;
	public float _UpgDelayStamina;
    //Exp
    public float _Exp;
    public int _unlockedLevel;

	////Upgrade levels////

	//Guns
	public int _levelAP;		//AmmoPistol
	public int _levelAR;		//AmmoRifle
	public int _levelDP;		//DamagePistol
	public int _levelDR;		//DamageRifle
	//Stats
	public int _levelMHe;		//MaxHealth
	public int _levelMSh;		//MaxShield
	public int _levelMSt;		//MaxStamina
	public int _levelDHe;		//DelayHealth
	public int _levelDSh;		//DelayShield
	public int _levelDSt;		//DelayStamina

	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

	public void SaveManagerLoadMsg () {
		StartCoroutine("GetAmmoPistol");
		StartCoroutine("GetAmmoRifle");
		StartCoroutine("GetDamagePistol");
		StartCoroutine("GetDamageRifle");
		StartCoroutine("GetMaxHealth");
		StartCoroutine("GetMaxShield");
		StartCoroutine("GetMaxStamina");
		StartCoroutine("GetDelayHealth");
		StartCoroutine("GetDelayShield");
		StartCoroutine("GetDelayStamina");
	}

	public void UpdateAmmoPistol() {
		if (_levelAP == 1 && _Exp < 100 || _levelAP == 2 && _Exp < 250 ||
		_levelAP == 3 && _Exp < 500 || _levelAP == 4 && _Exp < 1000) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelAP == 1 && _Exp >= 100 || _levelAP == 2 && _Exp >= 250 ||
		_levelAP == 3 && _Exp >= 500 || _levelAP == 4 && _Exp >= 1000) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelAP == 4 && _Exp >= 1000) {
			_UpgAmmoPistol = 32;
			_Exp -= 1000;
			_levelAP = 5;
		}
		if (_levelAP == 3 && _Exp >= 500) {
			_UpgAmmoPistol = 24;
			_Exp -= 500;
			_levelAP = 4;
		}
		if (_levelAP == 2 && _Exp >= 250) {
			_UpgAmmoPistol = 20;
			_Exp -= 250;
			_levelAP = 3;
		}
		if (_levelAP == 1 && _Exp >= 100) {
			_UpgAmmoPistol = 16;
			_Exp -= 100;
			_levelAP = 2;
		}
	}
	public void UpdateAmmoRifle() {
		if (_levelAR == 1 && _Exp < 100 || _levelAR == 2 && _Exp < 250 ||
		_levelAR == 3 && _Exp < 500 || _levelAR == 4 && _Exp < 1000) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelAR == 1 && _Exp >= 100 || _levelAR == 2 && _Exp >= 250 ||
		_levelAR == 3 && _Exp >= 500 || _levelAR == 4 && _Exp >= 1000) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelAR == 4 && _Exp >= 1000) {
			_UpgAmmoRifle = 96;
			_Exp -= 1000;
			_levelAR = 5;
		}
		if (_levelAR == 3 && _Exp >= 500) {
			_UpgAmmoRifle = 72;
			_Exp -= 500;
			_levelAR = 4;
		}
		if (_levelAR == 2 && _Exp >= 250) {
			_UpgAmmoRifle = 60;
			_Exp -= 250;
			_levelAR = 3;
		}
		if (_levelAR == 1 && _Exp >= 100) {
			_UpgAmmoRifle = 48;
			_Exp -= 100;
			_levelAR = 2;
		}
	}
	public void UpdateDamagePistol() {
		if (_levelDP == 1 && _Exp < 100 || _levelDP == 2 && _Exp < 250 ||
		_levelDP == 3 && _Exp < 500 || _levelDP == 4 && _Exp < 1000) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelDP == 1 && _Exp >= 100 || _levelDP == 2 && _Exp >= 250 ||
		_levelDP == 3 && _Exp >= 500 || _levelDP == 4 && _Exp >= 1000) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelDP == 4 && _Exp >= 1000) {
			_UpgDamagePistol = 35;
			_Exp -= 1000;
			_levelDP = 5;
		}
		if (_levelDP == 3 && _Exp >= 500) {
			_UpgDamagePistol = 25;
			_Exp -= 500;
			_levelDP = 4;
		}
		if (_levelDP == 2 && _Exp >= 250) {
			_UpgDamagePistol = 18;
			_Exp -= 250;
			_levelDP = 3;
		}
		if (_levelDP == 1 && _Exp >= 100) {
			_UpgDamagePistol = 15;
			_Exp -= 100;
			_levelDP = 2;
		}
	}
	public void UpdateDamageRifle() {
		if (_levelDR == 1 && _Exp < 100 || _levelDR == 2 && _Exp < 250 ||
		_levelDR == 3 && _Exp < 500 || _levelDR == 4 && _Exp < 1000) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelDR == 1 && _Exp >= 100 || _levelDR == 2 && _Exp >= 250 ||
		_levelDR == 3 && _Exp >= 500 || _levelDR == 4 && _Exp >= 1000) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelDR == 4 && _Exp >= 1000) {
			_UpgDamageRifle = 15;
			_Exp -= 1000;
			_levelDR = 5;
		}
		if (_levelDR == 3 && _Exp >= 500) {
			_UpgDamageRifle = 10;
			_Exp -= 500;
			_levelDR = 4;
		}
		if (_levelDR == 2 && _Exp >= 250) {
			_UpgDamageRifle = 8;
			_Exp -= 250;
			_levelDR = 3;
		}
		if (_levelDR == 1 && _Exp >= 100) {
			_UpgDamageRifle = 6;
			_Exp -= 100;
			_levelDR = 2;
		}
	}
	public void UpdateMaxHealth() {
		if (_levelMHe == 1 && _Exp < 200 || _levelMHe == 2 && _Exp < 500 ||
		_levelMHe == 3 && _Exp < 800 || _levelDR == 4 && _Exp < 1250) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelMHe == 1 && _Exp >= 200 || _levelMHe == 2 && _Exp >= 500 ||
		_levelMHe == 3 && _Exp >= 800 || _levelMHe == 4 && _Exp >= 1250) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelMHe == 4 && _Exp >= 1250) {
			_UpgMaxHealth = 250;
			_Exp -= 1250;
			_levelMHe = 5;
		}
		if (_levelMHe == 3 && _Exp >= 800) {
			_UpgMaxHealth = 200;
			_Exp -= 800;
			_levelMHe = 4;
		}
		if (_levelMHe == 2 && _Exp >= 500) {
			_UpgMaxHealth = 150;
			_Exp -= 500;
			_levelMHe = 3;
		}
		if (_levelMHe == 1 && _Exp >= 200) {
			_UpgMaxHealth = 125;
			_Exp -= 200;
			_levelMHe = 2;
		}
	}
	public void UpdateMaxShield() {
		if (_levelMSh == 1 && _Exp < 200 || _levelMSh == 2 && _Exp < 500 ||
		_levelMSh == 3 && _Exp < 800 || _levelMSh == 4 && _Exp < 1250) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelMSh == 1 && _Exp >= 200 || _levelMSh == 2 && _Exp >= 500 ||
		_levelMSh == 3 && _Exp >= 800 || _levelMSh == 4 && _Exp >= 1250) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelMSh == 4 && _Exp >= 1250) {
			_UpgMaxShield = 200;
			_Exp -= 1250;
			_levelMSh = 5;
		}
		if (_levelMSh == 3 && _Exp >= 800) {
			_UpgMaxShield = 150;
			_Exp -= 800;
			_levelMSh = 4;
		}
		if (_levelMSh == 2 && _Exp >= 500) {
			_UpgMaxShield = 100;
			_Exp -= 500;
			_levelMSh = 3;
		}
		if (_levelMSh == 1 && _Exp >= 200) {
			_UpgMaxShield = 50;
			_Exp -= 200;
			_levelMSh = 2;
		}
	}
	public void UpdateMaxStamina() {
		if (_levelMSt == 1 && _Exp < 200 || _levelMSt == 2 && _Exp < 500 ||
		_levelMSt == 3 && _Exp < 800 || _levelMSt == 4 && _Exp < 1250) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelMSt == 1 && _Exp >= 200 || _levelMSt == 2 && _Exp >= 500 ||
		_levelMSt == 3 && _Exp >= 800 || _levelMSt == 4 && _Exp >= 1250) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelMSt == 4 && _Exp >= 1250) {
			_UpgMaxStamina = 250;
			_Exp -= 1250;
			_levelMSt = 5;
		}
		if (_levelMSt == 3 && _Exp >= 800) {
			_UpgMaxStamina = 200;
			_Exp -= 800;
			_levelMSt = 4;
		}
		if (_levelMSt == 2 && _Exp >= 500) {
			_UpgMaxStamina = 150;
			_Exp -= 500;
			_levelMSt = 3;
		}
		if (_levelMSt == 1 && _Exp >= 200) {
			_UpgMaxStamina = 100;
			_Exp -= 200;
			_levelMSt = 2;
		}
	}
	public void UpdateDelayHealth() {
		if (_levelDHe == 1 && _Exp < 300 || _levelDHe == 2 && _Exp < 600 ||
		_levelDHe == 3 && _Exp < 900 || _levelDHe == 4 && _Exp < 1200) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelDHe == 1 && _Exp >= 300 || _levelDHe == 2 && _Exp >= 600 ||
		_levelDHe == 3 && _Exp >= 900 || _levelDHe == 4 && _Exp >= 1200) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelDHe == 4 && _Exp >= 1200) {
			_UpgDelayHealth = 4;
			_Exp -= 1200;
			_levelDHe = 5;
		}
		if (_levelDHe == 3 && _Exp >= 900) {
			_UpgDelayHealth = 5;
			_Exp -= 900;
			_levelDHe = 4;
		}
		if (_levelDHe == 2 && _Exp >= 600) {
			_UpgDelayHealth = 9;
			_Exp -= 600;
			_levelDHe = 3;
		}
		if (_levelDHe == 1 && _Exp >= 300) {
			_UpgDelayHealth = 10;
			_Exp -= 300;
			_levelDHe = 2;
		}
	}
	public void UpdateDelayShield() {
		if (_levelDSh == 1 && _Exp < 300 || _levelDSh == 2 && _Exp < 600 ||
		_levelDSh == 3 && _Exp < 900 || _levelDSh == 4 && _Exp < 1200) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelDSh == 1 && _Exp >= 300 || _levelDSh == 2 && _Exp >= 600 ||
		_levelDSh == 3 && _Exp >= 900 || _levelDSh == 4 && _Exp >= 1200) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelDSh == 4 && _Exp >= 1200) {
			_UpgDelayShield = 2;
			_Exp -= 1200;
			_levelDSh = 5;
		}
		if (_levelDSh == 3 && _Exp >= 900) {
			_UpgDelayShield = 3;
			_Exp -= 900;
			_levelDSh = 4;
		}
		if (_levelDSh == 2 && _Exp >= 600) {
			_UpgDelayShield = 4;
			_Exp -= 600;
			_levelDSh = 3;
		}
		if (_levelDSh == 1 && _Exp >= 300) {
			_UpgDelayShield = 5;
			_Exp -= 300;
			_levelDSh = 2;
		}
	}
	public void UpdateDelayStamina() {
		if (_levelDSt == 1 && _Exp < 300 || _levelDSt == 2 && _Exp < 600 ||
		_levelDSt == 3 && _Exp < 900 || _levelDSt == 4 && _Exp < 1200) {
			AudioSource _ui3 = GameObject.Find("UI3").GetComponent<AudioSource>();
			_ui3.Play();
		}
		if (_levelDSt == 1 && _Exp >= 300 || _levelDSt == 2 && _Exp >= 600 ||
		_levelDSt == 3 && _Exp >= 900 || _levelDSt == 4 && _Exp >= 1200) {
			AudioSource _ui2 = GameObject.Find("UI2").GetComponent<AudioSource>();
			_ui2.Play();
		}
		if (_levelDSt == 4 && _Exp >= 1200) {
			_UpgDelayHealth = 3;
			_Exp -= 1200;
			_levelDSt = 5;
		}
		if (_levelDSt == 3 && _Exp >= 900) {
			_UpgDelayHealth = 4;
			_Exp -= 900;
			_levelDSt = 4;
		}
		if (_levelDSt == 2 && _Exp >= 600) {
			_UpgDelayHealth = 8;
			_Exp -= 600;
			_levelDSt = 3;
		}
		if (_levelDSt == 1 && _Exp >= 300) {
			_UpgDelayHealth = 10;
			_Exp -= 300;
			_levelDSt = 2;
		}
	}

	IEnumerator GetAmmoPistol() {
		if (_levelAP == 1) {
			_UpgAmmoPistol = 8;
		}
		if (_levelAP == 2) {
			_UpgAmmoPistol = 16;
		}
		if (_levelAP == 3) {
			_UpgAmmoPistol = 20;
		}
		if (_levelAP == 4) {
			_UpgAmmoPistol = 24;
		}
		if (_levelAP == 5) {
			_UpgAmmoPistol = 32;
		}
		yield break;
	}
	IEnumerator GetAmmoRifle() {
		if (_levelAR == 1) {
			_UpgAmmoRifle = 24;
		}
		if (_levelAR == 2) {
			_UpgAmmoRifle = 48;
		}
		if (_levelAR == 3) {
			_UpgAmmoRifle = 60;
		}
		if (_levelAR == 4) {
			_UpgAmmoRifle = 72;
		}
		if (_levelAR == 5) {
			_UpgAmmoRifle = 96;
		}
		yield break;
	}
	IEnumerator GetDamagePistol() {
		if (_levelDP == 1) {
			_UpgDamagePistol = 10;
		}
		if (_levelDP == 2) {
			_UpgDamagePistol = 15;
		}
		if (_levelDP == 3) {
			_UpgDamagePistol = 18;
		}
		if (_levelDP == 4) {
			_UpgDamagePistol = 25;
		}
		if (_levelDP == 5) {
			_UpgDamagePistol = 35;
		}
		yield break;
	}
	IEnumerator GetDamageRifle() {
		if (_levelDR == 1) {
			_UpgDamageRifle = 5;
		}
		if (_levelDR == 2) {
			_UpgDamageRifle = 6;
		}
		if (_levelDR == 3) {
			_UpgDamageRifle = 8;
		}
		if (_levelDR == 4) {
			_UpgDamageRifle = 10;
		}
		if (_levelDR == 5) {
			_UpgDamageRifle = 15;
		}
		yield break;
	}
	IEnumerator GetMaxHealth() {
		if (_levelMHe == 1) {
			_UpgMaxHealth = 100;
		}
		if (_levelMHe == 2) {
			_UpgMaxHealth = 125;
		}
		if (_levelMHe == 3) {
			_UpgMaxHealth = 150;
		}
		if (_levelMHe == 4) {
			_UpgMaxHealth = 200;
		}
		if (_levelMHe == 5) {
			_UpgMaxHealth = 250;
		}
		yield break;
	}
	IEnumerator GetMaxShield() {
		if (_levelMSh== 1) {
			_UpgMaxShield = 25;
		}
		if (_levelMSh == 2) {
			_UpgMaxShield = 50;
		}
		if (_levelMSh == 3) {
			_UpgMaxShield = 100;
		}
		if (_levelMSh == 4) {
			_UpgMaxShield = 150;
		}
		if (_levelMSh == 5) {
			_UpgMaxShield = 200;
		}
		yield break;
	}
	IEnumerator GetMaxStamina() {
		if (_levelMSt == 1) {
			_UpgMaxStamina = 80;
		}
		if (_levelMSt == 2) {
			_UpgMaxStamina = 100;
		}
		if (_levelMSt == 3) {
			_UpgMaxStamina = 150;
		}
		if (_levelMSt == 4) {
			_UpgMaxStamina = 200;
		}
		if (_levelMSt == 5) {
			_UpgMaxStamina = 250;
		}
		yield break;
	}
	IEnumerator GetDelayHealth() {
		if (_levelDHe == 1) {
			_UpgDelayHealth = 12;
		}
		if (_levelDHe == 2) {
			_UpgDelayHealth = 10;
		}
		if (_levelDHe == 3) {
			_UpgDelayHealth = 9;
		}
		if (_levelDHe == 4) {
			_UpgDelayHealth = 5;
		}
		if (_levelDHe == 5) {
			_UpgDelayHealth = 4;
		}
		yield break;
	}
	IEnumerator GetDelayShield() {
		if (_levelDSh == 1) {
			_UpgDelayShield = 6;
		}
		if (_levelDSh == 2) {
			_UpgDelayShield = 5;
		}
		if (_levelDSh == 3) {
			_UpgDelayShield = 4;
		}
		if (_levelDSh == 4) {
			_UpgDelayShield = 3;
		}
		if (_levelDSh == 5) {
			_UpgDelayShield = 2;
		}
		yield break;
	}
	IEnumerator GetDelayStamina() {
		if (_levelDSt == 1) {
			_UpgDelayStamina = 12;
		}
		if (_levelDSt == 2) {
			_UpgDelayStamina = 10;
		}
		if (_levelDSt == 3) {
			_UpgDelayStamina = 8;
		}
		if (_levelDSt == 4) {
			_UpgDelayStamina = 4;
		}
		if (_levelDSt == 5) {
			_UpgDelayStamina = 3;
		}
		yield break;
	}
}
