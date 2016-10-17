using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour
{
    public RelativeJoint2D relativeJoint;
    public ConstantForce2D constantF;
    public Vector2 relativeF, touchPos;   //relative force of the constant force 2d object, position of touch on screen
    Vector3 wp;
    BoxCollider2D boxCol;
    public Rigidbody2D myRigitBody;
    public Animator myAnimator;
    public float movespeed = 1;
    public float jumpForce = 60f;
    public float horizontalMove = 1f;
    bool jumped = false;
    bool maininput = false;
    bool swinging = false;



    //float distToGround = 0;

    // Use this for initialization
    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        constantF = GetComponent<ConstantForce2D>();
        relativeF = constantF.relativeForce;
        relativeJoint = GetComponent<RelativeJoint2D>();
        myRigitBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //myRigitBodyAnimation = GetComponent<Animator>();
    }

    public bool IsGrounded()
    {
        if (myRigitBody.velocity.y == 0f) { return true; }
        else return false;
    }


    // Update is called once per frame
    void Update()
    {
 
    }

    void FixedUpdate()
    {

        //   if (jumped == true) { myAnimator.SetBool("isJump", true); }
        //   if (jumped == false) { myAnimator.SetBool("isJump", false); }

        //for phone
        //if (Input.touchCount >= 1 && jumped == false)
        //for pc
        //if (Input.GetKey("z") && jumped == false)   
        if (Input.touchCount > 0)
        {
            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPos = new Vector2(wp.x, wp.y);
            if (boxCol == Physics2D.OverlapPoint(touchPos))
            {
                //your code
                Debug.Log("Touched the monkey");

            }
            maininput = true;
        }
  
        if (Input.GetKey("z")) { maininput = true; }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigitBody.velocity = new Vector2(-movespeed, myRigitBody.velocity.y);
            System.Console.WriteLine("Left arrow pressed");

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigitBody.velocity = new Vector2(movespeed, myRigitBody.velocity.y);

        }

        if (maininput == true && jumped == false)
        {
            myRigitBody.AddForce(transform.up * jumpForce);

            jumped = true;
        }



        if (IsGrounded() == true)
        {
            jumped = false;

        }

        if (!swinging)
        {
            myRigitBody.transform.Translate(Vector3.right * horizontalMove * Time.deltaTime);
        }


        maininput = false;



    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("slkdfj");
        if (col.collider.tag == "Vine")
        {
            Debug.Log("touched Vine");
            //Vines will never touch, so relativeJoint will always be disabled before reaching a new Vine
            //If the monkey is not attatched to anything, enable and attach to the colliding object
            if(relativeJoint.enabled == false)
            {
                swinging = true;
                relativeJoint.enabled = true;
                relativeJoint.connectedBody = col.rigidbody;
                myAnimator.SetBool("swinging", true);


              //  myAnimator.SetBool("isWalking", false);
            }
            
        }
    }

}

