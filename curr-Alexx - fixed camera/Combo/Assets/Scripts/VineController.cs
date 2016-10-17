using UnityEngine;
using System.Collections;

public class VineController : MonoBehaviour
{
    public Rigidbody2D endpoint;
    public ConstantForce2D constantF;
    //public ConstantForce2D constantF2;
    public Vector2 relativeF;
    public float movespeed = 1;
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
        constantF = GetComponent<ConstantForce2D>();
      
        relativeF = constantF.relativeForce;
        endpoint = GetComponent<Rigidbody2D>(); //Change to specific link
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
      
        if(endpoint.transform.localPosition.x > 0.15 || endpoint.transform.localPosition.x >= -0.15 )
        {
            Debug.Log("ACTIVATED");
   
            relativeF.x = (int)relativeF.x*-1;
           // relativeF.y = (int)relativeF.y * -1;
            constantF.relativeForce = relativeF;
        }else
        {
        //    Debug.Log("y is ");
         //   Debug.Log(endpoint.transform.position.y);
        }
    }
    void OnCollision2D(Collider2D col)
    {
        Debug.Log("Vine reporting collision");
        if(col.tag == "Player")
        {
            Debug.Log("player touched me!");
            relativeF.x *= 2;
            relativeF.y *= 2;
            constantF.relativeForce = relativeF;
           
        }
    }

}