using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void escenaPrincipal()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Parkour()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void salir()
    {
        Application.Quit();

    }
}
