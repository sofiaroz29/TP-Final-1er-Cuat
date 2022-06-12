using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 position;
    //float rotationSpeed = 2f;
    float movementSpeed = 0.2f;
    public float jumpForce = 5;
    int MaxJump = 2;
    int hasJump;
    Rigidbody rb;
    public Camera mainCamara;
    public Camera secondaryCamara;
    public bool isPressed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasJump = 2;
        isPressed = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPressed == false)
        {
            if (Input.GetKey(KeyCode.UpArrow) /*&& hasJump == MaxJump*/)
            {
                transform.Translate(movementSpeed, 0, 0);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0, 0, -movementSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(0, 0, movementSpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow) /*&& hasJump == MaxJump*/)
            {
                transform.Translate(-movementSpeed, 0, 0);
            }
        }

        if (isPressed == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) /*&& hasJump == MaxJump*/)
            {
                transform.Translate(movementSpeed, 0, 0);

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, 0, -movementSpeed);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, 0, movementSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow) /*&& hasJump == MaxJump*/)
            {
                transform.Translate(-movementSpeed, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && isPressed == false)
        {
            //transform.Rotate(0, rotationSpeed, 0);
          
            ShowFirstPerson();
            isPressed = true;
        }

        else if (Input.GetKeyDown(KeyCode.A) && isPressed == true)
        {
            //transform.Rotate(0, -rotationSpeed, 0);
           
            ShowFromTheSide();
            isPressed = false;

            Debug.Log(isPressed);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasJump>0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump--;
        }


    }

    void ShowFromTheSide ()
    {
        secondaryCamara.enabled = true;
        mainCamara.enabled = false;
        
    }

    void ShowFirstPerson()
    {
        secondaryCamara.enabled = false;
        mainCamara.enabled = true;
        if (Input.GetKey(KeyCode.RightArrow) /*&& hasJump == MaxJump*/)
        {
            transform.Translate(movementSpeed, 0, 0);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -movementSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, movementSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) /*&& hasJump == MaxJump*/)
        {
            transform.Translate(-movementSpeed, 0, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "platform")
        {
            hasJump = MaxJump;
        }

        if (col.gameObject.name == "Enemy")
        {
           Destroy(gameObject);
           
        }



    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.name == "Money")
    //    {

    //    }
    //}
}
