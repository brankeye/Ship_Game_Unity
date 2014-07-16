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
  public List<Vector3Serializer> vectorList;
  public List<ColorSerializer>   colorList;
  
  public Ship(Ship temp) {
    smallestX = temp.smallestX;
    largestX = temp.largestX;
    smallestY = temp.smallestY;
    largestY = temp.largestY;
    numberOfBlocks = temp.numberOfBlocks;
    vectorList = new List<Vector3Serializer>(temp.vectorList);
    colorList = new List<ColorSerializer>(temp.colorList);
    shipScale = temp.shipScale;
  }

  public Ship(Vector3 blockPoint, Color blockColor) {
    shipScale = 1.0f;
    vectorList = new List<Vector3Serializer>();
    colorList = new List<ColorSerializer>();

    AddBlock(blockPoint, blockColor);
    smallestX = blockPoint.x;
    largestX = blockPoint.x;
    smallestY = blockPoint.y;
    largestY = blockPoint.y;
  }

  public Ship(int numBlocks, List<Vector3Serializer> vList, List<ColorSerializer> cList) {
    numberOfBlocks = numBlocks;
    vectorList = vList;
    colorList = cList;
  }

  public void AddBlock(Vector3 blockPoint, Color blockColor) {
    Vector3Serializer serBlockPoint = new Vector3Serializer();
    serBlockPoint.Vector3_S = blockPoint;
    if(vectorList.Contains(serBlockPoint)) {
      int i = vectorList.IndexOf(serBlockPoint);
      vectorList.RemoveAt(i);
      colorList.RemoveAt(i);
    }
    vectorList.Add(new Vector3Serializer(blockPoint));
    colorList.Add(new ColorSerializer(blockColor));
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
    for(int i = 0; i < vectorList.Count; i++) {
      if(vectorList[i].Vector3_S.Equals(blockPoint)) {
        vectorList.RemoveAt(i);
        colorList.RemoveAt(i);
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
