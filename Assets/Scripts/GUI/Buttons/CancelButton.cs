using UnityEngine;
using System.Collections;

public class CancelButton : MonoBehaviour {

  public GameObject shipEditor;
  private Button cancelButton;
  private EditShip editShip;
  
  void Start() {
    cancelButton = GetComponent<Button>();
    editShip = shipEditor.GetComponent<EditShip>();
  }
  
  void Update () {
    if(cancelButton.ButtonClicked) {
      //editShip.cancelCurrentModifications();
    }
  }
}
