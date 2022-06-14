using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playaudio : MonoBehaviour
{

    public AudioManager miAM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Enemy")
        {
            miAM.PlayClip();
           
        }
    }
}
