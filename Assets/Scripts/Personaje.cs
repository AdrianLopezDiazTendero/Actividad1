using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    // Velocidades serializadas de giro y desplazamiento
    [SerializeField] 
    private float velocidadGiro = 100;

    [SerializeField] 
    private float velocidadDesplazamiento = 1;

    [SerializeField]
    private float intervaloRayCast = 0.5f; // Intervalo en segundos para emitir el raycast

    [SerializeField]
    private float distanciaMaxima = 100f; // Distancia máxima del raycast

    [SerializeField]
    private  Transform puntoRespawn; // Punto de respawn


    private CharacterController controller;
    private float ultimoMomentoRayCast = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Obtener valores de entrada del jugador
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // Giro: teclas A/D o flechas izquierda/derecha
        float inputHorizontal = Input.GetAxis("Horizontal"); 
        // Movimiento: teclas W/S o flechas arriba/abajo
        float inputVertical = -Input.GetAxis("Vertical");

        // Rotar al personaje
        transform.Rotate(0, inputHorizontal * velocidadGiro * Time.deltaTime, 0);

        // Calcular la dirección de movimiento en espacio local
        Vector3 direccionMovimiento = new Vector3(0, 0, inputVertical);

        // Convertir la dirección al espacio global
        direccionMovimiento = transform.TransformDirection(direccionMovimiento);

        // Aplicar la velocidad de movimiento y el deltaTime
        direccionMovimiento *= velocidadDesplazamiento * Time.deltaTime;

        // Mover al personaje usando CharacterController
        controller.Move(direccionMovimiento);

        if (Time.time > ultimoMomentoRayCast + intervaloRayCast)
        {
            EmitirRaycast();
            ultimoMomentoRayCast = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BotonPuerta")) 
        {
        }
    }


    void EmitirRaycast()
    {
        RaycastHit rc;

        if (Physics.Raycast(transform.position, Vector3.forward, out rc, distanciaMaxima))
        {
            if (rc.collider.CompareTag("BotonPuerta"))
            {
                ControladorBoton switchController = rc.collider.GetComponent<ControladorBoton>();
                if (switchController != null)
                {
                    switchController.ActivarBoton();
                }
            }
        }
    }

    public void Respawn()
    {
        // Obtener el nombre de la escena actual y recargarla
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
