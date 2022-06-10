using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 position;
    float rotationSpeed = 2f;
    float movementSpeed = 0.1f;
    float jumpForce = 10;
    int MaxJump = 1;
    int hasJump;
    Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasJump = 2;
    }

    // Update is called once per frame
    void Update()
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

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasJump>0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump--;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            hasJump = MaxJump;
        }

        //if (col.gameObject.name == "Enemy")
        //{
        //    Destroy(gameObject);
        //}

    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.name == "Money")
    //    {

    //    }
    //}
}
