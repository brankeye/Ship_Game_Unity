using UnityEngine;
using System.Collections;

public class DisplayShips : MonoBehaviour {

	// Use this for initialization
	void Start () {
    gameObject.AddComponent("SpriteRenderer");
    handleDisplayShips();
	}
	
	// Update is called once per frame
	void Update () {
    handleDisplayShips();
	}

  void handleDisplayShips() {
    if(GameControl.control.numberOfShips <= 0) {
      Sprite missingSprite = Resources.Load("Sprites/missingShip", typeof(Sprite)) as Sprite;
      GetComponent<SpriteRenderer>().sprite = missingSprite;
    } else {
      GetComponent<SpriteRenderer>().enabled = false;
      if(GameControl.control.shipList[0].created == false) {
        CreateShip(GameControl.control.shipList[0], "Ventura");
      }
    }
  }

  public void CreateShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    newShip.transform.parent = gameObject.transform;

    newShip.transform.position = new Vector3(0, 0, transform.parent.position.z - 1);
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i];
      newBlock.transform.localPosition = ship.vectorList[i];
      newBlock.GetComponent<MeshRenderer>().material.color = ship.colorList[i];
      newBlock.transform.parent = newShip.transform;

      newBlock.transform.position = new Vector3(0, 0, transform.parent.position.z - 1);
    }
    
    ship.created = true;
  }
}
