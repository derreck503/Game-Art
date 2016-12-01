using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform player;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
