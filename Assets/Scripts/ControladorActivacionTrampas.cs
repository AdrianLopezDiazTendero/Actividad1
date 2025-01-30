using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTrampas : MonoBehaviour
{

    [SerializeField] private ControladorMuroTrampa muroTrampa;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            muroTrampa.ActivarMuro();
        }
    }
}
