using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VineShifter : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("VSExit");
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("UsedVine");
        }

    }
}
