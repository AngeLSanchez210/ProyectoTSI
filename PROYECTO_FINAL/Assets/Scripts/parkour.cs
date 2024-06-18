using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkour : MonoBehaviour
{ 
public Transform teleportTarget; // Un transform que determina la posición y rotación de destino del teletransporte

void OnTriggerEnter(Collider other)
{
    // Verificar si el objeto que toca el cubo es el personaje (etiquetado como "Player")
    if (other.CompareTag("Player"))
    {
        // Teletransportar al personaje
        other.transform.position = teleportTarget.position;
        other.transform.rotation = teleportTarget.rotation; // Opcional: Teletransportar con la misma rotación
    }
}
}