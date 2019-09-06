using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingOptimizer : MonoBehaviour {

	//Variables the script depends on
		//Variable for the lighting
		public GameObject _Lighting;	
		/*Variable to determine if the lighting is enabled or disabled by default
			//This is because spawn areas must remain enabled, 
			/while every other area must be disabled*/
		public bool _isActive;

	//Disables or enables the lighting by default
	void Start()
	{
		_Lighting.SetActive(_isActive);
	}
	
	//Starts when something enters the collider
	void OnTriggerEnter (Collider c) 
	{
		//This makes sure the events are only called when the player is the one entering the collider
		if (c.gameObject.tag == "Player" || c.gameObject.tag == "CutsceneCams")
		{
			Debug.Log("LightingOptimizer: Activating lighting for this building");
			_Lighting.SetActive(true);
		}
	}

	//Starts when something exits the collider
	void OnTriggerExit (Collider c2)
	{
		//Makes sure it's still only the player causing the objects to deactivate
		if (c2.gameObject.tag == "Player" || c2.gameObject.tag == "CutsceneCams")
		{
			Debug.Log("LightingOptimizer: Deactivating lighting for this building");
			_Lighting.SetActive(false);
		}
	}
}
