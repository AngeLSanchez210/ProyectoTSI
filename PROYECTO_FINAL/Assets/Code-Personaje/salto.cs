using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour

{
    public movimiento mv;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     private void OnTriggerStay(Collider other)
    {
        mv.canSalto = true;
    }

    private void OnTriggerExit(Collider other)
    {
        mv.canSalto = false;
    }
}