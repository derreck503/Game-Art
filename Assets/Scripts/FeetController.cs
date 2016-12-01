using UnityEngine;
using System.Collections;

public class FeetController : MonoBehaviour {
    public BoxCollider2D feetCollider;
	// Use this for initialization
	void Start () {
        feetCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Global.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Global.grounded = false;
        }
    }
}
