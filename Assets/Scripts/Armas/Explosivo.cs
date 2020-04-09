using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosivo : MonoBehaviour
{
    private int porcentajeDañoExplosivo;
    private ParticleSystem explosion;
    public float tiempoDeVida = 8;
    private float vidaTimer;

    private void Start() 
    {
        porcentajeDañoExplosivo = GameObject.Find("Jugador").GetComponent<Jugador_Ataque>().porcentajeDañoExplosivo;
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
            other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoExplosivo);
            Explosion();
        }            
    }

    private void Explosion()
    {
        Destroy(gameObject.GetComponent<MeshRenderer>());
        explosion = gameObject.GetComponent<ParticleSystem>();
        explosion.Play();
        Destroy(gameObject, explosion.main.duration);
    }
}
