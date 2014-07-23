using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockConnector : MonoBehaviour {

  /* Index - Side
   * 0 - top 
   * 1 - right
   * 2 - bottom
   * 3 - left
   */

  // if the rotation is default (0,0,0) then where can other blocks connect to?
  public bool[] connector;
  private int numberOfSides = 4;

  public void RotateRight(float angle) {
    for(int i = 0; i < Mathf.RoundToInt(angle / 90.0f); i++) {
      RotateRight();
    }
  }

  public void RotateRight() {
    bool lastSide = connector[numberOfSides - 1];
    for(int i = 0; i < numberOfSides; i++) {
      bool savedSide = connector[i];
      connector[i] = lastSide;
      lastSide = savedSide;
    }
  }

  public void RotateLeft(float angle) {
    for(int i = 0; i < Mathf.RoundToInt(angle / 90.0f); i++) {
      RotateLeft();
    }
  }

  public void RotateLeft() {
    bool nextSide = connector[0];
    for(int i = numberOfSides - 1; i >= 0; i--) {
      bool savedSide = connector[i];
      connector[i] = nextSide;
      nextSide = savedSide;
    }
  }
}
