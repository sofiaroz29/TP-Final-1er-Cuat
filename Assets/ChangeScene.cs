using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gamescene()
    {
        SceneManager.LoadScene("tp final fbwg");
    }

    public void firstscene()
    {
        SceneManager.LoadScene("ComenzarJuego");
    }
}
