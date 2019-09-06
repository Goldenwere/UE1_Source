using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LampLightOff : MonoBehaviour {

	public GameObject _player;
    public GameObject _buggy;
    public HoverPlayerManager _hpm;
    public Light _lamp;
	public float _minDist;
	public float _actualDist;
    public int _scene;
    public bool _activated;
    public CutsceneManager _cm;


	void Start () {
        _scene = SceneManager.GetActiveScene().buildIndex;
		if (_scene != 1) {
            _player = GameObject.FindWithTag("Player");
			if (_scene == 5 || _scene == 8) {
	        	_buggy = GameObject.FindWithTag("Buggy");
                _hpm = GameObject.Find("HoverCarManager").GetComponent<HoverPlayerManager>();
			}
		}
		_cm = GameObject.Find("CUTSCENEMANAGER").GetComponent<CutsceneManager>();
	}

    void Update () {
		if (_scene != 1 && _cm._isCutscene == false) {
			if (_scene == 5 || _scene == 8) {
				if (_hpm._isInside == true) {
					_actualDist = Vector3.Distance(_buggy.transform.position, gameObject.transform.position) * 0.7f * 0.4f;
				}
				if (_hpm._isInside == false) {
					_actualDist = Vector3.Distance(_player.transform.position, gameObject.transform.position) * 0.4f;
				}
			}
			if (_scene != 5 && _scene != 8) {
				_actualDist = Vector3.Distance(_player.transform.position, gameObject.transform.position) * 0.4f;
			}
			if (_actualDist <= _minDist && _activated == false) {
				_lamp.enabled = true;
				_activated = true;
	        }
			if (_actualDist > _minDist && _activated == true) {
				_lamp.enabled = false;
				_activated = false;
			}
		}
	}
}
