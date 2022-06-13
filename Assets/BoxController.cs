using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public GameObject objectToClone;
    public int cloneAmount;
    public Text instrucciones;

    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.name == "Player" /*&& Input.GetKeyDown(KeyCode.E)*/)
        {
            Destroy(gameObject);
            instrucciones.text = "Press K to hit";

        }

        int counter = 0;

        while (counter < cloneAmount)
        {
            for (int i = 0; i < cloneAmount; i++)
            {
                Instantiate(objectToClone);
                counter++;

            }
        }

    }


    
}
