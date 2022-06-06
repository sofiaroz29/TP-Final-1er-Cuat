using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 position;
    float rotationSpeed = 1f;
    float movementSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

        position = transform.position + new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(movementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -movementSpeed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, movementSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-movementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0, -rotationSpeed, 0);
        }


    }
}
