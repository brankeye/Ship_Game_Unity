using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipFunctions : MonoBehaviour {

  public GameObject CreateShip(Ship ship, string name) {
    GameObject newShip = new GameObject();
    newShip.name = name;
    newShip.tag = "Ship";
    
    for(int i = 0; i < ship.numberOfBlocks; i++) {
      GameObject newBlock = Instantiate(Resources.Load(ship.blockList[i].BlockType)) as GameObject;
      Block block = ship.blockList[i];
      newBlock.transform.localPosition = block.BlockPosition.Vector3_S;
      newBlock.transform.localRotation = Quaternion.AngleAxis(block.BlockRotation, Vector3.forward);
      newBlock.GetComponent<BlockConnector>().RotateRight(block.BlockRotation);
      newBlock.GetComponent<SpriteRenderer>().color = block.BlockColor.Color_S;
      newBlock.transform.parent = newShip.transform;
    }

    float scaleMod = 1.0f;
    scaleMod = 1 / ship.GetDimensions().magnitude;
    ship.SaveScale(scaleMod);

    return newShip;
  }

  public GameObject CreateBlock(GameObject ship, string blockType, Vector3 blockPosition, float blockRotation, Color blockColor) {
    GameObject newBlock = Instantiate(Resources.Load(blockType)) as GameObject;
    newBlock.transform.parent = ship.transform;
    newBlock.transform.localScale = Vector3.one;
    newBlock.transform.localPosition = new Vector3(blockPosition.x, blockPosition.y, blockPosition.z);
    newBlock.transform.localRotation = Quaternion.AngleAxis(blockRotation, Vector3.forward);
    newBlock.GetComponent<BlockConnector>().RotateRight(blockRotation);
    newBlock.GetComponent<SpriteRenderer>().color = blockColor;
    
    return newBlock;
  }

  public GameObject CheckBlock(string objectTag, Vector3 screenPoint, Vector3 direction, float rayDistance) {
    Ray ray = Camera.main.ScreenPointToRay(screenPoint);

    RaycastHit2D hit = Physics2D.Raycast(ray.origin, direction, rayDistance);
    if(hit.collider != null && hit.collider.gameObject.tag.Equals(objectTag)) {
      return hit.collider.gameObject;
    }
    
    return null;
  }
  
  public Dictionary<GameObject, Vector3> CheckBlocks(string objectTag, Vector3 screenPoint, List<Vector3> directions, float rayDistance) {
    Dictionary<GameObject, Vector3> objectList = new Dictionary<GameObject, Vector3>();

    Ray ray = Camera.main.ScreenPointToRay(screenPoint);
    
    for(int i = 0; i < directions.Count; i++) {
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, directions[i], rayDistance);
      if(hit.collider != null && hit.collider.gameObject.tag.Equals(objectTag)) {
        objectList.Add(hit.collider.gameObject, directions[i]);
      }
    }

    return objectList;
  }

  /*
    public List<GameObject> CheckBlocks(string objectTag, Vector3 screenPoint, List<Vector3> directions, float rayDistance) {
    List<GameObject> objectList = new List<GameObject>();

    Ray ray = Camera.main.ScreenPointToRay(screenPoint);
    
    for(int i = 0; i < directions.Count; i++) {
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, directions[i], rayDistance);
      if(hit.collider != null && hit.collider.gameObject.tag.Equals(objectTag)) {
        objectList.Add(hit.collider.gameObject);
      }
    }

    return objectList;
  }
   * */
}
