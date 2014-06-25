using UnityEngine;
using System.Collections;

public class FollowOtherObject : MonoBehaviour {

    public GameObject otherObject;
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;

	// Use this for initialization
	void Start () {
        setPosition();
	}
	
	// Update is called once per frame
	void Update () {
        setPosition();
	}

    void setPosition() {
        transform.position = new Vector3(otherObject.transform.position.x + offsetX,
                                         otherObject.transform.position.y + offsetY,
                                         transform.position.z);
    }
}
