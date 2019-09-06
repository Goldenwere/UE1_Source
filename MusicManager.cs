using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public LoadManager _loadmgr; 			//For _levelSelected & _currentscene
    public CutsceneManager _cutscenemgr; 	//For determining cutscenes (for final level)
	//Timer which depends on track length
	public float _waitTime;
    //This creates a loop for the PlayTrack
    public bool _isStopped;
    public bool _isTransition;
    public bool _isStartTrack;
    public AudioSource _currTrack;
    public float _currCurrVol;
    public AudioSource _prevTrack;
    public float _currPrevVol;
    public float _currTrackWaitTime;
    public int _nonstdType;
    public int _randomTrackNo;

	void Awake () {
        DontDestroyOnLoad(gameObject);
		_loadmgr = GameObject.FindWithTag("LoadManagerTag").GetComponent<LoadManager>();
    }

    void Update () {
        if (_isStopped == true) {
            StartCoroutine("GetCurrTrack");
        }
        //Transitions
        if (_isTransition == true) {
            _currCurrVol = _currTrack.volume;
            if (_prevTrack != null) {
                _currPrevVol = _prevTrack.volume;
                _prevTrack.volume = Mathf.Lerp(_currPrevVol, 0f, 0.66f * Time.deltaTime);
            }
            _currTrack.volume = Mathf.Lerp(_currCurrVol, 1.0f, 0.66f * Time.deltaTime);
        }
    }

    public IEnumerator PlayTrack() {
        Debug.Log("MusicManager: Current Coroutine - PlayTrack");
        _isStopped = false;
        _isTransition = true;
        _currTrack.Play();
        yield return new WaitForSecondsRealtime(3.1f);
        _isTransition = false;
        if (_prevTrack != null) {
            _prevTrack.Stop();
        }
        _prevTrack = _currTrack;
        yield return new WaitForSecondsRealtime(_currTrackWaitTime);
        if (_isStartTrack == true) {
            _isStartTrack = false;
        }
        _isStopped = true;
        yield break;
    }

    public IEnumerator GetCurrTrack() {
        _isStopped = false;
        Debug.Log("MusicManager: Current Coroutine - GetCurrTrack");
        if (_loadmgr._levelSelected == 1 || _loadmgr._levelSelected == 2 || _loadmgr._levelSelected == 3 ||
		_loadmgr._levelSelected == 5 || _loadmgr._levelSelected == 6 || _loadmgr._levelSelected == 10 ||
		_loadmgr._levelSelected == 16 || _loadmgr._levelSelected == 17 || _loadmgr._levelSelected == 22 ||
        _loadmgr._levelSelected == 21) {
            if (_isStartTrack == false) {
                _randomTrackNo = Random.Range(1,9);
            }
            if (_randomTrackNo == 1) {
                _currTrack = GameObject.Find("1.1").GetComponent<AudioSource>();
                _currTrackWaitTime = 369f;
            }
            if (_randomTrackNo == 2) {
                _currTrack = GameObject.Find("1.2").GetComponent<AudioSource>();
                _currTrackWaitTime = 461f;
            }
            if (_randomTrackNo == 3) {
                _currTrack = GameObject.Find("1.3").GetComponent<AudioSource>();
                _currTrackWaitTime = 256f;
            }
            if (_randomTrackNo == 4) {
                _currTrack = GameObject.Find("1.4").GetComponent<AudioSource>();
                _currTrackWaitTime = 242.5f;
            }
            if (_randomTrackNo == 5) {
                _currTrack = GameObject.Find("1.5").GetComponent<AudioSource>();
                _currTrackWaitTime = 227f;
            }
            if (_randomTrackNo == 6) {
                _currTrack = GameObject.Find("1.6").GetComponent<AudioSource>();
                _currTrackWaitTime = 326.5f;
            }
            if (_randomTrackNo == 7) {
                _currTrack = GameObject.Find("1.7").GetComponent<AudioSource>();
                _currTrackWaitTime = 336f;
            }
            if (_randomTrackNo == 8) {
                _currTrack = GameObject.Find("1.8").GetComponent<AudioSource>();
                _currTrackWaitTime = 244.5f;
            }
            if (_randomTrackNo == 9) {
                _currTrack = GameObject.Find("1.9").GetComponent<AudioSource>();
                _currTrackWaitTime = 314f;
            }
		}
        if (_loadmgr._levelSelected == 4 || _loadmgr._levelSelected == 7 || _loadmgr._levelSelected == 8 ||
        _loadmgr._levelSelected == 11 || _loadmgr._levelSelected == 14 || _loadmgr._levelSelected == 19 ||
        _loadmgr._levelSelected == 20 || _loadmgr._levelSelected == 24 || _loadmgr._levelSelected == 27 ||
        _loadmgr._levelSelected == 28) {
            if (_isStartTrack == false) {
                _randomTrackNo = Random.Range(1,9);
            }
            if (_randomTrackNo == 1) {
                _currTrack = GameObject.Find("2.1").GetComponent<AudioSource>();
                _currTrackWaitTime = 371f;
            }
            if (_randomTrackNo == 2) {
                _currTrack = GameObject.Find("2.2").GetComponent<AudioSource>();
                _currTrackWaitTime = 218.5f;
            }
            if (_randomTrackNo == 3) {
                _currTrack = GameObject.Find("2.3").GetComponent<AudioSource>();
                _currTrackWaitTime = 360f;
            }
            if (_randomTrackNo == 4) {
                _currTrack = GameObject.Find("2.4").GetComponent<AudioSource>();
                _currTrackWaitTime = 208f;
            }
            if (_randomTrackNo == 5) {
                _currTrack = GameObject.Find("2.5").GetComponent<AudioSource>();
                _currTrackWaitTime = 286.5f;
            }
            if (_randomTrackNo == 6) {
                _currTrack = GameObject.Find("2.6").GetComponent<AudioSource>();
                _currTrackWaitTime = 128f;
            }
            if (_randomTrackNo == 7) {
                _currTrack = GameObject.Find("2.7").GetComponent<AudioSource>();
                _currTrackWaitTime = 89f;
            }
            if (_randomTrackNo == 8) {
                _currTrack = GameObject.Find("2.8").GetComponent<AudioSource>();
                _currTrackWaitTime = 282f;
            }
            if (_randomTrackNo == 9) {
                _currTrack = GameObject.Find("2.9").GetComponent<AudioSource>();
                _currTrackWaitTime = 213f;
            }
        }
        if (_loadmgr._levelSelected == 12 || _loadmgr._levelSelected == 13 || _loadmgr._levelSelected == 15 ||
        _loadmgr._levelSelected == 18 || _loadmgr._levelSelected == 23 || _loadmgr._levelSelected == 25 ||
        _loadmgr._levelSelected == 26 || _loadmgr._levelSelected == 29 || _loadmgr._levelSelected == 30) {
            if (_isStartTrack == false) {
                _randomTrackNo = Random.Range(1,9);
            }
            if (_randomTrackNo == 1) {
                _currTrack = GameObject.Find("3.1").GetComponent<AudioSource>();
                _currTrackWaitTime = 291f;
            }
            if (_randomTrackNo == 2) {
                _currTrack = GameObject.Find("3.2").GetComponent<AudioSource>();
                _currTrackWaitTime = 105f;
            }
            if (_randomTrackNo == 3) {
                _currTrack = GameObject.Find("3.3").GetComponent<AudioSource>();
                _currTrackWaitTime = 151f;
            }
            if (_randomTrackNo == 4) {
                _currTrack = GameObject.Find("3.4").GetComponent<AudioSource>();
                _currTrackWaitTime = 239.5f;
            }
            if (_randomTrackNo == 5) {
                _currTrack = GameObject.Find("3.5").GetComponent<AudioSource>();
                _currTrackWaitTime = 256.5f;
            }
            if (_randomTrackNo == 6) {
                _currTrack = GameObject.Find("3.6").GetComponent<AudioSource>();
                _currTrackWaitTime = 206f;
            }
            if (_randomTrackNo == 7) {
                _currTrack = GameObject.Find("3.7").GetComponent<AudioSource>();
                _currTrackWaitTime = 115f;
            }
            if (_randomTrackNo == 8) {
                _currTrack = GameObject.Find("3.8").GetComponent<AudioSource>();
                _currTrackWaitTime = 120f;
            }
            if (_randomTrackNo == 9) {
                _currTrack = GameObject.Find("3.9").GetComponent<AudioSource>();
                _currTrackWaitTime = 352f;
            }
        }
        if (_loadmgr._levelSelected == 99) {
            _currTrack = GameObject.Find("menutrack").GetComponent<AudioSource>();
            _currTrackWaitTime = 285f;
        }
        if (_loadmgr._levelSelected == 9) {
            _currTrack = GameObject.Find("P.1").GetComponent<AudioSource>();
            _currTrackWaitTime = 218f;
        }
        //intro, outro, credits not needed because they can only play once
        StartCoroutine("PlayTrack");
        yield break;
    }

    public void StartLevelTrack(int _musicLevel) {
        _isStopped = false;
        _isStartTrack = true;
        Debug.Log("MusicManager: Current Coroutine - StartLevelTrack");
        //Choose track based on _musicLevel
        if (_musicLevel == 1) {
            _randomTrackNo = 3;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 2) {
            _randomTrackNo = 7;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 3) {
            _randomTrackNo = 1;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 4) {
            _randomTrackNo = 5;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 5) {
            _randomTrackNo = 4;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 6) {
            _randomTrackNo = 8;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 7) {
            _randomTrackNo = 1;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 8) {
            _randomTrackNo = 3;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 9) {
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 10) {
            _randomTrackNo = 5;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 11) {
            _randomTrackNo = 7;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 12) {
            _randomTrackNo = 9;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 13) {
            _randomTrackNo = 6;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 14) {
            _randomTrackNo = 4;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 15) {
            _randomTrackNo = 7;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 16) {
            _randomTrackNo = 9;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 17) {
            _randomTrackNo = 2;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 18) {
            _randomTrackNo = 8;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 19) {
            _randomTrackNo = 9;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 20) {
            _randomTrackNo = 8;
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 99) {
            StartCoroutine("GetCurrTrack");
        }
        if (_musicLevel == 97) {
            _currTrack = GameObject.Find("introtrack").GetComponent<AudioSource>();
            _currTrackWaitTime = 111f;
            StartCoroutine("PlayTrack");    //Skip getting current track since current track is start track
        }
        if (_musicLevel == 98) {
            _currTrack = GameObject.Find("creditstrack").GetComponent<AudioSource>();
            StartCoroutine("PlayTrack");    //Skip getting current track since current track is start track
        }
        if (_musicLevel == 96) {
            _currTrack = GameObject.Find("outrotrack").GetComponent<AudioSource>();
            StartCoroutine("PlayTrack");    //Skip getting current track since current track is start track
        }
    }
}
