using UnityEngine;
using System.Collections;

public class VineController : MonoBehaviour
{
    Transform vine;
    public Rigidbody2D endpoint;
    public ConstantForce2D constantF;
    public RelativeJoint2D relativeJ;
    //public ConstantForce2D constantF2;
    public Vector2 relativeF;
    public float movespeed = 1;
    float x = 3f;

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
        constantF = GetComponent<ConstantForce2D>();
      
        relativeF = constantF.relativeForce;
        relativeJ = GetComponent<RelativeJoint2D>();
        endpoint = GetComponent<Rigidbody2D>(); //Change to specific link

    
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Time.timeScale = 2F;
        if (endpoint.transform.localPosition.y > .1  )
        {
            
            x *= -1;
            endpoint.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            //relativeF.x = (int)relativeF.x*-1; HERE
            // constantF.relativeForce = relativeF; HERE
        }
        else
        {
            endpoint.transform.Translate(new Vector3(0,1, 0) * Time.deltaTime);
            //    Debug.Log("y is ");
            //   Debug.Log(endpoint.transform.position.y);
        }
    }
    void OnCollision2D(Collision2D col)
    {
      //  relativeF.x *= 2;  HERE

    }
    void OnCollisionExit2D(Collision2D col)
    {
//        foreach (Transform child in root)
 //       {
//            child.gameObject.layer = LayerMask.NameToLayer("UsedVine");
 //       }
    }


}