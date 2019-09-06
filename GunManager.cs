using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GunManager : MonoBehaviour {

	//Variables needed for the script

		//This handles which gun is in the player's hand
			public int _GunSelection;
		//This handles the animations of the guns & HUD
			public Animation _animPistol;
			public Animation _animRifle;
			public Animation _animHUD;
		//This handles the sounds of the guns
			public AudioSource _sfxPistol;
			public AudioSource _sfxRifle;
			public AudioSource _sfxOut;
		//This is used to delay the firing of the weapons
			public float _delay;
		//This is a prefab for a flash effect
			public GameObject _flash;
			public GameObject _flashClone;
			public GameObject _pistolFlashParent;
			public GameObject _rifleFlashParent;
			public GameObject _hole;
			public GameObject _holeClone;
		//This handles the amount of ammo for the guns
			public int _pistolAmmo;
			public int _rifleAmmo;
			public Text _pistolAmmoText;
			public Text _rifleAmmoText;
		//This handles the gameobjects of the guns
			public GameObject _pistolObj;
			public GameObject _rifleObj;
			public GameObject _fireSource;
		//Accesses the player controller
			public CharacterController _controller;
			public FirstPersonController _player;
			public Camera _playercam;
			public Camera _playercam2;
			public float _camFOVNorm;
			public float _camFOVZoom;
			public float _cam1FOVCurr;
			public float _cam2FOVCurr;
			public PlayerStats _pstats;
			public LevelManager _levelManager;
		//This will pause animations temporarily to allow coroutine animations to play
			public bool _animStop;
		//Prevents fall animations from looping
			public bool _PreventLoop;

	// Use this for initialization
	void Start ()
	{
        _camFOVNorm = 75;
		_camFOVZoom = 40;
		_pistolObj.SetActive(true);
		_rifleObj.SetActive(false);
		_GunSelection = 0;
		_pistolAmmo = _pstats._PPistolAmmo;
		_rifleAmmo = _pstats._PRifleAmmo;
		_levelManager = GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>();
	}

	// Update is called once per frame
	void Update ()
	{
		////Constantly updated variables////

		//Constantly advance _delay
		_delay += Time.deltaTime;
		//Update ammo texts to the ammo amount
		_pistolAmmoText.text = _pistolAmmo.ToString("F0");
		_rifleAmmoText.text = _rifleAmmo.ToString("F0");
		_cam1FOVCurr = _playercam.fieldOfView;
		_cam2FOVCurr = _playercam2.fieldOfView;

		////To handle the animations////

		//To handle switching of the guns
		if (Input.GetButtonUp("SwitchWeapon"))
		{
				if (_GunSelection == 0)
				{
					_GunSelection = 1;
					StartCoroutine("EnableRifle");
				}
				else
				{
					_GunSelection = 0;
					StartCoroutine("EnablePistol");
				}
		}
		//This handles the pistol's animations
		if (_GunSelection == 0 && _animStop == false)
		{
			if (_controller.isGrounded == true)
			{
				if (_controller.velocity.magnitude > 0)
				{
					if (_controller.velocity.magnitude <= 5)
					{
						_animPistol.CrossFade("PWalk");
					}
					if (_controller.velocity.magnitude > 5)
					{
						_animPistol.CrossFade("PRun");
					}
				}
				if (_controller.velocity.magnitude == 0)
				{
					_animPistol.CrossFade("PIdle");
                }
			}
			//This handles the falling animations when the controller is not grounded
			if (_controller.isGrounded == false && _PreventLoop == false) {
                _animPistol.CrossFade("PFall");
			}
		}
		//This handles the rifle's animations
		if (_GunSelection == 1 && _animStop == false)
		{
			if (_controller.isGrounded == true)
			{
				if (_controller.velocity.magnitude > 0)
				{
					if (_controller.velocity.magnitude <= 5)
					{
						_animRifle.CrossFade("RWalk");
					}
					if (_controller.velocity.magnitude > 5)
					{
						_animRifle.CrossFade("RRun");
					}
				}
				if (_controller.velocity.magnitude == 0)
				{
					_animRifle.CrossFade("RIdle");
                }
			}
			//This handles the falling animations when the controller is not grounded
			if (_controller.isGrounded == false && _PreventLoop == false) {
                _animRifle.CrossFade("RFall");
			}
        }

		//This handles zooming
        if (Input.GetButton("Fire2"))
		{
            _player._canRun = false;
			_playercam.fieldOfView = Mathf.Lerp(_cam1FOVCurr, _camFOVZoom, 2 * Time.deltaTime);
			_playercam2.fieldOfView = Mathf.Lerp(_cam2FOVCurr, _camFOVZoom, 2 * Time.deltaTime);
		}
		if (!Input.GetButton("Fire2"))
        {
            if (!Input.GetButton("Sprint"))
			{
				_playercam.fieldOfView = Mathf.Lerp(_cam1FOVCurr, _camFOVNorm, 2 * Time.deltaTime);
        		_playercam2.fieldOfView = Mathf.Lerp(_cam2FOVCurr, _camFOVNorm, 2 * Time.deltaTime);
			}
			if (_pstats._isWaiting == false && _pstats._PStamina >= 0)
			{
            _player._canRun = true;
			}
		}
		//This handles the HUD's animations

			//This is to handle the walking and running animations when the controller
			//is Grounded and the player is moving, or handles idle animation when not moving
			if (_controller.isGrounded == true)
			{
				if (_controller.velocity.magnitude > 0)
				{
					if (_controller.velocity.magnitude <= 5)
					{
						_animHUD.CrossFade("HUDWalk");
					}
					if (_controller.velocity.magnitude > 5)
					{
						_animHUD.CrossFade("HUDRun");
					}
				}
				if (_controller.velocity.magnitude == 0)
				{
					_animHUD.CrossFade("HUDIdle");
				}
				if (_PreventLoop == true) {
					_PreventLoop = false;
				}
			}
			//This handles the falling animations when the controller is not grounded
			if (_controller.isGrounded == false && _PreventLoop == false) {
				_animHUD.CrossFade("HUDFall");
				_PreventLoop = true;
			}

		////To handle firing of the guns//

		//This handles the pistol
		Debug.DrawRay(_fireSource.transform.position, _fireSource.transform.forward * 5000f, Color.cyan, 0, true);
		if (Input.GetButtonDown("Fire1") && _GunSelection == 0 && _pistolAmmo > 0 && _delay > 1.0
		&& _animStop == false && _levelManager._isPaused == false && _levelManager._isComplete == false
		&& _levelManager._isDead == false && _levelManager._isLoading == false)
		{
			_delay = 0;
			_pistolAmmo -= 1;
			_sfxPistol.Play();
			_flashClone = Instantiate(_flash, _pistolFlashParent.transform.position, _pistolFlashParent.transform.rotation);
			RaycastHit hit = new RaycastHit();
			Ray ray = new Ray(_fireSource.transform.position, _fireSource.transform.forward);
			if (Physics.Raycast(ray, out hit, 5000f)) {
				if (hit.collider.gameObject.tag == "ENT")
				{
                    hit.collider.gameObject.SendMessage("DecreaseHealthFromPistol");
				}
				GameObject _holeClone = Instantiate(_hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject;
				_holeClone.transform.parent = hit.transform;
			}
		}
		//This handles the rifle
		if (Input.GetButton("Fire1") && _GunSelection == 1 && _rifleAmmo > 0 && _delay > 0.15 && _animStop == false
		&& _levelManager._isPaused == false && _levelManager._isComplete == false
		&& _levelManager._isDead == false && _levelManager._isLoading == false)
		{
			_delay = 0;
			_rifleAmmo -= 1;
			_sfxRifle.Play();
			_flashClone = Instantiate(_flash, _rifleFlashParent.transform.position, _rifleFlashParent.transform.rotation);
			RaycastHit hit = new RaycastHit();
			Ray ray = new Ray(_fireSource.transform.position, _fireSource.transform.forward);
			if (Physics.Raycast(ray, out hit, 2000f)) {
				if (hit.collider.gameObject.tag == "ENT")
				{
					hit.collider.gameObject.SendMessage("DecreaseHealthFromRifle");
				}
				GameObject _holeClone = Instantiate(_hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject;
				_holeClone.transform.parent = hit.transform;
			}
		}
		//This handles empty ammo
		if (Input.GetButtonDown("Fire1") && _GunSelection == 0 && _pistolAmmo <= 0 ||
			Input.GetButtonDown("Fire1") && _GunSelection == 1 && _rifleAmmo <= 0)
		{
			_sfxOut.Play();
		}

	}

	////Gun switching coroutines////

	//This is a coroutine to switch to the rifle
	IEnumerator EnableRifle()
	{
		_animStop = true;
		_animPistol.Stop();
		_animPistol.CrossFade("PUnequip");
		yield return new WaitForSeconds(2);
		_pistolObj.SetActive(false);
		_rifleObj.SetActive(true);
		_animRifle.Stop();
		_animRifle.CrossFade("REquip");
		yield return new WaitForSeconds(2);
		_animStop = false;
		yield break;
	}
	//This is a coroutine to switch to the pistol
	IEnumerator EnablePistol()
	{
		_animStop = true;
		_animRifle.Stop();
		_animRifle.CrossFade("RUnequip");
		yield return new WaitForSeconds(2);
		_rifleObj.SetActive(false);
		_pistolObj.SetActive(true);
		_animPistol.Stop();
		_animPistol.CrossFade("PEquip");
		yield return new WaitForSeconds(2);
		_animStop = false;
		yield break;
	}
}
