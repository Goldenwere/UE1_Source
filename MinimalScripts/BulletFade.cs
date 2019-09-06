using System.Collections;
using UnityEngine;

public class BulletFade : MonoBehaviour {
	void Start () {
		StartCoroutine("FadeBullet");
    }
	public IEnumerator FadeBullet() {
		yield return new WaitForSecondsRealtime(10f);
		gameObject.GetComponent<Animation>().CrossFade("BulletFade");
		yield return new WaitForSecondsRealtime(1.5f);
		Destroy(gameObject);
	}
}
