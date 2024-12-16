using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Velocidades serializadas de giro y desplazamiento
    [SerializeField] 
    private float velocidadGiro = 100;
    [SerializeField] 
    private float velocidadDesplazamiento = 1;


    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // Obtener valores de entrada del jugador

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
        controller.Move(direccionMovimiento); ;
    }

}
