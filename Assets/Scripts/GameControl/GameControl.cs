﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

  public static GameControl control;
  public int experience = 0;
  public int numberOfShips = 0;

  public bool soundEnabled = true;
  public bool musicEnabled = true;

  public Ship activeShip;
  public List<Ship> shipList;

  private string savePath;

	void Awake () {
    savePath = Application.persistentDataPath + "/playerSave.dat";

		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
    numberOfShips = 0;
	}

  void OnEnable() {
    // Loading
    Load();
  }

  void OnDisable() {
    // Saving
    Save();
  }

  void Start() {
    shipList = new List<Ship>();
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
      file.Close();
      acquireData(data);
    }
  }

  private void setData(PlayerData tempData) {
    tempData.experience = experience;
    tempData.numberOfShips = numberOfShips;
  }

  private void acquireData(PlayerData tempData) {
    experience = tempData.experience;
  }
}

[Serializable]
class PlayerData {
  public int numberOfShips;
  public int experience;
}
