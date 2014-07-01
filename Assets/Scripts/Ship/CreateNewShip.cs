using UnityEngine;
using System.Collections;

public class CreateNewShip : MonoBehaviour {

  private GameObject newShip;

	// Use this for initialization
	void Start () {
    CreateShip(GameControl.control.shipList[GameControl.control.currentShipIndex], "Ventura");
	}

  public void CreateShip(Ship ship, string name) {
    newShip = new GameObject();
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
