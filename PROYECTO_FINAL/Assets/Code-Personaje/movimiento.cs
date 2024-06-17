using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 7f;
    public float rotacion = 250f;
    public Animator ani;
    private float x, y;
    public Rigidbody rb;
    public float impulso = 5;
    public bool canSalto;
    public Camera cam; // Añadido: referencia a la cámara

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (y != 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 target = hit.point;
                target.y = transform.position.y; // Mantén la altura del personaje
                Vector3 direction = (target - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotacion * Time.deltaTime);
            }

            transform.Translate(0, 0, y * Time.deltaTime * velocidad);
        }
        else
        {
            transform.Rotate(0, x * Time.deltaTime * rotacion, 0);
        }

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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, y * Time.deltaTime * velocidad * 2f); 
            ani.SetBool("corriendo", true);
        }
        else
        {
            transform.Translate(0, 0, y * Time.deltaTime * velocidad);
            ani.SetBool("corriendo", false);
        }

    }
}
