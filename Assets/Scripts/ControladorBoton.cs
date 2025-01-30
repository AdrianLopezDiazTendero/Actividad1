using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBoton : MonoBehaviour
{
    [SerializeField] private ControladorPuerta controladorPuerta;

    // Start is called before the first frame update
    public void ActivarBoton() 
    {
        if (controladorPuerta != null) 
        {
            controladorPuerta.DestruirPuerta();
            FindObjectOfType<CanvasManager>().MostrarTexto("La " + controladorPuerta.name + " se ha abierto");
        }
    }

}
