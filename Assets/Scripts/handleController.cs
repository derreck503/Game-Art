using UnityEngine;
using System.Collections;

public class handleController : MonoBehaviour {
    Transform parent;
	// Use this for initialization
	void Start () {
        parent = transform.root.root;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoneWithVine()
    {
        Debug.Log("Donewithvine called");
        foreach (Transform child in parent)
        {
            //child.gameObject.layer = LayerMask.NameToLayer("UsedVine");
            child.gameObject.tag = "UsedVine";
            foreach(Transform handle in child)
            {
                handle.gameObject.tag = "UsedVine";
            }
            //Change the tag instead of the layer to be consistent with using the regular vine tag as a boolean
        }
    }
}
