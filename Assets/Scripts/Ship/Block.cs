using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Block {

  private string blockType;
  private Vector3Serializer blockPosition;
  private float blockRotation;
  private ColorSerializer blockColor;

  public string BlockType {
    get { return blockType; }
    set { blockType = value; }
  }

  public Vector3Serializer BlockPosition {
    get { return blockPosition; }
    set { blockPosition = value; }
  }

  public float BlockRotation {
    get { return blockRotation; }
    set { blockRotation = value; }
  }

  public ColorSerializer BlockColor {
    get { return blockColor; }
    set { blockColor = value; }
  }

  public Block(string type, Vector3 position, float rotation, Color color) {
    blockPosition = new Vector3Serializer();
    blockColor = new ColorSerializer();
    SetBlock(type, position, rotation, color);
  }

	public void SetBlock(string type, Vector3 position, float rotation, Color color) {
    blockType = type;
    BlockPosition.Vector3_S = position;
    blockRotation = rotation;
    BlockColor.Color_S = color;
  }
}
