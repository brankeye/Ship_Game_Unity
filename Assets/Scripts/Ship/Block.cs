using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Block {

  private string blockType;
  private Vector3Serializer blockVector;
  private ColorSerializer blockColor;

  public string BlockType {
    get { return blockType; }
    set { blockType = value; }
  }

  public Vector3Serializer BlockVector {
    get { return blockVector; }
    set { blockVector = value; }
  }

  public ColorSerializer BlockColor {
    get { return blockColor; }
    set { blockColor = value; }
  }

  public Block(string type, Vector3 vector, Color color) {
    blockVector = new Vector3Serializer();
    blockColor = new ColorSerializer();
    SetBlock(type, vector, color);
  }

	public void SetBlock(string type, Vector3 vector, Color color) {
    blockType = type;
    BlockVector.Vector3_S = vector;
    BlockColor.Color_S = color;
  }
}
