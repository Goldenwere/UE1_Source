using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityChunkLoading : MonoBehaviour {

	public GameObject _player;
    public GameObject _buggy;
    public HoverPlayerManager _hpm;
    public GameObject _chunk;
	public float _minDist;
	public float _actualDist;
    public int _scene;
    public bool _activated;

	// Update is called once per frame
	void Update () {
		if (_scene == 5 || _scene == 8) {
			if (_hpm._isInside == true) {
				_actualDist = Vector3.Distance(_buggy.transform.position, gameObject.transform.position) * 0.5f * 0.33f;
			}
			if (_hpm._isInside == false) {
				_actualDist = Vector3.Distance(_player.transform.position, gameObject.transform.position) * 0.33f;
			}
		}
		if (_scene != 5 && _scene != 8) {
			_actualDist = Vector3.Distance(_player.transform.position, gameObject.transform.position) * 0.33f;
		}
		if (_actualDist <= _minDist && _activated == false) {
			_chunk.SetActive(true);
			_activated = true;
        }
		if (_actualDist > _minDist && _activated == true) {
			_chunk.SetActive(false);
			_activated = false;
		}
	}
}
