using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MonkeyController : MonoBehaviour
{
    public Text scoretext4;
    public RelativeJoint2D handRelativeJoint;
    public ConstantForce2D constantF;
    public Vector2 touchPos;   //relative force of the constant force 2d object, position of touch on screen
                                          // Vector3 wp;

    public Rigidbody2D myRigitBody;
    public Animator myAnimator;
    public float movespeed = 1;
    public float jumpForce;
    public float horizontalMove = 2f;
    float timeSinceLastJump = 0;
    bool jump = false;
    bool swinging = false;
    bool riding = false;
    float timeLastReleased = 0f;
    int oldTouchCount = 0;
    int jumpCount = 0;

    int numberBananasCaught = 0;
    BoxCollider2D boxCol; //monkey collider
    public Collider2D activeCol; //Used for tracking the collider the monkey is attatched to.



    //float distToGround = 0;

    // Use this for initialization
    void Start()
    {
      //  Application.targetFrameRate = 600;
        scoretext4.text = "Score: " + Global.score;
        boxCol = GetComponent<BoxCollider2D>();
        constantF = GetComponent<ConstantForce2D>();
        myRigitBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        activeCol = GetComponent<Collider2D>();
        handRelativeJoint = GetComponent<RelativeJoint2D>();
       // myAnimator.SetBool("swinging", true);
        /*    foreach(Transform child in transform)
            {
                if(child.tag == "Hand")
                {
                    handRelativeJoint = child.GetComponent<HingeJoint2D>();
                }
                else if(child.tag == "Foot")
                {

                }
            } */
    }


    // Update is called once per frame
    void Update()
    {
       
        //Input Handling
        if ((Input.GetButtonDown("Jump") || Input.touchCount >= 1) && (Global.grounded || swinging))
        {
            oldTouchCount = Input.touchCount;

            Debug.Log("Touched the screen");
            if (swinging)
                ReleaseVine();
            else
            {
                jump = true;
            }
               
            Debug.Log("After ReleaseVine");
        }
        else if (Input.GetKey("up"))
        {
            GoUpOneLink();
        }
        else if (Input.GetKey("down"))
        {
            GoDownOneLink();
        }
        else
        {
            Debug.Log("No z or touch");
        }

    }

    void FixedUpdate()
    {
      //  Time.timeScale = 2F;
     //   if (activeCol)
       //      Debug.Log("activeCol: " + activeCol.tag + " " + Time.realtimeSinceStartup);
        //Keeping the Monkey Upright
        if (!swinging && transform.rotation.eulerAngles.z > .5 && transform.rotation.eulerAngles.z < 359.5 )
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }/*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigitBody.velocity = new Vector2(-movespeed, myRigitBody.velocity.y);
            System.Console.WriteLine("Left arrow pressed");

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigitBody.velocity = new Vector2(movespeed, myRigitBody.velocity.y);

        } */

        if (jump)
        {
            
            if(Time.timeSinceLevelLoad - timeSinceLastJump > .7f)
            {
                timeSinceLastJump = Time.timeSinceLevelLoad;
                myRigitBody.AddForce(transform.up * jumpForce);
                myRigitBody.AddForce(transform.right * (jumpForce / 2));

                jump = false;
                Global.grounded = false;
            }
            
        }
        if (Global.grounded && !riding && !swinging)
        {
            myRigitBody.transform.Translate(Vector3.right * horizontalMove * movespeed * Time.deltaTime);
            Debug.Log("grounded, should move right");
            myRigitBody.freezeRotation = true;
        }

    }
    public void incrementscore4()
    {
        Global.score = Global.score + 100;
        scoretext4.text = "Score: " + Global.score;
    }



    void OnCollisionEnter2D(Collision2D col)
    {

        activeCol = col.collider;
        Debug.Log("activeCol is " + activeCol.tag);

        if (Time.time - timeLastReleased < .7 && col.gameObject.tag == "Vine" || col.gameObject.tag == "UsedVine") {
            Debug.Log("tried to grab vine too soon");
            Physics2D.IgnoreCollision(boxCol, col.collider);
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            myAnimator.SetBool("swinging", false);
            //  myRigitBody.gravityScale = 1;
            Global.grounded = true;
            swinging = false;
            Debug.Log("set grounded to true");
            myRigitBody.freezeRotation = true;
            if (col.collider.tag == "hippo" || col.collider.tag == "sidewaysGator")
            {
                Debug.Log("riding hippo");
                riding = true;
                myAnimator.SetBool("riding", true);
                transform.parent = col.transform;
            }
            else if (col.collider.gameObject.tag == "WinZone")
            {
                float t = 0;
                while (t < 3)
                    t += Time.deltaTime;
                Debug.Log("Should load level ocmplete");
                   Application.LoadLevel("LevelComplete");

            } else if (col.collider.gameObject.tag == "GameBeat")
            {
                //Time.timeScale = 0;
                Global.grounded = false;
                float t = 0;
                while (t < 150)
                    t += Time.deltaTime;
                myRigitBody.AddForce(new Vector2(35, 40));

                Debug.Log("Should load winScene");
                    Application.LoadLevel("WinScene");
                //Time.timeScale = 1;
            }

        }
        else if (col.collider.gameObject.layer == LayerMask.NameToLayer("Death"))
        {
            Debug.Log("touched death");
            // If my player object collide with anything object/collider that is on the Death layer
            //my application reloads the current level
            Application.LoadLevel("DeathScene");

        }else if(col.collider.gameObject.tag == "WinBanana")
        {
            Physics2D.IgnoreCollision(boxCol, col.collider);
            Destroy(col.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        activeCol = col.collider;
        Debug.Log("-----Col exit - activeCol is " + activeCol.tag);
        if(col.collider.tag == "hippo" || col.collider.tag == "sidewaysGator")
        {
            Debug.Log("=====Withhippo");
            riding = false;
            myAnimator.SetBool("riding", false);
            transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCol)
    {
        activeCol = triggerCol;
      //  Debug.Log("-triggerEnter activeCol: " + triggerCol.tag);
        if (Time.time - timeLastReleased < .7 && triggerCol.gameObject.tag == "Vine")
        {
            Debug.Log("tried to grab vine too soon");
            Physics2D.IgnoreCollision(boxCol, triggerCol);
        }else if (triggerCol.tag == "Banana")
        {
            Debug.Log("Grabbed a Banana!");
            Destroy(triggerCol.gameObject);
            numberBananasCaught++;
            incrementscore4();
        }
        else if (triggerCol.tag == "Vine")
        {
            Debug.Log("touched Vine");
            
            //Vines will never touch, so relativeJoint will always be disabled before reaching a new Vine
            //If the monkey is not attatched to anything, enable and attach to the colliding object

            if (handRelativeJoint.enabled == false)
            {
                //activeCol.GetComponent<VineLinkBasic>().IncreaseMomentum();
                timeLastReleased = Time.time;
                swinging = true;
                riding = false;
                Global.grounded = false;
                handRelativeJoint.enabled = true;
                handRelativeJoint.connectedBody = triggerCol.gameObject.GetComponent<Rigidbody2D>();
                myAnimator.SetBool("swinging", true);
              //  Vector2 negateForce = Vector2.Scale(myRigitBody.velocity, Vector2.left);
              //  myRigitBody.AddForce(negateForce);
                myRigitBody.freezeRotation = false;
                // myRigitBody.AddForce(new Vector2(-10, -10));
             }
        }
    }
    void OnTriggerExit2D(Collider2D triggerCol)
    {
        Debug.Log("TriggerExit triggerCol.tag: " + triggerCol.tag);
    }
    public void ReleaseVine()
    {
        if (activeCol != null)
        {
            activeCol.gameObject.tag = "UsedVine";
            activeCol.GetComponent<handleController>().DoneWithVine();
            myAnimator.SetBool("swinging", false);
            Debug.Log("ReleaseVine called");
            handRelativeJoint.enabled = false;
            handRelativeJoint.connectedBody = null;
            swinging = false;
            riding = false;
            Global.grounded = false;
            myRigitBody.AddForce(new Vector2(25, 30));
            // myRigitBody.AddForce(new Vector2(-.5f, -.5f)); //dampening force
            //   myRigitBody.gravityScale *= 2; //Undo this upon grounded
        }else
        {
            Debug.Log("activeCol is NULL");
        }

    }
    public void GoUpOneLink()
    {
        handRelativeJoint.connectedBody = activeCol.gameObject.GetComponentInParent<Rigidbody2D>();//rigidbody;
    }
    public void GoDownOneLink()
    {
        if(transform.childCount > 0)
        {
            handRelativeJoint.connectedBody = activeCol.gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>();//rigidbody;
        }else
        {
            Debug.Log("Cannot go down any further");
        }

    }
}

public class Global
{
    public static int score = 0;
    public static bool grounded = false;
    public static int sceneCode = 0;
}
