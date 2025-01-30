using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textPuerta;

    [SerializeField] private float tiempoMensaje = 5f; // Tiempo que el texto estará visible

    private float tiempoRestante; // Tiempo restante para que el texto esté visible
    private bool mostrandoMensaje; // Controla si el texto está siendo mostrado

    public void MostrarTexto(string mensaje) 
    {
        textPuerta.text = mensaje;
        textPuerta.gameObject.SetActive(true);
        mostrandoMensaje = true;
        tiempoRestante = tiempoMensaje;
    }

    private void Update()
    {
        if (mostrandoMensaje)
        {
            // Decrementar el tiempo restante
            tiempoRestante -= Time.deltaTime;

            // Verificar si el tiempo ha expirado
            if (tiempoRestante <= 0)
            {
                textPuerta.gameObject.SetActive(false); // Ocultar el texto
                mostrandoMensaje = false; // Actualizar el estado
            }
        }
    }

}
