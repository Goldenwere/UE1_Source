using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	//Variables needed to execute this script

		//This is to ensure only the player can use the elevator
		public GameObject _player;
		//This determines the elevator's position
		public int _position;
		//This plays an energy-like sound
		//public AudioSource _sound;
		//Location A
		public GameObject _locA;
		public GameObject _locB;

	void Start ()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
	}

	// This will be called when something enters and stays in the collider
	void OnTriggerEnter (Collider c)
	{
		//This makes sure the events are only called when the player is the one entering the collider
		if (c.gameObject.tag == "Player")
		{
			StartCoroutine("ElevatorSequence");
		}
	}

	public IEnumerator ElevatorSequence()
	{
		//Position must be 0 to take elevator up
		if (_position == 0)
		{
			//This will take the elevator up
			Debug.Log("Elevator lifting");
			//_sound.Play();
			//_elev.Play("ElevUp");
			//_player.transform.position = new Vector3(518, 65, 665);
			_player.transform.position = _locB.transform.position;
			_position = 1;
			yield break;
		}
		//Position must be 1 to take elevator down
		if (_position == 1)
		{
			//This will take the elevator down
			Debug.Log("Elevator lowering");
			//sound.Play();
			//_elev.Play("ElevDown");
			//_player.transform.position = new Vector3(511, 29.6, 656);
			_player.transform.position = _locA.transform.position;
			_position = 0;
			yield break;
		}
	}
}
