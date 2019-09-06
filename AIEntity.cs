using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIEntity : MonoBehaviour {

	//Stats for the entity
	//For the health
		public float _enthealth;
			public float _entbasehealth;
	//For movement
		public float _entspd;
		public float _entrotspd;
		public Vector3 _startPos;
		public float _wanderTimer;
		public float _roamRadius;
		public bool _canRoam;
	//For damage
		public float _entdmg;
			public float _entbasedmg;
			public float _senddmg;
		public GameObject _entbullet;
		public GameObject _entbulletclone;
		public float _dmgTimer;
		//public float _entbulletspeed;
		public float _entdelay;
		public float _counter;
		public GameObject _fireSource;
		public AudioSource _fireSFX;
		public AudioSource _playerFire;
		public AudioSource _playerElec;
	//Identifier for the entity
		public int _entid;
		public int _entdmgtype;
	//Determines actual stats based on difficulty, must grab the level manager
		public LevelManager _LevelManager;
		public float _multiplier;
	//Target the player, determine its distance, and follow when in range
		public Transform _target;
		public Transform _target2;
		public PlayerStats _targetStats;
		public HoverPlayerManager _targetStats2;
		public LoadManager _loadMGR;
		public float _targetdist;
		public float _targetdistmin;
		public float _targetdistminHover;
			public float _targetdistminbase;
    	public int _scene;
	//For death
		public GameObject _death;
    	public GameObject _deathclone;
    //For randomization
    	public int _RandomDialogue;
		public int _RandomCheck;
		public int _DialogueCheck;
        public float _dialogueTimer;
		public float _dialogueTimerReq;
    //For Dialogue
	    public AudioSource _dialogue1;
	    public AudioSource _dialogue2;
	    public AudioSource _dialogue3;
	    public AudioSource _dialogue4;
	//Stuff for the functions of the entity
	//This sets up the entity's stats at the start of the game
	void Awake ()
	{
		//Sets up the base stats for a prismatic chunk
		if (_entid == 1)
		{
			_entbasedmg = 20f;
			_entbasehealth = 50f;
			_entrotspd = 150;
			_entspd = 10;
			_entdmgtype = 1;
			_entdelay = 1.5f;
			_targetdistminbase = 20;
		}
		//Sets up the base stats for a spherical chunk
		if (_entid == 2)
		{
			_entbasedmg = 25f;
			_entbasehealth = 60f;
			_entrotspd = 160;
			_entspd = 10;
			_entdmgtype = 2;
			_entdelay = 0.75f;
			_targetdistminbase = 20;
		}
		//Sets up the base stats for a ROD
		if (_entid == 3)
		{
			//Note: the ROD's damage method must call on a function on the
			//player to enable and disable an overlay
			//The damage method must also be done in a coroutine instead
			//of a one-shot function - is done [-20] * 3
			_entbasedmg = 20f;
			_entbasehealth = 75f;
			_entrotspd = 120;
			_entspd = 9;
			_entdmgtype = 3;
			_entdelay = 4f;
			_targetdistminbase = 35;
		}
		//Sets up the base stats for a Rot. Pyr.
		if (_entid == 4)
		{
			//Same note as ROD, except dmg is [-20] * 3 sec
			_entbasedmg = 20f;
			_entbasehealth = 80f;
			_entrotspd = 100;
			_entspd = 9;
			_entdmgtype = 4;
			_entdelay = 3f;
			_targetdistminbase = 35;
		}
		//Sets up the base stats for a Death Bot
		if (_entid == 5)
		{
			//Same note as ROD, except dmg is [-15] * 3 + [-15] * 3
			_entbasedmg = 15f;
			_entbasehealth = 200f;
			_entrotspd = 90;
			_entspd = 8;
			_entdmgtype = 5;
			_entdelay = 6f;
			_targetdistminbase = 40;
		}
	}
	void Start ()
    {
		_scene = SceneManager.GetActiveScene().buildIndex;
        //Target the player
        _target = GameObject.FindWithTag("Player").transform;
        _targetStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
		if (_scene == 5 || _scene == 8) {
			_target2 = GameObject.FindWithTag("Buggy").transform;
			_targetStats2 = GameObject.Find("HoverCarManager").GetComponent<HoverPlayerManager>();
		}
		//Set the fire and electrical sounds
		_playerElec = GameObject.Find("ElectricalSound").GetComponent<AudioSource>();
		_playerFire = GameObject.Find("FireDamageSound").GetComponent<AudioSource>();
		_LevelManager = GameObject.Find("LEVELMANAGER").GetComponent<LevelManager>();
		//Get the start position and set the roam radius to be within 10m
		_startPos = gameObject.transform.position;
		_roamRadius = 10f;
		//Set the damage timer above the time threshold for the entity to being targetting the player
		//to prevent the entity from targetting before the player damages the entity at the start of the level
		_dmgTimer = 15f;

		//Determine multiplier
		if (_LevelManager._difficultyScore <= 3) {
			_multiplier = 0.6f;
		}
		if (_LevelManager._difficultyScore > 3 && _LevelManager._difficultyScore <= 6) {
			_multiplier = 0.8f;
		}
		if (_LevelManager._difficultyScore > 6 && _LevelManager._difficultyScore <= 10) {
			_multiplier = 1.0f;
		}
		if (_LevelManager._difficultyScore > 10 && _LevelManager._difficultyScore <= 14) {
			_multiplier = 1.2f;
		}
		if (_LevelManager._difficultyScore == 15) {
			_multiplier = 1.5f;
        }
		//Use multipliers
		_entdmg = _entbasedmg * _multiplier;
        _enthealth = _entbasehealth * _multiplier;
		_targetdistmin = _targetdistminbase * _multiplier;
		_targetdistminHover = _targetdistminbase * _multiplier * 5;
		//Set the NavMeshAgent stats equivalent to the entity's abilities
		gameObject.GetComponent<NavMeshAgent>().angularSpeed = _entrotspd * _multiplier;
		gameObject.GetComponent<NavMeshAgent>().speed = _entspd * _multiplier;
    	gameObject.GetComponent<NavMeshAgent>().acceleration = 5;
		_dialogueTimerReq = 5.0f;
	}
	// Update is called once per frame
	void Update ()
	{
		////These variables are constantly updated////

			//Update the distance between the entity and the player
			if (_scene == 5 || _scene == 8) {
				if (_targetStats2._isInside == false) {
	            	_targetdist = Vector3.Distance(_target.position, gameObject.transform.position);
				}
				if (_targetStats2._isInside == true) {
					_targetdist = Vector3.Distance(_target2.position, gameObject.transform.position);
				}
			}
			if (_scene != 5 && _scene != 8) {
				_targetdist = Vector3.Distance(_target.position, gameObject.transform.position);
			}
			//Counter increases over time
			_counter += Time.deltaTime;
			//Wander timer increases over time
			_wanderTimer += Time.deltaTime;
			//Damage timer
			_dmgTimer += Time.deltaTime;
			//Dialogue timer
			_dialogueTimer += Time.deltaTime;

        ////Navigation////

        //Follow the player when in range for entities 3,4,5
        if (_scene == 5 || _scene == 8) {
			if (_targetStats2._isInside == false) {
				if (_targetdist < _targetdistmin && _targetdist > 2 || _dmgTimer < 10) {
                    gameObject.GetComponent<NavMeshAgent>().destination = _target.position;
					_canRoam = false;
                }
			}
			if (_targetStats2._isInside == true) {
				if (_targetdist < _targetdistminHover && _targetdist > 10 || _dmgTimer < 10) {
                    gameObject.GetComponent<NavMeshAgent>().destination = _target2.position;
					_canRoam = false;
				}
			}
		}
		if (_scene != 5 && _scene != 8) {
			if (_targetdist < _targetdistmin && _targetdist > 2 || _dmgTimer < 10) {
				gameObject.GetComponent<NavMeshAgent>().destination = _target.position;
				_canRoam = false;
			}
		}

		//Roam bool
		if (_targetdist > _targetdistmin && _dmgTimer > 10)
		{
			_canRoam = true;
		}
		//Wander check
		if (_wanderTimer >= 5f) {
            _RandomCheck = Random.Range(1, 1000);
			if (_RandomCheck >= 300) {
				Wander();
			}
			_wanderTimer = 0;
		}

        //Dialogue check
        if (_dialogueTimer >= _dialogueTimerReq) {
			_DialogueCheck = Random.Range(1, 1000);
			if (_DialogueCheck <= 333) {
            	Dialogue();
				_dialogueTimerReq = 35.0f;
			}
			_dialogueTimer = 0;
		}

		////Damage the player////

		//Determine whether to start shooting the player or not (ents 1 & 2)
		if (_targetdist < _targetdistmin && _counter > _entdelay && _entid < 3)
		{
			_fireSFX.Play();
			RaycastHit _hit = new RaycastHit();
			Ray _ray = new Ray(_fireSource.transform.position, _fireSource.transform.forward);
			if (Physics.Raycast(_ray, out _hit, 50000f))
			{
				if (_entdmgtype == 1 || _entdmgtype == 2)
				{
					_entbulletclone = Instantiate(_entbullet, _fireSource.transform.position, _fireSource.transform.rotation);
				}
				if (_hit.collider.tag.Equals("Player"))
				{
					if (_entdmgtype == 1 || _entdmgtype == 2)
					{
						_targetStats.StartCoroutine("TakeDamage", _entdmg);
					}
                }
				//Does not need to check for scene, because it's already detecting if the buggy is there or not w/ collider
				if (_hit.collider.tag.Equals("Buggy"))
				{
					if (_entdmgtype == 1 || _entdmgtype == 2)
					{
						_targetStats2.StartCoroutine("TakeDamage", _entdmg);
					}
				}
            }
			_counter = 0;
		}
        //Determine whether to damage the player or not (ents 3, 4, & 5)
        if (_scene == 5 || _scene == 8) {
			if (_targetStats2._isInside == true) {
				if (_entdmgtype == 3 && _targetdist <= 15 && _counter > _entdelay)
				{
                	StartCoroutine("SendDamageElectricity");
					_counter = 0;
				}
				if (_entdmgtype == 4 && _targetdist <= 15 && _counter > _entdelay)
				{
                	StartCoroutine("SendDamageFire");
					_counter = 0;
				}
				if (_entdmgtype == 5 && _targetdist <= 15 && _counter > _entdelay)
				{
					//The deathbot combines both fire and electricity damage
					StartCoroutine("SendDamageFire");
                	StartCoroutine("SendDamageElectricity");
					_counter = 0;
				}
			}
			if (_targetStats2._isInside == false) {
				if (_entdmgtype == 3 && _targetdist <= 5 && _counter > _entdelay)
				{
                    StartCoroutine("SendDamageElectricity");
					_counter = 0;
				}
				if (_entdmgtype == 4 && _targetdist <= 5 && _counter > _entdelay)
				{
                	StartCoroutine("SendDamageFire");
					_counter = 0;
				}
				if (_entdmgtype == 5 && _targetdist <= 5 && _counter > _entdelay)
				{
					//The deathbot combines both fire and electricity damage
					StartCoroutine("SendDamageFire");
            		StartCoroutine("SendDamageElectricity");
					_counter = 0;
				}
			}
		}
		if (_scene != 5 && _scene != 8) {
			if (_entdmgtype == 3 && _targetdist <= 5 && _counter > _entdelay)
			{
            	StartCoroutine("SendDamageElectricity");
				_counter = 0;
			}
			if (_entdmgtype == 4 && _targetdist <= 5 && _counter > _entdelay)
			{
                StartCoroutine("SendDamageFire");
				_counter = 0;
			}
			if (_entdmgtype == 5 && _targetdist <= 5 && _counter > _entdelay)
			{
				//The deathbot combines both fire and electricity damage
				StartCoroutine("SendDamageFire");
                StartCoroutine("SendDamageElectricity");
				_counter = 0;
			}
		}

		////Death of entity////

		if (_enthealth <= 0)
		{
			StartCoroutine("Death");
		}
	}

	////Random Checks////
	//Wander
	void Wander()
	{
		Vector3 randomDirection = Random.insideUnitSphere * _roamRadius;
		randomDirection += _startPos;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, _roamRadius, 1);
		Vector3 finalPosition = hit.position;
		gameObject.GetComponent<NavMeshAgent>().destination = finalPosition;
    }
	//Dialogue
	void Dialogue()
	{
        _RandomDialogue = Random.Range(1, 400);
        if (_RandomDialogue > 0 && _RandomDialogue <= 100) {
			_dialogue1.Play();
		}
		if (_RandomDialogue > 100 && _RandomDialogue <= 200) {
			_dialogue2.Play();
		}
		if (_RandomDialogue > 200 && _RandomDialogue <= 300) {
			_dialogue3.Play();
		}
		if (_RandomDialogue > 300 && _RandomDialogue <= 400) {
			_dialogue4.Play();
		}
	}

	////Damage of entity////

	IEnumerator DecreaseHealthFromPistol()
	{
		_enthealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>()._PPistolDamage;
		_dmgTimer = 0;
		yield break;
	}
	IEnumerator DecreaseHealthFromRifle()
	{
		_enthealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>()._PRifleDamage;
		_dmgTimer = 0;
		yield break;
	}

	////Death of entity coroutine////

	IEnumerator Death()
	{
		//The death particles
		_deathclone = Instantiate(_death, transform.position, transform.rotation);
		//Decrease LevelManager _entities if it's not already 0
		if (_LevelManager._entities > 0) {
			_LevelManager._entities -= 1;
			_LevelManager.UpdateDisplay();
		}
		//Add to Player Experience
		if (_entid == 1) {
			GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>()._Exp += 10;
		}
		if (_entid == 2) {
			GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>()._Exp += 15;
		}
		if (_entid == 3) {
			GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>()._Exp += 20;
		}
		if (_entid == 4) {
			GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>()._Exp += 25;
		}
		if (_entid == 5) {
			GameObject.FindGameObjectWithTag("StoreManagerTag").GetComponent<StoreManager>()._Exp += 30;
		}
		//Destroy the entity
		Destroy(this.gameObject);
		yield break;
	}

	////Player damage over time, non-bullet////

	IEnumerator SendDamageFire()
	{
		_fireSFX.Play();
		_playerFire.Play();
		//Base damage 5 (or 3 if DeBot) * 3 over 3 seconds
		if (_scene == 5 || _scene == 8) {
			if (_targetStats2._isInside == false) {
				_targetStats.FireDamageStatusOn();
				_targetStats.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(1.5f);
				_targetStats.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(1.5f);
                _targetStats.StartCoroutine("TakeDamage", _entdmg);
	        }
			if (_targetStats2._isInside == true) {
				_targetStats2.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(1.5f);
				_targetStats2.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(1.5f);
				_targetStats2.StartCoroutine("TakeDamage", _entdmg);
            }
        }
		if (_scene != 5 && _scene != 8) {
			_targetStats.FireDamageStatusOn();
			_targetStats.StartCoroutine("TakeDamage", _entdmg);
			yield return new WaitForSeconds(1.5f);
			_targetStats.StartCoroutine("TakeDamage", _entdmg);
			yield return new WaitForSeconds(1.5f);
            _targetStats.StartCoroutine("TakeDamage", _entdmg);
		}
		yield break;
	}
	IEnumerator SendDamageElectricity()
	{
		_fireSFX.Play();
		_playerElec.Play();
		//Base damage 4 (or 3 if DeBot) * 3 over 2 seconds
		if (_scene == 5 || _scene == 8) {
			if (_targetStats2._isInside == false) {
				_targetStats.ElecDamageStatusOn();
				_targetStats.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(0.5f);
				_targetStats.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(0.5f);
                _targetStats.StartCoroutine("TakeDamage", _entdmg);
	        }
			if (_targetStats2._isInside == true) {
				_targetStats2.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(0.5f);
				_targetStats2.StartCoroutine("TakeDamage", _entdmg);
				yield return new WaitForSeconds(0.5f);
				_targetStats2.StartCoroutine("TakeDamage", _entdmg);
            }
        }
		if (_scene != 5 && _scene != 8) {
			_targetStats.ElecDamageStatusOn();
			_targetStats.StartCoroutine("TakeDamage", _entdmg);
			yield return new WaitForSeconds(0.5f);
			_targetStats.StartCoroutine("TakeDamage", _entdmg);
			yield return new WaitForSeconds(0.5f);
            _targetStats.StartCoroutine("TakeDamage", _entdmg);
		}
		yield break;
	}
}
