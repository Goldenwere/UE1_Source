using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotParticleDestroyer : MonoBehaviour {

	//Change this in inspector so the script is re-usable on other objects
	public int _seconds;
	//This is for the bullet specifically
	public bool _isBullet;
	public int _speed;

	// Use this for initialization
	void Start () {
		StartCoroutine("AutoDestruct");
	}
	void Update () {
		if (_isBullet == true) {
            this.transform.Translate(0, 0, _speed);
		}
	}
	void OnCollisionEnter (Collision col) {
		if (_isBullet == true) {
			Destroy(gameObject);
		}
	}
	IEnumerator AutoDestruct() {
		yield return new WaitForSeconds(_seconds);
		Destroy(gameObject);
		yield break;
	}

}
