using UnityEngine;
using System.Collections;

public class OkButton : MonoBehaviour {
	
  public GameObject shipEditor;
  private Button okButton;
  private EditShip editShip;

  void Start() {
    okButton = GetComponent<Button>();
    editShip = shipEditor.GetComponent<EditShip>();
  }

	void Update () {
    shipEditor.GetComponent<EditShip>().shipWasChanged = false;
	  if(okButton.ButtonClicked) {
      editShip.updateModifiedShip();
    }
	}
}
