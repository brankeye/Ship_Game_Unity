using UnityEngine;
using System.Collections;

public class ChangeBlockColor : MonoBehaviour {

	/* 
	 * | White      - 0  | Yellow       - 1  | Orange  - 2  |
	 * | Red        - 3  | Rose         - 4  | Magenta - 5  |
	 * | Violet     - 6  | Blue         - 7  | Azure   - 8  |
	 * | Cyan       - 9  | Spring Green - 10 | Green   - 11 |
	 * | Chartreuse - 12 | Black        - 13 |
	 */
	public enum BlockColor { White, Yellow, Orange, Red, Rose, Magenta, Violet, 
		                     Blue, Azure, Cyan, SpringGreen, Green, Chartreuse, Black }; 

	public BlockColor currentColor;

    private BlockColor previousColor;
    private MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(currentColor != previousColor) {
            // Assigns a material named "Assets/Resources/DEV_Orange" to the object.
            string materialPath = "Materials/Blocks/" + currentColor.ToString();
            Material newColor = Resources.Load(materialPath, typeof(Material)) as Material;
            meshRenderer.material = newColor;
            previousColor = currentColor;
        }

	}
}
