using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

  public static GameControl control;
  public int currentShipIndex = 0;
  public int experience = 0;
  public int numberOfShips = 0;

  public bool soundEnabled = true;
  public bool musicEnabled = true;

  public List<Ship> shipList;

  public string savePath;

	void Awake () {
    savePath = Application.persistentDataPath + "/playerSave.dat";

		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

  void OnEnable() {
    // Loading
    Load();
  }

  void OnDisable() {
    // Saving
    Save();
  }

  public void Save() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(savePath);

    PlayerData data = new PlayerData();
    setData(data);
    bf.Serialize(file, data);
    file.Close();
  }

  public void Load() {
    if(File.Exists(savePath)) {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(savePath, FileMode.Open);
      PlayerData data = (PlayerData) bf.Deserialize(file);
      acquireData(data);
      file.Close();
    }
  }

  // for saving, set data of control data to player data
  private void setData(PlayerData tempData) {
    tempData.experience = experience;
    tempData.numberOfShips = numberOfShips;
    tempData.currentShipIndex = currentShipIndex;
    tempData.shipList = new List<Ship>(shipList);
  }

  // for loading, get control data from plater data
  private void acquireData(PlayerData tempData) {
    experience = tempData.experience;
    numberOfShips = tempData.numberOfShips;
    currentShipIndex = tempData.currentShipIndex;
    shipList = new List<Ship>(tempData.shipList);
  }
}

[Serializable]
class PlayerData {
  public int numberOfShips = 0;
  public int experience = 0;
  public List<Ship> shipList;
  public int currentShipIndex = 0;
  
  public PlayerData() {
    numberOfShips = 0;
    experience = 0;
    currentShipIndex = 0;
  }
}