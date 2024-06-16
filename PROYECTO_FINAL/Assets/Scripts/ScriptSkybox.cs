using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSkybox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float DuracionDiaNoche = 1;

    [Range(0.0f, 24f)] public float Hora = 12;
    public Transform Sol;
    private float solX;


    // Update is called once per frame
    void Update()
    {
        Hora += Time.deltaTime * (24 / (60 * DuracionDiaNoche));

        if (Hora >= 24)
        {
            Hora = 0;
        }
        RotacionSol();
    }

    void RotacionSol (){
        solX = 15 * Hora;
        Sol.localEulerAngles = new Vector3 (solX, 0, 0);
    }
    
}
