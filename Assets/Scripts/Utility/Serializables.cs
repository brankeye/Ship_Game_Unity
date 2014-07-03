using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Vector3Serializer
{
  public float x;
  public float y;
  public float z;
  
  public Vector3Serializer() {
    x = 0.0f; y = 0.0f; z = 0.0f;
  }

  public Vector3Serializer(Vector3 v3) {
    x = v3.x; y = v3.y; z = v3.z;
  }
  
  public void Fill(Vector3 v3)
  {
    x = v3.x;
    y = v3.y;
    z = v3.z;
  }
  
  public Vector3 Vector3_S {
    get { return new Vector3(x, y, z); } 
    set { Fill(value); }
  }
}

[Serializable]
public class ColorSerializer
{
  public float r;
  public float g;
  public float b;
  public float a;

  public ColorSerializer() {
    r = 0.0f; g = 0.0f; b = 0.0f; a = 0.0f;
  }

  public ColorSerializer(Color c) {
    r = c.r; g = c.g; b = c.b; a = c.a;
  }
  
  public void Fill(Color c)
  {
    r = c.r;
    g = c.g;
    b = c.b;
    a = c.a;
  }
  
  public Color Color_S {
    get { return new Color(r, g, b, a); } 
    set { Fill(value); }
  }
}
