using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject objectToClone;
    public int cloneAmount;


    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.name == "Player" /*&& Input.GetKey(KeyCode.K)*/)
        {
            Destroy(gameObject);

        }

        int counter = 0;
        while (counter < cloneAmount)
        {
            for (int i = 0; i < cloneAmount; i++)
            {
                Instantiate(objectToClone);
                counter++;
                //clone = instantiate(objecttoclone);
                //destroy(clone, 2);
            }
        }

    }


    
}
