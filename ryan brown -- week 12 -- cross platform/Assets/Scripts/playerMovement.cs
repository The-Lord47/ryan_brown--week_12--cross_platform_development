using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Vector2 inputDirection,lookDirection;
    Animator anim;

    private Vector3 touchStart, touchEnd;
    public Image joyStick, joyStickInputArea;
    public float joyStickInputMaxRadius;

    public GameObject Player;

    private Touch theTouch;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls
        calculateDesktopInputs();

        //calculateMobileInput();

        //calculateTouchInput();

        //sets up the animator
        animationSetup();

        //moves the player
        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);
    }


    void calculateDesktopInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

    }


    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.01f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", inputDirection.x);
        anim.SetFloat("inputY", inputDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }

    void calculateMobileInput()
    {
        if (Input.GetMouseButton(0))
        {
            joyStick.gameObject.SetActive(true);
            joyStickInputArea.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition;
            }

            touchEnd = Input.mousePosition;
            joyStickInputArea.transform.position = touchStart;

            float x = touchEnd.x - touchStart.x;
            float y = touchEnd.y - touchStart.y;

            inputDirection = new Vector2 (x, y).normalized;

            if((touchEnd - touchStart).magnitude > joyStickInputMaxRadius)
            {
                joyStick.transform.position = touchStart + (touchEnd - touchStart).normalized * joyStickInputMaxRadius; 
            }
            else
            {
                joyStick.transform.position = touchEnd;
            }
        }
        else
        {
            inputDirection = Vector2.zero;
            joyStick.gameObject.SetActive(false);
            joyStickInputArea.gameObject.SetActive(false);
        }
    }

    void calculateTouchInput()
    {
        if (Input.touchCount > 0)
        {
            joyStick.gameObject.SetActive(true);
            joyStickInputArea.gameObject.SetActive(true);

            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStart = theTouch.position;
            }
            else if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEnd = theTouch.position;
                joyStickInputArea.transform.position = touchStart;

                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y;

                inputDirection = new Vector2(x, y).normalized;

                if ((touchEnd - touchStart).magnitude > joyStickInputMaxRadius)
                {
                    joyStick.transform.position = touchStart + (touchEnd - touchStart).normalized * joyStickInputMaxRadius;
                }
                else
                {
                    joyStick.transform.position = touchEnd;
                }
            }
        }
        else
        {
            inputDirection = Vector2.zero;
            joyStick.gameObject.SetActive(false);
            joyStickInputArea.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cave1"))
        {
            Player.transform.position = new Vector2(-3.61f, -1.36f);
        }
        if (collision.CompareTag("Cave2"))
        {
            Player.transform.position = new Vector2(1.63f, 8.49f);
        }
        if (collision.CompareTag("Stairs1"))
        {
            Player.transform.position = new Vector2(2.86f, -9.44f);
        }
        if (collision.CompareTag("Stairs2"))
        {
            Player.transform.position = new Vector2(-0.93f, 3.24f);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cave1"))
        {
            Player.transform.position = new Vector2(-3.61f, -1.36f);
        }
        if (collision.gameObject.CompareTag("Cave2"))
        {
            Player.transform.position = new Vector2(1.63f, 8.49f);
        }
        if (collision.gameObject.CompareTag("Stairs1"))
        {
            Player.transform.position = new Vector2(2.86f, -9.44f);
        }
        if (collision.gameObject.CompareTag("Stairs2"))
        {
            Player.transform.position = new Vector2(-0.93f, 3.24f);
        }
    }*/
}
