using UnityEngine;
using System.Collections;

public class CreatePlayingShip : MonoBehaviour {

  private GameObject playerShip;
  private ShipFunctions shipFunctions;

	// Use this for initialization
	void Start () {
    shipFunctions = GetComponent<ShipFunctions>();

    Ship theShip = GameControl.control.shipList [GameControl.control.currentShipIndex];
    playerShip = shipFunctions.CreateShip(theShip, "Ventura");
    playerShip.transform.parent = transform;

    playerShip.transform.localScale = new Vector3(theShip.shipScale, theShip.shipScale, 1.0f);
	}
}
