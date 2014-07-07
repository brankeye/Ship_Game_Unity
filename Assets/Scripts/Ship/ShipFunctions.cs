using UnityEngine;
using System.Collections;

public class ShipFunctions : MonoBehaviour {

  public GameObject CreateDisplayShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i].Vector3_S;
      newBlock.GetComponent<MeshRenderer>().material.color = ship.colorList[i].Color_S;
      newBlock.transform.parent = newShip.transform;
    }

    return newShip;
  }

  public GameObject CreatePlayingShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i].Vector3_S;
      newBlock.GetComponent<MeshRenderer>().material.color = ship.colorList[i].Color_S;
      newBlock.AddComponent<BoxCollider2D>();
      newBlock.transform.parent = newShip.transform;
    }

    return newShip;
  }
}
