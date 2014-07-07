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
        displayShip = shipFunctions.CreateShip(GameControl.control.shipList [shipIndex], "Ventura");

        displayShip.transform.parent = transform;
        newShipIndex = shipIndex;

        refresh = false;
      }
    }
  }
}
