using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TypeTool : MonoBehaviour {

  private List<string> blockTypeList;
  private string currentType;

  public string CurrentType {
    get { return currentType; }
  }
  
	void Start () {
    blockTypeList = new List<string>();
    blockTypeList.Add("Blocks/Block00");
    blockTypeList.Add("Blocks/Block01");
    blockTypeList.Add("Blocks/Block02");
    blockTypeList.Add("Blocks/Block03");
    blockTypeList.Add("Blocks/Block04");

    currentType = blockTypeList [0];
	}

  public void SelectBlockType(int i) {
    currentType = blockTypeList[i];
  }
}
