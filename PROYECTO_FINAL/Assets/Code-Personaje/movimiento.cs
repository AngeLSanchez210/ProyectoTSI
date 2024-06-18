using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 3f;
    public float rotacion = 250f;
    public Animator ani;
    private float x, y;
    public Rigidbody rb;
    public float impulso = 5;
    public bool canSalto;


    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidad);

        ani.SetFloat("VelX", x);
        ani.SetFloat("VelY", y);

        if (Input.GetKey("e"))
        {
            ani.Play("salsa");
            ani.SetBool("pulsado", false);
        }

        if (x != 0 || y != 0)
        {
            ani.SetBool("pulsado", true);
        }


        if (canSalto)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                ani.SetBool("saltando", true);

                rb.AddForce(new Vector3(0, impulso, 0), ForceMode.Impulse);

            }
            ani.SetBool("essuelo", true);
        }
        else
        {
            ani.SetBool("saltando", false);
            ani.SetBool("essuelo", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, y * Time.deltaTime * velocidad * 7f); 
            ani.SetBool("corriendo", true);
        }
        else
        {
            transform.Translate(0, 0, y * Time.deltaTime * velocidad);
            ani.SetBool("corriendo", false);
        }

    }
}
