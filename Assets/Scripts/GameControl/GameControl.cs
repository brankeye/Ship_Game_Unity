// Name: GameControl.cs
// Purpose: handle saving of player data

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

  // static reference to this object so it can be called without initializing a game object
  public static GameControl control;
  public int currentShipIndex = 0;
  public int experience = 0;
  public int numberOfShips = 0;

  public bool soundEnabled = true;
  public bool musicEnabled = true;

  // a list of saved player ships
  public List<Ship> shipList;

  // the default save path of each respective platform
  public string savePath;

	void Awake () {
    // set the save path
    savePath = Application.persistentDataPath + "/playerSave.dat";

    // create a singleton of the GameControl object (only need one GameControl in any scene).
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

    saveData(data);
    bf.Serialize(file, data);
    file.Close();
  }

  public void Load() {
    if(File.Exists(savePath)) {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(savePath, FileMode.Open);
      PlayerData data = (PlayerData) bf.Deserialize(file);
      loadData(data);
      file.Close();
    }
  }

  // for saving, set data of control data to player data
  private void saveData(PlayerData tempData) {
    tempData.experience = experience;
    tempData.numberOfShips = numberOfShips;
    tempData.currentShipIndex = currentShipIndex;
    tempData.shipList = new List<Ship>(shipList);
  }

  // for loading, get control data from plater data
  private void loadData(PlayerData tempData) {
    experience = tempData.experience;
    numberOfShips = tempData.numberOfShips;
    currentShipIndex = tempData.currentShipIndex;
    shipList = new List<Ship>(tempData.shipList);
  }
}

// a serializable class to be saved or loaded

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