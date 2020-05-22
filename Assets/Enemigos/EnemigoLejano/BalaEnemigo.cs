﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public SonidosBiblioteca sSonidos;
    public float velocidad = 2;
    public int daño;
    public float tiempoDeVida = 2;
    private float vidaTimer;
    GameObject balaSalida;
    private void Start() 
    {
        balaSalida = GameObject.Find("BalaSalida");
        vidaTimer = tiempoDeVida;
    }
    private void Update() 
    {
        vidaTimer -= Time.deltaTime;
        if(vidaTimer <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += balaSalida.transform.forward * velocidad;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Jugador>().RecibirDaño(daño);
            sSonidos.Play(other.gameObject.GetComponent<AudioSource>(), sSonidos.Vaca);
            Destroy(gameObject);
        }            
    }
}
