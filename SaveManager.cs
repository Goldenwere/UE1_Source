using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {

    public StoreManager _store;
    public SettingsManager _settings;
    public Canvas _savecanvas;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        _savecanvas.enabled = false;
        StartCoroutine("InitializeManager");
    }

    public IEnumerator InitializeManager() {
        Text _text = GameObject.Find("InitDesc").GetComponent<Text>();
        _text.text = "Initializing...";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("Load");
        yield break;
    }

    public IEnumerator SaveCanvas() {
        _savecanvas.enabled = true;
        _savecanvas.GetComponent<Animation>().CrossFade("SaveNotifAnim");
        yield return new WaitForSeconds(1.0f);
        _savecanvas.GetComponent<Animation>().Stop();
        _savecanvas.enabled = false;
        yield break;
    }

	public void Save() {
        StartCoroutine("SaveCanvas");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/psav.dat");

        PlayerData data = new PlayerData();
        data.unlockedlvl = _store._unlockedLevel;
        data.exp = _store._Exp;
        data.levelAP = _store._levelAP;
        data.levelAR = _store._levelAR;
		data.levelDP = _store._levelDP;
        data.levelDR = _store._levelDR;
		data.levelDHe = _store._levelDHe;
		data.levelDSh = _store._levelDSh;
        data.levelDSt = _store._levelDSt;
		data.levelMHe = _store._levelMHe;
		data.levelMSh = _store._levelMSh;
        data.levelMSt = _store._levelMSt;
		data.ao = _settings._ao;
		data.dof = _settings._dof;
		data.gr = _settings._gr;
		data.pp = _settings._pp;
		data.csnap = _settings._camsnap;
		data.diff = _settings._playerDiff;
		data.music = _settings._Music;
		data.sfx = _settings._Effects;
        data.env = _settings._Enviro;

        bf.Serialize(file, data);
        file.Close();
    }

	public IEnumerator Load() {
        Text _text = GameObject.Find("InitDesc").GetComponent<Text>();
        if(File.Exists(Application.persistentDataPath + "/psav.dat")) {
            _text.text = "Save data found, loading data";
            yield return new WaitForSeconds(0.5f);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/psav.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            _text.text = "Loading store data";
            yield return new WaitForSeconds(0.2f);
            _store._Exp = data.exp;
            _store._unlockedLevel = data.unlockedlvl;
            _store._levelAP = data.levelAP;
            _store._levelAR = data.levelAR;
    		_store._levelDP = data.levelDP;
            _store._levelDR = data.levelDR;
    		_store._levelDHe = data.levelDHe;
    		_store._levelDSh = data.levelDSh;
            _store._levelDSt = data.levelDSt;
    		_store._levelMHe = data.levelMHe;
    		_store._levelMSh = data.levelMSh;
            _store._levelMSt = data.levelMSt;
            _text.text = "Using store data to set upgrades";
            yield return new WaitForSeconds(0.2f);
            _store.SaveManagerLoadMsg();
            _text.text = "Loading settings data";
            yield return new WaitForSeconds(0.2f);
    		_settings._ao = data.ao;
    		_settings._dof = data.dof;
    		_settings._gr = data.gr;
    		_settings._pp = data.pp;
    		_settings._camsnap = data.csnap;
    		_settings._playerDiff = data.diff;
    		_settings._Music = data.music;
    		_settings._Effects = data.sfx;
            _settings._Enviro = data.env;
            _text.text = "Using settings data to set audio levels";
            yield return new WaitForSeconds(0.2f);
            _settings.SetAllAudioFloats();
        }
        if(!File.Exists(Application.persistentDataPath + "/psav.dat")) {
            _text.text = "Save data not found, running first-time initialization";
            yield return new WaitForSeconds(0.5f);
            _store._Exp = 0;
            _store._unlockedLevel = 1;
            _store._levelAP = 1;
            _store._levelAR = 1;
            _store._levelDP = 1;
            _store._levelDR = 1;
            _store._levelDHe = 1;
            _store._levelDSh = 1;
            _store._levelDSt = 1;
            _store._levelMHe = 1;
            _store._levelMSh = 1;
            _store._levelMSt = 1;
            _store.SaveManagerLoadMsg();
            _settings._ao = true;
            _settings._dof = true;
            _settings._gr = true;
            _settings._pp = true;
            _settings._camsnap = 0;
            _settings._playerDiff = 1;
            _settings._Music = 6;
            _settings._Effects = 6;
            _settings._Enviro = 6;
            _settings.SetAllAudioFloats();
            _text.text = "Creating save data";
            yield return new WaitForSeconds(0.5f);
            this.Save();
        }
        _text.text = "Loading introduction cutscene";
        LoadManager _loadmgr = GameObject.FindWithTag("LoadManagerTag").GetComponent<LoadManager>();
        _loadmgr._levelSelected = 97;
        _loadmgr.StartCoroutine("load");
        yield break;
    }

    public void Delete() {
        if(File.Exists(Application.persistentDataPath + "/psav.dat")) {
            _store._Exp = 0;
            _store._unlockedLevel = 1;
            _store._levelAP = 1;
            _store._levelAR = 1;
            _store._levelDP = 1;
            _store._levelDR = 1;
            _store._levelDHe = 1;
            _store._levelDSh = 1;
            _store._levelDSt = 1;
            _store._levelMHe = 1;
            _store._levelMSh = 1;
            _store._levelMSt = 1;
            _store.SaveManagerLoadMsg();
            _settings._ao = true;
            _settings._dof = true;
            _settings._gr = true;
            _settings._pp = true;
            _settings._camsnap = 0;
            _settings._playerDiff = 1;
            _settings._Music = 6;
            _settings._Effects = 6;
            _settings._Enviro = 6;
            _settings.SetAllAudioFloats();
            this.Save();
        }
    }
}

[Serializable]
class PlayerData {
    public float exp;       //Experience
    public int unlockedlvl; //Unlocked level
    public int levelAP;		//AmmoPistol
    public int levelAR;		//AmmoRifle
    public int levelDP;		//DamagePistol
    public int levelDR;		//DamageRifle
    public int levelMHe;	//MaxHealth
    public int levelMSh;	//MaxShield
    public int levelMSt;	//MaxStamina
    public int levelDHe;	//DelayHealth
    public int levelDSh;	//DelayShield
    public int levelDSt;	//DelayStamina
    public bool pp;         //PostProcessing
    public bool gr;         //GodRays
    public bool dof;        //DepthOfField
    public bool ao;         //AmbientOcclusion
    public float csnap;     //CameraSnap
    public float diff;      //Difficulty
    public float music;
    public float sfx;
    public float env;
}
