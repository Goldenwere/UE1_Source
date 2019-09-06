using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneTransition : MonoBehaviour {

    public Animation _blackTransition;
	public Animation _cinemBkgd;
    public Animation _textAnim;
	public Text _baseTitleText;
	public Text _baseTitleTranslationText;
    public Text _stageTitleText;
    public GameObject _UIelements;
    public LoadManager _lm;

    void Awake () {
        DontDestroyOnLoad(this.transform);
        _UIelements.SetActive(false);
    }

	//For intro - voids are called on by CutsceneManager
	public void TransitionIntroBeginning() {
        _UIelements.SetActive(true);
		//If the level selected is 32 or less (did this to give collapsable GUI)
		//Then set the different text elements accordingly
		if (_lm._levelSelected <= 32) {
			if (_lm._levelSelected == 1) {
	            _baseTitleText.text = "Eslon";
	            _baseTitleTranslationText.text = "'Star'";
				_stageTitleText.text = "Stage 1";
	        }
			if (_lm._levelSelected == 2) {
				_baseTitleText.text = "Shanem";
				_baseTitleTranslationText.text = "(Omega Prime)";
				_stageTitleText.text = "Stage 1";
	        }
			if (_lm._levelSelected == 3) {
				_baseTitleText.text = "Terus";
				_baseTitleTranslationText.text = "'Life'";
				_stageTitleText.text = "Stage 1";
	        }
			if (_lm._levelSelected == 4) {
				_baseTitleText.text = "Eslon";
				_baseTitleTranslationText.text = "'Star'";
				_stageTitleText.text = "Stage 2";
	        }
			if (_lm._levelSelected == 5) {
				_baseTitleText.text = "Lokem";
				_baseTitleTranslationText.text = "'Universe'";
				_stageTitleText.text = "Stage 1";
	        }
			if (_lm._levelSelected == 6) {
				_baseTitleText.text = "Endolonus";
				_baseTitleTranslationText.text = "'Independence'";
				_stageTitleText.text = "Stage 1";
			}
			if (_lm._levelSelected == 7) {
				_baseTitleText.text = "Shanem";
				_baseTitleTranslationText.text = "(Omega Prime)";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 8) {
				_baseTitleText.text = "Terus";
				_baseTitleTranslationText.text = "'Life'";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 9) {
				_baseTitleText.text = "(between Terus & Palaveeo)";
				_baseTitleTranslationText.text = "(location error)";
				_stageTitleText.text = "Stage (error - unknown)";
			}
			if (_lm._levelSelected == 10) {
				_baseTitleText.text = "Palaveeo";
				_baseTitleTranslationText.text = "'Time'";
				_stageTitleText.text = "Stage 1";
			}
			if (_lm._levelSelected == 11) {
				_baseTitleText.text = "Lokem";
				_baseTitleTranslationText.text = "'Universe'";
				_stageTitleText.text = "Stage 2";
	        }
			if (_lm._levelSelected == 12) {
				_baseTitleText.text = "Eslon";
				_baseTitleTranslationText.text = "'Star'";
				_stageTitleText.text = "Stage 3";
	        }
			if (_lm._levelSelected == 13) {
				_baseTitleText.text = "Shanem";
				_baseTitleTranslationText.text = "(Omega Prime)";
				_stageTitleText.text = "Stage 3";
	        }
			if (_lm._levelSelected == 14) {
				_baseTitleText.text = "Endolonus";
				_baseTitleTranslationText.text = "'Independence'";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 15) {
				_baseTitleText.text = "Terus";
				_baseTitleTranslationText.text = "'Life'";
				_stageTitleText.text = "Stage 3";
			}
			if (_lm._levelSelected == 16) {
				_baseTitleText.text = "Onlenek";
				_baseTitleTranslationText.text = "'to See'";
				_stageTitleText.text = "Stage 1";
			}
			if (_lm._levelSelected == 17) {
				_baseTitleText.text = "Terelem";
				_baseTitleTranslationText.text = "'Progress'";
				_stageTitleText.text = "Stage 1";
			}
			if (_lm._levelSelected == 18) {
				_baseTitleText.text = "Lokem";
				_baseTitleTranslationText.text = "'Universe'";
				_stageTitleText.text = "Stage 3";
			}
			if (_lm._levelSelected == 19) {
				_baseTitleText.text = "Palaveeo";
				_baseTitleTranslationText.text = "'Time'";
				_stageTitleText.text = "Stage 2";
	        }
			if (_lm._levelSelected == 20) {
				_baseTitleText.text = "Onlenek";
				_baseTitleTranslationText.text = "'to See'";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 21) {
				_baseTitleText.text = "(carrier)";
				_baseTitleTranslationText.text = "(currently on carrier)";
				_stageTitleText.text = "Stage 1";
			}
			if (_lm._levelSelected == 22) {
				_baseTitleText.text = "Ootanus";
				_baseTitleTranslationText.text = "'Rain/Rainfall'";
				_stageTitleText.text = "Stage 1";
			}
			if (_lm._levelSelected == 23) {
				_baseTitleText.text = "Endolonus";
				_baseTitleTranslationText.text = "'Independence'";
				_stageTitleText.text = "Stage 3";
			}
			if (_lm._levelSelected == 24) {
				_baseTitleText.text = "Terelem";
				_baseTitleTranslationText.text = "'Progress'";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 25) {
				_baseTitleText.text = "Palaveeo";
				_baseTitleTranslationText.text = "'Time'";
				_stageTitleText.text = "Stage 3";
			}
			if (_lm._levelSelected == 26) {
				_baseTitleText.text = "Onlenek";
				_baseTitleTranslationText.text = "'to See'";
				_stageTitleText.text = "Stage 3";
			}
			if (_lm._levelSelected == 27) {
				_baseTitleText.text = "Ootanus";
				_baseTitleTranslationText.text = "'Rain/Rainfall'";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 28) {
				_baseTitleText.text = "(carrier)";
				_baseTitleTranslationText.text = "(currently on carrier)";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 29) {
				_baseTitleText.text = "Terelem";
				_baseTitleTranslationText.text = "'Progress'";
				_stageTitleText.text = "Stage 2";
			}
			if (_lm._levelSelected == 30) {
				_baseTitleText.text = "Ootanus";
				_baseTitleTranslationText.text = "'Rain/Rainfall'";
				_stageTitleText.text = "Stage 3";
			}
			if (_lm._levelSelected == 31) {
				_baseTitleText.text = "(unknown error)";
				_baseTitleTranslationText.text = "(entity vessel)";
				_stageTitleText.text = "Stage (error - unknown)";
			}
			if (_lm._levelSelected == 32) {
				_baseTitleText.text = "(carrier)";
				_baseTitleTranslationText.text = "(currently on carrier)";
				_stageTitleText.text = "Stage 3";
            }
        }
		//Play the different animations for the intro
        _cinemBkgd.Play("CinemFadeOut");
		_blackTransition.Play("BlackFadeIn");
		_textAnim.Play("SlideIn");
	}
	public void TransitionIntroEnding() {
		//Play the different animations for the end of the intro
        _cinemBkgd.Play("CinemFadeIn");
        _blackTransition.Play("BlackFadeOut");
        _textAnim.Play("SlideOut");
        StartCoroutine("CinemBkgd");
    }
    public IEnumerator CinemBkgd() {
        yield return new WaitForSeconds(3.0f);
        _cinemBkgd.Play("CinemFadeOut");
    }
	//For outro
	public void TransitionOutroBeginning() {
		_cinemBkgd.Play("CinemFadeOut");
    }
	public void TransitionOutroEnding() {
        _cinemBkgd.Play("CinemFadeIn");
        StartCoroutine("CinemBkgd");
	}
}
