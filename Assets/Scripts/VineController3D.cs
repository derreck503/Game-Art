using UnityEngine;
using System.Collections;

public class VineController3D : MonoBehaviour {

    Transform vine;
    public Rigidbody endpoint;
    public ConstantForce constantF;

    //public ConstantForce2D constantF2;
    public Vector3 relativeF;
    public float movespeed = 1;
    bool visitedLeft = false, visitedRight = false;
    //float x = 10f;

    //Initialize the vinelinks
    // public GameObject link0, link1, link2, link3, link4, link5, link6, link7, link8, link9, link10, link11, link12;
    // Use this for initialization
    void Start()
    {
        /*   link0 = transform.Find("link0").gameObject;
           link1 = transform.Find("link1").gameObject;
           link2 = transform.Find("link2").gameObject;
           link3 = transform.Find("link3").gameObject;
           link4 = transform.Find("link4").gameObject;
           link5 = transform.Find("link5").gameObject;
           link6 = transform.Find("link6").gameObject;
           link7 = transform.Find("link7").gameObject;
           link8 = transform.Find("link8").gameObject;
           link9 = transform.Find("link9").gameObject;
           link10 = transform.Find("link10").gameObject;
           link11 = transform.Find("link11").gameObject;
           link12 = transform.Find("link12").gameObject; */
        vine = transform;
        constantF = GetComponent<ConstantForce>();
        if(constantF)
            relativeF = constantF.force;
        endpoint = GetComponent<Rigidbody>(); //Change to specific link


    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        if (endpoint.transform.localPosition.x > 3.5 && !visitedRight)
        {
            Debug.Log("should change directions");
           // x *= -1;
           // endpoint.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            relativeF.x = (int)relativeF.x*-1; 
            if(constantF)
                constantF.force = relativeF;
            visitedRight = true;
            visitedLeft = false;
        }
        else if(endpoint.transform.localPosition.x < -2 && !visitedLeft)
        {
            relativeF.x = (int)relativeF.x * -1;
            if(constantF)
                constantF.force = relativeF;
            visitedLeft = true;
            visitedRight = false;
            // Debug.Log("transforming");
            // endpoint.transform.Translate(new Vector3(x, 0, 0) * Time.deltaTime);
            //    Debug.Log("y is ");
            //   Debug.Log(endpoint.transform.position.y);
        }
    }
    void OnCollision2D(Collision2D col)
    {
      //    relativeF.x *= 2; 

    }
    void OnCollisionExit2D(Collision2D col)
    {
        //        foreach (Transform child in root)
        //       {
        //            child.gameObject.layer = LayerMask.NameToLayer("UsedVine");
        //       }
    }
}
