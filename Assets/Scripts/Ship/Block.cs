using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

  public Block leftBlock   = null;
  public Block rightBlock  = null;
  public Block topBlock    = null;
  public Block bottomBlock = null;

  // 1 - left, 2 - up, 3 - right, 4 - down
  public void AddSurroundingBlock(int raycastDirection, Block otherBlock) {
    // place the other block on the otherside of the current block (opposite the raycast direction
    switch(raycastDirection) {
      case 1: // left
        rightBlock = otherBlock;
        break;
      case 2: // up
        bottomBlock = otherBlock;
        break;
      case 3: // right
        leftBlock = otherBlock;
        break;
      case 4: // down
        topBlock = otherBlock;
        break;
      default:
        break;
    }
  }
}
