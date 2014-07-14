using UnityEngine;
using System.Collections;

public class DisplayShip : MonoBehaviour {

  public GameObject deleteShipButton;
  private DeleteShipButton deleteButton;
  public GameObject shipEditor;
  private ShipFunctions shipFunctions;
  private GameObject displayShip;
  private int newShipIndex = -1;
  private SpriteRenderer spriteRenderer;
  private bool refresh = true;
  public bool scaleTheShip = false;

	// Use this for initialization
	void Start () {
    deleteButton = deleteShipButton.GetComponent<DeleteShipButton>();
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
    
      if (newShipIndex != shipIndex || refresh || deleteButton.shipDeleted)
      {
        if (displayShip != null)
        {
          Destroy(displayShip);
        }
        Ship theShip = GameControl.control.shipList [shipIndex];
        displayShip = shipFunctions.CreateShip(theShip, "Ventura");

        displayShip.transform.parent = transform;
        if(scaleTheShip) {
          displayShip.transform.localScale = new Vector3(theShip.shipScale, theShip.shipScale, 1);
        }
        newShipIndex = shipIndex;

        refresh = false;
      }
    }
  }
}
