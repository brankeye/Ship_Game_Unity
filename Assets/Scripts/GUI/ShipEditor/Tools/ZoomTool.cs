using UnityEngine;
using System.Collections;

public class ZoomTool : MonoBehaviour {

  private float zoomAmount = 0.1f;
  private float upperScaleLimit = 1.0f;
  private float lowerScaleLimit = 0.1f;

  public void ZoomIn(GameObject targetObject) {
    if(targetObject.transform.localScale.x + zoomAmount <= upperScaleLimit) {
      targetObject.transform.localScale = new Vector3(targetObject.transform.localScale.x + zoomAmount,
                                                    targetObject.transform.localScale.y + zoomAmount,
                                                    1.0f);
    }
  }

  public void ZoomOut(GameObject targetObject) {
    if(targetObject.transform.localScale.x - zoomAmount >= lowerScaleLimit) {
      targetObject.transform.localScale = new Vector3(targetObject.transform.localScale.x - zoomAmount,
                                                      targetObject.transform.localScale.y - zoomAmount,
                                                      1.0f);
    }
  }
}
