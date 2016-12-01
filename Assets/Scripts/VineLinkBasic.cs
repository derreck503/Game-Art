using UnityEngine;
using System.Collections;

public class VineLinkBasic : MonoBehaviour {

    // Use this for initialization

    Transform root;
    Rigidbody2D vRigidBody;
    void Start () {

        root = transform.root;
        vRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DoneWithVine()
    {
        foreach (Transform child in root)
        {
            //child.gameObject.layer = LayerMask.NameToLayer("UsedVine");
            child.gameObject.tag = "UsedVine";  
            //Change the tag instead of the layer to be consistent with using the regular vine tag as a boolean
        }
    }
    
    public void IncreaseMomentum()
    {
        Debug.Log("increase momentum called");
        vRigidBody.AddTorque(80f);
        vRigidBody.AddForce(new Vector2(20, 1));
        vRigidBody.mass += 10;
    }
}
