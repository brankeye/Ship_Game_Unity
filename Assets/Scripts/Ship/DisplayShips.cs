using UnityEngine;
using System.Collections;

public class DisplayShips : MonoBehaviour {

  public GameObject deleteShipButton;
  private GameObject newShip;
  private int newShipIndex = 0;
  private bool created = false;

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
      if(newShip != null) {
        Destroy(newShip);
      }
      Sprite missingSprite = Resources.Load("Sprites/missingShip", typeof(Sprite)) as Sprite;
      GetComponent<SpriteRenderer>().sprite = missingSprite;
      created = false;
    } else {
      GetComponent<SpriteRenderer>().sprite = null;
      int shipIndex = GameControl.control.currentShipIndex;

      if(newShipIndex != shipIndex || deleteShipButton.GetComponent<DeleteShipButton>().shipDeleted) {
        created = false;
      }

      if(created == false) {
        if(newShip != null) {
          Destroy(newShip);
        }
        CreateShip(GameControl.control.shipList[shipIndex], "Ventura");
        created = true;
        newShipIndex = shipIndex;
      }
    }
  }

  public void CreateShip(Ship ship, string name) {
    newShip = new GameObject();
    newShip.name = name;
    newShip.transform.parent = gameObject.transform;

    newShip.transform.position = new Vector3(0, 0, transform.parent.position.z - 1);
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i].Vector3_S;
      newBlock.GetComponent<MeshRenderer>().material.color = ship.colorList[i].Color_S;
      newBlock.transform.parent = newShip.transform;

      newBlock.transform.position = new Vector3(0, 0, transform.parent.position.z - 1);
    }
  }
}
