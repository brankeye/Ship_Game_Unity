using UnityEngine;
using System.Collections;

public class ShipFunctions : MonoBehaviour {

  public GameObject CreateShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i].Vector3_S;
      newBlock.GetComponent<SpriteRenderer>().color = ship.colorList[i].Color_S;
      newBlock.transform.parent = newShip.transform;
    }

    float scaleMod = 1.0f;
    /*
    Vector2 size = ship.GetDimensions();
    scaleMod = 1 / size.magnitude;*/
    
    newShip.transform.localScale = new Vector3(scaleMod,
                                               scaleMod,
                                               newShip.transform.localScale.z);

    return newShip;
  }
}
