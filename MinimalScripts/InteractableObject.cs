using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

	//1 - Repair Quest; 2 - pistol ammo; 3 - rifle ammo; 4 - medkit;
	//5 - shield battery; 6 - stamina shot
	public int _object;
	public GameObject _text;
	//For distance between object and player
	public GameObject _player;
	public float _minDist;
	public float _actualDist;

	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
		_minDist = 5.0f;
	}
	void Update () {
		//Update the distance between the player and the object
		_actualDist = Vector3.Distance(_player.transform.position, gameObject.transform.position);
		//Toggle the text when in range
		if (_actualDist < _minDist) {
			_text.SetActive(true);
		}
		if (_actualDist > _minDist) {
			_text.SetActive(false);
		}
		//Make the text a face-me
		_text.transform.LookAt(_player.transform);

		////Determine what the object does when the player interacts with it, depending on what the object is

		//Complete a repair objective
		if (_object == 1) {
			if (Input.GetButtonDown("Interact") && _actualDist < _minDist) {
				if (GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>()._repair > 0) {
                    GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>()._repair -= 1;
					GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>().UpdateDisplay();
				}
        		GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>()._Exp += 5;
				GameObject.Find("UI4").GetComponent<AudioSource>().Play();
				Destroy(gameObject);
			}
		}
		//Player recovery objects (ammo/stats) set the _(current value) to the _(max value)
		if (_object == 2) {
			if (Input.GetButtonDown("Interact") && _actualDist < _minDist) {
				_player.GetComponentInChildren<GunManager>()._pistolAmmo = _player.GetComponent<PlayerStats>()._PPistolAmmo;
				GameObject.Find("AmmoPickup").GetComponent<AudioSource>().Play();
			}
		}
		if (_object == 3) {
			if (Input.GetButtonDown("Interact") && _actualDist < _minDist) {
				_player.GetComponentInChildren<GunManager>()._rifleAmmo = _player.GetComponent<PlayerStats>()._PRifleAmmo;
				GameObject.Find("AmmoPickup").GetComponent<AudioSource>().Play();
			}
		}
		if (_object == 4) {
			if (Input.GetButtonDown("Interact") && _actualDist < _minDist) {
				_player.GetComponent<PlayerStats>()._PHealth = _player.GetComponent<PlayerStats>()._PMaxHealth;
				GameObject.Find("HealthPickup").GetComponent<AudioSource>().Play();
			}
		}
		if (_object == 5) {
			if (Input.GetButtonDown("Interact") && _actualDist < _minDist) {
				_player.GetComponent<PlayerStats>()._PShield = _player.GetComponent<PlayerStats>()._PMaxShield;
				GameObject.Find("ShieldPickup").GetComponent<AudioSource>().Play();
			}
		}
		if (_object == 6) {
			if (Input.GetButtonDown("Interact") && _actualDist < _minDist) {
				_player.GetComponent<PlayerStats>()._PStamina = _player.GetComponent<PlayerStats>()._PMaxStamina;
				GameObject.Find("HealthPickup").GetComponent<AudioSource>().Play();
			}
		}
	}
}
