using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private int porcentajeDañoArmaScientifica;
    public float tiempoDeVida = 4;
    private float vidaTimer;

    private void Start() 
    {
        porcentajeDañoArmaScientifica = GameObject.Find("Jugador").GetComponent<Jugador_Ataque>().porcentajeDañoArmaScientifica;
        vidaTimer = tiempoDeVida;
    }
    private void Update() 
    {
        vidaTimer -= Time.deltaTime;
        if(vidaTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "enemigo")
        {
            other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoArmaScientifica);
            Destroy(gameObject);
        }            
    }
}
