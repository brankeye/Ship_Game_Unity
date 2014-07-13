using UnityEngine;
using System.Collections;

public class ViewTool : MonoBehaviour {

  private GameObject targetObject;
  Vector3 lastPoint, thisPoint, targetVector, targetPoint;
  bool moveTargetObject = false;
  bool mouseDown = false;

  void Update() {
    if(moveTargetObject) {
      // CTRL + LMB
      if(!mouseDown) {
        mouseDown = true;

        thisPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lastPoint = thisPoint;
      } else {
        thisPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetVector = lastPoint - thisPoint;

        targetPoint = targetObject.transform.position - targetVector;
        targetObject.transform.position = new Vector3(targetPoint.x, targetPoint.y, targetObject.transform.position.z);

        lastPoint = thisPoint;
      }

      moveTargetObject = false;
    } else {
      mouseDown = false;
    }
  }

	public void MoveGameObject(GameObject tempObject) {
    targetObject = tempObject;
    moveTargetObject = true;
  }
}
