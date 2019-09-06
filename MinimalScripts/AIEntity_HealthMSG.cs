using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEntity_HealthMSG : MonoBehaviour {

	public AIEntity _ai;
	
	IEnumerator DecreaseHealthFromPistol() {
		_ai.SendMessage("DecreaseHealthFromPistol");
		yield break;
	}
	IEnumerator DecreaseHealthFromRifle() {
		_ai.SendMessage("DecreaseHealthFromRifle");
		yield break;
	}
}
