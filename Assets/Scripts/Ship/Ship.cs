using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Ship {
  public int numberOfBlocks;
  public List<Vector3Serializer> vectorList;
  public List<ColorSerializer>   colorList;

  public Ship() {
    vectorList = new List<Vector3Serializer>();
    colorList = new List<ColorSerializer>();
    numberOfBlocks = 0;
  }

  public Ship(int numBlocks, List<Vector3Serializer> vList, List<ColorSerializer> cList) {
    numberOfBlocks = numBlocks;
    vectorList = vList;
    colorList = cList;
  }

  public void AddBlock(Vector3 blockPoint, Color blockColor) {
    vectorList.Add(new Vector3Serializer(blockPoint));
    colorList.Add(new ColorSerializer(blockColor));
    numberOfBlocks++;
  }
}
