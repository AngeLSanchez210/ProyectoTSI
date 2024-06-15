using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour

{

    public float velocidad = 7;
    public float rotacion = 250;

    public Animator ani;

    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        x= Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0,x * Time.deltaTime * rotacion  ,0);
        transform.Translate(0,0, y * Time.deltaTime * velocidad);

        ani.SetFloat("VelX", x);
        ani.SetFloat("VelY", y);
       
    }
}
