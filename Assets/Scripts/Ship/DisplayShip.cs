using UnityEngine;
using System.Collections;

public class DisplayShip : MonoBehaviour {

  public GameObject deleteShipButton;
  public GameObject shipEditor;
  private ShipFunctions shipFunctions;
  private GameObject displayShip;
  private int newShipIndex = -1;
  private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
    shipFunctions = GetComponent<ShipFunctions>();
    spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    DisplayCurrentShip();
	}
 
  private void DisplayCurrentShip() {
    if (GameControl.control.numberOfShips <= 0)
    {
      if (displayShip != null)
      {
        Destroy(displayShip);
      }
      Sprite missingSprite = Resources.Load("Sprites/missingShip", typeof(Sprite)) as Sprite;
      spriteRenderer.sprite = missingSprite;
      newShipIndex = -1;
    } else
    {

      spriteRenderer.sprite = null;
      int shipIndex = GameControl.control.currentShipIndex;
    
      if (newShipIndex != shipIndex || deleteShipButton.GetComponent<DeleteShipButton>().shipDeleted || shipEditor.GetComponent<EditShip>().shipWasChanged)
      {
        if (displayShip != null)
        {
          Destroy(displayShip);
        }
        displayShip = shipFunctions.CreateDisplayShip(GameControl.control.shipList [shipIndex], "Ventura");


        displayShip.transform.position = new Vector3(displayShip.transform.position.x,
                                                     displayShip.transform.position.y,
                                                     transform.parent.position.z - 1);
        displayShip.transform.parent = transform;
        newShipIndex = shipIndex;
      }
    }
  }
}
