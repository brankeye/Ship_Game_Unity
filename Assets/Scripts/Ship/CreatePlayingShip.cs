using UnityEngine;
using System.Collections;

public class CreatePlayingShip : MonoBehaviour {

  private GameObject playerShip;
  private ShipFunctions shipFunctions;

	// Use this for initialization
	void Start () {
    shipFunctions = GetComponent<ShipFunctions>();
    playerShip = shipFunctions.CreateShip(GameControl.control.shipList[GameControl.control.currentShipIndex], "Ventura");
    playerShip.transform.parent = transform;

    playerShip.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
	}
}
