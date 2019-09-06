using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LensFlareFixedDistance : MonoBehaviour {
	public float Size;
	public LensFlare Flare;
	public GameObject camera1;
	public GameObject camera2;
	public int _scene;
	public int _sceneno;
	public HoverPlayerManager _hpm;
	public LoadManager _lm;
	void Start()
	{
			_lm = GameObject.FindWithTag("LoadManagerTag").GetComponent<LoadManager>();
			_scene = SceneManager.GetActiveScene().buildIndex;
			_sceneno = _lm._levelSelected;
			if (_scene != 1) {
				camera1 = GameObject.FindWithTag("MainCamera");
				if (_scene == 5 || _scene == 8) {
					camera2 = GameObject.Find("HoverCarCamera");
					_hpm = GameObject.Find("HoverCarManager").GetComponent<HoverPlayerManager>();
				}
			}
			if (_scene == 1) {
				camera1 = GameObject.Find("CutsceneCam1");
				camera2 = GameObject.Find("CutsceneCam2");
			}
			if (Flare == null)
					Flare = GetComponent<LensFlare>();

			if (Flare == null)
			{
					Debug.LogWarning("No LensFlare on " + name + ", destroying.", this);
					Destroy(this);
					return;
			}

			Size = Flare.brightness;
	}

	void Update()
	{
		if (_scene == 5 || _scene == 8) {
			if (_hpm._isInside == false) {
				float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, camera1.transform.position));
				Flare.brightness = Size / ratio;
			}
			if (_hpm._isInside == true) {
				float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, camera2.transform.position));
				Flare.brightness = Size / ratio;
			}
		}
		if (_scene != 5 && _scene != 8 && _scene != 1) {
			float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, camera1.transform.position));
			Flare.brightness = Size / ratio;
		}
		if (_scene == 1 && _sceneno == 97) {
			float ratio = (Mathf.Sqrt(Vector3.Distance(transform.position, camera1.transform.position)) * 0.08f);
			Flare.brightness = Size / ratio;
		}
		if (_scene == 1 && _sceneno == 98) {
			float ratio = Mathf.Sqrt(Vector3.Distance(transform.position, camera2.transform.position));
			Flare.brightness = Size / ratio;
		}
	}
}
