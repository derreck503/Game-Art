using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{
    public Animator myanim;
    public float moveSpeed = 1f;
    public float rightLimit = 4f;
    public float leftLimit = -4f;
    public float upLimit = 4f;
    public float downLimit = -4f;
    float originalX;
    float originalY;
    bool startMoving = false;
    bool touchedLeft = true;
    bool touchedRight = false;
    SpriteRenderer spriteRend;

    public enum axis { horizontal, vertical }; //controls if the platform moves up to down or left to right
    public axis moveAxis;
    Rigidbody2D pRigidBody;
    int dir = 1;
    int count = 0;
    void Start()
    {
        spriteRend = transform.GetComponent<SpriteRenderer>();
        if (transform.gameObject.tag == "hippo")
        {
            Debug.Log("have hippo");
            myanim = GetComponent<Animator>();
            startMoving = false;
            myanim.SetBool("MovingRight", true);
        }
        else
        {
            Debug.Log("not hippo");
            startMoving = true;
        }

        pRigidBody = GetComponent<Rigidbody2D>();
       /* originalX = transform.localPosition.x;
        originalY = transform.localPosition.y;
        rightLimit += originalX;
        leftLimit += originalX;
        upLimit += originalY;
        downLimit += originalY; */
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (transform.localPosition.x > rightLimit && touchedLeft)
        {
            dir = -1;
            if (transform.gameObject.tag == "hippo")
                myanim.SetBool("MovingRight", false);
            if (transform.gameObject.tag == "sidewaysGator")
            {
                Debug.Log("right limit============");
                touchedLeft = false;
                touchedRight = true;
                spriteRend.flipY = true;
               
            }

        }
        else if (transform.localPosition.x < leftLimit && touchedRight)
        {
            dir = 1;
            if (transform.gameObject.tag == "hippo" )
                myanim.SetBool("MovingRight", true);
            if (transform.gameObject.tag == "sidewaysGator")
            {
                touchedLeft = true;
                touchedRight = false;
                spriteRend.flipY = false;
            }
                
        }
        else if (transform.localPosition.y > upLimit)
        {
            dir = -1;
        }
        else if (transform.localPosition.y < downLimit)
        {
            dir = 1;
        }

        if (moveAxis == axis.horizontal && startMoving) //start moving only applies to hippos which move horizontally
        {

            Debug.Log("Horizontal");
            transform.Translate(new Vector2(dir, 0) * Time.deltaTime * moveSpeed);
        }
        else if (moveAxis == axis.vertical && startMoving )
        {
            Debug.Log("Vertical");
            transform.Translate(new Vector2(0, dir) * Time.deltaTime * moveSpeed);

        }
        else
        {
            Debug.Log("shouldn't be possible");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(transform.tag == "hippo")
        {
            if(col.transform.tag == "Monkey")
            {
                startMoving = true;
            }
        }
    }
}
