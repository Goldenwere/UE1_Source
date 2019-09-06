using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAnimationBkgd : MonoBehaviour {

    public string animText;

	// Use this for initialization
	void Start () {
		this.GetComponent<Animation>().CrossFade(animText);
	}
}
