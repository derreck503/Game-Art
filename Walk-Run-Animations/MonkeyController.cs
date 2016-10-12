using UnityEngine;
using System.Collections;

public class MonkeyController : MonoBehaviour
{

    public Rigidbody2D myRigitBody;
    public Animator myAnimator;
    public float jumpForce = 60f;
    public float horizontalMove = 1f;
    bool jumped = false;
    bool maininput = false;



    //float distToGround = 0;

    // Use this for initialization
    void Start()
    {
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
        if (jumped == true) { myAnimator.SetBool("isJump", true); }
        if (jumped == false) { myAnimator.SetBool("isJump", false); }

        //for phone
        //if (Input.touchCount >= 1 && jumped == false)
        //for pc
        //if (Input.GetKey("z") && jumped == false)   

        if (Input.touchCount >= 1 || Input.GetKey("z")) { maininput = true; }


        if (maininput == true && jumped == false)
        {
            myRigitBody.AddForce(transform.up * jumpForce);

            jumped = true;
        }



        if (IsGrounded() == true)
        {
            jumped = false;

        }

        myRigitBody.transform.Translate(Vector3.right * horizontalMove * Time.deltaTime);

        maininput = false;




    }

    void FixedUpdated()
    {
       

    }


}
