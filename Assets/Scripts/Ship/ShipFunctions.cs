using UnityEngine;
using System.Collections;

public class ShipFunctions : MonoBehaviour {

  public GameObject CreateShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i].Vector3_S;
      newBlock.GetComponent<MeshRenderer>().material.color = ship.colorList[i].Color_S;
      newBlock.AddComponent<BoxCollider2D>();
      newBlock.transform.parent = newShip.transform;
    }

    float scaleMod = 0.0f;
    Vector2 size = ship.GetDimensions();
    
    if(size.x >= size.y) {
      scaleMod = 1.0f / size.x;
    } else if(size.y > size.x) {
      scaleMod = 1.0f / size.y;
    }
    
    newShip.transform.localScale = new Vector3(scaleMod,
                                               scaleMod,
                                               newShip.transform.localScale.z);

    return newShip;
  }
}
