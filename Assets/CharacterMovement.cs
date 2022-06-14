using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text coinsDisplay;
    [SerializeField]
    int coinCounter;

    public GameObject Caja;
    public GameObject objectToClone;
    Rigidbody rbMoneda;
    public Transform TR;
    public int cloneAmount;
    public float fuerza;

    public GameObject panel;
    public GameObject panelWin;
    public Text txtTimer;
    public Text txtFinal;
    float tiempo;
    bool stoptimer;
    public GameObject Bandera;
    public GameObject Confetti;

    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;

    public AudioManager miAM;

     
    //public GameObject movingPlatform;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hasJump = 2;
        isPressed = false;
        coinCounter = 0;
        stoptimer = true;
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

        if (Input.GetKeyDown(KeyCode.Space) && hasJump > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJump--;
        }

        if (stoptimer == true)
        {
            tiempo = Mathf.Floor(Time.time);

        }

        txtTimer.text = "Time: " + tiempo.ToString();

        if (transform.position.y < -1)
        {
            panel.SetActive(true);
        }

    }

    void ShowFromTheSide()
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
            panel.SetActive(true);
            stoptimer = false;
        }

        if (col.gameObject.name == "Player" /*&& Input.GetKeyDown(KeyCode.E)*/)
        {
            Destroy(Caja);
            int counter = 0;

            while (counter < cloneAmount)
            {
                for (int i = 0; i < cloneAmount; i++)
                {
                    GameObject clon;
                    clon = Instantiate(objectToClone);
                    rbMoneda = objectToClone.GetComponent<Rigidbody>();
                    clon.transform.position = Caja.transform.position - Caja.transform.forward;
                    rbMoneda.AddForce(clon.transform.forward * fuerza, ForceMode.Impulse);
                    rbMoneda.AddForce(TR.transform.up * fuerza, ForceMode.Impulse);
                    counter++;

                }
            }
        }

        if (col.gameObject.name == "finalplatform1")
        {
            platform1.SetActive(true);
        }

        if (col.gameObject.name == "finalplatform2")
        {
            platform2.SetActive(true);
        }

        if (col.gameObject.name == "finalplatform3")
        {
            platform3.SetActive(true);


        }

        if (col.gameObject.name == "finalplatform4")
        {


            miAM.PlayClip();
            panelWin.SetActive(true);
            //txtTimer.text = tiempo.ToString();
            int counter = 0;

            while (counter < cloneAmount)
            {
                for (int i = 0; i < cloneAmount; i++)
                {
                    GameObject clon;
                    clon = Instantiate(Confetti);
                    rbMoneda = objectToClone.GetComponent<Rigidbody>();
                    clon.transform.position = Bandera.transform.position - Bandera.transform.forward;
                    rbMoneda.AddForce(clon.transform.forward * fuerza, ForceMode.Impulse);
                    rbMoneda.AddForce(clon.transform.up * fuerza, ForceMode.Impulse);
                    counter++;

                }
            }
            coinsDisplay.text = "";
            txtFinal.text = "Total Coins: " + coinCounter.ToString() + '\n' + "Timer: " + tiempo.ToString();
        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Money" || col.gameObject.name == "Money (1)(Clone)")
        {
            coinCounter++;
            coinsDisplay.text = "Coins: " + coinCounter.ToString();
            Destroy(col.gameObject);
        }

        //    if (col.gameObject.name == "hb Moving Platform")
        //    {
        //        gameObject.transform.SetParent(movingPlatform.transform.parent);
        //    }
        //}


        //void OnTriggerExit (Collider col)
        //{
        //    if (col.gameObject.name == "hb Moving Platform")
        //    {
        //        gameObject.transform.parent = gameObject.transform.parent;
        //    }
        //}
    }

}

