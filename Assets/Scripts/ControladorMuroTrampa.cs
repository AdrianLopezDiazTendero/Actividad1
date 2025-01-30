using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControladorMuroTrampa : MonoBehaviour
{
       
    [SerializeField] float velocidadMuro = 2f;

    private Rigidbody rb;
    private float tiempoMovimiento = 5f;
    private bool muroActivo = false;
    private float tiempoRestante; 
     

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tiempoRestante = tiempoMovimiento;
    }

    private void FixedUpdate()
    {
        if (muroActivo)
        {
            rb.MovePosition(rb.position + transform.right * velocidadMuro * Time.fixedDeltaTime);

            // Decrementar el tiempo restante
            tiempoRestante -= Time.deltaTime;

            // Verificar si el tiempo ha expirado
            if (tiempoRestante <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personaje>().Respawn();
        }
    }

    public void ActivarMuro()
    {
        muroActivo = true;
    }
}
