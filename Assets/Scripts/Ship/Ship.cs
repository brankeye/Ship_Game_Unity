using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship {
  public int numberOfBlocks;
  public List<Vector3> vectorList;
  public List<Color>   colorList;

  public Ship() {
    vectorList = new List<Vector3>();
    colorList = new List<Color>();
    numberOfBlocks = 0;
  }

  public Ship(int numBlocks, List<Vector3> vList, List<Color> cList) {
    numberOfBlocks = numBlocks;
    vectorList = vList;
    colorList = cList;
  }

  public void AddBlock(Vector3 blockPoint, Color blockColor) {
    vectorList.Add(blockPoint);
    colorList.Add(blockColor);
  }
}
