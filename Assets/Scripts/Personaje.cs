using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{

    private string nombre;
    private int vidas;
    private int edad;
    private float danho;
    private float defensa;

    private void Mover(float x, float y, float z, float velocidad)

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hola Mundo");
        SumarDosNumeros();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Ha pasado un frame");
        
    }


    void SumarDosNumeros() 
    {
        Debug.Log("Voy a sumnar dos numeros");
    }
}
