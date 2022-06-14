using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z >= 39.17424f)
        {
            Enemy1.transform.position -= new Vector3(0, 0, 0.02f);
        }

        if (Player.transform.position.z >= 68.72009f)
        {
            Enemy2.transform.position -= new Vector3(0, 0, 0.02f);
        }

        if (Player.transform.position.z >= 78.4129f)
        {
            Enemy3.transform.position -= new Vector3(0, 0, 0.02f);
        }
    }
}
