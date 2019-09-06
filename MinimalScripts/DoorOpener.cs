using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
	//Variables that the door opener depends on

		//Door opening sound
		public AudioSource _sound;
		//Canvas that renders the "Press this button to interact" notification
		//public Canvas _notification;
		//To detect when the player enters in the area to open the door
		//public GameObject _player;
		//The door object
		public Animation _door;
		public bool _isOpen;

	// Use this for initialization
	/*void Start ()
	{
		//This disables the notification at the start of the level
		_notification.enabled = false;
	}*/

	// This will be called when something enters and stays in the collider
	void OnTriggerEnter (Collider c)
	{
		//This makes sure the events are only called when the player is the one entering the collider
		if (c.gameObject.tag == "Player" && _isOpen == false || c.gameObject.tag == "ENT" && _isOpen == false)
		{
			Debug.Log("DoorOpener: Door opened");
			_sound.Play();
            _door.Play("DoorOpen");
			_isOpen = true;
			//_notification.enabled = true;
			/*//The actual door opening function is done when the player presses the interact button
			if(Input.GetButtonDown("Interact"))
			{
				Debug.Log("Door opened");
				//_sound.Play();
				_door.Play("DoorOpen");
			}*/
		}
	}
	// This disables the interact text when the player leaves the collider
	void OnTriggerExit (Collider c2)
	{
		//Makes sure it's still only the player causing the animation to play again
		if (c2.gameObject.tag == "Player" && _isOpen == true || c2.gameObject.tag == "ENT" && _isOpen == true)
		{
			Debug.Log("DoorOpener: Door closed");
			//_notification.enabled = false;
			_sound.Play();
            _door.Play("DoorClose");
			_isOpen = false;
		}
	}
	// This makes the notification a face-me object
	/*void Update ()
	{
		_notification.transform.LookAt(_player.transform);
	}*/
}
