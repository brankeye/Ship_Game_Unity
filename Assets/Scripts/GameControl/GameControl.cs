using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

  public static GameControl control;
  public int experience = 0;

  public bool soundEnabled = true;
  public bool musicEnabled = true;

  private string savePath;

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
      file.Close();
      acquireData(data);
    }
  }

  private void setData(PlayerData tempData) {
    tempData.experience = experience;
  }

  private void acquireData(PlayerData tempData) {
    experience = tempData.experience;
  }
}

[Serializable]
class PlayerData {
  public int experience;
}
