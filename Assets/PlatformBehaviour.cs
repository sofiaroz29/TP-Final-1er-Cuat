using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public bool toRight;

    // Start is called before the first frame update
    void Start()
    {
        toRight = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (toRight == true)
        {
            transform.position += new Vector3(0, 0, 0.15f);
        }
        else
        {
            transform.position -= new Vector3(0, 0, 0.15f);
        }

       
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "base1")
        {
            //transform.position -= new Vector3(0, 0, 0.2f);
            toRight = true;
        }

        if (col.gameObject.name == "base2")
        {
            toRight = false;
            //transform.position += new Vector3(0, 0, 0.2f);

        }
    }
}
