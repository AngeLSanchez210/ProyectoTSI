using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Rigidbody body;
    public float potenciaSalto = 10f; // Ajustado para que el salto sea más notable
    public Transform tf;
    public float distancia = 0.5f; // Ajustado para detectar mejor el suelo
    public LayerMask suelo;
    private bool esSuelo;

    public float velocidad = 7f;
    public float rotacion = 250f;

    public Animator ani;

    private float x, y;

    void Start()
    {
        ani = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        tf = transform;
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

        esSuelo = Physics.CheckSphere(tf.position, distancia, suelo);

        if (Input.GetKeyDown(KeyCode.Space) && esSuelo)
        {
            ani.Play("Jump");
        }
    }

    // Este método será llamado por el evento de animación
    public void ApplyJumpForce()
    {
        body.AddForce(Vector3.up * potenciaSalto, ForceMode.Impulse);
    }
}
