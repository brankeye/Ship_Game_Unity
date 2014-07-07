using UnityEngine;
using System.Collections;

public class CreatePlayingShip : MonoBehaviour {

  private GameObject playerShip;

	// Use this for initialization
	void Start () {
    ShipFunctions shipFuncs = new ShipFunctions();
    playerShip = shipFuncs.CreatePlayingShip(GameControl.control.shipList[GameControl.control.currentShipIndex], "Ventura");
    playerShip.transform.parent = transform;
    Destroy(shipFuncs);
	}
}
