using UnityEngine;
using System.Collections;

public class ShipFunctions : MonoBehaviour {

  public GameObject CreateShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    newShip.tag = "Ship";
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
      newBlock.transform.position = ship.vectorList[i].Vector3_S;
      newBlock.GetComponent<SpriteRenderer>().color = ship.colorList[i].Color_S;
      newBlock.transform.parent = newShip.transform;
    }

    float scaleMod = 1.0f;

    Vector2 size = ship.GetDimensions();
    scaleMod = 1 / size.magnitude;

    newShip.transform.localScale = new Vector3(scaleMod,
                                               scaleMod,
                                               newShip.transform.localScale.z);

    ship.SaveScale(newShip.transform.localScale);

    return newShip;
  }

  public void CreateBlock(GameObject ship, Vector3 blockPosition, Color blockColor) {
    GameObject newBlock = Instantiate(Resources.Load("Block")) as GameObject;
    newBlock.transform.parent = ship.transform;
    newBlock.transform.localScale = Vector3.one;
    newBlock.transform.localPosition = new Vector3(blockPosition.x, blockPosition.y, blockPosition.z);
    newBlock.GetComponent<SpriteRenderer>().color = blockColor;
  }
}
