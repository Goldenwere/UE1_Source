using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour {

	//GFX Settings
	//Bools that control whether certain effects should be enabled or not
	public bool _pp;
	public bool _gr;
	public bool _dof;
	public bool _ao;
	//Other settings
	public float _camsnap;
	public float _playerDiff;
	//SFX Settings
	//These floats control the different sounds in the game
		/*Music = in-game music
		Effects = sounds from non-static objects (player, entities, etc.)
		Environment = sounds from static objects (lamps, buildings, etc.)*/
	public float _Music;
	public float _Effects;
    public float _Enviro;
	//These are the actual volumes
		//Levels are +5db, +2.5db, 0db, -1db, -2.5db, -5db, -8db, -10db, and mute
    public float _MusicVol;
    public float _EffectsVol;
	public float _EnviroVol;
	//Master mixer
	public AudioMixer _mixer;
	//Scene + Cams

	void Awake() {
		DontDestroyOnLoad(this.transform);
    }

	public void SetAudioFloats (int setting) {
		if (setting == 5) {
			if (_Music == 0) {
				_mixer.SetFloat("musicVol", -80f);
            }
			if (_Music == 1) {
				_mixer.SetFloat("musicVol", -10f);
            }
			if (_Music == 2) {
				_mixer.SetFloat("musicVol", -8f);
            }
			if (_Music == 3) {
				_mixer.SetFloat("musicVol", -5f);
            }
			if (_Music == 4) {
				_mixer.SetFloat("musicVol", -2.5f);
            }
			if (_Music == 5) {
				_mixer.SetFloat("musicVol", -1f);
            }
			if (_Music == 6) {
				_mixer.SetFloat("musicVol", 0f);
            }
			if (_Music == 7) {
				_mixer.SetFloat("musicVol", 2.5f);
			}
			if (_Music == 8) {
				_mixer.SetFloat("musicVol", 5f);
			}
		}
		if (setting == 6) {
			if (_Enviro == 0) {
				_mixer.SetFloat("enviroVol", -80f);
			}
			if (_Enviro == 1) {
				_mixer.SetFloat("enviroVol", -10f);
			}
			if (_Enviro == 2) {
				_mixer.SetFloat("enviroVol", -8f);
			}
			if (_Enviro == 3) {
				_mixer.SetFloat("enviroVol", -5f);
			}
			if (_Enviro == 4) {
				_mixer.SetFloat("enviroVol", -2.5f);
			}
			if (_Enviro == 5) {
				_mixer.SetFloat("enviroVol", -1f);
			}
			if (_Enviro == 6) {
				_mixer.SetFloat("enviroVol", 0f);
			}
			if (_Enviro == 7) {
				_mixer.SetFloat("enviroVol", 2.5f);
			}
			if (_Enviro == 8) {
				_mixer.SetFloat("enviroVol", 5f);
			}
        }
		if (setting == 7) {
			if (_Effects == 0) {
				_mixer.SetFloat("effectsVol", -80f);
			}
			if (_Effects == 1) {
				_mixer.SetFloat("effectsVol", -10f);
			}
			if (_Effects == 2) {
				_mixer.SetFloat("effectsVol", -8f);
			}
			if (_Effects == 3) {
				_mixer.SetFloat("effectsVol", -5f);
			}
			if (_Effects == 4) {
				_mixer.SetFloat("effectsVol", -2.5f);
			}
			if (_Effects == 5) {
				_mixer.SetFloat("effectsVol", -1f);
			}
			if (_Effects == 6) {
				_mixer.SetFloat("effectsVol", 0f);
			}
			if (_Effects == 7) {
				_mixer.SetFloat("effectsVol", 2.5f);
			}
			if (_Effects == 8) {
				_mixer.SetFloat("effectsVol", 5f);
			}
		}
    }

	public void SetAllAudioFloats () {
		if (_Effects == 0) {
			_mixer.SetFloat("effectsVol", -80f);
		}
		if (_Effects == 1) {
			_mixer.SetFloat("effectsVol", -10f);
		}
		if (_Effects == 2) {
			_mixer.SetFloat("effectsVol", -8f);
		}
		if (_Effects == 3) {
			_mixer.SetFloat("effectsVol", -5f);
		}
		if (_Effects == 4) {
			_mixer.SetFloat("effectsVol", -2.5f);
		}
		if (_Effects == 5) {
			_mixer.SetFloat("effectsVol", -1f);
		}
		if (_Effects == 6) {
			_mixer.SetFloat("effectsVol", 0f);
		}
		if (_Effects == 7) {
			_mixer.SetFloat("effectsVol", 2.5f);
		}
		if (_Effects == 8) {
			_mixer.SetFloat("effectsVol", 5f);
        }
		if (_Enviro == 0) {
			_mixer.SetFloat("enviroVol", -80f);
		}
		if (_Enviro == 1) {
			_mixer.SetFloat("enviroVol", -10f);
		}
		if (_Enviro == 2) {
			_mixer.SetFloat("enviroVol", -8f);
		}
		if (_Enviro == 3) {
			_mixer.SetFloat("enviroVol", -5f);
		}
		if (_Enviro == 4) {
			_mixer.SetFloat("enviroVol", -2.5f);
		}
		if (_Enviro == 5) {
			_mixer.SetFloat("enviroVol", -1f);
		}
		if (_Enviro == 6) {
			_mixer.SetFloat("enviroVol", 0f);
		}
		if (_Enviro == 7) {
			_mixer.SetFloat("enviroVol", 2.5f);
		}
		if (_Enviro == 8) {
			_mixer.SetFloat("enviroVol", 5f);
        }
		if (_Music == 0) {
			_mixer.SetFloat("musicVol", -80f);
		}
		if (_Music == 1) {
			_mixer.SetFloat("musicVol", -10f);
		}
		if (_Music == 2) {
			_mixer.SetFloat("musicVol", -8f);
		}
		if (_Music == 3) {
			_mixer.SetFloat("musicVol", -5f);
		}
		if (_Music == 4) {
			_mixer.SetFloat("musicVol", -2.5f);
		}
		if (_Music == 5) {
			_mixer.SetFloat("musicVol", -1f);
		}
		if (_Music == 6) {
			_mixer.SetFloat("musicVol", 0f);
		}
		if (_Music == 7) {
			_mixer.SetFloat("musicVol", 2.5f);
		}
		if (_Music == 8) {
			_mixer.SetFloat("musicVol", 5f);
		}
	}
	public void UIResetter () {
		GameObject.Find("Canvas_Settings").BroadcastMessage("OnUIReset");
	}
}
