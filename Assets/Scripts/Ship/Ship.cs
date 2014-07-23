using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Ship {
  public float shipScale;
  public float smallestX;
  public float largestX;
  public float smallestY;
  public float largestY;
  public int numberOfBlocks;
  public List<Block> blockList;
  
  public Ship(Ship temp) {
    smallestX = temp.smallestX;
    largestX = temp.largestX;
    smallestY = temp.smallestY;
    largestY = temp.largestY;
    numberOfBlocks = temp.numberOfBlocks;
    blockList = new List<Block>(temp.blockList);
    shipScale = temp.shipScale;
  }

  public Ship(string blockType, Vector3 blockPoint, float blockRotation, Color blockColor) {
    shipScale = 1.0f;
    blockList = new List<Block>();

    AddBlock(blockType, blockPoint, blockRotation, blockColor);
    smallestX = blockPoint.x;
    largestX = blockPoint.x;
    smallestY = blockPoint.y;
    largestY = blockPoint.y;
  }
  
  public Ship(int numBlocks, List<Block> bList) {  
    numberOfBlocks = numBlocks;
    blockList = new List<Block>(bList);
  }

  public void AddBlock(string blockType, Vector3 blockPoint, float blockRotation, Color blockColor) {
    Block block = new Block(blockType, blockPoint, blockRotation, blockColor);
    blockList.Add(block);
    numberOfBlocks++;

    if(blockPoint.x < smallestX) {
      smallestX = blockPoint.x;
    } else if(blockPoint.x > largestX) {
      largestX = blockPoint.x;
    }

    if(blockPoint.y < smallestY) {
      smallestY = blockPoint.y;
    } else if(blockPoint.y > largestY) {
      largestY = blockPoint.y;
    }
  }

  public bool DeleteBlock(Vector3 blockPoint) {
    for(int i = 0; i < blockList.Count; i++) {
      if(blockList[i].BlockPosition.Vector3_S == blockPoint) {
        blockList.RemoveAt(i);
        numberOfBlocks--;
        return true;
      }
    }
    return false;
  }

  public Vector2 GetDimensions() {
    return new Vector2(largestX - smallestX + 1, largestY - smallestY + 1);
  }

  public void SaveScale(float scale) {
    shipScale = scale;
  }
}
